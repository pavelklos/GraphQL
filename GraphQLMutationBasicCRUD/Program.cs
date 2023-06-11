// *****************************************************************************
using GraphQLMutationBasicCRUD.GraphQL;
using GraphQLMutationBasicCRUD.IService;
using GraphQLMutationBasicCRUD.Service;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
// *****************************************************************************
// Add services to the container.
builder.Services.AddRazorPages();

// GraphQL
builder.Services.AddSingleton<IGroupService, GroupService>();
builder.Services.AddSingleton<IStudentService, StudentService>();
builder.Services.AddGraphQL(x => SchemaBuilder.New()
    .AddServices(x)
    .AddType<GroupType>()
    .AddType<StudentType>()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
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

    // GraphQL
    app.UsePlayground(new PlaygroundOptions     // HotChocolate.AspNetCore
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
