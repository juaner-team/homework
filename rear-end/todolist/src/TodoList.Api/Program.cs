using TodoList.Infrastructure;
using TodoList.Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureLog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 添加基础设施配置
builder.Services.AddInfrastructure(builder.Configuration);

// 省略以下...


//var builder = WebApplication.CreateBuilder(args);
//// Add services to the container.
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

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

// 省略以上...
app.MapControllers();

// 调用扩展方法
app.MigrateDatabase();

app.Run();
