using GeekShopping.Product.Api.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
ConfigureServices(builder.Services);

// Add services to the container.


void ConfigureServices(IServiceCollection services) {


  services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
  services.AddEndpointsApiExplorer();
  services.AddSwaggerGen();

    var connection = Configuration["MySQLConnection:MySQLConnectionString"];
  services.AddDbContext<MySQLContext>(options => options.
                 UseMySql(connection,
                           new MySqlServerVersion(new Version(8, 0, 5))));

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
