using Microsoft.EntityFrameworkCore;
using WA.Data;
using WA.Infra.Repository;
using WA.Infra.Repository.Interfaces;
namespace WA
{
    public class Program
    {

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddEntityFrameworkSqlServer()
            .AddDbContext<APICorujaDBContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoSQL"))
                );
           
            builder.Services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
            builder.Services.AddScoped<IDisciplinaRepositorio, DisciplinaRepositorio>();
            builder.Services.AddScoped<ITurmaRepositorio, TurmaRepositorio>();
            builder.Services.AddScoped<IInscricaoRepositorio, InscricaoRepositorio>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

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

            app.Run();
        }
    }
}
