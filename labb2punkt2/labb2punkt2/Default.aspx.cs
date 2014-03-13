using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using labb2punkt2.Model;
using System.ComponentModel.DataAnnotations;

namespace labb2punkt2
{
    public partial class Default : System.Web.UI.Page
    {
        private Service service;

        private Service Service
        {
            get { return service ?? (service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression

        public IEnumerable<Contact> ContactListView_GetData()
        {
          int count = 20;
        //    Service.GetContactsPageWise(5, 1, out count); 
          return Service.GetContactsPageWise(1, 20, out count);

        }

        public void ContactListView_InsertItem(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveContact(contact);
                }
                catch (Exception ex)
                {
                    /*   var valitadionResults = ex.Data["ValidationResults"] as IEnumerable<ValidationResult>;
                       if (valitadionResults != null)
                       {
                            foreach ( var validationResult in valitadionResults)
                            {
                                foreach (var memberName in validationResult.MemberNames)
                                {
                                    ModelState.AddModelError(memberName, validationResult.ErrorMessage);
                                    }
                           }

                       }*/
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade när kontaktuppgiften skulle läggas till");
                }
            }
        }

        public void ContactListView_UpdateItem(int contactId)
        {
            try
            {
                var contact = Service.GetContact(contactId);
                if (contact == null)
                {
                    //Hittade inte kontakten
                    ModelState.AddModelError(String.Empty, String.Format("Kontakten med kontaktnummer {0} hittades inte.", contactId));
                    return;
                }

                if (TryUpdateModel(contact)) 
                {
                    Service.SaveContact(contact);
                }
            }
            catch(Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade när kontaktuppgiften skulle uppdateras");
            }

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ContactListView_DeleteItem(int contactId)
        {
            try
            {
                Service.DeleteContact(contactId);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade när kontaktuppgiften skulle tas bort");
            }
        }

    }
}