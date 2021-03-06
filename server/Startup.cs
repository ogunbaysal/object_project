﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using server.Helpers;
using server.Models.User;
using server.Services;
using server.Models.Category;
using Microsoft.AspNetCore.Identity;
using Sieve.Services;
using server.Repositories.Interface;
using System.Reflection;
using server.Models.Order;
using server.Repositories.Orders;
using server.Models.Address;
using server.Repositories.Addresses;
using server.Repositories.Categories;
using server.Models.ProductProperty;
using server.Repositories.ProductProperties;
using server.Models.Product;
using server.Repositories.Products;
using server.Repositories;
using Microsoft.OpenApi.Models;

namespace server
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {

            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ModelContext>(opts => opts.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers()
                .AddNewtonsoftJson(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddCors();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mavi Api", Version = "v1" });
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped<SieveProcessor>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IProductPropertyService, ProductPropertyService>();
            services.AddScoped<IOrderService, OrderService>();

            //repositories
            services.AddScoped<IRepository<District>, DistrictRepository>();
            services.AddScoped<IRepository<Province>, ProvinceRepository>();
            services.AddScoped<IRepository<Category>, CategoryRepository>();
            services.AddScoped<IRepository<ChildCategory>, ChildCategoryRepository>();
            services.AddScoped<IRepository<SubCategory>, SubCategoryRepository>();
            services.AddScoped<IRepository<Basket>, BasketRepository>();
            services.AddScoped<IRepository<OrderDetail>, OrderDetailRepository>();
            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<ProductColor>, ProductColorRepository>();
            services.AddScoped<IRepository<ProductHeight>, ProductHeightRepository>();
            services.AddScoped<IRepository<ProductSize>, ProductSizeRepository>();
            services.AddScoped<IRepository<ProductTheme>, ProductThemeRepository>();
            services.AddScoped<IRepository<ProductTrotter>, ProductTrotterRepository>();
            services.AddScoped<IRepository<ProductImage>, ProductImageRepository>();
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IRepository<ProductProperty>, ProductPropertyRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ModelContext context, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //jwt configure
            var appSettingsSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var options = new JwtBearerOptions
            {
                TokenValidationParameters =
                {
                    ValidIssuer = "http://localhost",
                    ValidAudience = "object-project",
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }

            };

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            context.Database.EnsureCreated();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mavi API V1");
            });
        }
    }
}
