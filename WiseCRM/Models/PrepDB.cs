using Microsoft.EntityFrameworkCore;

namespace WiseCRM.Models
{
    public class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ColorContext>());
            }
        }

        public static void SeedData(ColorContext colorContext)
        {
            System.Console.WriteLine("Appling Migrations...");

            colorContext.Database.Migrate();

            if(!colorContext.Colors.Any())
            {
                System.Console.WriteLine("Adding data");
                colorContext.Colors.AddRange(
                    new Color { Name = "Blue"}
                    );

                colorContext.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already Have Data");
            }
        }
    }
}
