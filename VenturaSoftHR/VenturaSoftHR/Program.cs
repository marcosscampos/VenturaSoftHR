using VenturaSoftHR.Api.Common;

var builder = WebApplication.CreateBuilder(args);

var host = new HostBuilder();
host.ConfigureAppConfiguration((HostBuilderContext context, IConfigurationBuilder _builder) =>
{
    _builder.AddEnvironmentVariables().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
});
// Add services to the container.
builder.Services.ConfigureApplicationDependencies(builder.Configuration);

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
