using System;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cmjimenez.PasswordResetTool.ApplicationTest.PasswordReset.Model
{
    [TestClass]
    public class BannerIDTest
    {
        
        [TestMethod]
        [ExpectedException(typeof(BannerIDInvalidFormatException))]
        public void BannerID_Throws_Error_If_Less_Than_Nine_Characters_Long()
        {
            String failingBannerIDValue = "1234567";
            BannerID result = BannerID.CreateBannerID(failingBannerIDValue);
        }

        [TestMethod]
        [ExpectedException(typeof(BannerIDInvalidFormatException))]
        public void BannerID_Throws_Error_If_More_Than_Nine_Characters_Long()
        {
            String failingBannerIDValue = "1234567890";
            BannerID result = BannerID.CreateBannerID(failingBannerIDValue);
        }

        [TestMethod]
        [ExpectedException(typeof(BannerIDInvalidFormatException))]
        public void BannerID_Throws_Error_If_Does_Not_Start_With_An_A()
        {
            String failingBannerIDValue = "B12345678";
            BannerID result = BannerID.CreateBannerID(failingBannerIDValue);
        }

    }
}
