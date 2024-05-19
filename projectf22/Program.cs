using projectf22.Models;

var builder = WebApplication.CreateBuilder(args);
///a
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<DB>();
builder.Services.AddScoped<User>();
builder.Services.AddScoped<Tickets>();
builder.Services.AddScoped<Event>();
builder.Services.AddScoped<Booking>();
builder.Services.AddScoped<Payment>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

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
app.UseSession();

app.Run();
