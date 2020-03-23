using AutoMapper;
using DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly StudentContext _studentContext;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentRepository> _exceptionLogger;
        public StudentRepository(StudentContext studentContext,IMapper mapper, ILogger<StudentRepository> exceptionLogger)
        {
            _studentContext = studentContext;
            _mapper = mapper;
            _exceptionLogger = exceptionLogger;
        }

        public List<StudentDTO> GetAllStudents()
        {
            try
            {
                return _mapper.Map<List<StudentDTO>>(_studentContext.Students.ToList());
            }
            catch (Exception ex)
            {
                _exceptionLogger.LogError(ex.Message);
                return new List<StudentDTO>();
            }
            
        }

        public StudentDTO GetStudentDetail(int id)
        {
            try
            {
                return _mapper.Map<StudentDTO>(_studentContext.Students.AsNoTracking()
                  .FirstOrDefault(e => e.StudentId == id));
            }
            catch (Exception ex)
            {
                _exceptionLogger.LogError(ex.Message);
                return new StudentDTO();
            }
            
        }

        public bool AddStudent(StudentDTO student)
        {
            try
            {
                _studentContext.Students.Add(_mapper.Map<Student>(student));
                _studentContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _exceptionLogger.LogError(ex.Message);
                return false;
            }
            
        }

        public bool UpdateStudent(StudentDTO student)
        {
            try
            {
                var entity = _mapper.Map<Student>(student);
                _studentContext.Set<Student>().Attach(entity);
                _studentContext.Entry(entity).State = EntityState.Modified;
                _studentContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _exceptionLogger.LogError(ex.Message);
                return false;
            }           
        }

        public bool DeleteStudent(StudentDTO student)
        {
            try
            {
                _studentContext.Students.Remove(_mapper.Map<Student>(student));
                _studentContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _exceptionLogger.LogError(ex.Message);
                return false;
            }
            
        }
    }
}
