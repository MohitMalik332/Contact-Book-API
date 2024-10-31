using ContactBookAPI.Data_Access_Layer;
using ContactBookAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace ContactBookAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DbConnection _db;

        public ContactRepository()
        {
            _db = new DbConnection();
        }


        public List<Contact> GetAllContact()
        {
            List<Contact> contacts = new List<Contact>();
            using (SqlConnection conn = _db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("GetAllContacts", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    contacts.Add(new Contact
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString(),
                    });
                }
            }
            return contacts;
        }


        public Contact GetContactnById(int id)
        {
            Contact contact = null;
            using (SqlConnection conn = _db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("GetContactById", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    contact = new Contact
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }
            }
            return contact;
        }

        public void AddContact(Contact contact)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("AddContact", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Name", contact.Name);
                cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                cmd.Parameters.AddWithValue("@Email", contact.Email);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public bool UpdateContact(int id, Contact contact)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UpdateContact", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", contact.Name);
                cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                cmd.Parameters.AddWithValue("Email", contact.Email);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteContact(int id)
        {
            using (SqlConnection conn = _db.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("DeleteContact", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
