using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatSmart.Models;
using EatSmart.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;


namespace EatSmart.Tests.ServiceTests
{
    public class InputValidationTests
    {
        InputValidation inputValidation;

        [SetUp]

        public void Setup()
        {
            inputValidation = new InputValidation();
        }

        [Test]
        public void User_With_Complete_List_Of_Intolerances_In_Correct_Format_Should_Return_Null()
        {
            //Arrange
            User testUser = new();

            testUser.FirstName = "John";
            testUser.Surname = "Smith";
            testUser.MaxDailyCalories = 3000;
            testUser.Intolerances = "Dairy,Egg,Gluten,Grain,Peanut,Seafood,Sesame,Shellfish,Soy,Sulfite,Tree_Nut2,Wheat";



            //Act

            string validationResult = inputValidation.ValidateUser(testUser);

            //Assert

            validationResult.Should().BeNull();
        }
        [Test]
        public void User_With_Complete_List_Of_Intolerances_Plus_1_Not_Catered_For_Should_Return_Error()
        {
            //Arrange
            User testUser = new();

            testUser.FirstName = "John";
            testUser.Surname = "Smith";
            testUser.MaxDailyCalories = 3000;
            testUser.Intolerances = "Dairy,Egg,Gluten,Grain,Peanut,Seafood,Sesame,Shellfish,Soy,Sulfite,Tree_Nut2,Wheat,Iron";



            //Act

            string validationResult = inputValidation.ValidateUser(testUser);

            //Assert

            validationResult.Should().Be("Intolerance Iron is not known");
        }

        [Test]
        public void A_Space_Instead_Of_A_Comma_In_Intolerance_String_Should_Return_Format_Error()
        {
            //Arrange
            User testUser = new();

            testUser.FirstName = "John";
            testUser.Surname = "Smith";
            testUser.MaxDailyCalories = 3000;
            testUser.Intolerances = "Dairy,Egg Gluten,Grain,Peanut,Seafood,Sesame,Shellfish,Soy,Sulfite,Tree_Nut2,Wheat";



            //Act

            string validationResult = inputValidation.ValidateUser(testUser);

            //Assert

            validationResult.Should().Be("Invalid format for Intolerances");
        }

        [Test]
        public void An_Empty_Intolerance_String_Should_Return_Null()
        {
            //Arrange
            User testUser = new();

            testUser.FirstName = "John";
            testUser.Surname = "Smith";
            testUser.MaxDailyCalories = 3000;
            testUser.Intolerances = "";



            //Act

            string validationResult = inputValidation.ValidateUser(testUser);

            //Assert

            validationResult.Should().BeNull();
        }

        [Test]
        public void Exceeding_MAX_CALORIES_Generates_An_Error()
        {
            //Arrange
            User testUser = new();

            testUser.FirstName = "John";
            testUser.Surname = "Smith";
            testUser.MaxDailyCalories = 10001;
            testUser.Intolerances = "";



            //Act

            string validationResult = inputValidation.ValidateUser(testUser);

            //Assert

            validationResult.Should().Be($"That's too many calories for one day! (Max: 10000)");
        }

        [Test]
        public void Exceeding_MIN_CALORIES_Generates_An_Error()
        {
            //Arrange
            User testUser = new();

            testUser.FirstName = "John";
            testUser.Surname = "Smith";
            testUser.MaxDailyCalories = 999;
            testUser.Intolerances = "";



            //Act

            string validationResult = inputValidation.ValidateUser(testUser);

            //Assert

            validationResult.Should().Be($"That's too few calories for one day! (Min: 1000)");
        }

        [Test]
        public void A_Non_Alphabetical_FirstName_Generates_An_Error()
        {
            //Arrange
            User testUser = new();

            testUser.FirstName = "Jo4hn";
            testUser.Surname = "Smith";
            testUser.MaxDailyCalories = 999;
            testUser.Intolerances = "";



            //Act

            string validationResult = inputValidation.ValidateUser(testUser);

            //Assert

            validationResult.Should().Be("Invalid format for FirstName");
        }

        [Test]
        public void A_Non_Alphabetical_SurnameName_Generates_An_Error()
        {
            //Arrange
            User testUser = new();

            testUser.FirstName = "John";
            testUser.Surname = "Sm1th";
            testUser.MaxDailyCalories = 999;
            testUser.Intolerances = "";



            //Act

            string validationResult = inputValidation.ValidateUser(testUser);

            //Assert

            validationResult.Should().Be("Invalid format for Surname");
        }

    }
}


