namespace Linq;

public class LinqQueries
{
    private List<Book>? librosCollection = new List<Book>();

    public LinqQueries()
    {
        // Lector de archivos con streamReader, se le pasa una ruta
        using (StreamReader reader = new StreamReader("books.json"))
        {
            // Guardar dentro de un json la lectura de todo el archivo
            string json = reader.ReadToEnd();

            // Transformar la colección de json a tipo List<Book>
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }

    // Retornar la colección de libros sin niguna transformación
    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }
}