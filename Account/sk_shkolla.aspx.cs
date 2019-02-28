using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace financa_shkolla.Account
{
    public partial class sk_shkolla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void bind()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Skonto sk = new Skonto();
            Nxenesi nx = new Nxenesi();


            var sk_nx = from c in financa_sh.Skontos
                        from c1 in financa_sh.Nxenesis
                        from c2 in financa_sh.Kestets
                        where (c1.Id_nxenesi == c.Id_nxenesi) && (c1.Viti_shkollor == vitiddl1.SelectedItem.Text) && (c2.Id_nxenesi == c.Id_nxenesi)
                        //group c by new { c1.Id_nxenesi, c1.Emri, c1.Mbiemri, c2.Vlera, c.Ulje_1, c.Ulje_2, c.Ulje_3, c.Ulje_4, c.Ulje_5, c.Ulje_6, c.Ulje_7, c.Ulje_8, c.Ulje_9, c.Ulje_10, c.Ulje_11, c.Ulje_12 }
                        //    into r
                        //    select new {convert.to r.Key.Ulje_1.Value.ToString()*10};
                        select new { c1.Id_nxenesi, c1.Emri, c1.Mbiemri, c2.Vlera, s1 = c.Ulje_1 * c2.Vlera /10, c.Ulje_2, c.Ulje_3, c.Ulje_4, c.Ulje_5, c.Ulje_6, c.Ulje_7, c.Ulje_8, c.Ulje_9, c.Ulje_10, c.Ulje_11, c.Ulje_12 };

            GridView1.DataSource = sk_nx.Distinct();
            GridView1.DataBind();

           

        }

        protected void vitiddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind();
        }

    }
}