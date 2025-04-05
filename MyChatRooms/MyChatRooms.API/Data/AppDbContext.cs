using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyChatRooms.API.Data.Models;

namespace MyChatRooms.API.Data;

public class AppDbContext : IdentityDbContext<ChatUser>
{

    public DbSet<Group> Groups { get; set; }
    public DbSet<UserGroups> UserGroups { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

}
