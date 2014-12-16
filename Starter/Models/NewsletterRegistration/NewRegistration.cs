using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Starter.Code;

namespace Starter.Models.NewsletterRegistration
{
	public class NewRegistration
	{
		[Required(ErrorMessage = "First Name Must Be Provided")]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public string EmailAddress { get; set; }
		public bool ReceiveDailyEmail { get; set; }
	}
}