using DTO;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class StudentService:IStudentService
    {
        private  IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public bool AddStudent(StudentDTO student)
        {
            return _studentRepository.AddStudent(student);
        }

        public bool DeleteStudent(StudentDTO student)
        {
            return _studentRepository.DeleteStudent(student);
        }

        public List<StudentDTO> GetAllStudents()
        {
            return _studentRepository.GetAllStudents().ToList();
        }

        public StudentDTO GetStudentDetail(int studentId)
        {
           return _studentRepository.GetStudentDetail(studentId);
        }

        public bool UpdateStudent(StudentDTO student)
        {
            return _studentRepository.UpdateStudent(student);
        }
    }
}
