using MassTransit;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SharedKernel.Messaging;
using Subscriber.Messaging;
using Subscriber.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    string[] allowedOrigins = builder.Configuration["CORS_ALLOWED_ORIGINS"].Split(',');

    options.AddPolicy("MySite", builder =>
    {
        builder.WithOrigins(allowedOrigins)
        .AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddControllers(options => options.UseNamespaceRouteToken());
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pub/Sub", Version = "v1" });
    c.EnableAnnotations();
    c.UseApiEndpoints();
});

builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("RabbitMQ"));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<RabbitMqConfiguration>>().Value);

builder.Services.AddSingleton<RabbitMqServiceFactory>();

builder.Services.AddTransient<OrderConsumer>();
builder.Services.AddSingleton<IRepository<OrderCreated>, Repository<OrderCreated>>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pub/Sub V1"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("MySite");
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

