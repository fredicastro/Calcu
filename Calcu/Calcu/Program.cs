using Calcu;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// DbContext
builder.Services.AddDbContext<FmcDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
//infraestructure
//builder.Services.AddScoped<IMessageProducer, TransactionPublisher>();
//builder.Services.AddScoped<IMessageConsumer, TransactionConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //
    using (var scope = app.Services.CreateScope())
    {
        var FmcDbContext = scope.ServiceProvider.GetRequiredService<FmcDbContext>();
        FmcDbContext.Database.EnsureCreated();
    }
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
