using Cmjimenez.PasswordResetTool.Application.PasswordReset.Main.Repository;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmjimenez.PasswordResetTool.Application.Main.Repository
{
    public class FakeActiveDirectoryRepository : IActiveDirectoryRepository
    {
        private List<User> _users = new List<User>();

        public FakeActiveDirectoryRepository()
        {
            for(int x = 1; x < 10; x++)
            {
                BannerID bannerNumber = BannerID.CreateBannerID(("A0000000"+x));
                String samAccountName = ("testuser"+ x);
                String fullname = ("test, user "+ x);
                User user = new User(bannerNumber, samAccountName, fullname);
                _users.Add(user);
            }
        }
        public bool ChangeUserPassword(User user, string newPassword)
        {
            if (user.BannerID.Value.Equals("A00000001"))
                return false;
            return true;
        }

        public bool ChangeUserResetAttribute(User user)
        {
            if (user.BannerID.Value.Equals("A00000001")||user.BannerID.Value.Equals("A00000002"))
                return false;
            return true;
        }

        public User FindUserByBannerID(BannerID bannerID)
        {
           User foundUser =  _users.Find(user => user.BannerID.Equals(bannerID));
           return foundUser;
        }

        public User FindUserBySamAccountName(string testSamAccountName)
        {
            throw new NotImplementedException();
        }
    }
}
