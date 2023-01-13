using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.Services;
using AllOut.Api.Services.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#if PROD
var connectionstring = builder.Configuration.GetConnectionString("PROD_SQL_CON");
#else
var connectionstring = builder.Configuration.GetConnectionString("DEV_SQL_CON");
#endif

builder.Services.AddDbContext<AllOutDbContext>(options => options.UseSqlServer(connectionstring));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IUtilityService, UtilityService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy",
        policy =>
        {
            policy.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("Policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
