using sistalabben.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sistalabben.Pages.ContactPages
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Success"] as bool? == true)
            {
                MessagePlaceHolder.Visible = true;
                Session.Remove("Success");
            }
        }


        public void ContactListView_InsertItem(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var service = new Service();
                    service.SaveContact(contact);
                   // Session["Success"]= true;
                    //Response.Redirect("~/Pages/ContactPages/Create.aspx");
                  
                    Page.SetTempData("SuccessMessage", "Kunden lades till.");
                    Response.RedirectToRoute("ContactListing");
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception ex)
                {
                   ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade när kontaktuppgiften skulle läggas till");
                   // ModelState.AddModelError(String.Empty, ex.Message);
                }
            }
        }


    }
}