using Eonix.TechnicalTest.WebAPI.Business.Services;
using Eonix.TechnicalTest.WebAPI.Infrastructure.Persistance;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

Configure(builder.Services, builder.Configuration);


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

static void Configure(IServiceCollection services, IConfiguration configuration)
{
    // Add services to the container.

    services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddDbContext<PersonDbContext>();

    services.AddMediatR(config =>
    {
        config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    });

    services.AddScoped<IPersonService,  PersonService>();

}