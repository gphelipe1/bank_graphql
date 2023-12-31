using Bank;
using Bank.Context;
using Bank.Model;
using Bank.Repositories;
using Bank.Services;
using Bank.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
builder.Services.AddDbContext<ApiContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
                                        ServiceLifetime.Scoped);
builder.Services.AddScoped<ApiContext, ApiContext>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<AccountQuery>();

builder.Services.AddErrorFilter<GraphQLErrorFilter>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<AccountQuery>()
    .AddMutationType<AccountMutation>()
    .AddType<Account>();

var app = builder.Build();

app.MapGraphQL(path: "/");

app.Run();
