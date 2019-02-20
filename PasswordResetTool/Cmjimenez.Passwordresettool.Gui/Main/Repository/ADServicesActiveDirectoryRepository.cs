using System;
using System.DirectoryServices.AccountManagement;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Model;
using Cmjimenez.PasswordResetTool.Application.PasswordReset.Main.Service;
using Cmjimenez.PasswordResetTool.Application.Main.Repository;

namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.Main.Repository
{

     class ADServicesActiveDirectoryRepository : IActiveDirectoryRepository
    {
        private const string PASSWORD_RESET_VALUE = "RESET";
        private PrincipalContextFactory _contextFactory;
        
        public ADServicesActiveDirectoryRepository(PrincipalContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public bool ChangeUserPassword(User user, string newPassword)
        {
            using (PrincipalContext context = _contextFactory.GeneratePrincipalContext())
            {
                UserPrincipalExtension userSearchParameters = new UserPrincipalExtension(context) { ExtensionAttribute14 = user.BannerID.Value};
                PrincipalSearcher userSearch = new PrincipalSearcher(userSearchParameters) { QueryFilter = userSearchParameters };
                UserPrincipalExtension userSearchResult = (UserPrincipalExtension)userSearch.FindOne();
                if (userSearchResult != null)
                {
                    try
                    {
                        userSearchResult.SetPassword(newPassword);
                        userSearchResult.Save();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                    
                }
                else
                {
                    return false;
                }
            }
        }

        public bool ChangeUserResetAttribute(User user)
        {
            using (PrincipalContext context = _contextFactory.GeneratePrincipalContext())
            {
                UserPrincipalExtension userSearchParameters = new UserPrincipalExtension(context) { ExtensionAttribute14 = user.BannerID.Value };
                PrincipalSearcher userSearch = new PrincipalSearcher(userSearchParameters) { QueryFilter = userSearchParameters };
                UserPrincipalExtension userSearchResult = (UserPrincipalExtension)userSearch.FindOne();
                if (userSearchResult != null)
                {
                    try
                    {
                        userSearchResult.ExtensionAttribute8 = PASSWORD_RESET_VALUE;
                        userSearchResult.Save();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                   
                }
                else
                {
                    return false;
                }
            }
        }

        public User FindUserByBannerID(BannerID bannerID)
        {

            using (PrincipalContext context = _contextFactory.GeneratePrincipalContext())
            {
                UserPrincipalExtension userSearchParameters = new UserPrincipalExtension(context) { ExtensionAttribute14 = bannerID.Value };
                PrincipalSearcher userSearch = new PrincipalSearcher(userSearchParameters) { QueryFilter = userSearchParameters };
                UserPrincipalExtension userSearchResult = (UserPrincipalExtension)userSearch.FindOne();
                if (userSearchResult != null)
                    return ConvertUserPrincipalToUser(userSearchResult);
                return null;
            }   
        }

        public User FindUserBySamAccountName(string samAccountName)
        {
            using (PrincipalContext context = _contextFactory.GeneratePrincipalContext())
            {
                UserPrincipalExtension userSearchParameters = new UserPrincipalExtension(context) { SamAccountName = samAccountName };
                PrincipalSearcher userSearch = new PrincipalSearcher(userSearchParameters) { QueryFilter = userSearchParameters };
                UserPrincipalExtension userSearchResult = (UserPrincipalExtension)userSearch.FindOne();
                if (userSearchResult != null)
                    return ConvertUserPrincipalToUser(userSearchResult);
                return null;
            }
        }

        private User ConvertUserPrincipalToUser(UserPrincipalExtension userPrincipalExtension)
        {
            BannerID bannerID = BannerID.CreateBannerID(userPrincipalExtension.ExtensionAttribute14);
            string fullName = String.Format("{0}, {1} {2}", userPrincipalExtension.Surname, userPrincipalExtension.GivenName, userPrincipalExtension.MiddleName);
            string samAccountName = userPrincipalExtension.SamAccountName;
            return new User(bannerID, samAccountName, fullName);
        }

        
    }
}
