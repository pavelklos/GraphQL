namespace HotChocolateTutorial.GraphQL;

using HotChocolateTutorial.Models;
public class Query
{
    public Book GetBook() =>
        new Book
        {
            Title = "C# in depth.",
            Author = new Author
            {
                Name = "Jon Skeet"
            }
        };
}
