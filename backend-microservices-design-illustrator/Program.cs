using FakeTehranFavaServer.Repositories;
using FakeTehranFavaServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true ;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRepository, DbRepo>();
builder.Services.AddCors();

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

app.UseCors(x => 
{
    x.AllowAnyOrigin();
    x.AllowAnyMethod();
    x.AllowAnyHeader();
});
 // app.UseMiddleware<WriteToDbMiddleWare>();

var repository = app.Services.GetRequiredService<IRepository>();


app.Lifetime.ApplicationStarted.Register(() =>
{
    DbRepo.Load(repository);
});


app.Lifetime.ApplicationStopping.Register(() =>
{
    DbRepo.Save(repository);
});

app.Lifetime.ApplicationStopped.Register(() =>
{
    DbRepo.Save(repository);
});


app.Run();
