using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SharedKernel.Messaging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.UseNamespaceRouteToken());
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pub/Sub", Version = "v1" });
    c.EnableAnnotations();
    c.UseApiEndpoints();
});

builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("RabbitMQ"));
builder.Services.AddTransient(sp => sp.GetRequiredService<IOptions<RabbitMqConfiguration>>().Value);

var serviceProvider = builder.Services.BuildServiceProvider();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        RabbitMqConfiguration rabbitMqConfiguration = serviceProvider.GetRequiredService<RabbitMqConfiguration>();
        //builder.RegisterModule(new AutofacBusinessModule());
        builder.Register(context => new RabbitMqPublisher(rabbitMqConfiguration, "myQueue")).Keyed<RabbitMqPublisher>("myQueue").InstancePerLifetimeScope();
    });



//builder.Services.AddTransient<RabbitMqPublisher>();

var app = builder.Build();



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