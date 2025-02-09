using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Controllerlar eklendi.
builder.Services.AddControllers();
builder.Services.AddSingleton<IHotelService,HotelManager>();
builder.Services.AddSingleton<IHotelRepository,HotelRepository>();

var app = builder.Build();

// Controllerlar maplendi.
app.MapControllers();


app.Run();
