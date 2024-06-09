using KDWEBAPI.DBHUBContext;
using KDWEBAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(KDProductRepository<>));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(KDCategoryRepository<>));

// Add ms sql
builder.Services.AddDbContext<HBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add cors.
builder.Services.AddCors(options => options.AddPolicy(name: MyAllowSpecificOrigins, policy => { policy.WithOrigins("http://localhost:3000"); }));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();
app.Run();
