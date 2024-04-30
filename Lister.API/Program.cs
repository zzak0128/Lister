using Lister.Library.DTOs;
using Lister.Library.Interfaces;
using Lister.Library.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IToDoService, ToDoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/ToDos", (IToDoService todos) => 
{
    var allTodos = todos.GetAllToDos().Select(x => new ToDoDTO(x.Title, x.IsComplete));

    return allTodos;
})
.WithName("GetToDos")
.WithOpenApi();

app.Run();
