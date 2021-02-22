using EfPerfTest.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPerfTest.Core.Interfaces
{
    public interface IEfPerfTestRepository
    {
        void Save1PerCustomer(IList<Customer> customers);
    }
}
