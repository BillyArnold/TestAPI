using Microsoft.OpenApi.Models;
using Products.DB;

var builder = WebApplication.CreateBuilder(args);
    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test API", Description = "Test API for front end practise", Version = "v1" });
});
    
var app = builder.Build();
    
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
   });
}
    
app.MapGet("/", () => "Hello World!");
app.MapGet("/products", () => ProductDB.GetProducts());
app.MapGet("/products/{id}", (int id) => ProductDB.GetProduct(id));
app.MapGet("/product", () => new { id = 1 });

app.MapPost("/products", (Product product) => ProductDB.CreateProduct(product));

app.MapPut("/products/{id}", (int id, Product product) => ProductDB.UpdateProduct(id, product));

app.MapDelete("/products/{id}", (int id) => ProductDB.RemoveProduct(id));

app.Run();
