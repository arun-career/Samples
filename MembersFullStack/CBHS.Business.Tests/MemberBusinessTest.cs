using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CBHS.Datasource;
using System.Collections.Generic;

namespace CBHS.Business.Tests
{
    [TestClass]
    public class MemberBusinessTest
    {
        [TestMethod]
        public void Test_Check_Member_Is_Added()
        {
            //Arrange
            var mockRepository = new Mock<IDataRepository>();

            mockRepository.Setup(repository => repository.AddMember(It.Is<Entity.Member>((r) =>
                r.FirstName.Equals("TestFirstName") &&
                r.LastName.Equals("TestLastName") &&
                r.DateOfBirth.Equals("10/10/1990") &&
                r.Email.Equals("test@test.com")
            ))).Returns(true);

            var memberService = new MemberService(mockRepository.Object);

            //Act
            var IsAdded = memberService.Add(new Entity.Member()
            {
                MemberId = 0,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                DateOfBirth = "10/10/1990",
                Email = "test@test.com"
            });

            //Assert
            //mockRepository.VerifyAll();
            Assert.IsTrue(IsAdded);
        }

        [TestMethod]
        public void Test_Check_Members_Are_Listed()
        {
            //Arrange
            var mockRepository = new Mock<IDataRepository>();

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

            mockRepository.Setup(repository => repository.GetMembers()).Returns(listOfEntityMembersExpected);

            var memberService = new MemberService(mockRepository.Object);

            //Act
            var listOfMembersActual = memberService.List();

            //Assert
            Assert.AreEqual(listOfEntityMembersExpected.Count, listOfMembersActual.Count);
            Assert.AreEqual(listOfEntityMembersExpected[0].FirstName, listOfMembersActual[0].FirstName);
            Assert.AreEqual(listOfEntityMembersExpected[1].LastName, listOfMembersActual[1].LastName);
            Assert.AreEqual(listOfEntityMembersExpected[2].DateOfBirth, listOfMembersActual[2].DateOfBirth);
        }

        [TestMethod]
        public void Test_Check_If_Oldest_Member_Is_Returned()
        {
            //Arrange
            var mockRepository = new Mock<IDataRepository>();

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
            mockRepository.Setup(repository => repository.GetMembers()).Returns(listOfEntityMembersExpected);
            var memberService = new MemberService(mockRepository.Object);

            //Act
            var oldestMemberActual = memberService.GetOldestMember();

            //Assert
            Assert.AreEqual(listOfEntityMembersExpected[0].FirstName, oldestMemberActual.FirstName);
            Assert.AreEqual(listOfEntityMembersExpected[0].LastName, oldestMemberActual.LastName);
            Assert.AreEqual(listOfEntityMembersExpected[0].Email, oldestMemberActual.Email);
            Assert.AreEqual(listOfEntityMembersExpected[0].DateOfBirth, oldestMemberActual.DateOfBirth);
        }
    }
}
