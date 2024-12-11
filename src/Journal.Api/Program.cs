using Journal.Domain.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Journal.Domain.DataAccess;
using Journal.Domain.ServiceContracts;
using Journal.Core.Profiles;
using Journal.Core.Services;
using Journal.Api;
using Journal.Infrastructure.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var myPolicyName = "MyPolicyName"; // you will specify the exact same string in different places, so assigning policy names to variables avoids potential typo mistakes.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myPolicyName,
      configurePolicy: policy =>
      {
          policy.AllowAnyOrigin()
          .AllowAnyMethod().AllowAnyHeader();
      });
});
var dataConnectionString = builder.Configuration["ConnectionStrings:JournalConnection"];

builder.Services.AddScoped<IDataContext, DataContext>();
builder.Services.AddAutoMapper(typeof(ToDoItemProfile));
builder.Services.AddScoped<IToDoItemService, ToDoItemService>();

builder.Services.AddDbContext<JournalContext>(options =>
    options.UseSqlServer(dataConnectionString,
            providerOptions => providerOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)));

builder.Services.AddAuthentication();

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<JournalContext>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(myPolicyName);

app.MapIdentityApi<IdentityUser>();

app.MapPost("/logout", async (SignInManager<IdentityUser> signInManager) =>
{
    await signInManager.SignOutAsync().ConfigureAwait(false);
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseMiddleware<ExceptionMiddleware>();



app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
