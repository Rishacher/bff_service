namespace bff_service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            RegisterServices(builder.Services);

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            
            app.MapControllers();

            app.UseCors((options) => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.Run();
        }
        
        private static void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<HttpClient>();
            serviceCollection.AddScoped<VlpService>();
            serviceCollection.AddScoped<IprService>();
            serviceCollection.AddScoped<IntersectionService>();
        }
    }
}