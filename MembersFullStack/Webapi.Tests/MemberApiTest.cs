using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CBHS.Webapi.Tests
{
    using Moq;
    using CBHS.Webapi.Controllers;
    using CBHS.Business.Interfaces;
    using System.Web.Http;
    using System.Collections;
    using System.Collections.Generic;

    [TestClass]
    public class MemberApiTest
    {
        [TestMethod]
        public void Test_Check_Member_Is_Added()
        {
            //Arrange
            var mockService = new Mock<IMemberService>();

            mockService.Setup(service => service.Add(new Entity.Member()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                DateOfBirth = "10/10/1990",
                Email = "test@test.com"
            })).Returns(true);
                        
            var membersController = new MembersController(mockService.Object);

            //Act
            var IsAdded = membersController.Add(new Models.MemberModel()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                DateOfBirth = "10/10/1990",
                Email = "test@test.com"
            });

            //Assert
            Assert.IsTrue(IsAdded);
        }

        [TestMethod]
        public void Test_Check_Members_Are_Listed()
        {
            //Arrange
            var mockService = new Mock<IMemberService>();

            var listOfMembersExpected = new List<Entity.Member>
                                        {
                                            new Entity.Member()
                                            {
                                                FirstName = "TestFirstName1",
                                                LastName = "TestLastName1",
                                                DateOfBirth = "10/10/1991",
                                                Email = "test1@test.com"
                                            },
                                            new Entity.Member()
                                            {
                                                FirstName = "TestFirstName2",
                                                LastName = "TestLastName2",
                                                DateOfBirth = "10/10/1992",
                                                Email = "test2@test.com"
                                            },
                                            new Entity.Member()
                                            {
                                                FirstName = "TestFirstName3",
                                                LastName = "TestLastName3",
                                                DateOfBirth = "10/10/1993",
                                                Email = "test3@test.com"
                                            }
                                        };

            mockService.Setup(service => service.List()).Returns(listOfMembersExpected);

            var membersController = new MembersController(mockService.Object);

            //Act
            var listOfMembersActual = membersController.List();

            //Assert
            CollectionAssert.AreEqual(listOfMembersExpected, (List<Entity.Member>)listOfMembersActual);
        }
    }
}