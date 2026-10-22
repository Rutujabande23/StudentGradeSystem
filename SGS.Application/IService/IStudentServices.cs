
using SGS.Domain.Entities;

namespace SGS.Application.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();

        void AddStudent(Student student);

        decimal GetAverageGrade();

        Student? GetHighestGradeStudent();
    }
}
