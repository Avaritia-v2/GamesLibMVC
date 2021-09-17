using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GamesLibMVC.Models
{
    public class GameInfo
    {
        [Key]
        public int GameInfoID { get; set; }
        public int GameID { get; set; }
        public int GenreID { get; set; }

        public Game Game { get; set; }
        public Genre Genre { get; set; }
    }
}
