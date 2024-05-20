using projectf22.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<DB>();
builder.Services.AddScoped<User>();
builder.Services.AddScoped<Tickets>();
builder.Services.AddScoped<Event>();
builder.Services.AddScoped<Booking>();
builder.Services.AddScoped<Payment>();
builder.Services.AddDistributedMemoryCache(); // This is necessary for session state management.

// Configure session settings
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set a long enough timeout for the session.
    options.Cookie.HttpOnly = true; // Enhance security by limiting access to the cookie from client-side scripts.
    options.Cookie.IsEssential = true; // Marks the session cookie as essential for the application to function.
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// IMPORTANT: UseSession must be called after UseRouting and before UseEndpoints (or UseRazorPages in this case).
app.UseSession();

app.MapRazorPages();

app.Run();
