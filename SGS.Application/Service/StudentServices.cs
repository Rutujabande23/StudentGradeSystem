
using SGS.Application.Interfaces;
using SGS.Domain.Entities;

namespace SGS.Application.Services
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        // Get all students
        public List<Student> GetAllStudents()
        {
            return _repository.GetAll();
        }

        // Add a student with validation
        public void AddStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.Name))
            {
                throw new ArgumentException("Student name is required.");
            }

            if (student.Grade < 0 || student.Grade > 100)
            {
                throw new ArgumentException("Grade must be between 0 and 100.");
            }

            if (string.IsNullOrWhiteSpace(student.Subject))
            {
                throw new ArgumentException("Subject is required.");
            }

            _repository.Add(student);
        }

        // Calculate average grade
        public decimal GetAverageGrade()
        {
            return _repository.GetAverageGrade();
        }

        // Get student with highest grade
        public Student? GetHighestGradeStudent()
        {
            return _repository.GetHighestGradeStudent();
        }
    }
}
