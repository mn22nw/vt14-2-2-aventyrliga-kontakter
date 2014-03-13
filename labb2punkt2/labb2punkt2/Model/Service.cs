using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using labb2punkt2.Model;
using labb2punkt2.Model.DAL;

namespace labb2punkt2.Model
{
    public class Service  // kommunicerar med dataatkomstlagret som man kan instansiera i presentationslagret
    {
        private ContactDAL _contactDAL;

        private ContactDAL ContactDAL
        {
            get { return _contactDAL ?? (_contactDAL = new ContactDAL()); }
        }

        public void DeleteContact(Contact contact)
        {
            ContactDAL.InsertContact(contact);
        }

        public void DeleteContact(int contactId)
        {
            // kod
        }

        public Contact GetContact(int contactId)
        {
            return ContactDAL.GetContactById(contactId);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return ContactDAL.GetContacts();

        }

        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            throw new NotImplementedException(); 
        }


        public void SaveContact(Contact contact)
        {
            try
            {
                if (contact.ContactId >= 0)
                {

                    if (contact.ContactId == 0)
                    {
                        ContactDAL.InsertContact(contact);
                    }

                    if (contact.ContactId > 0)
                    {
                        ContactDAL.UpdateContact(contact);
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Värdet måste vara större eller lika med 0");
                }
            }
            catch
            {
                throw new ApplicationException("Det uppstod ett fel vid uppdatering/tillägg av kund");
            }
        }

        /*    
            Genom egenskapen Data i klassen 
           ApplicationException och metoden Add kan en referens till samlingen med valideringsresultat
           skickas med undantaget, som tas omhand och behandlas i presentationslogiklagret.*/
    }
}