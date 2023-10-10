using DZ_2.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

app.MapGet("/", () => new {Message = "Connected", Date = DateTime.Now.ToLongDateString()});
app.MapGet("/test", () => new {Message = "Ok", Time=DateTime.Now.ToLongTimeString()});


app.MapGet("/all", async (AppDbContext db) =>
{
    return db.Veciles;
});

app.MapPost("/add", async (AppDbContext db, FarmVehicleFleet vehicle) =>
{
    db.Veciles.Add(vehicle);
    await db.SaveChangesAsync();
    return vehicle;
});

app.MapGet("/get/{id:int}", async (AppDbContext db, int id) =>
{
    return await db.Veciles.FirstOrDefaultAsync(h => h.Id == id);
});

app.MapPut("/update", async (AppDbContext db, FarmVehicleFleet vehicle) =>
{
    var vehicleUpdate = await db.Veciles.FirstOrDefaultAsync(h => h.Id == vehicle.Id);
    if(vehicleUpdate != null)
    {
        vehicleUpdate.Name = vehicle.Name;
        vehicleUpdate.Type = vehicle.Type;
        vehicleUpdate.YearOfManufacture = vehicle.YearOfManufacture;
        await db.SaveChangesAsync();
    }
    return vehicle;
});

app.MapDelete("/delete/{id:int}", async (AppDbContext db, int id) =>
{

    var vehicle = await db.Veciles.FirstOrDefaultAsync(h => h.Id == id);
    if(vehicle != null)
    {
        db.Veciles.Remove(vehicle);
        await db.SaveChangesAsync();
    }
});






app.Run();
