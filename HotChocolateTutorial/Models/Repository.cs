namespace HotChocolateTutorial.Models;

public class Repository
{
    public List<Book> Books { get; set; }
    public IEnumerable<User> Users { get; set; }

    public Repository()
    {
        Books = GetBooksMock();
        Users = GetUsersMock();
    }

    private List<Book> GetBooksMock()
    {
        return new List<Book>()
        {
            new Book { Id = 1, Author = new Author { Name = "Marcel Proust" }, Title = "In Search of Lost Time" },
            new Book { Id = 2, Author = new Author { Name = "James Joyce" }, Title = "Ulysses" },
            new Book { Id = 3, Author = new Author { Name = "Miguel de Cervante" }, Title = "Don Quixote" },
            new Book { Id = 4, Author = new Author { Name = "Gabriel Garcia Marquez" }, Title = "One Hundred Years of Solitude" },
            new Book { Id = 5, Author = new Author { Name = "F. Scott Fitzgerald" }, Title = "The Great Gatsby" },
        };
    }
    private List<User> GetUsersMock()
    {
        return new List<User>()
        {
            new User { Id = 1, Name = "James", Role = UserRole.Admin },
            new User { Id = 2, Name = "Robert", Role =UserRole.Default },
            new User { Id = 3, Name = "John" },
            new User { Id = 4, Name = "Michael" },
            new User { Id = 5, Name = "David" },
         };
    }
}
