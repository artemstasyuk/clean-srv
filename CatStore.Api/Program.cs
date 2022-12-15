using CatStore.Api;
using CatStore.Application;
using CatStore.Infrastructure;
using CatStore.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
//DI
builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();


app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();