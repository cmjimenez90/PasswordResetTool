using System;
using System.Collections.Generic;

namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.Model
{
    public class User
    {
        private readonly string _fullName;
        private readonly string _samAccountName;
        private readonly BannerID _bannerID;

        public BannerID BannerID
        {
            get { return _bannerID; }
        }

        public String SamAccountName
        {
            get { return _samAccountName; }
        }

        public String FullName
        {
            get { return _fullName; }
        }

        public User(BannerID bannerID, String samAccountName, String fullName)
        {
            _fullName = fullName;
            _samAccountName = samAccountName;
            _bannerID = bannerID;
        }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            return user != null &&
                   _fullName == user._fullName &&
                   _samAccountName == user._samAccountName &&
                  _bannerID.Equals(user._bannerID);
        }

        public override int GetHashCode()
        {
            var hashCode = -1641708324;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_fullName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_samAccountName);
            hashCode = hashCode * -1521134295 + EqualityComparer<BannerID>.Default.GetHashCode(_bannerID);
            return hashCode;
        }
    }
}
