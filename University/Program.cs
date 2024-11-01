using Microsoft.EntityFrameworkCore;
using RepositoryUniversity;
using RepositoryUniversity.Interfaces;
using UniversityService;
using UniversityService.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<IPangramService, PangramService>();
builder.Services.AddScoped<IArticleService, ArticleService>();


builder.Services.AddHttpClient();


var connectionString = builder.Configuration.GetConnectionString("DB");

builder.Services.AddDbContext<UniversityContext>(options => {

    options.UseSqlServer(connectionString);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
