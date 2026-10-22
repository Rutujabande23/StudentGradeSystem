
namespace SGS.Domain.Entities
{
    public class Student
    {
        public int StudentId { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Grade { get; set; }

        public string Subject { get; set; } = string.Empty;
    }
}
