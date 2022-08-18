using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookTrack.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<BookTrackContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookTrackContext") ?? throw new InvalidOperationException("Connection string 'BookTrackContext' not found.")));

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
