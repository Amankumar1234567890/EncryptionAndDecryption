using System.ComponentModel.DataAnnotations;

namespace EncryptionAndDecryption.Model
{
    public class Student
    {

        [Key]
        public int StudentId { get; set; }
        public string? Name { get; set; }
     
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
