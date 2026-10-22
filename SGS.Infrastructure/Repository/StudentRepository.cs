
using Microsoft.EntityFrameworkCore;
using SGS.Application.Interfaces;
using SGS.Domain.Entities;
using SGS.Infrastructure.Data;
using DbStudent = SGS.Infrastructure.Models.Student;

namespace SGS.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentGradeDbContext _context;

        public StudentRepository(StudentGradeDbContext context)
        {
            _context = context;
        }

        // Get all students
        public List<SGS.Domain.Entities.Student> GetAll()
        {
            return _context.Students
                .AsNoTracking()
                .Select(s => new SGS.Domain.Entities.Student
                {
                    StudentId = s.StudentId,
                    Name = s.Name,
                    Grade = s.Grade,
                    Subject = s.Subject
                })
                .ToList();
        }

        // Add a new student
        public void Add(SGS.Domain.Entities.Student student)
        {
            var dbStudent = new DbStudent
            {
                Name = student.Name,
                Grade = student.Grade,
                Subject = student.Subject
            };

            _context.Students.Add(dbStudent);
            _context.SaveChanges();
        }

        // Calculate average grade
        public decimal GetAverageGrade()
        {
            if (!_context.Students.Any())
            {
                return 0;
            }

            return _context.Students.Average(s => s.Grade);
        }

        // Get student with highest grade
        public SGS.Domain.Entities.Student? GetHighestGradeStudent()
        {
            var student = _context.Students
                .AsNoTracking()
                .OrderByDescending(s => s.Grade)
                .FirstOrDefault();

            if (student == null)
            {
                return null;
            }

            return new SGS.Domain.Entities.Student
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Grade = student.Grade,
                Subject = student.Subject
            };
        }
    }
}
