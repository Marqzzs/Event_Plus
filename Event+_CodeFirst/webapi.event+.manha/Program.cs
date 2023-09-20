using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Aciona o serviço de JWT Bearer ( forma de autenticação )
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})
.AddJwtBearer("JwtBearer", options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         //valida quem está solicitando
         ValidateIssuer = true,

         //valida quem está recebendo
         ValidateAudience = true,

         //define se o tempo de expiracao sera validado 
         ValidateLifetime = true,

         //froma de criptografia e valida a chave de autenticacao
         IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("event+-chave-autenticacao-webapi")),

         //valida o tempo de expiracao do token
         ClockSkew = TimeSpan.FromMinutes(5),

         //nome do issuer (de onde está vindo)
         ValidIssuer = "webapi.event+.manha",

         //nome do audience (para onde está indo)
         ValidAudience = "webapi.event+.manha"
     };
 });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//Adiciona o serviço de Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SENAI EVENT+ API",
        Description = "API para o web site da empresa EVENT+ para a finalidade de gerenciamentos de eventos",
        Contact = new OpenApiContact
        {
            Name = "Marqzzs",
            Url = new Uri("https://github.com/Marqzzs/Event_Plus")
        },

    });

    //Usando a autenticaçao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

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
app.UseAuthentication();

app.MapControllers();

app.Run();
