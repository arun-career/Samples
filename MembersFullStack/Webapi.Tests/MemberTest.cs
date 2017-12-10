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
            var mockMember = new Mock<IMemberService>();
            mockMember.SetupProperty(member => member.FirstName, "SampleFirstName")
                        .SetupProperty(member => member.LastName, "SampleLastName")
                        .SetupProperty(member => member.Email, "Sample@email.com")
                        .SetupProperty(member => member.DateOfBirth, "01/01/2000");
            mockMember.Setup(member => member.Add(mockMember.Object)).Returns(true);
                        
            var membersController = new MembersController(mockMember.Object);
            var IsAdded = membersController.Add(mockMember.Object);

            Assert.IsTrue(IsAdded);
        }
    }
}
