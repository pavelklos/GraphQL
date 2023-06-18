using HotChocolate.Types.NodaTime;
using HotChocolateTutorial.GraphQL;
using HotChocolateTutorial.Models;

// *****************************************************************************
var builder = WebApplication.CreateBuilder(args);
// *****************************************************************************

builder.Services.AddSingleton<Repository>();

// [GraphQL]
builder.Services
    .AddGraphQLServer()
    .AddType(new UuidType('D'))
    .AddType<DurationType>()
    .AddType<ZonedDateTimeType>()
    .AddType<DateTimeZoneType>()

    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    //.AddTransactionScopeHandler<CustomTransactionScopeHandler>()
    .AddDefaultTransactionScopeHandler() // Microsoft ADO.NET data provider with Entity Framework
    //.AddMutationConventions(applyToAllMutations: true)
    .AddMutationConventions(); // for field attribute [UseMutationConvention]

// *****************************************************************************
var app = builder.Build();
// *****************************************************************************

// [GraphQL]
app.MapGraphQL();

// Minimal API
app.MapGet("/", () => "Hello World!");

// *****************************************************************************
app.Run();
// *****************************************************************************
