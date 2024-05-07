using System.Security.Claims;
using TheBookSummary.Data.Repositories;
using TheBookSummary.Web.ViewModels.Comments;

namespace TheBookSummaryTests;

using System.Reflection;

using AutoMapper;
using Moq;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using TheBookSummary.Data.Common.Repositories;
using TheBookSummary.Data.Models.Identity;
using TheBookSummary.Data.Models.MyBookSummary_Models;
using TheBookSummary.Services;
using TheBookSummary.Services.Mapping;
using TheBookSummary.Web.ViewModels;
using TheBookSummary.Data;

public class CommentServiceTests : IDisposable
{
    private readonly CommentService sut;
    
    private readonly IDeletableEntityRepository<Comment>? inMemoryCommentRepo;
    private readonly IDeletableEntityRepository<Reply>? inMemoryReplyRepo;
    
    private readonly Mock<HttpContextAccessor> httpContextMock;
    private readonly Mock<UserManager<ApplicationUser>> userManagerMock;
    
    private readonly IMapper mapperMock;

    public CommentServiceTests()
    {
        var context = this.CreateInMemoryDatabase();

        this.inMemoryCommentRepo = new EfDeletableEntityRepository<Comment>(context);
        this.inMemoryReplyRepo = new EfDeletableEntityRepository<Reply>(context);

        this.mapperMock = this.CreateMapper();
        this.httpContextMock = new Mock<HttpContextAccessor>();
        this.userManagerMock = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

        this.sut = new CommentService(
            this.inMemoryCommentRepo,
            this.inMemoryReplyRepo,
            this.httpContextMock.Object,
            this.userManagerMock.Object,
            this.mapperMock);
    }

    [Fact]
    public async Task AddCommentAsync_ShouldMapDtoToDbModelAndAddTheModelToTheDatabase()
    {
        //Arrange
        ApplicationUser mockUser = new ApplicationUser()
        {
            FirstName = "Gosho",
            LastName = "Gosho",
            SummariesRead = 0,
            RatingsGiven = 0,
            CreatedOn = DateTime.Now,
            ModifiedOn = DateTime.Now,
            IsDeleted = false,
            Roles = new List<IdentityUserRole<string>>(),
            Claims = new List<IdentityUserClaim<string>>(),
            Logins = new List<IdentityUserLogin<string>>()
        };

        var principalClaim = new ClaimsPrincipal();

        var mockCommentDto = new CommentInputModel()
        {
            BookId = "1234",
            Text = "This is some text that represents the comment"
        };

        this.httpContextMock.Object.HttpContext.User = principalClaim;

        
        this.userManagerMock.Setup(x => 
            x.GetUserAsync(principalClaim)
            )
            .ReturnsAsync(It.IsAny<ApplicationUser>());
        
        //Act
        await this.sut.AddCommentAsync(mockCommentDto);
        var result = this.inMemoryCommentRepo.AllAsNoTracking().FirstOrDefault();

        //Assert
        Assert.True(result != null);
        Assert.IsType<Comment>(result);
        
        Assert.Equal(result.Text, mockCommentDto.Text);
        Assert.Equal(result.BookId, mockCommentDto.BookId);
        
        Assert.Equal(result.ApplicationUser.FirstName, mockUser.FirstName);
        Assert.Equal(result.ApplicationUser.LastName, mockUser.LastName);
    }
    
    private ApplicationDbContext CreateInMemoryDatabase()
    {
        var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "MyBookSummaryDb")
            .Options;

        var context = new ApplicationDbContext(dbOptions);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        return context;
    }
    
    private IMapper CreateMapper()
    {
        AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

        return AutoMapperConfig.MapperInstance;
    }
    
    public void Dispose()
    {
        this.inMemoryCommentRepo.Dispose();
        this.inMemoryReplyRepo.Dispose();
    }
}
