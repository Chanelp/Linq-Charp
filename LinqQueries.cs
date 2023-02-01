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

    #endregion


}