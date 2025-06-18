using EduCenterApi.Application;
using EduCenterApi.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy.WithOrigins("https://localhost:7039") // bu sizning Blazor frontend manzilingiz
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddSwaggerGen();

builder.Services.RegisterApplicationServices();
builder.Services.RegisterInfrastructureServces(
    connectionString: builder.Configuration.GetConnectionString("DefaultConnectionString") ?? throw new NullReferenceException("Connection string not founf")
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowBlazorClient");

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
