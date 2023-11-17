using _30HillsProject.API.Core;
using _30HillsProject.Application.UseCases.Commands;
using _30HillsProject.Application.UseCases.Queries;
using _30HillsProject.DataAccess;
using _30HillsProject.Domain;
using _30HillsProject.Implementation.UseCases.Commands;
using _30HillsProject.Implementation.UseCases.Queries;
using _30HillsProject.Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

namespace _30HillsProject.API.Extensions
{
    public static class ContainerExcension
    {

        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            services.AddTransient(x =>
            {
                var context = x.GetService<_30HillsProjectDbContext>();
                var settings = x.GetService<AppSettings>();

                return new JWTManager(context, settings.JwtSettings);
            });


            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
        public static void AddApplicationUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUser>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];

                //Pristup payload-u
                var claims = accessor.HttpContext.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonymousUser();
                }

                var actor = new JWTUser
                {
                    Identity = claims.FindFirst("Username").Value,
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    Username = claims.FindFirst("Username").Value,
                    //Identity = claims.FindFirst("Email").Value,
                    // "[1, 2, 3, 4, 5]"
                    UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
                };

                return actor;
            });
        }

        public static void AddUseCases(this IServiceCollection services)
        {
            #region Categories
            services.AddTransient<ICreateCategoryCommand, EFCreateCategoryCommand>();
            #endregion

            #region Registration
            services.AddTransient<IRegisterUserCommand, EFRegisterUserCommand>();
            #endregion

            #region Products
            services.AddTransient<IGetProductsQuery, EFGetProductsQuery>();
            services.AddTransient<IGetSingleProductQuery, EFGetSingleProductQuery>();
            services.AddTransient<ICreateProductCommand, EFCreateProductCommand>();
            services.AddTransient<IDeleteProductCommand, EFDeleteProductCommand>();
            #endregion

            #region ProductCart
            services.AddTransient<ICreateProductCartCommand,EFCreateProductCartCommand>();
            services.AddTransient<IGetProductCartQuery,EFGetProductCartQuery>();
            services.AddTransient<IDeleteProductCartCommand,EFDeleteProductCartCommand>();
            #endregion

            #region Cart
            services.AddTransient<IGetCartsQuery, EFGetCartsQuery>();
            services.AddTransient<IDeleteCartCommand, EFDeleteCartCommand>();
            #endregion

            #region Validators
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<RegisterUserValidator>();
            #endregion
        }
        public static void AddHillsProjectDBContext(this IServiceCollection services, string conString)
        {
            services.AddTransient(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder();


                optionsBuilder.UseSqlServer(conString);

                var options = optionsBuilder.Options;

                return new _30HillsProjectDbContext(options);
            });
        }


    }
}
