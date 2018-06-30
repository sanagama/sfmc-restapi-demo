using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using SfmcRestApiDemo.Models;

namespace SfmcRestApiDemo
{
    internal class SfmcDemoInitializer
    {
        private SfmcContext _context;
        public SfmcDemoInitializer(SfmcContext context)
        {
            _context = context;
        }
        
        public void Initialize()
        {
            // Drop & recreate the database and seed data at each demo run
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            // Create seed data for demo
            SeedData();
        }

        //
        // Seed sample data for this demo
        //
        private void SeedData()
        {
            // Account
            var account = new Account { AccountId = 1, Name = "Peh's Bicycle Shop"};
            _context.Accounts.Add(account);
            _context.SaveChanges();

            // BU
            var businessUnit = new BusinessUnit { MID = 1, Name = "Peh's Bicycle Shop - Redmond Location"};
            account.BusinessUnits.Add(businessUnit);
            _context.SaveChanges();

            // Contacts
            var contacts = new List<Contact>
            {
                new Contact
                {
                    ContactKey = 1,
                    MID = 1,
                    BusinessUnit = businessUnit,
                    FirstName = "Syam",
                    LastName = "Nair",
                    EmailAddress = "syam@syam.org",
                    PhoneNumber = "123-456-7890"
                },
                new Contact
                {
                    ContactKey = 2,
                    MID = 1,
                    BusinessUnit = businessUnit,
                    FirstName = "Pehkeong",
                    LastName = "The",
                    EmailAddress = "peh@the.org",
                    PhoneNumber = "123-123-1234"
                },
                new Contact
                {
                    ContactKey = 3,
                    MID = 1,
                    BusinessUnit = businessUnit,
                    FirstName = "Gautam",
                    LastName = "Dharamshi",
                    EmailAddress = "gautam@@gautam.org",
                    PhoneNumber = "123-007-0007"
                }
            };

            _context.Contacts.AddRange(contacts);
            _context.SaveChanges();

            // Emails
            var emails = new List<Email>
            {
                new Email
                {
                    MessageKey = 1,
                    MID = 1,
                    BusinessUnit = businessUnit,

                    Contents = new List<Content>
                    {
                        new Content
                        {
                            ContentKey = 1,
                            TextContent = "Hello"
                        },
                        new Content
                        {
                            ContentKey = 2,
                            TextContent = "This is the first line of content"
                        },
                        new Content
                        {
                            ContentKey = 3,
                            TextContent = "This is the second line of content"
                        }
                    }
                },
                new Email
                {
                    MessageKey = 2,
                    MID = 1,
                    BusinessUnit = businessUnit,

                    Contents = new List<Content>
                    {
                        new Content
                        {
                            ContentKey = 4,
                            TextContent = "Hello again"
                        },
                        new Content
                        {
                            ContentKey = 5,
                            TextContent = "This is a line of content"
                        }
                    }
                },
                new Email
                {
                    MessageKey = 3,
                    MID = 1,
                    BusinessUnit = businessUnit,

                    Contents = new List<Content>
                    {
                        new Content
                        {
                            ContentKey = 6,
                            TextContent = "Hello there!"
                        }
                    }
                }
            };

            _context.Emails.AddRange(emails);
            _context.SaveChanges();
        }
    }
}