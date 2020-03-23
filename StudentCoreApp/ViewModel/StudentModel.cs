using StudentCoreApp.ViewModel.Common;
using System.Collections.Generic;

namespace ViewModel
{
    public class StudentModel
    {
        public StudentModel()
        {
        }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public string StudentAddress { get; set; }
        public AuthModel AuthToken { get; set; }
        public List<StudentModel> studentList { get; set; }
    }
}
