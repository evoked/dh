using PMDashboard.Api.Repositories;
using PMDashboard.Api.Repositories.Product;
using PMDashboard.Api.Services.Product;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ILiteDb, LiteDb>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var specificOrgins = "AppOrigins";
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: specificOrgins,
					  policy =>
					  {
						  policy.WithOrigins("http://localhost:5173");
					  });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(specificOrgins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
