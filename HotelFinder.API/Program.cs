using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Controllerlar eklendi.
builder.Services.AddControllers();
builder.Services.AddSingleton<IHotelService,HotelManager>();
builder.Services.AddSingleton<IHotelRepository,HotelRepository>();
builder.Services.AddSwaggerDocument(configure=>{
    configure.PostProcess=(doc=>{
        doc.Info.Title = "All Hotels Api";
        doc.Info.Version="1.0.3";
        doc.Info.Contact=new NSwag.OpenApiContact(){
            Name="Minter Coder",
            Url="http://google.com",
            Email="mintercoder.com"
        };
    });
});

var app = builder.Build();

// Controllerlar maplendi.
app.MapControllers();
app.UseOpenApi();
app.UseSwaggerUi();
app.Run();
