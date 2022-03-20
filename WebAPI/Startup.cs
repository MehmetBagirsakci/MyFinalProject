using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
//nuget: Microsoft.AspNetCore.Authentication
//nuget: nswag -> NSwag.AspNetCore

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //bir class i�erisinde data tutmuyorsak singleton
            //ama bir sepet uygulamas�nda Sepeti manager'da tutuyorsan�z singleton olursa bir client
            //sepetine bir �r�n ekledi�inde herkesin sepetine eklenir.
            //sepetdeki �r�nleri veri taban�nda tutmak mant�kl�.
            //services.AddSingleton<IProductService, ProductManager>();//Birisi constructorda IProductService isterse, ona ProductManager'i new leyip veriyor.
            //services.AddSingleton<IProductDal, EfProductDal>();

            services.AddCors();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
            services.AddDependencyResolvers(new ICoreModule[] { 
            new CoreModule()
            });//Biz extension yazd�k.

            //Swagger aktifle�tiriyoruz.
            services.AddSwaggerDocument(config=>
            {
                config.PostProcess = (doc =>
                {
                    doc.Info.Title = "My Final Project";
                    doc.Info.Version = "1.0.13";
                    doc.Info.Description = "Katmanl� Mimari ve API ile ilk uygulamam";
                    doc.Info.Contact = new NSwag.OpenApiContact
                    {
                        Email = "mehmetbagirsakci@gmail.com",
                        Name = "Mehmet Ba��rsak��"
                    };
                    
             
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureCustomExceptionMiddleware(); //biz ekledik. Exceptionlar� merkezi hale getirdik.

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader()); //Angular 4200 portu ile aya�a kalk�yor. 4200 portundan gelen istekleri kabul et demi� olduk.

            app.UseHttpsRedirection();

            app.UseRouting(); 

            app.UseOpenApi();//swagger i�in ekledik.
            app.UseSwaggerUi3();//swagger i�in ekledik.

            app.UseAuthentication();//biz ekledik.

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
//JwtBearerDefaults:using Microsoft.AspNetCore.Authentication.JwtBearer;