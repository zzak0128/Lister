using Lister.Infrastructure;
using Lister.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// To Do Items
app.MapGet("/ToDoItems", async (ToDoItemService todoItems) =>
{
    await todoItems.GetAllAsync();
});

app.MapGet("/ToDoItems/{id:int}", async (ToDoItemService todoItems, int id) =>
{
    await todoItems.GetToDoItemByIdAsync(id);
});

// To Do Lists
app.MapGet("/ToDoLists", async (ToDoListService todoItems) =>
{
    await todoItems.GetAllAsync();
});


app.Run();
