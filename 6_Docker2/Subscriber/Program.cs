using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SharedKernel.Messaging;
using Subscriber.Messaging;
using Subscriber.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => options.UseNamespaceRouteToken());
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pub/Sub", Version = "v1" });
    c.EnableAnnotations();
    c.UseApiEndpoints();
});

builder.Services.Configure<MessageBrokerSettings>(builder.Configuration.GetSection("RabbitMQ"));

builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value);

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    busConfigurator.AddConsumer<OrderConsumer>();

    busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
    {
        MessageBrokerSettings messageBrokerSettings = context.GetRequiredService<MessageBrokerSettings>();
        busFactoryConfigurator.Host(new Uri(messageBrokerSettings.Host), hostConfigurator =>
        {
            hostConfigurator.Username(messageBrokerSettings.UserName);
            hostConfigurator.Password(messageBrokerSettings.Password);
        });
    });
});

builder.Services.AddScoped<IRepository<OrderCreated>, Repository<OrderCreated>>();

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
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

