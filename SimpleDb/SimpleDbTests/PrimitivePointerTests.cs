using SimpleDb.Core.Enums;
using SimpleDb.Core.Primitives;

namespace SimpleDbTests;

[TestFixture]
public class PrimitivePointerTests
{
    [SetUp]
    public void Setup()
    {
        var ptr1 = new RecordPointer(PointerType.LeafNode, 4096, 2);
    }

    [Test]
    public void RecordPointerPropertiesAreConvertedCorrectly()
    {
        var ptr1 = new RecordPointer(PointerType.LeafNode, 4096, 2);
        
        Assert.That(ptr1.PointerType, Is.EqualTo(PointerType.LeafNode));
        Assert.That(ptr1.Position, Is.EqualTo(4096));
        Assert.That(ptr1.Chunk, Is.EqualTo(2));
    }

    [Test]
    public void RecordPointersAreEncodedAndDecodedCorrectly()
    {
        var ptr1 = new RecordPointer(PointerType.LeafNode, 4096, 2);
        var bytes = ptr1.Encode();
        var ptr2 = RecordPointer.Decode(bytes);
        
        Assert.That(ptr2.PointerType, Is.EqualTo(ptr1.PointerType));
        Assert.That(ptr2.Position, Is.EqualTo(ptr1.Position));
        Assert.That(ptr2.Chunk, Is.EqualTo(ptr1.Chunk));
    }
}