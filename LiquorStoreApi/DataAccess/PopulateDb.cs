using DomainModels;
using DomainModels.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public static class PopulateDb
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new List<User>
                {
                    new User
                    {   Id = 1,
                        FirstName = "Boris",
                        LastName = "Krstovski",
                        Email = "boriskrstovski@gmail.com",
                        Password = "boris123",
                        ConfirmedPassword = "boris123"
                    }
                });
            modelBuilder.Entity<Beverage>()
                .HasData(new List<Beverage>
                {
                    new Beverage
                    {
                        Id = 1,
                        Name = "Skopsko",
                        Type = BeverageTypeEnum.Beer,
                        Price = 70,
                        Quantity = 50

                    }
                });

        }
    }
}
