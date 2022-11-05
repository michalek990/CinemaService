using CinemaService.Entities;
using FluentValidation.AspNetCore;
using System.Reflection;
using CinemaService.Service;
using CinemaService.Middleware;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder();




// Add services to the container.
builder.Services.AddRazorPages();

    builder.Services.AddControllers().AddFluentValidation();
    builder.Services.AddDbContext<CinemaDbContext>();
    builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
    builder.Services.AddScoped<ICinemaService,CinemaService.Service.CinemaService>();
    builder.Services.AddScoped<ErrorHandlingMiddleware>();
    builder.Services.AddSwaggerGen();
    //mozliwosc ³¹czenia sie z frontendem
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("FrontendEndClient", policybuilder =>
            policybuilder
                .AllowAnyMethod()
                .WithOrigins(builder.Configuration["AllowedOrigins"])
        );
    });
    
    
    var app = builder.Build();
    var scope = app.Services.CreateScope();



        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        //sprawdzanie wyjatkow

        //uruchomienie autentykacji
        app.UseAuthentication();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Resteruant API");
        });
        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
