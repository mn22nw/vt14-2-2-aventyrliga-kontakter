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
            // kod
        }

        public void DeleteContact(int contactId)
        {
            // kod
        }

        public Contact GetContact(int contactId)
        {
            return ContactDAL.GetContactById(contactId);
        }

     /*     Metoden Save används både då en ny kontaktuppgift ska läggas till i tabellen Contact och då en 
            befintlig kontaktuppgift ska uppdateras. Genom att undersöka värdet egenskapen ContactId har för 
            Contact-objektet kan det bestämmas om det är fråga om en helt ny post, eller en uppdatering. Har 
            ContactId värdet 0 (standardvärdet för fält av typen int) är det en ny post. Är värdet större än 0 
            måste det vara en befintlig post som ska uppdateras.
            Innan en post skapas eller uppdateras måste Contact-objektet valideras. Misslyckas valideringen ska 
            ett undantag av typen ApplicationException kastas. Genom egenskapen Data i klassen 
            ApplicationException och metoden Add kan en referens till samlingen med valideringsresultat
            skickas med undantaget, som tas omhand och behandlas i presentationslogiklagret.*/


        public IEnumerable<Contact> GetContacts()
        {
            return ContactDAL.GetContacts();

        }

        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            throw new NotImplementedException(); // bara för stomme s det inte blir rött
        }


        // throw new NotImplementedException(); // bara för stomme s det inte blir rött

        public void SaveContact(Contact contact)
        {
        }
    }
}