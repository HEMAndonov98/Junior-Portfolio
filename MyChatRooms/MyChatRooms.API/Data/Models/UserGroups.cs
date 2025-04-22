using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyChatRooms.API.Data.Models;

public class UserGroups
{
    public UserGroups()
    {
        this.UserGroupsId = Guid.NewGuid().ToString();
    }
    //Add property for admin isAdmin bool
    [Key]
    public string UserGroupsId { get; set; }
    public string UserId { get; set; }
    public string GroupId { get; set; }

    [ForeignKey(nameof(UserId))]
    public List<ChatUser> Users { get; set; } = null!;

    [ForeignKey(nameof(GroupId))]
    public List<Group> Groups { get; set; } = null!;
}
