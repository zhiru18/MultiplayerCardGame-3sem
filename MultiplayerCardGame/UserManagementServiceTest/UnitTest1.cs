using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace UserManagementServiceTest
{
    //<summary> in this project we use moq to mock the dependencies of our methods 
    //such that we can run the test 
    //regardless of wether or not we have access to the database</summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSuccessfullLogin() {
            //Arrange
            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
            User user = new User() {
                UserName = "Test",
                PassWord = "1234",
            };

            //Act
            mockUserRepository.Setup(obj => obj.GetByUserName("Test")).Returns(user);
            IUserManagementService userManagementService = new UserManagementService(mockUserRepository.Object);
            string data = userManagementService.Login("Test", "1234");

            //Assert
            Assert.AreNotEqual(data, "");

        }
        [TestMethod]
        public void TestUnssuccessfullLogin() {
            //Arrange
            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
            User user = new User() {
                UserName = "Test",
                PassWord = "1234",
            };

            //Act
            mockUserRepository.Setup(obj => obj.GetByUserName("Test")).Returns(user);
            IUserManagementService userManagementService = new UserManagementService(mockUserRepository.Object);
            string data = userManagementService.Login("Test1", "1235");

            //Assert
            Assert.AreEqual(data, "");
        }
        [TestMethod]
        public void TestIsValidUser() {
            //Arrange
            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
            User user = new User() {
                UserName = "Test",
                PassWord = "1234",
            };
            MessageHeader header;
            string userToken;
            bool isValid;
            //Act
            mockUserRepository.Setup(obj => obj.GetByUserName("Test")).Returns(user);
            IUserManagementService userManagementService = new UserManagementService(mockUserRepository);
            userToken = userManagementService.Login("Test", "1234");
            header = MessageHeader.CreateHeader("TokenHeader", "TokenNameSpace", userToken);
            OperationContext.Current.OutgoingMessageHeaders.Add(header);
            isValid = userManagementService.IsValidUser();

            //Assert
            Assert.IsTrue(isValid);
        }
        [TestMethod]
        public void TestIsInvalidUser() {
            //Arrange
            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
            User user = new User() {
                UserName = "Test",
                PassWord = "1234",
            };
            MessageHeader header;
            string userToken;
            bool isValid;
            //Act
            mockUserRepository.Setup(obj => obj.GetByUserName("Test")).Returns(user);
            IUserManagementService userManagementService = new UserManagementService(mockUserRepository);
            userToken = userManagementService.Login("Test1", "12345");
            header = MessageHeader.CreateHeader("TokenHeader", "TokenNameSpace", userToken);
            OperationContext.Current.OutgoingMessageHeaders.Add(header);
            isValid = userManagementService.IsValidUser();

            //Assert
            Assert.IsFalse(isValid);
        }

    }
}
