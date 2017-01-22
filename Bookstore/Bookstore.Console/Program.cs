using Bookstore.Context;
using System.Linq;

namespace Bookstore.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //contexto de la bd Bookstore para consultar a través de Entity Framework (LINQ)
            var context = new BookstoreDbContext();

            //Busca todos los libros que contengan en el titulo la palaba C# y los devuelve ordenadamente por titulo
            //QueryInTitleExample(context, "C#");


            //Buscar todos los libros de nivel intermedio (BookLevel = 2) y los devuelve ordenadamente por titulo (descendente)
            //QueryByBookLevel(context, 2);

            //Buscar todos los libros de nivel intermedio (BookLevel = 2) y los devuelve ordenadamente por titulo (descendente) y
            //luego por estado del libro
            QueryByBookLevel2(context, 2);
        }

        static void QueryInTitleExample(BookstoreDbContext context, string wordToSearch)
        {
            var query = context.Books.Where(b => b.Title.Contains(wordToSearch)).OrderBy( c=> c.Title);

            foreach(var b in query)
                System.Console.WriteLine(b.Title);

            System.Console.ReadLine();
        }

        static void QueryByBookLevel(BookstoreDbContext context, int bookLevel)
        {
            var query = context.Books.Where(b => b.BookLevelId == bookLevel).OrderByDescending(c => c.Title);

            foreach (var b in query)
                System.Console.WriteLine(b.Title);

            System.Console.ReadLine();
        }



        static void QueryByBookLevel2(BookstoreDbContext context, int bookLevel)
        {
            var query = context.Books
                .Where(b => b.BookLevelId == bookLevel)
                .OrderByDescending(c => c.Title)
                .ThenBy(b=>b.BookState);

            foreach (var b in query)
                System.Console.WriteLine(b.Title);

            System.Console.ReadLine();
        }

    }
}
