using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GamesLibMVC.Models
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Display(Name = "Жанр")]
        public string GenreName { get; set; }

        public virtual ICollection<GameInfo> GamesInfo { get; set; }
    }
}
