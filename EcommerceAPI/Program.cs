using EcommerceRepository.DBContext;
using Microsoft.EntityFrameworkCore;

using EcommerceRepository.Contract;
using EcommerceRepository.Implementation;
using EcommerceUtilities;
using EcommerceService.Contract;
using EcommerceService.Implementation;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbecommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});

builder.Services.AddTransient(typeof(IGerenicRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();

builder.Services.AddCors(options =>
{
options.AddPolicy("New Policy", app =>
  {
      app.AllowAnyOrigin()
      .AllowAnyHeader()
      .AllowAnyMethod();

});
}
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("New Policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
