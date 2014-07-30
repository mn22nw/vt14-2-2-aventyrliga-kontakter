using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sistalabben.MODEL;
using sistalabben.MODEL.DAL;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace sistalabben.MODEL
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

        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return ContactDAL.GetContactsPageWise(maximumRows,startRowIndex, out totalRowCount);
        }


        public void SaveContact(Contact contact)
        {
            ICollection<ValidationResult> validationResults;

            
            if (!contact.Validate(out validationResults))
            {
                Debug.WriteLine("iiig");
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                Debug.WriteLine(ex.Message);
                throw ex;
            }

            try
            {
                if (contact.ContactId == 0) // Ny post om CustomerId är 0!
                {
                    ContactDAL.InsertContact(contact);
                }
                else
                {
                    ContactDAL.UpdateContact(contact);
                }
                
              //  else
              //  {
                    // throw new ArgumentOutOfRangeException("Värdet måste vara större eller lika med 0");
                 //   throw new ApplicationException("Det uppstod ett fel vid uppdatering/tillägg av kontakt");
              //  }
            }
            catch(Exception ex)
            {
               throw new ApplicationException("Det uppstod ett fel vid uppdatering/tillägg av kontakt");
            }
        }

        /*    
            Genom egenskapen Data i klassen 
           ApplicationException och metoden Add kan en referens till samlingen med valideringsresultat
           skickas med undantaget, som tas omhand och behandlas i presentationslogiklagret.*/
    }
}