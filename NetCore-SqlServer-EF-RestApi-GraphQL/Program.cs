using GPL.DBModels;
using GPL.Queries;
using System.Reflection.Metadata;

// *****************************************************************************
var builder = WebApplication.CreateBuilder(args);
// *****************************************************************************
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// [GraphQL]
// - Provides DI extension methods to configure GraphQL server.
// - Adds GraphQL server core services to DI.
builder.Services.AddGraphQLServer()
    .AddQueryType<Productdata>()    // Add GraphQL query type
    .AddProjections()               // Adds filtering support
    .AddFiltering()                 // Adds filtering support
    .AddSorting();                  // Adds filtering support

// *****************************************************************************
var app = builder.Build();
// *****************************************************************************
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();

// [GraphQL]
// - Adds GraphQL endpoint to endpoint configurations.
// - Path to which GraphQL endpoint shall be mapped.
app.MapGraphQL("/graphql");  // Path to which GraphQL endpoint shall be mapped

// *****************************************************************************
app.Run();
// *****************************************************************************

//using (var db = new ProductDataContext())
//{
//    var category = new TblCategory { CategoryName = "CATEGORY-1" };
//    db.TblCategories.Add(category);
//    db.SaveChanges();
//}
