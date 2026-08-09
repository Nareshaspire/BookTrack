using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookTrack.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Prefer a cross-platform SQLite connection when provided; otherwise fall back to SQL Server.
builder.Services.AddDbContext<BookTrackContext>(options =>
{
    var sqliteConn = builder.Configuration.GetConnectionString("SqliteConnection");
    if (!string.IsNullOrEmpty(sqliteConn))
    {
        options.UseSqlite(sqliteConn);
    }
    else
    {
        var sqlServerConn = builder.Configuration.GetConnectionString("BookTrackContext") ?? throw new InvalidOperationException("Connection string 'BookTrackContext' not found.");
        options.UseSqlServer(sqlServerConn);
    }
});

var app = builder.Build();

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
