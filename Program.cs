using MovieStock.Models;
using MovieStock.Services;

class Program
{
    static void Main()
    {
        var movieService = new MovieStockService();
        int selectedOption;

        do
        {
            Console.WriteLine("======================================");
            Console.WriteLine("\nMenu:");
            Console.WriteLine("======================================");
            Console.WriteLine("[1] - Novo Produto");
            Console.WriteLine("[2] - Listar Produtos");
            Console.WriteLine("[3] - Remover Produtos");
            Console.WriteLine("[4] - Entrada Estoque");
            Console.WriteLine("[5] - Saída Estoque");
            Console.WriteLine("[0] - Sair");
            Console.WriteLine("======================================");
            Console.Write("Escolha uma opção: ");
            
            if (!int.TryParse(Console.ReadLine(), out selectedOption))
            {
                Console.WriteLine("Opção inválida, tente novamente.");
                continue;
            }

            switch (selectedOption)
            {
                case 1:
                    Guid movieCode = Guid.NewGuid();

                    Console.Write("Nome do Filme: ");
                    string movieName = Console.ReadLine() ?? throw new ArgumentNullException("Nome do filme não pode estar vazio.");
                    Console.Write("Preço de Compra: ");
                    decimal moviePrice = decimal.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Preço de compra não pode estar vazio."));
                    Console.Write("Gênero do Filme: ");
                    string movieGenre = Console.ReadLine() ?? throw new ArgumentNullException("Gênero do filme não pode estar vazia.");
                    Console.Write("Década do filme: ");
                    int movieDecade = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Preço de compra não pode estar vazio."));

                    
                    movieService.AddMovie(new MovieModel(movieCode, movieName, moviePrice, movieGenre, movieDecade));
                    break;

                case 2:
                    movieService.ListMovie();
                    break;

                case 3:
                    Console.Write("Nome ou Código do Produto a Remover: ");
                    movieService.RemoveMovie(Console.ReadLine() ?? throw new ArgumentNullException("Nome do filme não pode estar vazio."));
                    break;

                case 4:
                    Console.Write("Nome ou Código do Produto: ");
                    string movieNameToStock = Console.ReadLine() ?? throw new ArgumentNullException("Nome do filme não pode estar vazio.");

                    Console.Write("Quantidade a Adicionar: ");
                    int qtdStockIten = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Quantidade não pode estar vazia."));

                    movieService.AddStock(movieNameToStock, qtdStockIten);
                    break;

                case 5:
                    Console.Write("Nome ou Código do Produto: ");
                    string movieNameToRemove = Console.ReadLine() ?? throw new ArgumentNullException("Nome do filme não pode estar vazio.");

                    Console.Write("Quantidade a Remover: ");
                    int qtdStockItenRemove = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException("Quantidade não pode estar vazia."));
                    
                    movieService.RemoveStock(movieNameToRemove, qtdStockItenRemove);
                    break;

                case 0:
                    Console.WriteLine("Saindo...");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        } while (selectedOption != 0);
    }
}
