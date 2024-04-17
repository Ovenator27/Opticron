using System.ComponentModel.DataAnnotations;

namespace Opticron.Models;

public class ProductCategories
{
    public int Id { get; set; }
    public byte[]? Image { get; set; }
    public string? Description { get; set; }
    public string? Link { get; set; }
}