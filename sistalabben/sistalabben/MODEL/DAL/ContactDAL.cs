using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Configuration;
using sistalabben.MODEL;
using sistalabben.MODEL.DAL;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace sistalabben.MODEL.DAL
{
    public class ContactDAL : DALBase
    {

        public void DeleteContact(int contactId)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("Person.uspRemoveContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contactId;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                }

                catch
                {
                    throw new ApplicationException("Det gick inte att uppdatera kontakt i databasen");
                }
            }
        }

        public Contact GetContactById(int contactId)
        {
            using (var conn = CreateConnection())  // å
            {
                try
                {
                    var cmd = new SqlCommand("Person.uspGetContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contactId;

                    conn.Open();  // ska inte vara öppen mer än vad som behövs, därför läggs den in här senare. 

                    using (var reader = cmd.ExecuteReader())
                    {
                        var contactIdIndex = reader.GetOrdinal("ContactID"); // ger tillbaka ett heltal där ContactId finns
                        var firstNameIndex = reader.GetOrdinal("FirstName");
                        var lastNameIndex = reader.GetOrdinal("LastName");
                        var emailIndex = reader.GetOrdinal("EmailAddress");
                        if (reader.Read())
                        {
                            return new Contact
                            {
                                ContactId = reader.GetInt32(contactIdIndex),
                                FirstName = reader.GetString(firstNameIndex),
                                LastName = reader.GetString(lastNameIndex),
                                EmailAddress = reader.GetString(emailIndex)
                            };
                        }
                    }

                    return null;
                }

                catch
                {
                    throw new ApplicationException("Det gick inte att hämta ut kontakt från databasen");
                }
            }
        }

        public IEnumerable<Contact> GetContacts()
        {
            using (var conn = CreateConnection())  // å
            {
              //  try
                //{
                    var contacts = new List<Contact>(100);   // Object som håller ordning på de objekt som ska instansieras

                    var cmd = new SqlCommand("Person.uspGetContacts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();  // ska inte vara öppen mer än vad som behövs, därför läggs den in här senare. 

                    using (var reader = cmd.ExecuteReader())
                    {
                        var contactIdIndex = reader.GetOrdinal("ContactID");        
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
                                EmailAddress = reader.GetString(emailIndex)
                            });
                        }
                        contacts.TrimExcess(); // krymper till det faktiskta antalet element som är utnyttjat 
                    }
                    //Debug.WriteLine(contacts[8].FirstName.ToString() + "woop"  );
                    return contacts;

              /*  }
                catch
                {
                    throw new ApplicationException("Det gick inte att hämta ut kontakterna från databasen");
                }*/
            }
        }

        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            totalRowCount = GetContacts().Count();
            return GetContacts().Skip(startRowIndex).Take(maximumRows);
        }

        public void InsertContact(Contact contact)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("Person.uspAddContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAddress;

                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    conn.Open();  // ska inte vara öppen mer än vad som behövs, därför läggs den in här senare. 

                    //ExecuteNonQuery används för att exekvera den lp. 
                    cmd.ExecuteNonQuery();

                    contact.ContactId = (int)cmd.Parameters["@ContactID"].Value;
                }

                catch
                {
                    throw new ApplicationException("Det gick inte att lägga till kontakt i databasen");
                }
            }
        }

        public void UpdateContact(Contact contact)
        {
            using (var conn = CreateConnection())  // å
            {
                try
                {
                    var cmd = new SqlCommand("Person.uspUpdateContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                  
                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contact.ContactId;  
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAddress;
                    conn.Open();  // ska inte vara öppen mer än vad som behövs, därför läggs den in här senare. 

                    //ExecuteNonQuery används för att exekvera den lp. 
                    cmd.ExecuteNonQuery();
                }

                catch
                {
                    throw new ApplicationException("Det gick inte att uppdatera kontakt i databasen");
                }
            }
        }

        // throw new NotImplementedException(); // bara för stomme s det inte blir rött



    }
}