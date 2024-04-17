using System.ComponentModel.DataAnnotations;

namespace Opticron.Models;

public class NavigationCards
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public byte[]? Image { get; set; }
    public string? Description { get; set; }
    public string? Link { get; set; }
    public string? LinkText { get; set; }
}