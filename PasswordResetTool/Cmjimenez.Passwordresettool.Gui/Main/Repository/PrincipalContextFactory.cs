using System;
using System.DirectoryServices.AccountManagement;


namespace Cmjimenez.PasswordResetTool.Application.Main.Repository
{
    public class PrincipalContextFactory
    {
        public PrincipalContextFactory()
        {

        }

        public PrincipalContext GeneratePrincipalContext()
        {
            String DCPath = Properties.Settings.Default.DC_FQDN;
            if(DCPath.Equals("") == false)
            {
                return ConfigContext(DCPath);
            }
            return DefaultContext();
        }

        private PrincipalContext DefaultContext()
        {
                PrincipalContext context = new PrincipalContext(ContextType.Domain);
                return context;

        }

        private PrincipalContext ConfigContext(String DomainControllerPath)
        {           
                PrincipalContext context = new PrincipalContext(ContextType.Domain,DomainControllerPath);
                return context;    
        }
    }
}
