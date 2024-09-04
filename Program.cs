namespace WebApp.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            //localhost:7080/Home/Index
            //localhost:7080/Student/1

            ////https://localhost:44359/StudentDetails/10
            //app.MapControllerRoute(
            //    name: "StudentIndex",
            //    pattern: "StudentDetails/{ID:int:min(10):max(15)}", //int int > 10, decimal, bool regix{()} //10020KUN1200 
            //    defaults: new { controller = "Student", action = "Details" }
            //);

            //Routing constraints


            app.Run();
        }
    }
}