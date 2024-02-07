using System.ComponentModel.DataAnnotations;

namespace ConsoleAppEFC.Entities;

internal class RoleEntity
{
    [Key]
    public int Id { get; set; }
    public string RoleName { get; set; } = null!;

}
