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
    public partial class Pagesa_nxenesi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Page.IsPostBack == false)
                vitiddl1.Text = gjej_vitin();

        }



        public decimal gjej_kestin()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Kestet nxenesi_kest = new Kestet();
            decimal kesti=0;
            var nxenesi_k = from c in financa_sh.Kestets
                            where (c.Id_nxenesi.ToString() == Nxenesiddl.SelectedValue)
                            select new { c.Vlera };
            if (nxenesi_k.Count() > 0)
            {
                kesti = nxenesi_k.FirstOrDefault().Vlera;
                return kesti;
            }
            else
                return 0;
        }

        public decimal gjej_pren()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Cmimet nxenesi_kest = new Cmimet();
            int kesti = 0;
            var nxenesi_k1 = from c in financa_sh.Cmimets
                            where (c.Klasa.ToString() == Klasaddl.SelectedValue) && (c.Viti_shkollor == vitiddl1.SelectedValue)
                            select new { c.Prenotimi };
            if (nxenesi_k1.Count() > 0)
            {
                kesti = nxenesi_k1.FirstOrDefault().Prenotimi;
                return kesti;
            }
            else
                return 0;
            
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
                if ((ka_keste(Convert.ToInt64(Nxenesiddl.SelectedValue)) == false) && (ka_prenotim(Convert.ToInt64(Nxenesiddl.SelectedValue)) == false))
                {
                    kestelbl.Text = "Nxenesi nuk ka pagesa  !";
                    kestelbl.ForeColor = System.Drawing.Color.Red;

                }
                else
                {
                    bind();
                //  Label4.Text= gjej_kestin().ToString();
                  //Label6.Text = (Convert.ToDecimal(Label4.Text) * Convert.ToDecimal(Label5.Text)).ToString();
                }
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
            var nx_k = from c in financa_sh.Kestets
                       where (c.Id_nxenesi == ID)
                       select new { c.Id_nxenesi };
            if (nx_k.Count() == 0)
                return false;
            else
                return true;


        }

        protected bool ka_pagesa(Int64 id)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Kestet sk = new Kestet();
            var s_nxenesi = from c in financa_sh.Kestets
                            where (c.Id_nxenesi == id) && (c.Paguar == true)
                            select new { c.Id_nxenesi };
            if (s_nxenesi.Count() == 0)
                return true;
            else
                return false;


        }

        protected bool ka_prenotim(Int64 id)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Kestet sk = new Kestet();
            var s_nxenesi = from c in financa_sh.Prenotimis
                            where (c.Id_nxenesi == id) && (c.Paguar == false)
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
            GridView1.SelectedIndex = -1;

            var pag_n = from c in financa_sh.Kestets
                        from d in financa_sh.Pagesas
                        from pg in financa_sh.Prenotimis
                        where ((c.Id_nxenesi.ToString() == Nxenesiddl.SelectedValue) && (c.Id_pagesa == d.Id_pagesa) && (d.Anulluar == false)) || ((pg.Id_pagesa == d.Id_pagesa) && (pg.Id_nxenesi == Convert.ToInt64(Nxenesiddl.SelectedItem.Value)))
                        select new { d.Id_pagesa, d.Data, d.Totali, d.Monedha, d.Skonto, d.Penaliteti, d.Nr_kestesh,d.Koment, tr = (from t in  financa_sh.Arkas
                                                                                                                                    where (t.Id_transaksioni == d.Id_transaksioni)
                                                                                                                                    select t).FirstOrDefault().Vendndodhja.ToString()
                        };

                        GridView1.DataSource=pag_n.Distinct();
                        GridView1.DataBind();

                        if (GridView1.Rows.Count == 0)
                        {
                            Label6.Visible = false;
                            Label8.Visible = false;
                        }
                        else
                        {
                            Label6.Visible = true;
                            Label8.Visible = true;
                        }
                        
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
                if ((ka_keste(Convert.ToInt64(Nxenesiddl.SelectedValue)) == false) && (ka_prenotim(Convert.ToInt64(Nxenesiddl.SelectedValue)) == false)) 
                {
                    kestelbl.Text = "Nxenesi nuk ka pagesa !";
                    kestelbl.ForeColor = System.Drawing.Color.Red;
                    bind();
                   

                }
                else
                {
                    bind();
                    //Label4.Text = gjej_kestin().ToString();
                   // Label6.Text = (Convert.ToDecimal(Label4.Text) * Convert.ToDecimal(Label5.Text)).ToString();
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
            sb.Append("PAGESA PER SHKOLLEN<br><br>");
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
        int tot3= 0;
        decimal tot4;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Label4.Visible = true;
            //Label5.Visible = true;
            //Label6.Visible = true;
            //Label7.Visible = true;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                tot3 = tot3 + Convert.ToInt16(e.Row.Cells[5].Text);
                
                //Label5.Text = tot3.ToString("# ##0.00");
            }
            tot4 = (gjej_kestin()*10) - (tot3 * gjej_kestin());
            Label6.Text = tot4.ToString();

            
        }
       

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button clicked 
                // by the user from the Rows collection.
                GridViewRow row = GridView1.Rows[index];
               string nr_fat =  GridView1.Rows[index].Cells[0].Text;
               string data = GridView1.Rows[index].Cells[1].Text;
               string totali = GridView1.Rows[index].Cells[2].Text;
               string valuta = GridView1.Rows[index].Cells[3].Text;
               string nr_keste = GridView1.Rows[index].Cells[5].Text;
               string ulje = GridView1.Rows[index].Cells[6].Text;
               string pen = GridView1.Rows[index].Cells[7].Text;
               string vlera_kesti="0";
                if (Convert.ToDecimal(pen) == 0 && Convert.ToDecimal(ulje) > 0)
               {

                   vlera_kesti = (Convert.ToDecimal(totali) / (1 - Convert.ToDecimal(ulje) / 100) ).ToString();
               }

                if (Convert.ToDecimal(pen) > 0 && Convert.ToDecimal(ulje) == 0)
                {

                    vlera_kesti = (Convert.ToDecimal(totali) / (1 + Convert.ToDecimal(pen) / 100)).ToString();
                }
                if (Convert.ToDecimal(pen) == 0 && Convert.ToDecimal(ulje) == 0)
                {

                    vlera_kesti = (Convert.ToDecimal(totali)).ToString();
                }



            GridView1.PagerSettings.Visible = false;

            //  GridView1.DataBind();

            StringWriter sw = new StringWriter();

            HtmlTextWriter hw = new HtmlTextWriter(sw);

            // GridView1.RenderControl(hw);

            string gridHTML = sw.ToString().Replace("\"", "'")

                .Replace(System.Environment.NewLine, "");

            StringBuilder sb = new StringBuilder();

            sb.Append("<script type = 'text/javascript'>");

            sb.Append("window.onload = new function(){");

            sb.Append("var printWin = window.open('', '', 'left=0");

            sb.Append("left = 0,top=0,scrollbars=0,status=0');");

            sb.Append("printWin.document.write(\"");
            //******
            sb.Append(data);
            sb.Append("<br>");            
            sb.Append("Nr : ");
            sb.Append(nr_fat);
            sb.Append("<br>");

            sb.Append("&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<b><u>MANDAT ARKETIMI</u></b>");
            sb.Append("<br><br>");
        
            sb.Append("Nxenesi : ");
            sb.Append(Nxenesiddl.SelectedItem.Text);
            sb.Append("<br>");
            sb.Append("Numer kestesh : ");
            sb.Append(nr_keste);
            sb.Append("<br>");
            sb.Append("Vlera : ");
            sb.Append(vlera_kesti);
            sb.Append(" ");
            sb.Append(valuta);
            sb.Append("<br>");
            sb.Append("Skonto : ");
            sb.Append(ulje);
            sb.Append(" %");
            sb.Append("<br>");
            sb.Append("Kamata : ");
            sb.Append(pen);
            sb.Append(" %");
            sb.Append("<br>");            
            sb.Append("<b>TOTALI : ");
            sb.Append(totali); sb.Append("</b>");
            sb.Append(" "); 
            sb.Append(valuta); 

            sb.Append("<br><br>");
            sb.Append("Financieri : ");
            sb.Append(HttpContext.Current.User.Identity.Name);
            sb.Append("&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspPrindi");
            sb.Append("<br><br><br>");
            sb.Append("<b>_______________");
            sb.Append("&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp");
            sb.Append("_______________");
            sb.Append("<br>");
            sb.Append("<br>");


            // sb.Append(gridHTML);

            sb.Append("\");");

            sb.Append("printWin.document.close();");

            sb.Append("printWin.focus();");

            sb.Append("printWin.print();");

            sb.Append("printWin.close();};");

            sb.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(), "FaturaPrint", sb.ToString());

            GridView1.PagerSettings.Visible = true;

           



            }
          
        }


    }
}