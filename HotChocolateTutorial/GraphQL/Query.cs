namespace HotChocolateTutorial.GraphQL;

using HotChocolateTutorial.Models;

public class Query
{
    private readonly Repository _repository;
    public Query(Repository repository)
    {
        _repository = repository;
    }

    // Book-Author
    public List<Book> GetBooks() => _repository.Books;
    public Book GetBook(int id, bool active = true) => _repository.Books.First(b => b.Id == id);
    public Author GetAuthor() => new Author { Name = "BEST AUTHOR: Jon Skeet" };

    // User
    public User GetUser(int id) => _repository.Users.First(b => b.Id == id);
    public IEnumerable<User> GetUsers() => _repository.Users;
    public User[] GetUsersByRole(UserRole role) =>
        _repository.Users.Where(u => u.Role == role).ToArray();

    // Other
    public DateTime GetDateNow() => DateTime.Now; // "2023-06-12T13:21:44.096+02:00"
    public int GetRandom() => new Random().Next();
    public Guid GetGuid() => Guid.NewGuid();

    // NDC Copenhagen 2022
    // (Michael Staib)
    // - Getting started with GraphQL in .NET
    public string Hello(string name = "World") =>
        $"Hello, {name}!";
    public record AuthorNDC( string Name );
    public record BookNDC( string Title, AuthorNDC Author );
    public IEnumerable<BookNDC> GetBooksNDC()
    {
        var author = new AuthorNDC("Jon Skeet");
        yield return new BookNDC("C# in Depth", author);
        yield return new BookNDC("C# in Depth 2nd Edition", author);
    }

}