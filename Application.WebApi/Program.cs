using Application.Common;
using Application.Common.Application.Controllers;
using Application.Common.Application.Midleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddNegotiationModule(builder.Configuration);
builder.Services.AddControllers();
//builder.Services.AddControllers().AddApplicationPart(typeof(MacrosegmentsController).Assembly);

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

//TODO: Crear extension en el proyecto common
app.UseMiddleware<AuthMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
