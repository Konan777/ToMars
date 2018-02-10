using System;
using System.ComponentModel.DataAnnotations;

namespace ToMars.Model.Models
{
    public class AnketaModel 
    {
        public int ID { get; set; }
        public int FileId { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "ФИО")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 5 до 150 символов")]
        [DataType(DataType.Text)]
        public string FIO { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "EMail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Неверный EMail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Телефон")]
        [DataType(DataType.Text)]
        public string Phone { get; set; }
    }
}

