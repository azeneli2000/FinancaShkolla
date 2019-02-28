using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace financa_shkolla.Account
{
    public partial class Pagesa_nxenesi_trans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
                vitiddl1.Text = gjej_vitin();
        }
        public string gjej_vitin()
        {
            if (DateTime.Now.Month >= 7)
                return (DateTime.Now.Year).ToString() + "-" + (DateTime.Now.Year + 1).ToString();
            else
                return
                 (DateTime.Now.Year - 1).ToString() + "-" + (DateTime.Now.Year).ToString();
        }

        protected void vitiddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Klasaddl.SelectedIndex = 0;
            Indeksiddl.SelectedIndex = 0;

            Nxenesi nxenesit = new Nxenesi();

            var nxensi_klasa = from c in financa_sh.Nxenesis
                               where (c.Klasa == Klasaddl.SelectedValue) && (c.Indeksi == Indeksiddl.SelectedValue) && (c.Viti_shkollor == vitiddl1.SelectedValue)
                               let emri = c.Emri
                               let mbiemri = c.Mbiemri

                               select new { c.Id_nxenesi, c.Emri, c.Mbiemri, em = emri + " " + mbiemri, c.Atesia, c.Memesia, c.Ditelindja, c.Nr_amza, c.Nr_tel };
            Nxenesiddl.DataSource = nxensi_klasa;
            Nxenesiddl.DataTextField = "em";
            Nxenesiddl.DataValueField = "Id_nxenesi";

            Nxenesiddl.DataBind();
            Atesialbl.Text = "";
            Memesialbl.Text = "";
            Amzalbl.Text = "";
            Tellbl.Text = "";
            kestelbl.Text = "";
           
        }

        protected void Klasaddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Indeksiddl.SelectedIndex = 0;

            DataClasses1DataContext financa_sh = new DataClasses1DataContext();

            Nxenesi nxenesit = new Nxenesi();
            var nxensi_klasa = from c in financa_sh.Nxenesis
                               where (c.Klasa == Klasaddl.SelectedValue) && (c.Indeksi == Indeksiddl.SelectedValue) && (c.Viti_shkollor == vitiddl1.SelectedValue)
                               let emri = c.Emri
                               let mbiemri = c.Mbiemri

                               select new { c.Id_nxenesi, c.Emri, c.Mbiemri, em = emri + " " + mbiemri, c.Atesia, c.Memesia, c.Ditelindja, c.Nr_amza, c.Nr_tel };
            Nxenesiddl.DataSource = nxensi_klasa;
            Nxenesiddl.DataTextField = "em";
            Nxenesiddl.DataValueField = "Id_nxenesi";
            Nxenesiddl.DataBind();
            Atesialbl.Text = "";
            Memesialbl.Text = "";
            Amzalbl.Text = "";
            Tellbl.Text = "";
            kestelbl.Text = "";
        }

        protected void Indeksiddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Nxenesi nxenesit = new Nxenesi();

            var nxensi_klasa = from c in financa_sh.Nxenesis
                               where (c.Klasa == Klasaddl.SelectedValue) && (c.Indeksi == Indeksiddl.SelectedValue) && (c.Viti_shkollor == vitiddl1.SelectedValue)
                               let emri = c.Emri
                               let mbiemri = c.Mbiemri

                               select new { c.Id_nxenesi, c.Emri, c.Mbiemri, em = emri + " " + mbiemri, c.Atesia, c.Memesia, c.Ditelindja, c.Nr_amza, c.Nr_tel };
            Nxenesiddl.DataSource = nxensi_klasa;
            Nxenesiddl.DataTextField = "em";
            Nxenesiddl.DataValueField = "Id_nxenesi";

            Nxenesiddl.DataBind();
            if (Nxenesiddl.Text != "")
            { //vendos gjeneralitetet
                Atesialbl.Text = "ATESIA  : " + nxensi_klasa.FirstOrDefault().Atesia.ToString();
                Memesialbl.Text = "MEMESIA  : " + nxensi_klasa.FirstOrDefault().Memesia.ToString();
                Tellbl.Text = "TEL  : " + nxensi_klasa.FirstOrDefault().Nr_tel.ToString();
                Amzalbl.Text = "AMZA  : " + nxensi_klasa.FirstOrDefault().Nr_amza.ToString();

                //shikon nqs ka keste
                if (ka_keste(Convert.ToInt64(Nxenesiddl.SelectedValue)) == false)
                {
                    kestelbl.Text = "Nxenesi nuk i jane konfiguruar kestet !";
                    kestelbl.ForeColor = System.Drawing.Color.Red;

                }
                else
                    bind();
            }
            else
            {
                kestelbl.Text = "";
              
                Atesialbl.Text = "";
                Memesialbl.Text = "";
                Amzalbl.Text = "";
                Tellbl.Text = "";
            }
        }




        protected bool ka_keste(Int64 ID)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Kestet nx_keste = new Kestet();
            Transporti nx_tr = new Transporti();
            var nx_trans = from c in financa_sh.Transportis
                       where (c.Id_nxenesi == ID)
                       select new { c.Id_nxenesi };
            if (nx_trans.Count() == 0)
                return false;
            else
                return true;


        }

        protected bool ka_pagesa(Int64 id)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Kestet sk = new Kestet();
            Transporti nx_tr = new Transporti();
            var s_nxenesi = from c in financa_sh.Transportis
                            where (c.Id_nxenesi == id) && (c.Paguar == true)
                            select new { c.Id_nxenesi };
            if (s_nxenesi.Count() == 0)
                return true;
            else
                return false;


        }

        protected void bind()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Kestet k = new Kestet();
            Pagesa p = new Pagesa();
            //var pag_n = from c in financa_sh.Kestets
            //            from d in financa_sh.Pagesas
                        
            //            where (c.Id_nxenesi.ToString() == Nxenesiddl.SelectedValue) && (c.Id_pagesa == d.Id_pagesa)
            //            select new 
            //            {
            //                d.Id_pagesa,
            //                d.Data,
            //                d.Totali,
            //                d.Monedha,
            //                d.Skonto,
            //                d.Penaliteti,
            //                tr = (from t in  financa_sh.Arkas 
            //                     where (t.Id_transaksioni == d.Id_transaksioni)
            //                     select t).FirstOrDefault().Koment.ToString().Remove(0,7)
                                 
                                
            //            };

            var pag_n = from c in financa_sh.Transportis
                        from d in financa_sh.Pagesas
                        where (c.Id_nxenesi.ToString() == Nxenesiddl.SelectedValue) && (c.Id_pagesa == d.Id_pagesa) && (d.Anulluar == false)
                        select new { d.Id_pagesa, d.Data, d.Totali, d.Monedha, d.Skonto, d.Penaliteti, d.Nr_kestesh,d.Koment, tr = (from t in  financa_sh.Arkas
                                                                                                                                    where (t.Id_transaksioni == d.Id_transaksioni)
                                                                                                                                    select t).FirstOrDefault().Vendndodhja.ToString()
                        };

                        GridView1.DataSource=pag_n.Distinct();
                        GridView1.DataBind();

        }

        protected void Nxenesiddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Nxenesi nxenesit = new Nxenesi();
            Nxenesiddl.DataBind();
             var nxenesi_id = from c in financa_sh.Nxenesis
                             where (c.Id_nxenesi.ToString() == Nxenesiddl.SelectedValue)
                             select new { c.Atesia, c.Memesia, c.Ditelindja, c.Nr_amza, c.Nr_tel };

            if (Nxenesiddl.Text != "")
            {
                //vendos gjeneralitetet
                Atesialbl.Text = "ATESIA  : " + nxenesi_id.FirstOrDefault().Atesia.ToString();
                Memesialbl.Text = "MEMESIA  : " + nxenesi_id.FirstOrDefault().Memesia.ToString();
                Tellbl.Text = "TEL  : " + nxenesi_id.FirstOrDefault().Nr_tel.ToString();
                Amzalbl.Text = "AMZA  : " + nxenesi_id.FirstOrDefault().Nr_amza.ToString();
              
            
           

                //shikon nqs ka keste
                if (ka_keste(Convert.ToInt64(Nxenesiddl.SelectedValue)) == false)
                {
                    kestelbl.Text = "Nxenesi nuk i jane konfiguruar kestet !";
                    kestelbl.ForeColor = System.Drawing.Color.Red;
                    bind();

                }
                else
                {
                    bind();
                    kestelbl.Text = "";
                }
            }
        
        }

        protected void Nxenesiddl_DataBound(object sender, EventArgs e)
        {

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.PagerSettings.Visible = false;

          //  GridView1.DataBind();

            StringWriter sw = new StringWriter();

            HtmlTextWriter hw = new HtmlTextWriter(sw);

            GridView1.RenderControl(hw);

            string gridHTML = sw.ToString().Replace("\"", "'")

                .Replace(System.Environment.NewLine, "");

            StringBuilder sb = new StringBuilder();

            sb.Append("<script type = 'text/javascript'>");

            sb.Append("window.onload = new function(){");
           
            sb.Append("var printWin = window.open('', '', 'left=0");

            sb.Append(",top=0,width=1000,height=600,status=0');");

            sb.Append("printWin.document.write(\"");
            //******
            sb.Append("PAGESA PER TRANSPORTIN<br><br>");
            sb.Append("Viti shkollor : ");
            sb.Append(vitiddl1.SelectedItem.Text);
            sb.Append("<br><br>");
            sb.Append("NXENESI : ");
            sb.Append(Nxenesiddl.SelectedItem.Text);
            sb.Append("<br>");
          
            sb.Append(gridHTML);

            sb.Append("\");");

            sb.Append("printWin.document.close();");

            sb.Append("printWin.focus();");

            sb.Append("printWin.print();");

            sb.Append("printWin.close();};");

            sb.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());

            GridView1.PagerSettings.Visible = true;

           // GridView1.DataBind();
        }


    }
}