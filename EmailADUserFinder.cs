using System;
using System.DirectoryServices.AccountManagement;

namespace TemplateMethod
{
    public class EmailADUserFinder : ADUserFinderAbstract<string>
    {
        protected override string convertPrincipal(UserPrincipal principal)
        {
            return principal.EmailAddress;
        }
    }
}
