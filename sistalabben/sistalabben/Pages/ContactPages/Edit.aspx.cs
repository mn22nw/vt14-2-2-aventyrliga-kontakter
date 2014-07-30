using sistalabben.MODEL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;

namespace sistalabben.Pages.ContactPages
{
    public partial class Edit : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
           get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SuccessUpdate"] as bool? == true)
            {
                MessagePlaceHolder.Visible = true;
                Session.Remove("Success");
            }

        }

        public Contact ContactFormView_GetItem([RouteData]int id)
        {
            try
            {
                return Service.GetContact(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då kunden hämtades vid redigering.");
                return null;
            }
        }

        public void ContactFormView_UpdateItem(int contactId) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var contact = Service.GetContact(contactId);
                    if (contact == null)
                    {
                        // Hittade inte kunden.
                        ModelState.AddModelError(String.Empty,
                            String.Format("Kunden med kundnummer {0} hittades inte.", contactId));
                        return;
                    }

                    if (TryUpdateModel(contact))
                    {
                        Service.SaveContact(contact);

                        Page.SetTempData("SuccessMessage", "Kunden uppdaterades.");
                        Response.RedirectToRoute("ContactListing");
                        Context.ApplicationInstance.CompleteRequest();
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade då kunden skulle uppdateras.");
                }
            }
        }
    }
}