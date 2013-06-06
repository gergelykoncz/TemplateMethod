using System.DirectoryServices.AccountManagement;

namespace TemplateMethod
{
    public abstract class ADUserFinderAbstract<T>
    {
        public T GetUser(string userName)
        {
            using (var context = new PrincipalContext(ContextType.Domain))
            {
                UserPrincipal foundPrincipal = UserPrincipal.FindByIdentity(context, userName);
                return convertPrincipal(foundPrincipal);
            }
        }

        protected abstract T convertPrincipal(UserPrincipal principal);
    }
}
