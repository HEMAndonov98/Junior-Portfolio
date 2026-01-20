using SimpleDb.Core.Constants;
using SimpleDb.Core.Primitives;

namespace SimpleDbTests;

[TestFixture]
public class PrimitivePageTests
{
    [Test]
    public void IsSlotFreeOnANewPageShouldReturnTrueForAllSlots()
    {
        var page = new DbPage(new byte[4096]);
        Assert.Multiple(() =>
        {
            for (int i = 0; i < page.Slots.Length; i++)
            {
                Assert.That(page.IsSlotFree(i), Is.True);
            }
        });
    }

    [Test]
    public void IsSlotFreeWhenSlotIsFilledShouldReturnFalse()
    {
        var data = new byte[4096];
        // Mark slot 0 as used
        data[32] |= (byte)(1 << 0);
        
        var page = new DbPage(data);
        Assert.That(page.IsSlotFree(0), Is.False);
    }

    [Test]
    public void FindNextFreeSlotOnFreshPageShouldReturn0()
    {
        var page = new DbPage(new byte[4096]);
        Assert.That(page.FindNextFreeSlot(), Is.EqualTo(0));
    }

    [Test]
    public void AfterFillingSlotsNextFreeSlotShouldReturnN()
    {
        var data = new byte[4096];

        // Mark slot 0 as used
        data[32] |= (byte)(1 << 0);

        var page = new DbPage(data);

        Assert.That(page.FindNextFreeSlot(), Is.EqualTo(1));
    }
    
    [Test]
    public void WhenFirst64SlotsAreFull_NextFreeSlotShouldBe65()
    {
        var data = new byte[4096];

        // Fill bitmap bytes 0–7 (slots 0–63)
        for (int i = 0; i < 8; i++)
            data[32 + i] = 0xFF; // 11111111

        // Fill slot 64 (byte 8, bit 0)
        data[32 + 8] |= (byte)(1 << 0);

        var page = new DbPage(data);

        Assert.That(page.FindNextFreeSlot(), Is.EqualTo(65));
    }

    [Test]
    public void FindNextFreeSlotShouldReturnNegativeOneWhenAllSlotsAreFilled()
    {
        var data = new byte[4096];

        // Fill bitmap bytes 0–7 (slots 0–309)
        for (int i = 0; i < PageConstants.MaximumSlotNumber; i++)
            data[32 + i] = 0xFF; // 11111111
        var page = new DbPage(data);

        Assert.That(page.FindNextFreeSlot(), Is.EqualTo(-1));

    }

    [Test]
    public void MarkSlotUsedCorrectlyChangesTheDataInThePage()
    {
        var page = new DbPage(new byte[4096]);
        
        page.MarkSlotUsed(0);
        Assert.That(page.FindNextFreeSlot(), Is.EqualTo(1));
    }

    [Test]
    public void AfterFreeSlot_FindNextFreeSlotShouldReturnLowestFreedSlot()
    {
        var page = new DbPage(new byte[4096]);

        // Fill all slots
        for (int i = 0; i < PageConstants.MaximumSlotNumber; i++)
            page.MarkSlotUsed(i);

        // Free specific slots
        page.FreeSlot(10);
        page.FreeSlot(42);

        // The next free slot should be the lowest one we freed
        Assert.That(page.FindNextFreeSlot(), Is.EqualTo(10));

        // Optionally free another and check again
        page.FreeSlot(5);
        Assert.That(page.FindNextFreeSlot(), Is.EqualTo(5));
    }


    [Test]
    public void MarkSlotUsed_ShouldThrow_OnInvalidIndex()
    {
        var page = new DbPage(new byte[4096]);

        Assert.Throws<ArgumentOutOfRangeException>(() => page.MarkSlotUsed(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => page.MarkSlotUsed(PageConstants.MaximumSlotNumber));
    }

    [Test]
    public void FullByteAllocation_ShouldReturnNextByteSlot()
    {
        var data = new byte[4096];
        data[32] = 0xFF; // slots 0–7 full

        var page = new DbPage(data);

        Assert.That(page.FindNextFreeSlot(), Is.EqualTo(8));
    }

    [Test]
    public void FullPageAllocationAndRandomFree_ShouldWorkCorrectly()
    {
        var page = new DbPage(new byte[4096]);

        for (int i = 0; i < PageConstants.MaximumSlotNumber; i++)
            page.MarkSlotUsed(i);

        Assert.That(page.FindNextFreeSlot(), Is.EqualTo(-1));

        // Free some slots
        page.FreeSlot(10);
        page.FreeSlot(42);

        Assert.That(page.FindNextFreeSlot(), Is.EqualTo(10));
    }


}