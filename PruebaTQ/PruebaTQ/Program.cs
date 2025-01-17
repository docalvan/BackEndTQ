using Microsoft.EntityFrameworkCore;
using PruebaTQ.Clases;
using PruebaTQ.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var config = builder.Configuration;
//string conex = config.GetConnectionString("PostgreSQLConecction");


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conecctionString = builder.Configuration.GetConnectionString("PostgreSQLConecction");
builder.Services.AddDbContext<DataPostgres>(options =>
                    options.UseNpgsql(conecctionString));

builder.Services.AddCors(options =>
    {
        options.AddPolicy("TQCors", policy =>
        {
            policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
        });
    }
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/Usuarios/", async (Usuario e, DataPostgres db) =>
    {
    db.Usuarios.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/Usuario/{e.Id}", e);
    }
);

app.MapGet("/Usuarios/{id:int}", async (int id, DataPostgres db) =>
{
    return await db.Usuarios.FindAsync(id)
        is Usuario e
        ? Results.Ok(e)
        : Results.NotFound();
}
);

app.MapGet("/Usuarios/", async (DataPostgres db) => await db.Usuarios.ToListAsync());

app.MapPut("/Usuarios/{id:int}", async (int id, Usuario e, DataPostgres db) =>
    {
        if (e.Id != id)
        {
            return Results.NotFound();
        }

        var usuario = await db.Usuarios.FindAsync(id);

        if (usuario is null)
        {
            return Results.NotFound(); 
        }

        usuario.Nombre = e.Nombre;
        usuario.Correo = e.Correo;
        usuario.Clave = e.Clave;
        usuario.Rol = e.Rol;

        await db.SaveChangesAsync();

        return Results.Ok(usuario);
    }
);

app.MapDelete("/Usuarios/{id:int}", async (int id, DataPostgres db) =>
    {
        var usuario = await db.Usuarios.FindAsync(id);

        if (usuario is null)
        {
            return Results.NotFound();
        }

        db.Usuarios.Remove(usuario);
        await db.SaveChangesAsync();

        return Results.NoContent();
    }
);

app.UseCors("TQCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
