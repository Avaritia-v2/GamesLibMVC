using System;
using System.Linq;
using GamesLibMVC.Models;

namespace GamesLibMVC.Data
{
    public class DbInitializer
    {

        public static void Initialize(GamesContext context)
        {
            context.Database.EnsureCreated();

            if (context.Games.Any())
            {
                return;
            }

            var genres = new Genre[]
            {
            new Genre{GenreName="Action"},
            new Genre{GenreName="FPS"},
            new Genre{GenreName="Stealth"},
            new Genre{GenreName="RPG"},
            new Genre{GenreName="Hack and Slash"},
            };
            foreach (Genre g in genres)
            {
                context.Genres.Add(g);
            }
            context.SaveChanges();

            var games = new Game[]
            {
            new Game{GameName="Doom Eternal", Developer = "id Software"},
            new Game{GameName="Bioshock", Developer = "2K"},
            new Game{GameName="Nier:Automata", Developer = "Platinum Games"},
            new Game{GameName="Dishonored", Developer = "Arkane Studios"},
            new Game{GameName="Disco Elysium", Developer = "ZA/UM"}
            };
            foreach (Game g in games)
            {
                context.Games.Add(g);
            }
            context.SaveChanges();

            var gamesinfo = new GameInfo[]
            {
            new GameInfo{GameID = 1, GenreID = 1},
            new GameInfo{GameID = 1, GenreID = 2},
            new GameInfo{GameID = 2, GenreID = 1},
            new GameInfo{GameID = 2, GenreID = 2},
            new GameInfo{GameID = 3, GenreID = 1},
            new GameInfo{GameID = 3, GenreID = 4},
            new GameInfo{GameID = 3, GenreID = 5},
            new GameInfo{GameID = 4, GenreID = 1},
            new GameInfo{GameID = 4, GenreID = 3},
            new GameInfo{GameID = 5, GenreID = 4},
            };
            foreach (GameInfo g in gamesinfo)
            {
                context.GamesInfo.Add(g);
            }
            context.SaveChanges();
        }
    }
}
