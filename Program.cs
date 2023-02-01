using Linq;

LinqQueries queries = new LinqQueries();

Console.WriteLine($"¿Algún libro fue publicado en 2005? {queries.HayLibroPublicadoEn2005()}");
//Console.WriteLine($"¿Todos los libros tienen status? {queries.TodosLosLibrosTienenStatus()}");

//ImprimirValores(queries.Libros250pagsTituloInAction());
//ImprimirValores(queries.librosdepuesdel2009());
// ImprimirValores(queries.TodaLaColeccion());

void ImprimirValores(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");

    foreach (var item in listadelibros)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}