using System.ComponentModel.DataAnnotations;

namespace Starter.Models.NewsletterRegistration
{
    public class NewRegistration
    {
        [Required(ErrorMessage = "First Name Must Be Provided")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public bool? ReceiveDailyEmail { get; set; }
    }
}