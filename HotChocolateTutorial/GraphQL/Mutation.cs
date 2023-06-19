namespace HotChocolateTutorial.GraphQL;

using HotChocolateTutorial.Models;

public class Mutation
{
    private readonly Repository _repository;
    public Mutation(Repository repository)
    {
        _repository = repository;
    }

    // PetInput = [OneOf]
    public Task CreatePetAsync(PetInput input)
    {
        // Omitted code for brevity
        return Task.CompletedTask;
    }

    // Book-Author
    //[UseMutationConvention]
    public Book AddBook(Book book)
    {
        _repository.Books.Add(book);

        return _repository.Books.First(b => b.Id == book.Id);
    }

    public Book AddBookByInput(BookInputMutable input)
    {
        Book book = new() { Title = input.Title, Author = input.Author };

        _repository.Books.Add(book);

        return _repository.Books.First(b => b.Id == book.Id);
    }

    // User
    public UpdateUserNamePayload UpdateUserName(UpdateUserNameInput input)
    {
        var user = _repository.Users.Single(u => u.Id == input.UserId);
        user.Name = input.UserName;

        var payload = new UpdateUserNamePayload { User = _repository.Users.First(u => u.Id == input.UserId) };
        return payload;
    }
    public class UpdateUserNameInput
    {
        [ID]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
    public class UpdateUserNamePayload
    {
        public User User { get; set; }
    }

    //      updateUserName(input: UpdateUserNameInput!): UpdateUserNamePayload!
    //      input UpdateUserNameInput
    //      {
    //        userId: ID!
    //        username: String!
    //      }
    //      type UpdateUserNamePayload
    //      {
    //        user: User
    //      }
}
