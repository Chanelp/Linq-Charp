using Linq;

LinqQueries queries = new LinqQueries();

// Selección dinámica 3 primeros libros
ImprimirValores(queries.TresPrimerosLibros());

//Tercer y cuarto libro de más de x # paginas
//ImprimirValores(queries.TerceryCuartoLibroMas400PAg(400));

// Operador Take
//ImprimirValores(queries.RetoOperadorTake("Java", 3));

// Libros más de x cantidad de páginas y ordenados de forma descendente por # de pags
//ImprimirValores(queries.LibrosNumeroPaginasDesc(450));

// Libros por categoría
//ImprimirValores(queries.LibrosDeCategoriaAsc("Java"));
//ImprimirValores(queries.LibrosDePython());

//Console.WriteLine($"¿Algún libro fue publicado en 2005? {queries.HayLibroPublicadoEn2005()}");
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