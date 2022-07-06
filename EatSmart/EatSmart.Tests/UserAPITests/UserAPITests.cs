using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using EatSmart.Controllers;
using EatSmart.Models;
using EatSmart.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace EatSmart.Tests.UserAPITests
{
 
    public class Tests
    {
        private UserController _controller;
        private Mock<IUserService> _mockUserService;

        [SetUp]
        public void Setup()
        {
            _mockUserService = new Mock<IUserService>();
            _controller = new UserController(_mockUserService.Object);
        }
        [Test]
        public void CreateUser_With_UserId_4_Creates_A_New_User()
        {
            //Arrange
            long userId = 4;
            User newUser= new() { UserId = userId, FirstName = "Adie" };

            _mockUserService.Setup(b => b.CreateUser(newUser)).Returns(newUser);

            //Act
            var result = _controller.CreateNewUser(newUser);

            //Assert

            result.Should().BeOfType(typeof(ActionResult<User>));

           
        }

        [Test]
        public void DeleteUser_With_UserId_4_Deletes_The_User()
        {
            //Arrange

            long userId = 4;

            _mockUserService.Setup(b => b.DeleteThisUser(userId)).Returns(true);

            //Act
            var result = _controller.DeleteUser(userId);

            //Assert
            result.Should().BeOfType(typeof(AcceptedResult));
        }   

        [Test]
        public void DeleteUser_With_UserId_99_Generates_UserId_Not_Found()
        {
            //Arrange

            long userId = 99;

            _mockUserService.Setup(b => b.DeleteThisUser(userId)).Returns(false);

            //Act
            var result = _controller.DeleteUser(userId);
            
            //Assert

            result.Should().BeOfType(typeof(NotFoundObjectResult));
            

        }

        [Test]
        public void UpdateUser_With_UserId_4_Updates_User()
        {
            //Arrange

            long userId = 4;
            User updatedUser = new() { UserId = userId, FirstName = "Vinu" };
            _mockUserService.Setup(b => b.UpdateThisUser(userId, updatedUser)).Returns(updatedUser);

            //Act
            var result = _controller.UpdateUser(userId, updatedUser);

            //Assert

            result.Should().BeOfType(typeof(ActionResult<User>));
   
        }

        [Test]
        public void UpdateUser_With_UserId_99_Generates_UserId_Not_Found()
        {
            //Arrange

            long userId = 99;
            User updatedUser = new() { UserId = userId, FirstName = "Vinu" };
            User? returnedUser = null;
            _mockUserService.Setup(b => b.UpdateThisUser(userId, updatedUser)).Returns(returnedUser);

            //Act
            var result = _controller.UpdateUser(userId, updatedUser);

            //Assert

            result.Result.Should().BeOfType(typeof(NotFoundObjectResult));      

        }

        [Test]
        public void FindUserByID_Returns_User_With_UserID_4()
        {
            //Arrange

            long userId = 4;
            User user = new() { UserId = userId, FirstName = "Apshan" };
            _mockUserService.Setup(b => b.GetUserById(userId)).Returns(user);

            //Act
            var result = _controller.FindUserById(userId);
            

            //Assert
            result.Should().BeOfType(typeof(ActionResult<User>));
   
        }

        [Test]
        public void FindUserByID_Returns_Not_Found_For_User_With_UserID_99()
        {
            //Arrange

            long userId = 99;
            User? user = null;
            _mockUserService.Setup(b => b.GetUserById(userId)).Returns(user);

            //Act
            var result = _controller.FindUserById(userId);

            //Assert

            result.Result.Should().BeOfType(typeof(NotFoundObjectResult));
           

        }

      
        
    }

}
