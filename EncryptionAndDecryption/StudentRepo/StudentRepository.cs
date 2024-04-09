using EncryptionAndDecryption.Context;
using EncryptionAndDecryption.Model;
using EncryptionAndDecryption.Service;

namespace EncryptionAndDecryption.StudentRepo
{
    public class StudentRepository : IStudent
    {
        private readonly StudentContext? _studentContext;
  

        public StudentRepository(StudentContext? studentContext)
        {
            _studentContext = studentContext;
           
        }
        public List<Student> GetAllStudentData()
        {
           
                var data = _studentContext.StudentData.ToList();
                foreach(var item in data)
                {
                    var emailDec = StudentService.StudentDataDecryption(item.Email);
                    item.Email = emailDec;
                }
                return data;
            
            
        }

        public string InsertStudentData(Student student)
        {
            try
            {
                var data = StudentService.StudentDataEncrytion(student.Email);
                student.Email = data;


                _studentContext?.StudentData.Add(student);
                _studentContext?.SaveChanges();

                return "Insert Successfull";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        

        }
    }
}
