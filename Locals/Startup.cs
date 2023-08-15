using Locals.Context;
using Locals.Models;
using Locals.Repositories;
using Locals.Repositories.Interfaces;
using Locals.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Locals;

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
        services.AddControllersWithViews();
        //Adicionando o context como serviço para poder utilizar o EF Core
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        
        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredUniqueChars = 1;
        });




        services.AddTransient<IReservaRepository, ReservaRepository>();
        //toda vez que solicitar uma instancia referenciando essas interfaces, o container DI vai
        //criar uma instancia da classe e injetar no construtor que estiver solciitando
        services.AddTransient<I_ImovelRepository,ImovelRepository>();
        services.AddTransient<ICategoriaRepository,CategoriaRepository>();
        services.AddScoped<ISeedUserRoleInitial,SeedUserRoleInitial>();

        //adicionado uma nova politica para acessar o admin
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", politica =>
            {
                politica.RequireRole("Admin");
            });
        });

        //Cria instancia a cada request
        services.AddScoped(p => CarrinhoReserva.GetCarrinho(p));
        //definindo tempo de vida do session e criar instancia do http context para receber informações de request e response e requisições
        services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
        services.AddMemoryCache();
        services.AddSession();


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedUserRoleInitial seedUserRoleInitial)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        //criando perfis
        seedUserRoleInitial.SeedRoles();
        //criando usuarios e atribuindo perfis
        seedUserRoleInitial.SeedUsers();
        //configurando session
        app.UseSession();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
          );

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");



            endpoints.MapControllerRoute(
                name: "CategoriaFiltro",
                pattern: "Imoveis/{action}/{categoria?}",
                defaults: new { Controller = "Imoveis", Action = "List" });


        });
    }
}
