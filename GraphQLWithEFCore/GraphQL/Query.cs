using GraphQLWithEFCore.Context;
using GraphQLWithEFCore.Models;

namespace GraphQLWithEFCore.GraphQL;

public class Query
{
    private readonly DatabaseContext dbContext;

    public Query(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IQueryable<Student> Students => dbContext.Students;
}