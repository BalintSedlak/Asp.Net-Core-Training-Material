using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SharedKernel.Messaging;

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

builder.Services.AddSingleton<RabbitMqServiceFactory>();

var app = builder.Build();



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