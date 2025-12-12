using AmargorDaVida.Routes;
using AmargorDaVida.vars;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dataOptions = builder.Configuration.GetSection("DataDirectory").Get<string>();

Paths.Initialize(dataOptions);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFront",
        policy => policy.WithOrigins("http://localhost:63342")
                                     .AllowAnyMethod()
                                     .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowFront");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.ADV_Routes();

//run code
app.UseHttpsRedirection();
app.Run();
