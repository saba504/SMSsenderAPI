using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SMSsenderAPI.Data;
using SMSsenderAPI.Implementations;
using SMSsenderAPI.Interfaces;
using SMSsenderAPI.Models;
using SMSsenderAPI.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
c.SwaggerDoc("v1", new OpenApiInfo { Title = "Presentation.WebApi", Version = "v1" });

var jwtSecurityScheme = new OpenApiSecurityScheme
{
    Scheme = "bearer",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Description = "ქვედა ტექსტბოქსში ჩაწერეთ *_მხოლოდ_* თქვენი token !",

    Reference = new OpenApiReference
    {
        Id = JwtBearerDefaults.AuthenticationScheme,
        Type = ReferenceType.SecurityScheme
    }
};
c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
c.AddSecurityRequirement(new OpenApiSecurityRequirement
                  {
                    { jwtSecurityScheme, Array.Empty<string>() }
                  });
});



builder.Services.AddScoped<ISmsService, SmsService>();
builder.Services.AddScoped<ISmsSendService, SmsSendService>();
builder.Services.AddScoped<ITemplateService, TemplateService>();
builder.Services.AddDbContext<DataContext>();
//builder.Services.AddScoped<Sms2Template>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.ConfigureCors(); //cross-origin
//builder.Services.AddCors(); //cross-origin


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
if (builder.Configuration.GetValue<Boolean>("ShowSwagger"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AnyPolicy"); //cross-origin

app.Run();