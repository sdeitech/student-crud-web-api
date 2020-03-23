using DTO;
using Models;
using System.Collections.Generic;

namespace Repository
{
    public interface IStudentRepository
    {
        StudentDTO GetStudentDetail(int studentId);
        List<StudentDTO> GetAllStudents();
        bool AddStudent(StudentDTO student);
        bool UpdateStudent(StudentDTO student);
        bool DeleteStudent(StudentDTO student);
    }
}
