namespace HotChocolateTutorial.GraphQL;

using HotChocolateTutorial.Models;

public class Subscription
{
    [Subscribe]
    public Book BookAdded([EventMessage] Book book) => book;
}