namespace MovieStock.Models;

public class MovieModel(Guid movieCode, string movieName, decimal moviePrice, string movieGenre, int movieDecade)
{
    public Guid MovieCode { get; private set; } = movieCode;
    public string MovieName { get; set; } = movieName;
    public decimal MoviePrice { get; set; } = moviePrice;
    public string MovieGenre { get; set; } = movieGenre;
    public int MovieDecade { get; set; } = movieDecade;
    public int Quantity { get; private set; } = 0;

    public void AddStock(int quantity) => Quantity += quantity;

    public bool RemoveStock(int quantity)
    {
        if (quantity > Quantity) return false;
        Quantity -= quantity;
        return true;
    }
}
