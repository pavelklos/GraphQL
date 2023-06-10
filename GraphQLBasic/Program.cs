// *****************************************************************************
using GraphQLBasic.IService;
using GraphQLBasic.Models;
using GraphQLBasic.Service;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;

var builder = WebApplication.CreateBuilder(args);
// *****************************************************************************
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IStudentService, StudentService>();
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
    app.UsePlayground(new PlaygroundOptions  // HotChocolate.AspNetCore
    {
        QueryPath = "/api",
        Path = "playground"
    });
}
app.MapGraphQL("/api"); // HotChocolate.AspNetCore
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

// *****************************************************************************
app.Run();
// *****************************************************************************
