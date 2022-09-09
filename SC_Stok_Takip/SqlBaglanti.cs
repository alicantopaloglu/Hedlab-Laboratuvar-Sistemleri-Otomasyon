using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace SC_Stok_Takip
{
    class SqlBaglanti
    {
        public SqlConnection baglanti()
        {

           SqlConnection baglan = new SqlConnection(@"Data Source=ALICAN\SQLEXPRESS;Initial Catalog=CLK_Stok_Takip;Integrated Security=True");
          //SqlConnection baglan = new SqlConnection(@"Data Source=192.168.10.6; Initial Catalog=SC_Stok_Takip; User ID=sa; Password=likomsa");
      

            baglan.Open();
            return baglan;
        }
    }
}
