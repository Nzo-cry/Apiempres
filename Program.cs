var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policity =>
    {
        policity
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

// Endpoint de prueba inicial
app.MapGet("/", () =>
{
    return "API Sistema de Gestión funcionando";
});

// Endpoint para la información general de la empresa (Inicio)
app.MapGet("/api/empresa", () =>
{
    return Results.Ok(new
    {
        Nombre = "Complejo Deportivo Gol & Pasión",
        Descripcion = "El mejor espacio para alquiler de canchas sintéticas y de loza con iluminación LED.",
        Telefono = "+51 987 654 321",
        Ubicacion = "Av. Del Deporte 123, Huancayo",
        HorarioAtencion = "Lunes a Domingo de 08:00 AM a 11:00 PM"
    });
});

// Endpoint para el Usuario 1 (Consulta de horarios y disponibilidad)
app.MapGet("/api/horarios", () =>
{
    return Results.Ok(new[]
    {
        new
        {
            ID= 1,
            Fecha= "2026-10-15",
            Hora= "18:00",
            Estado= "Disponible",
            TipoCancha= "Fútbol 7 (Sintética)",
            Precio= 80.00,
            Duracion= "1 hora"
        },
        new
        {
            ID= 2,
            Fecha= "2026-10-15",
            Hora= "19:00",
            Estado= "Ocupado",
            TipoCancha= "Fútbol 7 (Sintética)",
            Precio= 100.00,
            Duracion= "1 hora"
        },
        new
        {
            ID= 3,
            Fecha= "2026-10-16",
            Hora= "09:00",
            Estado= "Disponible",
            TipoCancha= "Fútbol 5 (Loza)",
            Precio= 50.00,
            Duracion= "1 hora"
        },
        new
        {
            ID= 4,
            Fecha= "2026-10-16",
            Hora= "10:00",
            Estado= "Mantenimiento",
            TipoCancha= "Fútbol 5 (Loza)",
            Precio= 50.00,
            Duracion= "1 hora"
        }
    });
});

// Endpoint para el Usuario 2 (Consulta de servicios)
app.MapGet("/api/servicios", () =>
{
    return Results.Ok(new[]
    {
        new
        {
            ID= 1,
            Nombre= "Alquiler de cancha",
            Descripcion= "Canchas de césped sintético y loza."
        },
        new
        {
            ID= 2,
            Nombre= "Vestuarios",
            Descripcion= "Casilleros y duchas con agua caliente."
        },
        new
        {
            ID= 3,
            Nombre= "Iluminación",
            Descripcion= "Reflectores LED para partidos nocturnos."
        },
        new
        {
            ID= 4,
            Nombre= "Estacionamiento",
            Descripcion= "Zona de parqueo segura para clientes."
        }
    });
});

// Endpoint extra para el Usuario 2 (Promociones)
app.MapGet("/api/promociones", () =>
{
    return Results.Ok(new[]
    {
        new 
        { 
            ID = 1, 
            Titulo = "Promo Mañanera", 
            Descripcion = "20% de descuento de 8:00 AM a 12:00 PM." 
        },
        new 
        { 
            ID = 2, 
            Titulo = "Fin de Semana", 
            Descripcion = "Alquila 2 horas y llévate 6 aguas minerales gratis." 
        }
    });
});

var port = Environment.GetEnvironmentVariable("Port") ?? "10000";

app.Run();