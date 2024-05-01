using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOffice.Entities
{
    public partial class Employee
    {
        public string ShortName
        {
            get
            {
                if (MiddleName.Length == 0)
                    return $"{LastName} {FirfstName[0]}.";
                else
                    return $"{LastName} {FirfstName[0]}. {MiddleName[0]}.";// Иванов. И. И

            }
        }


        public string FullName
        {
            get
            {
                return $"{LastName} {FirfstName} {MiddleName}";
            }
        }

    }
}
