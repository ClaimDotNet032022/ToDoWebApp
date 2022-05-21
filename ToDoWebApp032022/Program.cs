using Microsoft.EntityFrameworkCore;
using ToDoWebApp032022.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
string connectionString = builder.Configuration.GetConnectionString("ToDoDatabase");
builder.Services.AddDbContext<ToDoDbContext>(optionsBuilder => optionsBuilder.UseNpgsql(connectionString));

var app = builder.Build();

// Avoid DateTime errors with npgsql without having to set a Kind
// on every single DateTime we use.
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
