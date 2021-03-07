using EfPerfTest.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPerfTest.Common.Interfaces
{
    public interface IEfPerfTestRepository
    {
        void SaveOncePerCustomer(IEnumerable<Customer> customers);
        void SaveAllAtOnce(IEnumerable<Customer> customers);
    }
}
