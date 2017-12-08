using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CBHS.Webapi.Tests
{
    using Moq;


    using CBHS.Webapi.Controllers;
    using CBHS.Business.Interfaces;
    using System.Web.Http;

    [TestClass]
    public class MemberTest
    {
        [TestMethod]
        public void Test_Check_Member_Is_Added()
        {
            //Member SampleMember = new Member()
            //{
            //    FirstName = "SampleFirstName",
            //    LastName = "SampleLastName",
            //    Email = "Sample@email.com",
            //    DateOfBirth = "01/01/2000"
            //};

            var mockMember = new Mock<IMember>();
            mockMember.SetupProperty(member => member.FirstName, "SampleFirstName")
                        .SetupProperty(member => member.LastName, "SampleLastName")
                        .SetupProperty(member => member.Email, "Sample@email.com")
                        .SetupProperty(member => member.DateOfBirth, "01/01/2000");
            mockMember.Setup(member => member.Add(mockMember.Object)).Returns(1);
                        
            var membersController = new MembersController(mockMember.Object);
            var MemberId = membersController.Add(mockMember.Object);

            Assert.IsTrue(MemberId > 0);
        }
    }
}
