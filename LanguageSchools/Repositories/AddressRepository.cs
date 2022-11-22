using LanguageSchools.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace LanguageSchools.Repositories
{
    class AddressRepository : IAddressRepository
    {
        public void Add(Address address)
        {
            SqlConnection con1 = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select max(id) from Address;", con1);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
               int broj =  reader1.GetInt32(0);
                address.Id = broj;
            }
            reader1.Close();
            con1.Close();



            SqlConnection con = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Address VALUES (@street,@number,@city,@country);", con);
            cmd.Parameters.AddWithValue("@street",address.Street);
            cmd.Parameters.AddWithValue("@number", address.StreetNumber);
            cmd.Parameters.AddWithValue("@city", address.City);
            cmd.Parameters.AddWithValue("@country", address.Country);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public Address GetById(int id)
        {
            Address address = new Address();
            SqlConnection con2 = new SqlConnection("Data Source=MIHAJLO;Initial Catalog=baza_POP;Integrated Security=True");
            con2.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM Address where id = " + id.ToString() + ";", con2);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                address.Street = reader2["street"].ToString();
                address.StreetNumber = reader2["number"].ToString();
                address.City = reader2["city"].ToString();
                address.Country = reader2["country"].ToString();
            }

            con2.Close();
            reader2.Close();
            return address;
        }
    }
}
