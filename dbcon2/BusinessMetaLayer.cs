using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbcon2
{
    public class BusinessMetaLayer
    {
        static private BusinessMetaLayer m_instance = null;

        private BusinessMetaLayer() { }

        static public BusinessMetaLayer instance()
        {
            if (null == m_instance)
            {
                m_instance = new BusinessMetaLayer();
            }
            return m_instance;
        }

        // Could just have a set of static helper methods rather than a singleton!
        public List<Customer> getCustomers()
        {
            List<Customer> customers = new List<Customer>();

            DbConection con = DbFactory.instance();
            if (con.OpenConnection())
            {
                DbDataReader dr = con.Select("SELECT CUST_ID, cust_name, cust_address, cust_city FROM customers;");

                //Read the data and store them in the list
                while (dr.Read())
                {
                    Customer customer = new Customer();
                    customer.ID = dr.GetInt32(0);
                    customer.Name = dr.GetString(1);
                    customer.Address = dr.GetString(2);
                    customer.City = dr.GetString(3);
                    // etc.....

                    customers.Add(customer);
                }

                //close Data Reader
                dr.Close();
                con.CloseConnection();
            }

            return customers;
        }

        public List<Vendor> GetVendors()
        {
            List<Vendor> l_vendors = new List<Vendor>();

            DbConection l_connection = DbFactory.instance();
            if (l_connection.OpenConnection())
            {
                // Select all fields from vendor
                DbDataReader l_reader = l_connection.Select("SELECT * FROM customers;");

                //Read the data and store them in the list
                while (l_reader.Read())
                {
                    Vendor l_vendor = new Vendor();
                    l_vendor.ID = l_reader.GetInt32(0);
                    l_vendor.Name = l_reader.GetString(1);
                    l_vendor.Address = l_reader.GetString(2);
                    l_vendor.City = l_reader.GetString(3);
                    l_vendor.State = l_reader.GetString(4);
                    l_vendor.Zip = l_reader.GetString(5);
                    l_vendor.Country = l_reader.GetString(6);

                    l_vendors.Add(l_vendor);
                }

                //close Data Reader
                l_reader.Close();
                l_connection.CloseConnection();
            }

            return l_vendors;
        }
    }
}
