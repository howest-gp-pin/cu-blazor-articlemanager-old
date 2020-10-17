using ArticleManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleManager.Infrastructure.Data.Seeding
{
    public class CategorySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Games",
                    Description = "Boardgames and computer games"
                },
                new Category
                {
                    Id = 2,
                    Name = "Books",
                    Description = "Enhance your programming skills"
                },
                new Category
                {
                    Id = 3,
                    Name = "Hardware",
                    Description = "Computer hardware"
                });
        }             
    }
}
