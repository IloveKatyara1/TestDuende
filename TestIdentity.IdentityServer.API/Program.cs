var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication("cookie")
    .AddCookie("cookie", o =>
    {
        o.Cookie.Name = "demo";
        o.ExpireTimeSpan = TimeSpan.FromHours(8);

        o.LoginPath = "/account/Login";
        o.AccessDeniedPath = "/account/AccessDenied";
    });

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("ManageCustomers", plc =>
    {
        plc.RequireAuthenticatedUser();
        plc.RequireClaim("department", "sales");
        plc.RequireClaim("status", "senior");
    });
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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
