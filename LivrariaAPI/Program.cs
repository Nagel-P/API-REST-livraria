using Microsoft.EntityFrameworkCore;
using LivrariaAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração da string de conexão e do DbContext
builder.Services.AddDbContext<LivrariaContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("LivrariaConnection"), 
        new MySqlServerVersion(new Version(8, 0, 21)))); // Altere a versão conforme a sua instalação do MySQL

// Adicione os serviços do ASP.NET Core
builder.Services.AddControllers();

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Redireciona para uma página de erro em produção
    app.UseHsts();
}

// Outras configurações do middleware, como roteamento, CORS, etc.
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers(); // Mapeia os controladores para rotas

app.Run();
