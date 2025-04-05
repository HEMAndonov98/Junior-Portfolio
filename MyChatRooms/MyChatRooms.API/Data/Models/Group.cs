using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyChatRooms.API.Data.Models;

public class Group
{

    public Group(string name)
    {
        this.Name = name;
        this.Id = Guid.NewGuid().ToString();
    }

    [Key]
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }

    [InverseProperty("Groups")]
    List<UserGroups> UserGroups { get; } = [];
}
