using webapi;
using webapi.Models;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configuración de EF
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));


//las dependencias se agregan antes del build:
builder.Services.AddScoped< HellowordService>();  //en este caso la instania que se llama del servicio es la misma para cada controlador y clase. Como solo instancio la dependencia en el builder, queda siendo una sola
  
//de esta forma me ahorro la declaracion de la interface
//builder.Services.AddScoped(p=>new HellowordService()) ;
//builder.Services.AddSingleton //se instancia un nuevo objeto en cada llamada
builder.Services.AddScoped< ICategoriaService,CategoriaService>(); 
builder.Services.AddScoped<ITareasService,TareasService>(); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();
//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
