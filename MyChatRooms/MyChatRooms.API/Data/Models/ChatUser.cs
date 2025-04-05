using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MyChatRooms.API.Data.Models;

public class ChatUser : IdentityUser
{
    [InverseProperty("Users")]
    public List<UserGroups> UserGroups { get; } = [];
}
