using System.ComponentModel.DataAnnotations;

namespace Opticron.Models;

public class SpecialOffers
{
    public int Id { get; set; }
    public byte[]? Image { get; set; }
    public string? Description { get; set; }
    public string? OfferText { get; set; }
    public string? Link { get; set; }
}