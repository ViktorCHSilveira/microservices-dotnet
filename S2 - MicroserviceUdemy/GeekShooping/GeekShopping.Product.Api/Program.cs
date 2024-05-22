using AutoMapper;
using GeekShopping.ProductApi.Config;
using GeekShopping.ProductApi.Model.Context;
using GeekShopping.ProductApi.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
ConfigureServices(builder.Services);

// Add services to the container.


void ConfigureServices(IServiceCollection services) {


    services.AddControllers()
            .AddJsonOptions(options => {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    }); 
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    var connection = Configuration["MySQLConnection:MySQLConnectionString"];
    services.AddDbContext<MySQLContext>(options => options.
                   UseMySql(connection,
                   new MySqlServerVersion(new Version(8, 0, 21))));

    IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
    services.AddSingleton(mapper);
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddScoped<IProductRepository, ProductRepository>();
    

}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
