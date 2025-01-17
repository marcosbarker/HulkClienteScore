﻿using ClienteScore.MAG.Dominio;
using ClienteScore.MAG.Repositorios;
using ClienteScore.MAG.Servicos;
using ClienteScoreMAG.Dominio.Interfaces;
using ClienteScoreMAG.Repositorios;
using ClienteScoreMAG.Servicos;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(ClienteScore.MAG.Startup))]
namespace ClienteScore.MAG
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            builder.Services.Configure<IConfiguration>(configuration);
            builder.Services.AddScoped<IClienteScoreRepositorio, ClienteScoreRepositorio>();
            builder.Services.AddScoped<IModeloRepositorio, ModeloRepositorio>();
            builder.Services.AddScoped<IEmailServico, EmailServico>();
            builder.Services.AddScoped(typeof(AnalizadorSentimento));
            builder.Services.AddScoped<IModeloService, ModeloServico>();

        }
    }
}