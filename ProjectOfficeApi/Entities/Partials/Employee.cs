using Microsoft.EntityFrameworkCore.Metadata;

using System.Composition.Convention;
using System.Runtime.ExceptionServices;

namespace ProjectOfficeApi.Entities
{
    public partial class Employee
    {
         public string FullName { get => $"{LastName} {FirfstName} {MiddleName}" ; }
    }
}
