using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccessObjects
{
    public class PersonDAO
    {

        Crud.DataAccessHelper ah = new Crud.DataAccessHelper();
        public PersonDAO() { }

        public PersonDAO(int id, string firstName, string lastName, DateTime dateOfBirth, int age,  string gender)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Age = age;
            Gender = gender;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]        
        public DateTime DateOfBirth { get; set; }     
        [Required]
        public int Age { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Length must be between 2 and 100.", MinimumLength = 2)]
        public string Gender { get; set; }
        
    }
}
