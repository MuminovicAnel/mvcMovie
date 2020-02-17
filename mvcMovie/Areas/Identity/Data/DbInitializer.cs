using mvcMovie.Models;
using SimpleHashing.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcMovie.Areas.Identity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(mvcMovieContext context)
        {
            ISimpleHash simpleHash = new SimpleHash();

            context.Database.EnsureCreated();

            // Look for any films.
            if (context.Films.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category{ Name="Drame"},
                new Category{ Name="Comédie"},
                new Category{ Name="Thriller"},
                new Category{ Name="Action"},
                new Category{ Name="Fantastique"},
                new Category{ Name="Horreur"},
                new Category{ Name="Fiction"}
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var films = new Film[]
            {
                new Film{ Name="Indiana Jones and the Last Crusade", Year=DateTime.Parse("1989-05-24"), Image="https://m.media-amazon.com/images/M/MV5BMjNkMzc2N2QtNjVlNS00ZTk5LTg0MTgtODY2MDAwNTMwZjBjXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_SX300.jpg", Description="In 1938, after his father Professor Henry Jones, Sr.goes missing while pursuing the Holy Grail, Professor Henry \"Indiana\" Jones, Jr. finds himself up against Adolf Hitler's Nazis again to stop them from obtaining its powers.", category_id=4 },
                new Film{ Name="Ghostbusters", Year=DateTime.Parse("1984-03-13"), Image="https://m.media-amazon.com/images/M/MV5BMTkxMjYyNzgwMl5BMl5BanBnXkFtZTgwMTE3MjYyMTE@._V1_SX300.jpg", Description="Three former parapsychology professors set up shop as a unique ghost removal service.", category_id=2},
                new Film{ Name="Star Wars: Episode IV - A New Hope", Year=DateTime.Parse("1977-05-25"), Image="https://m.media-amazon.com/images/M/MV5BNzVlY2MwMjktM2E4OS00Y2Y3LWE3ZjctYzhkZGM3YzA1ZWM2XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", Description="Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.", category_id=4},
                new Film{ Name="Rio Bravo", Year=DateTime.Parse("1959-04-15"), Image="https://m.media-amazon.com/images/M/MV5BZDVhMTk1NjUtYjc0OS00OTE1LTk1NTYtYWMzMDI5OTlmYzU2XkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_SX300.jpg", Description="A small-town sheriff in the American West enlists the help of a cripple, a drunk, and a young gunfighter in his efforts to hold in jail the brother of the local bad guy.", category_id=3}
            };
            foreach (Film f in films)
            {
                context.Films.Add(f);
            }
            context.SaveChanges();

            var statuses = new Status[]
            {
                new Status{Name="A voir"},
                new Status{Name="Vu"},
                new Status{Name="Pas intéressé"},
                new Status{Name="Favoris / coup de coeur"}
            };
            foreach (Status s in statuses)
            {
                context.Statuses.Add(s);
            }
            context.SaveChanges();

            var users = new User[]
            {
                new User{ Firstname="Pierre", Lastname="André", Pseudo="Pierre03", Email="pierre.andre@gmail.com", Password=simpleHash.Compute("secret")},
                new User{ Firstname="Jean", Lastname="Marc", Pseudo="jeanJean", Email="jean.marc@gmail.com", Password=simpleHash.Compute("pass")}
            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            var filmUsers = new FilmUser[]
            {
                new FilmUser{ User_id=1, Film_id=1, Status_id=2, Rating=7},
                new FilmUser{ User_id=1, Film_id=4, Status_id=3, Rating=5}
            };
            foreach (FilmUser fu in filmUsers)
            {
                context.FilmUser.Add(fu);
            }
            context.SaveChanges();
        }
    }
}
