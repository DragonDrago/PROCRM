using System.ComponentModel.DataAnnotations;

namespace ProCrm.Ldi.Api.Requests
{
    public class LdiRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название статусa")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Введите название источникa")]
        public string Source { get; set; }

        [Required(ErrorMessage = "Введите имя человека которому закреплены")]
        public string AttachedTo { get; set; }

        [Required(ErrorMessage = "Введите ФИО")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Введите название работы")]
        public string JobTitle { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
        public string WebSite { get; set; }
        public string EmailAddress { get; set; }
        public string MailAddress { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Comments { get; set; }
    }
}
