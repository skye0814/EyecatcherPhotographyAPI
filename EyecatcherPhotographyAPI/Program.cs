using Core.Entities;
using Core.Interface.Repository;
using Core.Interface.Services;
using EyecatcherPhotography.Services;
using EyecatcherPhotographyAPI.Extensions;
using Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepositoryContext>(x => 
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


//Services injection and repository wrapper
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.ConfigureRepositoryWrapper();

// Repository injection
//builder.Services.AddScoped<IBillingDetailsRepository, BillingDetailsRepository>();
//builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
//builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Inject logging services
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

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
