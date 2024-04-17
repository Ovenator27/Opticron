namespace Opticron.Models;

public class HomeData {
    public List<NavigationCards> NavigationCards { get; set; } = new List<NavigationCards>();
    public List<ProductCategories> ProductCategories { get; set; } = new List<ProductCategories>();
    public List<SpecialOffers> SpecialOffers { get; set; } = new List<SpecialOffers>();
}