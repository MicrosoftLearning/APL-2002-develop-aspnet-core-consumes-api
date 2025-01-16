using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FruitDb>(opt => opt.UseInMemoryDatabase("FruitList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Fruit API",
        Description = "API for managing a list of fruit and their stock status.",
    });
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<FruitDb>();
    dbContext.Database.EnsureCreated();
}

app.MapGet("/", context =>
{
    context.Response.Redirect("/fruits");
    return Task.CompletedTask;
});

app.MapGet("/fruits", static async (FruitDb db) =>
        await db.Fruits.ToListAsync() ?? [])
    .Produces<Fruit[]>(200)
    .WithTags("get", "fruits")
    .WithSummary("Get all fruits");

app.MapGet("/fruits/{id}", static async (int id, FruitDb db) =>
    await db.Fruits.FindAsync(id)
        is Fruit fruit
            ? Results.Ok(fruit)
            : Results.NotFound())
    .Produces<Fruit>(200)
    .Produces(404)
    .WithTags("get", "fruit")
    .WithSummary("Get a fruit by Id");

app.MapPost("/fruits", async (Fruit fruit, FruitDb db) =>
{
    db.Fruits.Add(fruit);
    await db.SaveChangesAsync();

    return Results.Created($"/{fruit.Id}", fruit);
})
    .Produces<Fruit>(201)
    .WithTags("post", "fruits")
    .WithSummary("Create a new fruit");


app.MapPut("/fruits/{id}", async (int id, Fruit inputFruit, FruitDb db) =>
{
    var fruit = await db.Fruits.FindAsync(id);

    if (fruit is null) return Results.NotFound();

    fruit.Name = inputFruit.Name;
    fruit.Instock = inputFruit.Instock;

    await db.SaveChangesAsync();

    return Results.NoContent();
})
    .Produces(204)
    .WithTags("put", "fruits")
    .WithSummary("Update a fruit by Id");


app.MapDelete("/fruits/{id}", async (int id, FruitDb db) =>
{
    if (await db.Fruits.FindAsync(id) is Fruit fruit)
    {
        db.Fruits.Remove(fruit);
        await db.SaveChangesAsync();
        return Results.Ok(fruit);
    }

    return Results.NotFound();
})
    .Produces<Fruit>(200)
    .WithTags("delete", "fruits")
    .WithSummary("Delete a fruit by Id");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();