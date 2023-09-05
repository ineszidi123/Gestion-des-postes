//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;

//namespace Stage2023
//{
  //  public class Startup
    //{
      //  public Startup(IConfiguration configuration)
        //{
          //  Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        // Cette méthode est appelée à l'exécution. Utilisez cette méthode pour ajouter des services au conteneur.
        //public void ConfigureServices(IServiceCollection services)
        //{
          //  services.AddCors(options =>
            //{
              //  options.AddDefaultPolicy(builder =>
                //{
                  //  builder.WithOrigins("http://localhost:3000") // Autorise les requêtes provenant de http://localhost:3000
                    //       .AllowAnyMethod()
                      //     .AllowAnyHeader();
                //});
            //});

            // Autres configurations de services
        //}

        // Cette méthode est appelée à l'exécution. Utilisez cette méthode pour configurer le pipeline HTTP.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
          //  if (env.IsDevelopment())
            //{
              //  app.UseDeveloperExceptionPage();
            //}
            //else
            //{
                // Ajoutez ici des middlewares pour la gestion des erreurs en production, si nécessaire
            //}

            //app.UseCors(); // Utilisez le middleware CORS avant le middleware de routage

            //app.UseRouting();

            // Autres configurations middleware

            //app.UseEndpoints(endpoints =>
            //{
              //  endpoints.MapControllers();
                // Autres endpoints
          //  });
        //}
    //}
//}
