using DiaryPetProject.DAL.DependencyInjection;
using DiaryPetProject.Application.DependencyInjection;
using DiaryPetProject.Api;
using DiaryPetProject.Domain.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.DefaultSection));

builder.Services.AddControllers();

builder.Services.AddAuthentificationAndAuthorization(builder);
builder.Services.AddSwagger();

builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "DiaryPetProject v1.0");
        x.SwaggerEndpoint("/swagger/v2/swagger.json", "DiaryPetProject v2.0");
        x.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
