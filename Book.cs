namespace Linq;

public class Book
{
    public string Title {get; set;} = string.Empty;
    public int PageCount { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public string[]? Authors { get; set; }
    public string[]? Categories { get; set; }
}