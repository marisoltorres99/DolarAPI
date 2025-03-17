using DolarAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// config URL base del HttpClient para que las solicitudes de DolarService usen BaseUrlDolar como prefijo
// inyeccion de dependencias
builder.Services.AddHttpClient<IDolarService, DolarService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlDolar"]);
});

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
