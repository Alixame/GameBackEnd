namespace GameBackend;

public class Program 
{
    public static void Main(string[] args) 
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // DEFININDO SERVIÇOS A SEREM USADOS NO PROJETO
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        WebApplication app = builder.Build();

        // ADICIONANDO SWAGGER APENAS EM DESENVOLVIMENTO
        if (app.Environment.IsDevelopment()) {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // ADICIONANDO CONTROLLERS
        app.MapControllers();

        // RODANDO PROJETO
        app.Run();
    }
}