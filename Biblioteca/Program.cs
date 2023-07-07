using Biblioteca.BbContext;

var builder = WebApplication.CreateBuilder(args);
//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins", app =>
    {
        app.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
    //options.AddPolicy(name: MyAllowSpecificOrigins,
    //     builder =>
    // {
    //     builder.WithOrigins("http://localhost",
    //         "http://localhost:7211",
    //         "https://localhost:7211",
    //         "http://localhost:90")
    //     .AllowAnyMethod()
    //     .AllowAnyHeader()
    //     .SetIsOriginAllowedToAllowWildcardSubdomains();
    // });
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyAllowSpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
