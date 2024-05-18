using project;
var builder = WebApplication.CreateBuilder(args);
startUp startUp = new startUp(builder.Configuration);
startUp.ConfigureServices(builder.Services);

var app = builder.Build();
startUp.Configure(app, builder.Environment);
app.Run();