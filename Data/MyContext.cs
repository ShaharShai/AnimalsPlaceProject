using AnimalPlaceProject.Controllers;
using AnimalPlaceProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AnimalPlaceProject.Data
{
    public class MyContext : DbContext
    {


        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> AnimalCategories { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<LoginModel> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Mammals",
                    Animals = new List<Animal>() { }
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Birds",
                    Animals = new List<Animal>() { }
                },
                new Category
                {
                    CategoryId = 3,
                    Name = "Reptiles",
                    Animals = new List<Animal>() { }
                },
                new Category
                {
                    CategoryId = 4,
                    Name = "Fish",
                    Animals = new List<Animal>() { }
                },
                new Category
                {
                    CategoryId = 5,
                    Name = "Amphibians",
                    Animals = new List<Animal>() { }
                }
            );

            modelBuilder.Entity<Animal>().HasData(
                new Animal
                {
                    AnimalId = 1,
                    Name = "Lion",
                    Age = 5.5,
                    PictureName = "lion.jpg",
                    Description = "The lion is a large felid of the genus Panthera.",
                    CategoryId = 1
                },
                new Animal
                {
                    AnimalId = 2,
                    Name = "Eagle",
                    Age = 3.2,
                    PictureName = "eagle.jpg",
                    Description = "The eagle is a bird of prey found in many different habitats.",
                    CategoryId = 2

                },
                new Animal
                {
                    AnimalId = 3,
                    Name = "Turtle",
                    Age = 10.1,
                    PictureName = "turtle.jpg",
                    Description = "Turtles are reptiles characterized by their bony shells.",
                    CategoryId = 3
                },
                   new Animal
                   {
                       AnimalId = 4,
                       Name = "Giraffe",
                       Age = 7.8,
                       PictureName = "giraffe.jpg",
                       Description = "The giraffe is a tall African mammal with a long neck and legs.",
                       CategoryId = 1
                   },
                    new Animal
                     {
                   AnimalId = 5,
                   Name = "Parrot",
                   Age = 2.5,
                   PictureName = "parrot.jpg",
                   Description = "Parrots are colorful birds known for their ability to mimic human speech.",
                   CategoryId = 2
                   }
            );

            modelBuilder.Entity<Comment>().HasData(
              new Comment
              {
                  Id = 1,
                  Content = "This animal is amazing!",
                  numOfLikes = 3,
                  isLiked = false,
                  animalId = 1
              },
              new Comment
              {
                  Id = 2,
                  Content = "I love this animal!",
                  numOfLikes = 2,
                  isLiked = false,
                  animalId = 2
              },
              new Comment
              {
                  Id = 3,
                  Content = "What a crazy animal!",
                  numOfLikes = 0,
                  isLiked = false,
                  animalId = 3
              },
              new Comment
              {
                  Id = 4,
                  Content = "Dat Animalll!",
                  numOfLikes = 0,
                  isLiked = false,
                  animalId = 3

              },
                new Comment
                {
                    Id = 5,
                    Content = "The giraffe is my favorite animal!",
                    numOfLikes = 5,
                    isLiked = false,
                    animalId = 4
                },
                new Comment
                  {
               Id = 6,
               Content = "Parrots are so intelligent and beautiful!",
               numOfLikes = 4,
               isLiked = false,
                animalId = 5
               }
          );

            modelBuilder.Entity<BlogPost>().HasData(
    new BlogPost
    {
        Id = 1,
        Title = "First Blog Post",
        Content = "Lorem ipsum dolor sit amet.",
        CreateDate = DateTime.Now
    },
    new BlogPost
    {
        Id = 2,
        Title = "Second Blog Post",
        Content = "Consectetur adipiscing elit.",
        CreateDate = DateTime.Now.AddDays(-1)
    }
);

        }
    }
}
