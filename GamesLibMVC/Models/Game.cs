using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GamesLibMVC.Models
{
    public class Game
    {
        [Key]
        public int GameID { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Display(Name = "Название")]
        public string GameName { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Display(Name = "Студия разработчик")]
        public string Developer { get; set; }

        public virtual ICollection<GameInfo> GamesInfo { get; set; }
    }
}
