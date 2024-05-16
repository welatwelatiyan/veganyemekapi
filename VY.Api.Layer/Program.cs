using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using VY.Business.Layer.Auth.Worker;
using VY.Business.Layer.DepencyResolver;
using VY.Core.Layer.Utilities.Security.JWT;
using Microsoft.IdentityModel.Tokens;
using VY.DataAccess.Layer.DbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using VY.Business.Layer.Auth.Mapper;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacDepencyModel()));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc("V1", new OpenApiInfo
    {
        Version = "V1",
        Title = "WebAPI",
        Description = "Vegan Yemek"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "Vy.Api.Layer.xml");
    options.IncludeXmlComments(filePath);
});
TokenOptions tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
    };
});

var constr = builder.Configuration.GetConnectionString("authcon");
builder.Services.
    AddDbContext<AuthContext>(x => x.
    UseMySql(constr, ServerVersion.AutoDetect(constr)),ServiceLifetime.Transient);

builder.Services.AddHostedService<MailVerifyWorker>();

var app = builder.Build();
using(var scope = app.Services.CreateScope())
    scope.ServiceProvider.GetService<AuthContext>().Database.Migrate();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(options => {
    options.SwaggerEndpoint("/swagger/V1/swagger.json", "Vegan Yemek");
});


app.UseForwardedHeaders();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.MapControllers();

app.Run();
