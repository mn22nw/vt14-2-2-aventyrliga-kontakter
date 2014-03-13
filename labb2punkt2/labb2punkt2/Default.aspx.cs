using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using labb2punkt2.Model;

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
            return Service.GetContacts();
        }
    }
}