using MovieStock.Models;

namespace MovieStock.Services;

public class MovieStockService
{
    private readonly List<MovieModel> _movie = new();

    public void AddMovie(MovieModel product)
    {
        _movie.Add(product);
        Console.WriteLine("\nProduto adicionado com sucesso!");
    }

    public void ListMovie()
    {
        if (_movie.Count == 0)
        {
            Console.WriteLine("\nNenhum produto cadastrado.");
            return;
        }

        foreach (var product in _movie)
        {
            Console.WriteLine($"Código: {product.MovieCode} | Nome: {product.MovieName} | Preço: {product.MoviePrice:C} | Estoque: {product.Quantity} | Categoria: {product.MovieGenre} | Década: {product.MovieDecade} |");
        }

    }

    public void RemoveMovie(string MovieToRemove)
    {
        MovieModel? foundMovie = null;
        try
        {
            foundMovie = _movie.Find(p => p.MovieName.Equals(MovieToRemove, StringComparison.OrdinalIgnoreCase) || (Guid.TryParse(MovieToRemove, out var movieCode) && p.MovieCode == movieCode));
        }
        catch
        {
            Console.WriteLine("\nCódigo inválido.");
        }        
        if (foundMovie == null)
        {
            Console.WriteLine("\nProduto não encontrado.");
            return;
        }

        _movie.Remove(foundMovie);
        Console.WriteLine("\nProduto removido com sucesso!");
    }

    public void AddStock(string movieNameToStock, int qtdStockIten)
    {

        MovieModel? foundMovie = null;
        try
        {
            foundMovie = _movie.Find(p => p.MovieName.Equals(movieNameToStock, StringComparison.OrdinalIgnoreCase) || (Guid.TryParse(movieNameToStock, out var movieCode) && p.MovieCode == movieCode));
        }
        catch
        {
            Console.WriteLine("\nCódigo inválido.");
        }

        if (foundMovie == null)
        {
            Console.WriteLine("\nProduto não encontrado.");
            return;
        }

        foundMovie.AddStock(qtdStockIten);
        Console.WriteLine("\nEntrada de estoque realizada com sucesso!");
    }

    public void RemoveStock(string movieNameToRemove, int qtdStockItenRemove)
    {
        MovieModel? foundMovie = null;
        try
        {
            foundMovie = _movie.Find(p => p.MovieName.Equals(movieNameToRemove, StringComparison.OrdinalIgnoreCase) || (Guid.TryParse(movieNameToRemove, out var movieCode) && p.MovieCode == movieCode));
        }
        catch
        {
            Console.WriteLine("\nCódigo inválido.");
        }
        
        if (foundMovie == null)
        {
            Console.WriteLine("\nProduto não encontrado.");
            return;
        }

        if (!foundMovie.RemoveStock(qtdStockItenRemove))
        {
            Console.WriteLine("\nQuantidade insuficiente em estoque.");
            return;
        }

        Console.WriteLine("\nSaída de estoque realizada com sucesso!");
    }
}
