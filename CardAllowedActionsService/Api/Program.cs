using CardAllowedActionsService.Application.Cards.Resolvers;
using CardAllowedActionsService.Application.Cards.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IPartialAllowedActionsResolver, CardStatusActionsResolver>();
builder.Services.AddScoped<IPartialAllowedActionsResolver, CardTypeActionsResolver>();
builder.Services.AddScoped<IAllowedActionsResolver, AllAllowedActionsResolver>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
