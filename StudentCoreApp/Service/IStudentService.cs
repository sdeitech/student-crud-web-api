using DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IStudentService
    {
        StudentDTO GetStudentDetail(int studentId);
        List<StudentDTO> GetAllStudents();
        bool AddStudent(StudentDTO student);
        bool UpdateStudent(StudentDTO student);
        bool DeleteStudent(StudentDTO student);                           
    }
}
