using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserRegistrationProblem;
using System.ComponentModel.DataAnnotations;

namespace UserRegistrationTest
{
    [TestClass]
    public class UnitTest1
    {
        private RegexValidation user;

        [TestInitialize]
        public void InitClassObject()
        {
            //Arrange
            user = new RegexValidation();
        }
        [TestMethod]
        public void GivenUserFistName_WhenValidate_ShouldReturnTrue()
        {
            string firstName = "Suraj";
            //Act
            bool result = user.ValidateFirstName(firstName);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenUserLastName_WhenValidate_ShouldReturnTrue()
        {
            string lastName = "Sharma";
            //Act
            bool result = user.ValidateFirstName(lastName);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenEmailId_WhenValidate_ShouldReturnTrue()
        {
            string email = "surajsharma@gmail.com";
            //Act
            bool result = user.ValidateEmail(email);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenMobileNumber_WhenValidate_ShouldReturnTrue()
        {
            string mobileNumber = "91 8630539412";
            //Act
            bool result = user.ValidateMobile(mobileNumber);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void GivenPassword_WhenValidate_ShouldReturnTrue()
        {
            //Arrange

            string password = "Suraj$212";
            //Act
            bool result = user.ValidatePassword(password);
            //Assert
            Assert.IsTrue(result);
        }
        //Sad Test Cases(Test Cases Fail The Entry)
        [TestMethod]
        public void GivenUserFistName_WhenValidate_Should_throw_Custom_InvalidFirstNameException()
        {
            try
            {
                string firstName = "suraj";
                bool result = user.ValidateFirstName(firstName);
            }
            catch (InvalidUserDetailException e)
            {
                Assert.AreEqual("Invalid First Name", e.Message);
            }
        }
        [TestMethod]
        public void GivenUserLastName_WhenValidate_Should_throw_Custom_InvalidLastNameException()
        {
            try
            {
                string lastName = "sharma";
                bool result = user.ValidateLastName(lastName);
            }
            catch (InvalidUserDetailException e)
            {
                Assert.AreEqual("Invalid Last Name", e.Message);
            }
        }
        [TestMethod]
        public void GivenEmailId_WhenValidate_Should_throw_Custom_InvalidEmailException()
        {
            try
            {
                string email = "Sharma.suraj.com";
                bool result = user.ValidateEmail(email);
            }
            catch (InvalidUserDetailException e)
            {
                Assert.AreEqual("Invalid Email", e.Message);
            }
        }
        [TestMethod]
        public void GivenMobileNumber_WhenValidate_Should_throw_Custom_InvalidMobileException()
        {
            try
            {
                string mobileNumber = "91 0876543210";
                bool result = user.ValidateMobile(mobileNumber);
            }
            catch (InvalidUserDetailException e)
            {
                Assert.AreEqual("Invalid Mobile Number", e.Message);
            }
        }
        [TestMethod]
        public void GivenPassword_WhenValidate_Should_throw_Custom_InvalidPasswordException()
        {
            try
            {
                string password = "suraj@123*";
                bool result = user.ValidatePassword(password);
            }
            catch (InvalidUserDetailException e)
            {
                Assert.AreEqual("Invalid Password", e.Message);
            }
        }
        [TestMethod]
        [DataRow("abc@yahoo.com")]
        [DataRow("abc-100@yahoo.com")]
        [DataRow("abc.100@yahoo.com")]
        [DataRow("abc111@abc.com")]
        [DataRow("abc.100@abc.com.au")]
        [DataRow("abc-100@abc.net")]
        [DataRow("abc@1.com")]
        [DataRow("abc@gmail.com.com")]
        [DataRow("abc+100@gmail.com")]
        public void ValidateEmailId_Should_return_true(string email)
        {
            Assert.IsTrue(user.ValidateEmail(email));
        }
    }
}
