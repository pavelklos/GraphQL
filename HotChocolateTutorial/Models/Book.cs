namespace HotChocolateTutorial.Models;

public class Book
{
    public int Id { get; set; }

    //[DefaultValue("")]
    //public Optional<string> Title { get; set; }
    public string Title { get; set; }
    public Author Author { get; set; }
}

// Input Type
public class BookInputMutable
{
    public string Title { get; set; } = string.Empty;
    public Author Author { get; set; } = new();
    public bool Active { get; set; } = true;
}

// Immutable Input Type (class)
public class BookInputImmutableClass
{
    // No need for the setters now
    public string Title { get; } = string.Empty;
    public Author Author { get; } = new();

    public BookInputImmutableClass(string title, Author author)
    {
        Title = title;
        Author = author;
    }
}
// Immutable Input Type (record)
public record BookInputImmutableRecord(string Title, Author Author);