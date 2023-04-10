using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
  options.UseInMemoryDatabase("ToDoItemsDb");
});

var app = builder.Build();

app.MapGet("api/v1/todo", async (AppDbContext context) =>
{
  var items = await context.ToDoItems.ToListAsync<ToDoItem>();

  return Results.Ok(items);
});

app.MapPost("api/v1/todo", async (AppDbContext context, ToDoItem todoItem) =>
{
  if (todoItem == null)
  {
    return Results.BadRequest();
  }

  await context.AddAsync<ToDoItem>(todoItem);

  await context.SaveChangesAsync();

  return Results.Created($"api/v1/todo/{todoItem.Id}", todoItem);
});

app.Run();
