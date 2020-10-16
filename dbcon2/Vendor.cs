using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbcon2
{
    public class Vendor
    {
        private int m_vend_id;
        public int ID { get { return m_vend_id; } set { m_vend_id = value; } }

        private string m_vend_name;
        public string Name { get { return m_vend_name; } set { m_vend_name = value; } }

        private string m_vend_address;
        public string Address { get { return m_vend_address; } set { m_vend_address = value; } }

        private string m_vend_city;
        public string City { get { return m_vend_city; } set { m_vend_city = value; } }

        private string m_vend_state;
        public string State { get { return m_vend_state; } set { m_vend_state = value; } }
        private string m_vend_zip;
        public string Zip { get { return m_vend_zip; } set { m_vend_zip = value; } }

        private string m_vend_country;
        public string Country { get { return m_vend_country; } set { m_vend_country = value; } }

        public override string ToString()
        {
            return m_vend_id + ", " + m_vend_name;
        }

    }
}
