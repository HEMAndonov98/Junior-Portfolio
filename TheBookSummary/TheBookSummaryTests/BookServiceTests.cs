namespace TheBookSummaryTests;

using System.Reflection;

using AutoMapper;
using Microsoft.EntityFrameworkCore;

using TheBookSummary.Data;
using TheBookSummary.Data.Models.MyBookSummary_Models;
using TheBookSummary.Data.Repositories;
using TheBookSummary.Services;
using TheBookSummary.Services.Mapping;
using TheBookSummary.Web.ViewModels;
using TheBookSummary.Web.ViewModels.Book;

/// <summary>
/// This is class represents the unit tests for the BookService in TheBookSummary Web app using xUnit to test
/// </summary>
public class BookServiceTests : IDisposable
{
    private readonly BookService sut;

    private readonly EfDeletableEntityRepository<Book> inMemoryRepo;
    private readonly IMapper autoMapper;

    public BookServiceTests()
    {
        this.autoMapper = this.CreateMapper();
        this.inMemoryRepo = this.CreateRepository();
        this.sut = new BookService(this.inMemoryRepo, this.autoMapper);
    }
    
    //Mapping and retrieval of models test
    [Fact]
    public async Task GetAllBooksAsync_ShouldReturnBookDtoIEnumerable()
    {
        //Arrange
        var mockBooks = await this.SeedBooksAsync();
        
        //Act
        var result = await this.sut.GetAllBooksAsync();
        
        //Assert
        Assert.IsType<BookViewModel[]>(result);
        Assert.Equal(mockBooks.Count(), result.Count());
    }

    [Theory]
    [InlineData("TestFullBookSummary1", "TestShortBookSummary1", "TestBookName1")]
    [InlineData("TestFullBookSummary2", "TestShortBookSummary2", "TestBookName2")]
    [InlineData("TestFullBookSummary3", "TestShortBookSummary3", "TestBookName3")]
    private async Task AddingANewBook_ShouldMapDtoToDbModelAndWorkAsExpected(string fullSummary, string shortSummary, string bookName)
    {
        //Arrange
        var mockSummary = new BookSummaryInputModel()
        {
            FullSummary = fullSummary,
            ShortSummary = shortSummary
        };

        var mockBookDto = new BookInputModel()
        {
            BookName = bookName,
            Summary = mockSummary
        };
        
        //Act
        await this.sut.AddBookAsync(mockBookDto);

        var result = this.inMemoryRepo.AllAsNoTracking()
            .Include(b => b.BookSummary)
            .First();
        //Assert
        Assert.IsType<Book>(result);
        Assert.True(result != null);
        Assert.Equal(mockBookDto.BookName, result.BookName);
        Assert.Equal(mockBookDto.Summary.ShortSummary, result.BookSummary.ShortSummary);
        Assert.Equal(mockBookDto.Summary.FullSummary, result.BookSummary.FullSummary);
    }

    [Theory]
    [InlineData("TestId1")]
    [InlineData("TestId2")]
    [InlineData("TestId3")]
    private async Task RetrieveSingleBookAsync_ShouldWorkCorrectlyAndMapDbModelToDto(string id)
    {
        //Arrange
        var mockBooks = await this.SeedBooksAsync();
        
        //Act
        var result = await this.sut.RetrieveSingleBookAsync(id);

        //Assert
        Assert.IsType<BookViewModel>(result);
        Assert.True(!string.IsNullOrWhiteSpace(result.BookName));
        Assert.True(!string.IsNullOrWhiteSpace(result.Summary.ShortSummary));
        Assert.True(!string.IsNullOrWhiteSpace(result.Summary.FullSummary));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    private async Task RetrieveSingleBookAsync_ShouldThrowExceptionIfIdIsNullorEmptyst(string id)
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => this.sut.RetrieveSingleBookAsync(id));
    }

    private EfDeletableEntityRepository<Book> CreateRepository()
    {
        var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "MyBookSummaryDb")
            .Options;

        var context = new ApplicationDbContext(dbOptions);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        
        return new EfDeletableEntityRepository<Book>(context);
    }

    //Adds a couple of default db Book models to the in-memory db and returns them for testing
    private async Task<List<Book>> SeedBooksAsync()
    {
        var books = new List<Book>()
        {
            new Book()
            {
                Id = "TestId1", BookName = "TestBookName1",
                BookSummary = new BookSummary()
                    { Id = "BookSummaryId1", ShortSummary = "TestShortSummary1", FullSummary = "TestFullSummary1" },
                Comments = new List<Comment>(), Ratings = new List<Rating>(),
                CreatedOn = DateTime.Now,
                IsDeleted = false
            },
            new Book()
            {
                Id = "TestId2", BookName = "TestBookName2",
                BookSummary = new BookSummary()
                    { Id = "BookSummaryId2", ShortSummary = "TestShortSummary2", FullSummary = "TestFullSummary2" },
                Comments = new List<Comment>(), Ratings = new List<Rating>(),
                CreatedOn = DateTime.Now,
                IsDeleted = false
            },
            new Book()
            {
                Id = "TestId3", BookName = "TestBookName3",
                BookSummary = new BookSummary()
                    { Id = "BookSummaryId3", ShortSummary = "TestShortSummary3", FullSummary = "TestFullSummary3" },
                Comments = new List<Comment>(), Ratings = new List<Rating>(),
                CreatedOn = DateTime.Now,
                IsDeleted = false
            }
        };
        
        foreach (var mockBook in books)
        {
            await this.inMemoryRepo.AddAsync(mockBook);
            await this.inMemoryRepo.SaveChangesAsync();
        }

        return books;
    }

    private IMapper CreateMapper()
    {
        AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

        return AutoMapperConfig.MapperInstance;
    }

    public void Dispose()
    {
        this.inMemoryRepo.Dispose();
    }
}
