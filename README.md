# Neden .Net CORE
.NET framework sadece windows ortamında geçerli ve yayınlama sadece IIS olur.<br>
.NET Core'de cross-platform ve linux serverda da yayınlama yapılabilir.<br>
.Net Standard Library (Class Library) hepsinde de çalışır .Net Core'da da .net framework ve xamarinde de class library alıp çalıştırabiliriz.

.Net Core'nin 3 tane modülü vardır.
* MVC (Model View Controller)
* Razor Pages
* Web API (Bu notlar buraya aittir.)

### Dotnet Notları

# Dotnet Komutları
Bana HotelFinder isimli bir tane solution oluştur içerisine de bir tane class library yap ismi HotelFinder.Entities olsun.

```sh
dotnet new sln -o HotelFinder
cd HotelFinder
dotnet new classlib -o HotelFinder.Entities
dotnet sln add HotelFinder.Entities/HotelFinder.Entities.csproj
```

EntityFramework için
```sh
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.33
dotnet add package Microsoft.EntityFrameworkCore --version 6.0.33
```

Migration için
```sh
dotnet tool install --global dotnet-ef --version 6.0.20
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Swaggeri Ekleme Komutu


```sh
dotnet add package NSwag.AspNetCore --version 14.2.0
dotnet add package System.Text.Json --version 8.0.0
```

Koda eklenen kısım
```cs
builder.Services.AddSwaggerDocument();
app.UseOpenApi();
app.UseSwaggerUi();
```

http://localhost/swagger/index.html

![Clipboard_2025-02-09-12-34-25](https://github.com/user-attachments/assets/854ac06b-5272-42df-8feb-2b5a0611615e)
