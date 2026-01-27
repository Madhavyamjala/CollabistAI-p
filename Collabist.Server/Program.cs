using Collabist.Server.Application.Services;
using Collabist.Server.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CollabistDbContext>(options =>
    options.UseSqlite("Data Source=collabist.db"));
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCorsPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddHttpClient<GeminiService>();
builder.Services.AddSingleton<FileDiscoveryService>();
builder.Services.AddSingleton<FileHashService>();
builder.Services.AddScoped<IndexingService>();
builder.Services.AddSingleton<TextExtractionService>();
builder.Services.AddSingleton<SemanticParsingService>();
builder.Services.AddScoped<SemanticIndexingService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors("DevCorsPolicy");

app.MapControllers();

app.Run();
