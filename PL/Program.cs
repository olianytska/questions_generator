using Microsoft.EntityFrameworkCore;
using PL.EF;
using PL.Extensions;
using PL.Interfaces;
using PL.Repositories;
using PL.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://localhost:7191/api",
                                "http://localhost:4200");
        });
});
builder.Services.AddDbContext<QuestionsDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("QuestionsDBConnection")));

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 7191;
});

builder.Host.ConfigureLogging(b =>
{
    b.SetMinimumLevel(LogLevel.Information);
    b.AddLog4Net("log4net.config");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureBuildInExeptionHandler(app.Services.GetRequiredService<ILoggerFactory>());

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
