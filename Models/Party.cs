using System.ComponentModel.DataAnnotations;

namespace OnlineVotingSystem.Models
{
        public class Party
        {
            [Key]
            [Required(ErrorMessage = "Enter Voter ID !")]
            [Display(Name = "Voter ID")]
            public int Id { get; set; }


            [Required(ErrorMessage = "Enter Voter Name !")]
            [Display(Name = "Voter Name")]
            public string VoterName { get; set; }


            [Required(ErrorMessage = "Enter Mobile Number !")]
            [Display(Name = "Mobile Number")]
            [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number should be 10 digits.")]
            public string MobileNumber { get; set; } 



            [Required(ErrorMessage = "Enter Address !")]
            [Display(Name = "Address")]
            public string Address { get; set; } 


            [Required(ErrorMessage = "Enter City !")]
            [Display(Name = "City")]
            public string City { get; set; } 


            [Required(ErrorMessage = "Enter State !")]
            [Display(Name = "State")]
            public string State { get; set; }


            [Required(ErrorMessage = "Enter DateOfBirth !")]
            [Display(Name = "Date of Birth")]
            [DataType(DataType.Date)]
            public DateTime DateOfBirth { get; set; }



            [Required(ErrorMessage = "Enter Age !")]
            [Display(Name = "Age")]
            [Range(18, 120, ErrorMessage = "Age must be between 18 and 120.")]
            public int Age { get; set; }


            [Required(ErrorMessage = " Select the Political Party !")]
            [Display(Name = "Political Party")]
            public string SelectParty { get; set; } = string.Empty;

        }
}
