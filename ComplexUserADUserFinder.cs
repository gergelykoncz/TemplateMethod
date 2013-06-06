using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using TemplateMethod.Entities;

namespace TemplateMethod
{
    public class ComplexUserADUserFinder : ADUserFinderAbstract<ComplexUser>
    {
        protected override ComplexUser convertPrincipal(UserPrincipal principal)
        {
            var result = new ComplexUser();
            result.Department = tryGetUserDepartment(principal);
            result.EmailAddress = principal.EmailAddress;
            result.Name = principal.Name;
            return result;
        }

        private string tryGetUserDepartment(UserPrincipal principal)
        {
            DirectoryEntry directoryEntry = principal.GetUnderlyingObject() as DirectoryEntry;
            if (directoryEntry != null)
            {
                if (directoryEntry.Properties.Contains("department"))
                {
                    PropertyValueCollection propertyValueCollection = directoryEntry.Properties["department"];
                    if (propertyValueCollection.Count > 0)
                    {
                        return propertyValueCollection[0].ToString();
                    }
                }
            }
            return string.Empty;
        }
    }
}
