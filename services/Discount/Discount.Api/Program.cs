using Discount.Api.Services;
using Discount.Appliclication.Commands;
using Discount.Appliclication.Mappers;
using Discount.Core.Repositories;
using Discount.Infrastructure.Extentions;
using Discount.Infrastructure.Repositories;
using System.Net;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddMediatR(rg => rg.RegisterServicesFromAssemblies(
   Assembly.GetExecutingAssembly(),
   Assembly.GetAssembly(typeof(CreateDiscountCommand)))
);
builder.Services.AddAutoMapper(typeof(DiscountProile).Assembly);
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MigrateDataBase<Program>();
app.UseRouting();
app.UseEndpoints(
    endPoint => 
    {
        endPoint.MapGrpcService<DiscountService>();
        endPoint.MapGet("/", async context =>
        {
            await context.Response.WriteAsync("Communication Grpc  End point Must made throw Grpc Client (:");
        });
    
    });

app.Run();
