using IntegrationTestingDemo;
using IntegrationTestingDemo.App.Query;
using IntegrationTestingDemo.Core.Contracts.Repository;
using IntegrationTestingDemo.Infra;
using IntegrationTestingDemo.Infra.Respository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var startup = new Startup();
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, builder.Environment);
