using AppBackend.UseCases;


var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioUseCases, UsuarioUseCases>();
builder.Services.AddScoped<IEventoUseCases, EventoUseCases>();
builder.Services.AddScoped<IInscripcionUseCases, InscripcionUseCases>();
builder.Services.AddScoped<IPagoUseCases, PagoUseCases>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
