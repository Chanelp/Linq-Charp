namespace Linq;

public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();

    public LinqQueries()
    {
        // Lector de archivos con streamReader, se le pasa una ruta
        using (StreamReader reader = new StreamReader("books.json"))
        {
            // Guardar dentro de un json la lectura de todo el archivo
            string json = reader.ReadToEnd();

            // Transformar la colección de json a tipo List<Book>
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? Enumerable.Empty<Book>().ToList();
        }
    }

    // Retornar la colección de libros sin niguna transformación
    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }

    #region OPERADOR WHERE
    public IEnumerable<Book> librosdepuesdel2009()
    {
        // Entenxion method
        return librosCollection.Where(b => b.PublishedDate.Year > 2009);

        // Query expresion
        // return from book in librosCollection where book.PublishedDate.Year > 2009 select book; 
    }

    public IEnumerable<Book> Libros250pagsTituloInAction()
    {
        // Extension method
        return librosCollection.Where(b => b.PageCount > 250 && b.Title.Contains("in Action"));

        // Query expresion
        // return from b in librosCollection where b.PageCount > 250 && b.Title.Contains("in Action") select b;
    }
    #endregion

    #region OPERADORES ALL y ANY
    public bool TodosLosLibrosTienenStatus()
    {
        return librosCollection.All(b => b.Status != string.Empty);
    }

    public bool HayLibroPublicadoEn2005()
    {
        return librosCollection.Any(b => b.PublishedDate.Year == 2005);
    }
    #endregion

    #region OPERADOR CONTAINS
    public IEnumerable<Book> LibrosDePython()
    {
        // Extension method
        return librosCollection.Where(b => b.Categories.Contains("Python"));

        // Query expresion
        // return from book in librosCollection where book.Categories.Contains("Python") select book;
    }
    #endregion

    #region OPERADORES OrderBy y OrderByDescending
    public IEnumerable<Book> LibrosDeCategoriaAsc(string categoria)
    {
        return librosCollection.Where(b => b.Categories.Contains(categoria)).OrderBy(b => b.Title);
    }

    public IEnumerable<Book> LibrosNumeroPaginasDesc(int nPaginas)
    {
        return librosCollection.Where(b => b.PageCount > nPaginas).OrderByDescending(b => b.PageCount);
    }
    #endregion

    #region  OPERADORES TAKE Y Skip
    public IEnumerable<Book> RetoOperadorTake(string categoria, int cuantos)
    {
        return librosCollection
        .Where(book => book.Categories
        .Contains(categoria))
        .OrderBy(b => b.PublishedDate)
        .TakeLast(cuantos);
    }

    // Select therd and quarth book that have more than 400 pages
    public IEnumerable<Book> TerceryCuartoLibroMas400PAg(int nPages)
    {
        return librosCollection
        .Where(b => b.PageCount > nPages)
        .Take(4)
        .Skip(2);
    }

    #endregion

    #region SELECCIÓN DINÁMICA
    public IEnumerable<Book> TresPrimerosLibros()
    {
        return librosCollection.Take(3)
        .Select(b => new Book() { Title = b.Title, PageCount = b.PageCount });
    }
    #endregion

    #region OPERADORES DE AGREGACIÓN Count y LongCount
    public int CantidadLibrosEntre200y500Pag()
    {
        return librosCollection.Count(b => b.PageCount >= 200 && b.PageCount <= 500);
    }

    public long LongCantidadLibrosEntre200y500Pag()
    {
        return librosCollection.LongCount(b => b.PageCount >= 200 && b.PageCount <= 500);
    }
    #endregion

    #region OPERADOR Min y Max
    public DateTime FechaPublicacionMenor()
    {
        return librosCollection.Min(b => b.PublishedDate);
    }

    public int CantidadDelLibroMayorPag()
    {
        return librosCollection.Max(b => b.PageCount);
    }

    #endregion

    #region OPERADORES MinBy y MaxBy

    public Book? LibroConMenorNumeroPaginas()
    {
        return librosCollection.Where(b => b.PageCount > 0).MinBy(b => b.PageCount);
    }

    public Book? LibroFechaPublicReciente()
    {
        return librosCollection.MaxBy(b => b.PublishedDate);
    }
    #endregion

    #region SUM y AGGREGATE

    public int SumaPaginasLibroEntre0y500()
    {
        return librosCollection.Where(b => b.PageCount >= 0 && b.PageCount <= 500).Sum(b => b.PageCount);
    }

    public string TitulosLibrosDespues2015Concatenados()
    {
        return librosCollection
                .Where(b => b.PublishedDate.Year > 2015)
                // El "" es el valor inicial del acumulador, (nombre del acumulador y next elemento la colección filtrada), función
                .Aggregate("", (TitulosLibros, next) =>
                {
                    return TitulosLibros.Equals(string.Empty) ? TitulosLibros += next.Title : TitulosLibros += "||" + next.Title;
                });
    }

    // Con Func
    public string TitulosSeparadosPorGuion(Func<Book, bool> where) => string.Join(" - ", librosCollection.Where(where).Select(b => b.Title));  
    #endregion
}