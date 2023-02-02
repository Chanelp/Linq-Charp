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
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true })?? Enumerable.Empty<Book>().ToList();
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
        return librosCollection.All(b => b.Status!= string.Empty);
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
        .Select(b => new Book() { Title = b.Title, PageCount = b.PageCount});
    }
    #endregion

    #region OPERADORES DE AGREGACIÓN
    public int CantidadLibrosEntre200y500Pag()
    {
        return librosCollection.Where(b => b.PageCount >= 200 && b.PageCount <= 500).Count();
    }

    public long LongCantidadLibrosEntre200y500Pag()
    {
        return librosCollection.Where(b => b.PageCount >= 200 && b.PageCount <= 500).LongCount();
    }
    #endregion


}