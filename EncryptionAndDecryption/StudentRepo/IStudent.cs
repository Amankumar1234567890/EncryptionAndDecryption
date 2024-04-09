using EncryptionAndDecryption.Model;

namespace EncryptionAndDecryption.StudentRepo
{
    public interface IStudent
    {
        List<Student> GetAllStudentData();

        string InsertStudentData(Student student);
    } 
}
