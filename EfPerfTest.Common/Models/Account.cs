﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPerfTest.Common.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AcctNumber { get; set; } = string.Empty;
        public string AcctType { get; set; } = string.Empty;
        public IList<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
