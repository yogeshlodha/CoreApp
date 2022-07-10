using System;
using System.Collections.Generic;

namespace CoreService
{
    public class DemoService : IDemoService
    {
        // Find first match record with name.
        public List<Emp> FindRecordByName(List<Emp> list, string FindName)
        {
            return list.FindAll(m => m.Name.Contains(FindName));
        }

        // Get static records of Employees.
        public List<Emp> GetStaticRecords()
        {
            List<Emp> emp = new List<Emp> {
            new Emp{ Name = "Ram", Age="30", City="Jaipur", Salary="100k"  },
            new Emp{ Name = "Shayam", Age="28", City="Alwar", Salary="70k"  },
            new Emp{ Name = "Mohan", Age="25", City="Dehli", Salary="110k"  },
            new Emp{ Name = "Raman", Age="21", City="Mumbai", Salary="120k"  },
            new Emp{ Name = "Radhe", Age="25", City="Kota", Salary="110k"  }
            };

            return emp;
        }
    }
}
