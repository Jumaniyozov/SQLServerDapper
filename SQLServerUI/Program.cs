using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using DataAccessLibrary;
using DataAccessLibrary.Models;

namespace SQLServerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlCrud sql = new SqlCrud(GetConnectionString());
            //ReadAllContacts(sql);
            //ReadContact(sql, 1);
            //CreateNewContact(sql);
            //UpdateContact(sql);
            //RemovePhoneNumberFromContact(sql, 1, 2);
            Console.ReadLine();
        }

        private static void RemovePhoneNumberFromContact(SqlCrud sql, int contactId, int phoneNumberId)
        {
            sql.RemovePhoneNumberFromContact(contactId, phoneNumberId);
        }

        private static void UpdateContact(SqlCrud sql)
        {
            BasicContactModel contact = new BasicContactModel
            {
                Id = 1,
                FirstName = "Eeslum",
                LastName = "Jumaniyozov"
            };
            sql.UpdateContact(contact);
        }

        private static void CreateNewContact(SqlCrud sql)
        {
            FullContactModel user = new FullContactModel
            {
                BasicInfo = new BasicContactModel
                {
                    FirstName = "Solomon",
                    LastName = "David"
                },
            };

            user.EmailAdresses.Add(new EmailAddressModel { EmailAddress = "nope@aol.com" });
            user.EmailAdresses.Add(new EmailAddressModel { Id = 2, EmailAddress = "me@test.com" });

            user.PhoneNumbers.Add(new PhoneNumberModel { Id = 1, PhoneNumber = "555-666-777" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "444-888-999" });

            sql.CreateContact(user);

        }

        private static void ReadAllContacts(SqlCrud sql)
        {
            var rows = sql.GetAllContacts();
            foreach (var row in rows)
            {
                Console.WriteLine($"{row.Id}: {row.FirstName} {row.LastName}");
            }
        }

        private static void ReadContact(SqlCrud sql, int contactId)
        {
            var contact = sql.GetFullContactById(contactId);
            Console.WriteLine($"{contact.BasicInfo.Id}: {contact.BasicInfo.FirstName} {contact.BasicInfo.LastName}");
        }

        private static string GetConnectionString(string connectionStringName = "Default")
        {
            string output = "";
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            output = config.GetConnectionString(connectionStringName);

            return output;
        }
    }
}
