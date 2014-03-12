using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Configuration;
using labb2punkt2.Model;
using labb2punkt2.Model.DAL;

namespace labb2punkt2.Model.DAL
{
    public class ContactDAL : DALBase
    {
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
            throw new NotImplementedException(); // bara för stomme s det inte blir rött
        }

        public IEnumerable<Contact> GetContacts()
        {
           // string connectionString = WebConfigurationManager.ConnectionStrings["1dv409_AdventureWorksAssignmentConnectionString"].ConnectionString;
            // anslutningssträngen

            using (var conn = new SqlConnection(connectionString))  // å
            {
                var contacts = new List<Contact>(100);   // Object som håller ordning på de objekt som ska instansieras



                var cmd = new SqlCommand("Person.uspGetContacts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();  // ska inte vara öppen mer än vad som behövs, därför läggs den in här senare. 

                using (var reader = cmd.ExecuteReader())
                {
                    var contactIdIndex = reader.GetOrdinal("ContactID"); // ger tillbaka ett heltal där ContactId finns
                    var firstNameIndex = reader.GetOrdinal("FirstName");
                    var lastNameIndex = reader.GetOrdinal("LastName");
                    var emailIndex = reader.GetOrdinal("EmailAddress");

                    while (reader.Read()) //så länge metoden read returnerar true finns det data att hämta. 
                    {
                        contacts.Add(new Contact
                        {
                            ContactId = reader.GetInt32(contactIdIndex),
                            FirstName = reader.GetString(firstNameIndex),
                            LastName = reader.GetString(lastNameIndex),
                            EmailAddress = reader.GetString(firstNameIndex)

                        });
                    }

                    contacts.TrimExcess(); // krymper till det faktiskta antalet element som är utnyttjat 


                }

                return contacts;

            }
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