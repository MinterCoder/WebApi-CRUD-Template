# Swaggeri Ekleme

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