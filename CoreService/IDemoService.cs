using System;
using System.Collections.Generic;
using System.Text;

namespace CoreService
{
    public interface IDemoService
    {
        List<Emp> GetStaticRecords();
        List<Emp> FindRecordByName(List<Emp> list, string FindName);
    }
}
