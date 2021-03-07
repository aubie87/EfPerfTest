using Bogus;
using Bogus.Extensions;
using EfPerfTest.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPerfTest.Source
{
    public class Fake
    {
        private readonly Faker faker = new Faker();

        public Fake()
        {
        }

        public IEnumerable<Customer> LoadCustomers(int customerCount)
        {
            var customers = new List<Customer>();
            for (int i = 0; i < customerCount; i++)
            {
                customers.Add(NewCustomer());
            }
            return customers;
        }

        private Customer NewCustomer()
        {
            var person = new Person();
            return new Customer
            {
                Name = person.FullName,
                CustomerNumber = faker.Finance.Account(),
                Birthday = person.DateOfBirth,
                Email = person.Email,
                Phone = person.Phone,
                Address1 = person.Address.Street,
                Address2 = person.Address.Suite.OrNull(faker, .2f),
                Address3 = $"{person.Address.City}, {person.Address.State}  {person.Address.ZipCode}",
                Accounts = LoadAccounts(faker.Random.UInt(1, 9))
            };
        }

        private IList<Account> LoadAccounts(uint accountCount)
        {
            var accounts = new List<Account>();
            for(int i = 0; i<accountCount; i++)
            {
                accounts.Add(new Account 
                {
                    AcctType = faker.Finance.AccountName(),
                    AcctNumber = faker.Finance.Account(10),
                    Transactions = LoadTransactions(faker.Random.UInt(0, 30))
                });
            }
            return accounts;
        }

        private IList<Transaction> LoadTransactions(uint transactionCount)
        {
            var now = DateTime.Now.AddMonths(-1);
            var thisMonth = new DateTime(now.Year, now.Month, 1);

            var transactions = new List<Transaction>();
            for(int i = 0; i<transactionCount; i++)
            {
                transactions.Add(new Transaction
                {
                    TransType = faker.Finance.TransactionType(),
                    Date = faker.Date.Between(thisMonth, thisMonth.AddMonths(1)),
                    Amount = faker.Finance.Amount(3, 500),
                    Description = faker.Lorem.Sentence(8,3)
                });
            }
            return transactions;
        }
    }
}
