﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CBHS.Webapi.Tests
{
    using Moq;
    using CBHS.Webapi.Controllers;
    using CBHS.Business.Interfaces;
    using System.Collections.Generic;
    using System;
    using System.Linq.Expressions;

    [TestClass]
    public class MemberApiTest
    {
        [TestMethod]
        public void Test_Check_Member_Is_Added()
        {
            //Arrange
            var mockService = new Mock<IMemberService>();

            mockService.Setup(service => service.Add(It.Is<Entity.Member>((i) => 
                i.FirstName.Equals("TestFirstName") && 
                i.LastName.Equals("TestLastName") &&
                i.DateOfBirth.Equals("10/10/1990") && 
                i.Email.Equals("test@test.com")
            ))).Returns(true);
                        
            var membersController = new MembersController(mockService.Object);

            //Act
            var IsAdded = membersController.Add(new Models.MemberModel()
            {
                MemberId = 0,
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

            var listOfEntityMembersExpected = new List<Entity.Member>
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
            mockService.Setup(service => service.List()).Returns(listOfEntityMembersExpected);

            var listOfMemberModelsExpected = new List<Models.MemberModel>
                                                {
                                                    new Models.MemberModel()
                                                    {
                                                        FirstName = "TestFirstName1",
                                                        LastName = "TestLastName1",
                                                        DateOfBirth = "10/10/1991",
                                                        Email = "test1@test.com"
                                                    },
                                                    new Models.MemberModel()
                                                    {
                                                        FirstName = "TestFirstName2",
                                                        LastName = "TestLastName2",
                                                        DateOfBirth = "10/10/1992",
                                                        Email = "test2@test.com"
                                                    },
                                                    new Models.MemberModel()
                                                    {
                                                        FirstName = "TestFirstName3",
                                                        LastName = "TestLastName3",
                                                        DateOfBirth = "10/10/1993",
                                                        Email = "test3@test.com"
                                                    }
                                                };


            var membersController = new MembersController(mockService.Object);

            //Act
            var listOfMembersActual = membersController.List();

            //Assert
            Assert.AreEqual(listOfMemberModelsExpected.Count, listOfMembersActual.Count);
            Assert.AreEqual(listOfMemberModelsExpected[0].FirstName, listOfMembersActual[0].FirstName);
            Assert.AreEqual(listOfMemberModelsExpected[1].LastName, listOfMembersActual[1].LastName);
            Assert.AreEqual(listOfMemberModelsExpected[2].DateOfBirth, listOfMembersActual[2].DateOfBirth);
        }

        [TestMethod]
        public void Test_Check_If_Oldest_Member_Is_Returned()
        {
            //Arrange
            var mockService = new Mock<IMemberService>();

            var listOfEntityMembersExpected = new List<Entity.Member>
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
            mockService.Setup(service => service.GetOldestMember()).Returns(listOfEntityMembersExpected[0]);            var membersController = new MembersController(mockService.Object);

            //Act
            var oldestMemberActual = membersController.Oldest();

            //Assert
            Assert.AreEqual(listOfEntityMembersExpected[0].FirstName, oldestMemberActual.FirstName);
            Assert.AreEqual(listOfEntityMembersExpected[0].LastName, oldestMemberActual.LastName);
            Assert.AreEqual(listOfEntityMembersExpected[0].Email, oldestMemberActual.Email);
            Assert.AreEqual(listOfEntityMembersExpected[0].DateOfBirth, oldestMemberActual.DateOfBirth);
        }
    }
}