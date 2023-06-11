// *****************************************************************************
using GraphQLWithEFCore.Context;
using GraphQLWithEFCore.GraphQL;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// *****************************************************************************
// Add services to the container.
builder.Services.AddRazorPages();

//builder.Configuration
//    .AddIniFile("MyIniConfig.ini", optional: true, reloadOnChange: true)
//    .AddIniFile($"MyIniConfig.{builder.Environment.EnvironmentName}.ini",
//                optional: true, reloadOnChange: true);
//builder.Configuration.AddEnvironmentVariables();
//builder.Configuration.AddCommandLine(args);

var connectionString = builder.Configuration.GetConnectionString("TestDB");
builder.Services.AddDbContext<DatabaseContext>(o => o.UseSqlServer(connectionString));
builder.Services.AddScoped<Query>();
builder.Services.AddGraphQL(p => SchemaBuilder.New().AddServices(p)
    .AddType<StudentType>()
    .AddQueryType<Query>()
    .Create()
);

// *****************************************************************************
var app = builder.Build();
// *****************************************************************************
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UsePlayground(new PlaygroundOptions  	// HotChocolate.AspNetCore
    {
        QueryPath = "/api",
        Path = "/playground"
    });
}

app.MapGraphQL("/api"); 			// HotChocolate.AspNetCore

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

// *****************************************************************************
app.Run();
// *****************************************************************************
