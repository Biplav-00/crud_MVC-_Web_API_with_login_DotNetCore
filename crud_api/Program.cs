using crud_api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//manually added the created db context in the builder in in-memory database
/*builder.Services.AddDbContext<PersonApiDbContext>
    (options => options.UseInMemoryDatabase("Person_Db"));*/

//add the postgres database to the application
builder.Services.AddDbContext<PersonApiDbContext>(options => 
options.UseNpgsql(builder.Configuration.GetConnectionString("PersonApiConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
