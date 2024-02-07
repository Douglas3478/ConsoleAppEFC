using System.ComponentModel.DataAnnotations;

namespace ConsoleAppEFC.Entities;

internal class CategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;

}
