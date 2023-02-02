using Linq;

LinqQueries queries = new LinqQueries();

#region EJECUCION DE METODOS

//AGGREGATE
Console.WriteLine(queries.TitulosLibrosDespues2015Concatenados());

//SUM DE PAGINA DE LIBROS ENTRE 0 y 500
//Console.WriteLine($"Suma total de páginas: {queries.SumaPaginasLibroEntre0y500()}");

// Libro con menor numero de paginas - MinBy y MaxBy
// var libroMenorPag = queries.LibroConMenorNumeroPaginas();
// Console.WriteLine($"{libroMenorPag.Title} - {libroMenorPag.PageCount}");
// var libroFechaReciente = queries.LibroFechaPublicReciente();
// Console.WriteLine($"{libroFechaReciente.Title} - {libroFechaReciente.PublishedDate.ToShortDateString()}");

// Min y Max
//Console.WriteLine($"El libro con mayor # de páginas tiene: {queries.CantidadDelLibroMayorPag()} páginas");
//Console.WriteLine($"Fecha de publicación menor {queries.FechaPublicacionMenor()}");

//COUNT
//Console.WriteLine($"Cantidad de libros que tienen entre 200 y 500 pag: {queries.CantidadLibrosEntre200y500Pag()}");

// Selección dinámica 3 primeros libros
//ImprimirValores(queries.TresPrimerosLibros());

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

#endregion

void ImprimirValores(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");

    foreach (var item in listadelibros)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}