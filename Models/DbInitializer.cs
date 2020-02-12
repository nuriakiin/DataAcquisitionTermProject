using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAcquisitionTermProject.Models
{
    public static class DbInitializer
    {
        public static void Initializer(IApplicationBuilder app )
        {
            List<Movie> mo =new List<Movie>();
            List<User> us = new List<User>();
            List<MovieRate> mr = new List<MovieRate>();
            DataContext context = app.ApplicationServices.GetRequiredService<DataContext>();
            context.Database.Migrate();
            context.Database.EnsureCreated();

            if (!context.Movies.Any())
            {


                string[] lines = File.ReadAllLines("Dataset/u.item");
                foreach (string line in lines)
                {
                    Movie m = new Movie();
                    string[] a = line.Split("|");
                    m.MovieId = long.Parse(a[0]);
                    m.MovieTitle = a[1];
                    m.IMDBUrl = a[4];
                    m.MovieRate = 0 ;
                    mo.Add(m);
                }
               IEnumerable<Movie> movies = mo.AsEnumerable();
            context.Movies.AddRange(movies);
            context.SaveChanges();
            }
            if(!context.Users.Any())
            {
                string[] lines = File.ReadAllLines("Dataset/u.user");
                foreach(string line in lines)
                {
                    User u = new User();
                    string[] a = line.Split("|");
                    u.Username = "user" + a[0];
                    u.UserPassword = "pass" + a[1];
                    us.Add(u);
                }
                IEnumerable<User> users = us.AsEnumerable();
                context.Users.AddRange(users);
                context.SaveChanges();

            }
            if (!context.MovieRates.Any())
            {
                string[] lines = File.ReadAllLines("Dataset/u.txt");
                foreach(string line in lines)
                {
                    MovieRate rate = new MovieRate();
                    string[] a = line.Split('\t');
                    rate.UserId = long.Parse(a[0]);
                    rate.MovieId = long.Parse(a[1]);
                    rate.Rate = int.Parse(a[2]);
                    mr.Add(rate);

                }
                IEnumerable<MovieRate> movieRates = mr.AsEnumerable();
                context.AddRange(movieRates);
                context.SaveChanges();

            }


        }

    }
}