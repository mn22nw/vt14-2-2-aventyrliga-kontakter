using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using sistalabben.MODEL;

namespace sistalabben.Pages.ContactPages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SuccessMessageLiteral.Text = Page.GetTempData("SuccessMessage") as string;
            SuccessMessagePanel.Visible = !String.IsNullOrWhiteSpace(SuccessMessageLiteral.Text);
        }

        protected void exitbutton_OnClick(object sender, EventArgs e)
        {
            SuccessMessagePanel.Visible = false;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression

        public IEnumerable<Contact> ContactListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {   
            return Service.GetContactsPageWise(maximumRows, startRowIndex, out totalRowCount);

        }

         // The id parameter name should match the DataKeyNames value set on the control
        public void ContactListView_DeleteItem(int contactId)
        {
            try
            {
                Service.DeleteContact(contactId);
                Page.SetTempData("SuccessMessage", "Kunden deletades.");
                Response.RedirectToRoute("ContactListing");
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade när kontaktuppgiften skulle tas bort");
            }
        }

    }
}