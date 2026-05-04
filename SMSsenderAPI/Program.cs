using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SMSsenderAPI.Data;
using SMSsenderAPI.Models;
using SMSsenderAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISmsService, SmsService>();
builder.Services.AddScoped<ITemplateService, TemplateService>();
builder.Services.AddDbContext<DataContext>();

builder.Services.Configure<EvaluationApiOptions>(
    builder.Configuration.GetSection("EvaluationApi"));

builder.Services.AddHttpClient<IEvaluationService, EvaluationService>((sp, client) =>
{
    var options = sp.GetRequiredService<IOptions<EvaluationApiOptions>>().Value;

    client.BaseAddress = new Uri(options.BaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
