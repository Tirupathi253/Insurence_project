using InsuranceApp.Data;
using InsuranceApp.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using System.Text;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace InsuranceApp
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InsuranceContext>(options =>
            options.UseInMemoryDatabase("InsuranceDB"));

            services.AddControllersWithViews();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "yourissuer",
                        ValidAudience = "youraudience",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"))
                    };
                });

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IPolicyRepository, PolicyRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IClaimRepository, ClaimRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IAgentRepository, AgentRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapDefaultControllerRoute();
            });
        }

    }
}
