using Microsoft.EntityFrameworkCore.Metadata;

using System.Runtime.ExceptionServices;

namespace ProjectOffice.DataBase.Entities
{
    public partial class Employee
    {
        public string FullName { get => $"{LastName} {FirstName} {MiddleName}"; }
        public string ShortName
        {
            get
            {
                if (MiddleName == null)
                    return $"{LastName}, {FirstName[0]}";
                else
                    return $"{LastName}, {FirstName[0]}. {MiddleName[0]}";
            }
        }
    }
}
