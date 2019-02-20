using Cmjimenez.PasswordResetTool.Application.Main.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmjimenez.PasswordResetTool.Application.Navigation
{
    interface IPageFlow
    {
        string CurrentPage { get; }
        void NextPageInFlow();
        void ResetPageFlow();
    }
}
