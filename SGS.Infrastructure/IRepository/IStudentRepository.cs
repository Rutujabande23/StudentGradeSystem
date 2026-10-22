
using SGS.Domain.Entities;

namespace SGS.Application.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAll();

        void Add(Student student);

        decimal GetAverageGrade();

        Student? GetHighestGradeStudent();
    }
}
