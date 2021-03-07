using EfPerfTest.Common.Interfaces;
using EfPerfTest.Common.Models;
using System;
using System.Collections.Generic;
using System.Xml;

namespace EfPerfTest.Xml
{
    public class XmlSaveRepository : IEfPerfTestRepository
    {
        private readonly string xmlFilename;
        private static int customerId = 0;
        private static int accountId = 0;
        private static int transactionId = 0;

        public XmlSaveRepository(string xmlFilename)
        {
            this.xmlFilename = xmlFilename;
        }

        public void SaveOncePerCustomer(IEnumerable<Customer> customers)
        {
            throw new NotImplementedException();
        }

        public void SaveAllAtOnce(IEnumerable<Customer> customers)
        {
            using var xmlWriter = CreateXmlWriter();
            xmlWriter.WriteStartDocument();
            // root xml element
            WriteCustomers(xmlWriter, customers);
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        private void WriteCustomers(XmlWriter xmlWriter, IEnumerable<Customer> customers)
        {
            xmlWriter.WriteStartElement(null, "Customers", null);
            foreach (var customer in customers)
            {
                WriteCustomer(xmlWriter, customer);
            }
            xmlWriter.WriteEndElement();
        }

        private void WriteCustomer(XmlWriter xmlWriter, Customer customer)
        {
            if (customerId % 100 == 0) Console.WriteLine(customer);

            xmlWriter.WriteStartElement(null, "Customer", null);
            xmlWriter.WriteAttributeString(null, "id", null, (++customerId).ToString());
            xmlWriter.WriteElementString("CustomerNumber", customer.CustomerNumber);
            xmlWriter.WriteElementString("Name", customer.Name);
            xmlWriter.WriteElementString("Address1", customer.Address1);
            xmlWriter.WriteElementString("Address2", customer.Address2);
            xmlWriter.WriteElementString("Address3", customer.Address3);
            xmlWriter.WriteElementString("Address4", customer.Address4);
            //xmlWriter.WriteElementString("Birthday", XmlConvert.ToString(customer.Birthday.Date, XmlDateTimeSerializationMode.Local));
            xmlWriter.WriteElementString("Birthday", customer.Birthday.ToShortDateString());

            xmlWriter.WriteElementString("Email", customer.Email);
            xmlWriter.WriteElementString("Phone", customer.Phone);
            WriteAccounts(xmlWriter, customer.Accounts);
            xmlWriter.WriteEndElement();
        }

        private void WriteAccounts(XmlWriter xmlWriter, IList<Account> accounts)
        {
            xmlWriter.WriteStartElement(null, "Accounts", null);
            xmlWriter.WriteAttributeString(null, "count", null, accounts.Count.ToString());
            foreach (var acct in accounts)
            {
                WriteAccount(xmlWriter, acct);
            }
            xmlWriter.WriteEndElement();
        }

        private void WriteAccount(XmlWriter xmlWriter, Account acct)
        {
            xmlWriter.WriteStartElement(null, "Account", null);

            xmlWriter.WriteAttributeString(null, "id", null, (++accountId).ToString());
            xmlWriter.WriteElementString("AcctNumber", acct.AcctNumber);
            xmlWriter.WriteElementString("AcctType", acct.AcctType);

            WriteTransactions(xmlWriter, acct.Transactions);
            xmlWriter.WriteEndElement();
        }

        private void WriteTransactions(XmlWriter xmlWriter, IList<Transaction> transactions)
        {
            xmlWriter.WriteStartElement(null, "Transactions", null);
            xmlWriter.WriteAttributeString(null, "count", null, transactions.Count.ToString());
            foreach (var trans in transactions)
            {
                WriteTransaction(xmlWriter, trans);
            }
            xmlWriter.WriteEndElement();
        }

        private void WriteTransaction(XmlWriter xmlWriter, Transaction trans)
        {
            xmlWriter.WriteStartElement(null, "Transaction", null);

            xmlWriter.WriteAttributeString(null, "id", null, (++transactionId).ToString());
            xmlWriter.WriteElementString("TransType", trans.TransType);
            //xmlWriter.WriteElementString("Date", XmlConvert.ToString(trans.Date, XmlDateTimeSerializationMode.Local));
            xmlWriter.WriteElementString("Date", trans.Date.ToShortDateString());
            xmlWriter.WriteElementString("Amount", trans.Amount.ToString());
            xmlWriter.WriteElementString("Description", trans.Description);

            xmlWriter.WriteEndElement();
        }

        private XmlWriter CreateXmlWriter()
        {
            var xmlSettings = new XmlWriterSettings { Indent = true };  //, Async = true };
            return XmlWriter.Create(xmlFilename, xmlSettings);
        }
    }
}
