using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using labb2punkt2.Model;
using labb2punkt2.Model.DAL;
using System.ComponentModel.DataAnnotations;

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
            //kod
        }

        public void DeleteContact(int contactId)
        {
            ContactDAL.DeleteContact(contactId);
        }

        public Contact GetContact(int contactId)
        {
            return ContactDAL.GetContactById(contactId);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return ContactDAL.GetContacts();

        }

        public IEnumerable<Contact> GetContactsPageWise(int startRowIndex, int maximumRows, out int totalRowCount)
        {
            return ContactDAL.GetContactsPageWise(startRowIndex, maximumRows, out totalRowCount);
        }


        public void SaveContact(Contact contact)
        {
            var validationContext = new ValidationContext(contact);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(contact, validationContext, validationResults, true))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            try
            {
                if (contact.ContactId >= 0)
                {

                    if (contact.ContactId == 0)
                    {
                        ContactDAL.InsertContact(contact);
                    }

                    else
                    {
                        ContactDAL.UpdateContact(contact);
                    }
                }
                else
                {
                   // throw new ArgumentOutOfRangeException("Värdet måste vara större eller lika med 0");
                    throw new ApplicationException("Det uppstod ett fel vid uppdatering/tillägg av kund");
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