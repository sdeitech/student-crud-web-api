using DTO;
using NUnit.Framework;
using Repository;
using Service;

namespace StudentCoreApp.NUnitTest
{
    [TestFixture(Category= "studentService")]
    public class StudentCoreAppServiceTest
    {

        private IStudentService _studentService;
        
        [SetUp]
        public void SetUp()
        {

        }
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        public StudentCoreAppServiceTest(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [Test]
        public void AddStudent_InvalidObjectPassed_ReturnsFalse()
        {
            // Arrange
            var nameMissingStudentDTO = new StudentDTO()
            {
                StudentAddress = "Chandigarh",
                StudentAge = 26
            };
            //Act
            bool IsStudentAdded = _studentService.AddStudent(nameMissingStudentDTO);

            // Assert
            Assert.IsTrue(IsStudentAdded);
        }

        [Test]
        public void Add_ValidObjectPassed_ReturnsTrue()
        {
            var validStudentDTO = new StudentDTO()
            {
                StudentName = "John",
                StudentAddress = "Chandigarh",
                StudentAge = 26
            };
            bool IsStudentAdded = _studentService.AddStudent(validStudentDTO);

            Assert.IsTrue(IsStudentAdded);
        }
        [Test]
        public void GetStudentDetail_UnknownIdPassed_ReturnsNull()
        {
            var notFoundResult = _studentService.GetStudentDetail(0);

            Assert.IsNull(notFoundResult);
        }

        [Test]
        public void GetStudentDetail_KnownIdPassed_ReturnsNotNull()
        {
            var notFoundResult = _studentService.GetStudentDetail(1);

            Assert.IsNotNull(notFoundResult);
        }
        [Test]
        public void UpdateStudent_InvalidStudentObjectPassed_ReturnsFalse()
        {
            var missingStudentIdDTO = new StudentDTO()
            {
                StudentName = "John",
                StudentAddress = "Chandigarh",
                StudentAge = 26
            };

            bool IsStudentUpdated = _studentService.UpdateStudent(missingStudentIdDTO);

            Assert.IsTrue(IsStudentUpdated);
        }

        [Test]
        public void UpdateStudent_ValidStudentObjectPassed_ReturnsTrue()
        {
            var validStudentDTO = new StudentDTO()
            {
                StudentId = 1,
                StudentName = "John",
                StudentAddress = "New Chandigarh",
                StudentAge = 26
            };
            bool IsStudentupdated = _studentService.UpdateStudent(validStudentDTO);

            Assert.IsTrue(IsStudentupdated);
        }
        [Test]
        public void DeleteStudent_InvalidStudentObjectPassed_ReturnsFalse()
        {
            var missingStudentIdDTO = new StudentDTO()
            {
                StudentName = "john",
                StudentAddress = "Chandigarh",
                StudentAge = 26
            };
            bool IsStudentDeleted = _studentService.DeleteStudent(missingStudentIdDTO);

            Assert.IsTrue(IsStudentDeleted);
        }

        [Test]
        public void DeleteStudent_ValidStudentObjectPassed_ReturnsTrue()
        {
            var validStudentDTO = new StudentDTO()
            {
                StudentId = 1,
                StudentName = "John",
                StudentAddress = "Chandigarh",
                StudentAge = 26
            };
            bool IsStudentDeleted = _studentService.DeleteStudent(validStudentDTO);

            Assert.IsTrue(IsStudentDeleted);
        }

    }
}