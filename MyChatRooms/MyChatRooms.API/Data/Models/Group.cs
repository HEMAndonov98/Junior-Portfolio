using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MyChatRooms.API.Data.Models;

public class Group
{
    [Key]
    public Guid Id { get; set; } = new Guid();
    public string Name { get; set; }


    List<IdentityUser>? Users { get; set; }
}
