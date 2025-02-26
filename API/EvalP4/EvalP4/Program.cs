using Repositories;
using Microsoft.EntityFrameworkCore;
using Repositories.RepositoriesContracts;
using Services.Services;
using Repositories.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Ajout des services
builder.Services.AddControllers();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IPasswordRepository, PasswordRepository>();

// Configuration de Swagger pour le développement
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration de la base de données et des migrations
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Repositories")
    )
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
