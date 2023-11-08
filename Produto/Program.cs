using Produto.Mapper;
using Produto.Data;
using Produto.Domain;
using Produto.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMapperConfig();
builder.Services.AddInfrastructureDatabaseContext();
builder.Services.AddInfrastructureRepository();
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();


builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{

});

builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
