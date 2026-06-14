using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la conexión a la Base de Datos
builder.Services.AddDbContext<LabClinicoAPI.Context.ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();

// 🛠️ PASO 1: AGREGAR ESTAS DOS LÍNEAS (Para que el API reconozca Swagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🛠️ PASO 2: AGREGAR ESTAS DOS LÍNEAS (Para habilitar la interfaz gráfica azul)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Esto es lo que dibuja la página web de Swagger
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();