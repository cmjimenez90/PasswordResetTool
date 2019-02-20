using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;

namespace Cmjimenez.PasswordResetTool.Application.PasswordReset.Main.Service
{
    [DirectoryObjectClass("user")]
    [DirectoryRdnPrefix("CN")]
    public class UserPrincipalExtension : UserPrincipal
    {
        private const string EXTENSION_ATTRIBUTE_14 = "ExtensionAttribute14";
        private const string EXTENSION_ATTRIBUTE_8 = "ExtensionAttribute8";

        public UserPrincipalExtension(PrincipalContext context) : base(context) { }
        public UserPrincipalExtension(PrincipalContext context, String samAccountName, string password, Boolean enabled) 
            : base(context, samAccountName, password, enabled) { }

        [DirectoryProperty(EXTENSION_ATTRIBUTE_14)]
        public string ExtensionAttribute14
        {
            get
            {
                if (ExtensionGet(EXTENSION_ATTRIBUTE_14).Length != 1)
                    return null;
                return (string)ExtensionGet(EXTENSION_ATTRIBUTE_14)[0];
            }
            set { this.ExtensionSet(EXTENSION_ATTRIBUTE_14, value); }
        }

        [DirectoryProperty(EXTENSION_ATTRIBUTE_8)]
        public string ExtensionAttribute8
        {
            get
            {
                if (ExtensionGet(EXTENSION_ATTRIBUTE_8).Length != 1)
                    return null;
                return (string)ExtensionGet(EXTENSION_ATTRIBUTE_8)[0];
            }
            set { this.ExtensionSet(EXTENSION_ATTRIBUTE_8, value); }
        }
    }
}
