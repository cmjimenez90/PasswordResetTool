using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmjimenez.PasswordResetTool.Applicaiton.Messages
{
    class SamAccountNotFoundMessage
    {
        private readonly string _samAccountName;

        public string BannerID { get { return _samAccountName; } }

        public SamAccountNotFoundMessage(string samAccountName) => _samAccountName = samAccountName;
    }
}
