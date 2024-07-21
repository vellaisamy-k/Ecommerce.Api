using Ecommerce.Api;
using Ecommerce.Api.AppDbContext;
using Ecommerce.Api.Helper;
using Ecommerce.Api.Repositories;
using Ecommerce.Api.Repositories.GenericRepository;
using Ecommerce.Api.Repositories.IRepositories;
using Ecommerce.Api.Services;
using Ecommerce.Api.Services.ISevices;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);


// startup.cs file
var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app,builder.Environment);




