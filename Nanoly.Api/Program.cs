using Nanoly.Entities;
using Nanoly.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SegmentService>();
builder.Services.AddScoped<PostgresDBContext>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AuthenticationService>();


builder.Services.AddDbContext<PostgresDBContext>();

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
