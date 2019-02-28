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
    public partial class Pagesa_klasa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
                vitiddl1.Text = gjej_vitin();
            tot3 = 0;
            tot4 = 0;
            bind1();
        }
        public string gjej_vitin()
        {
            if (DateTime.Now.Month >= 7)
                return (DateTime.Now.Year).ToString() + "-" + (DateTime.Now.Year + 1).ToString();
            else
                return
                 (DateTime.Now.Year - 1).ToString() + "-" + (DateTime.Now.Year).ToString();
        }


        protected void bind1()
        {
          
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Kestet k = new Kestet();
            Nxenesi n = new Nxenesi();



            var nxenesit_keste_11 = from d in financa_sh.Nxenesis
                                   from c in financa_sh.Kestets
                                   where (c.Id_nxenesi == d.Id_nxenesi) && (d.Viti_shkollor == vitiddl1.SelectedItem.Text) 
                                   group c by new { d.Emri, d.Mbiemri, c.Vlera } into kestet_sum_1

                                   select new
                                   {

                                       emri1 = kestet_sum_1.Key.Emri,
                                       mbiemri1 = kestet_sum_1.Key.Mbiemri,
                                       keste_pa = kestet_sum_1.Count(x => x.Paguar == true),
                                       keste_paguar = kestet_sum_1.Count(x => ((x.Paguar == false) && (x.Aktiv == true))),
                                       vlera_paguar = kestet_sum_1.Key.Vlera * kestet_sum_1.Count(x => ((x.Paguar == false) && (x.Aktiv == true))),
                                       vlera_papag = kestet_sum_1.Key.Vlera * kestet_sum_1.Count(x => x.Paguar == true)
                                   };

            if (nxenesit_keste_11.Count() == 0)
                Label9.Text = "0";
            Label11.Text = "0";
            

            GridView2.DataSource = nxenesit_keste_11;
            GridView2.DataBind();





            //Label2.Text = Convert.ToString(kesti_kuq());
            //if (nxenesit_keste_1.Count() >= 0)
            //    Button1.Visible = true;
            //else
            //    Button1.Visible = false;

        }

        protected void bind()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Kestet k = new Kestet();
            Nxenesi n = new Nxenesi();
         


            var nxenesit_keste_1 = from d in financa_sh.Nxenesis
                                   from c in financa_sh.Kestets                                   
                                   where (c.Id_nxenesi == d.Id_nxenesi) && (d.Viti_shkollor == vitiddl1.SelectedItem.Text) && (d.Klasa == Klasaddl.SelectedItem.Text) && (d.Indeksi == Indeksiddl.SelectedItem.Text)
                                   group c by new {d.Emri, d.Mbiemri,c.Vlera} into kestet_sum_1
                                  
                                   select new
                                   {
                                      
                                       emri1=kestet_sum_1.Key.Emri,mbiemri1 = kestet_sum_1.Key.Mbiemri,
                                       keste_pa = kestet_sum_1.Count(x => x.Paguar == true),
                                       keste_paguar = kestet_sum_1.Count(x => ((x.Paguar == false) && (x.Aktiv == true))),
                                       vlera_paguar = kestet_sum_1.Key.Vlera * kestet_sum_1.Count(x => ((x.Paguar == false) && (x.Aktiv == true))),
                                       vlera_papag = kestet_sum_1.Key.Vlera * kestet_sum_1.Count(x => x.Paguar == true)
                                   };

           
                GridView1.DataSource = nxenesit_keste_1;
                GridView1.DataBind();
                if (GridView1.Rows.Count > 0)
                {
                    Label4.Visible = true;
                    Label5.Visible = true;
                    Label6.Visible = true;
                    Label7.Visible = true;
                    Button1.Visible = true;
                }
                else
                {
                    Button1.Visible = false;
                    Label4.Visible = false;
                    Label5.Visible = false;
                    Label6.Visible = false;
                    Label7.Visible = false;
                }




                Label2.Text = Convert.ToString(kesti_kuq());
               
        }
        protected void Indeksiddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind();
            
        }

        protected void vitiddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Klasaddl.SelectedIndex = 0;
            Indeksiddl.SelectedIndex = 0;
            tot3 = 0;
            tot4 = 0;
            bind();
            bind1();
        }

        protected void Klasaddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Indeksiddl.SelectedIndex = 0;
           bind();
        }

        protected int kesti_kuq()
        {
            DateTime s = Convert.ToDateTime("25/07/" + vitiddl1.Text.Remove(4, 5));
            //kestit te pare i ka kaluar data
            if (DateTime.Now > Convert.ToDateTime("25/07/"+ vitiddl1.Text.Remove(4,5)) && (DateTime.Now < Convert.ToDateTime("25/08/"+ vitiddl1.Text.Remove(4,5)))) //gusht
            {
                return 1;
            }
            if (DateTime.Now > Convert.ToDateTime("25/08/" + vitiddl1.Text.Remove(4, 5)) && (DateTime.Now < Convert.ToDateTime("25/09/" + vitiddl1.Text.Remove(4, 5))))//shtator
            {
                return 2;
            }
            if (DateTime.Now > Convert.ToDateTime("25/09/" + vitiddl1.Text.Remove(4, 5)) && (DateTime.Now < Convert.ToDateTime("25/10/" + vitiddl1.Text.Remove(4, 5))))//tetor
            {
                return 3;
            }
            if (DateTime.Now > Convert.ToDateTime("25/10/" + vitiddl1.Text.Remove(4, 5)) && (DateTime.Now < Convert.ToDateTime("25/11/" + vitiddl1.Text.Remove(4, 5))))//nentor
            {
                return 4;
            }
            if (DateTime.Now > Convert.ToDateTime("25/11/" + vitiddl1.Text.Remove(4, 5)) && (DateTime.Now < Convert.ToDateTime("25/12/" + vitiddl1.Text.Remove(4, 5))))//dhjetor
            {
                return 5;
            }
            //viti tjeter


            if (DateTime.Now > Convert.ToDateTime("25/12/" + vitiddl1.Text.Remove(4, 5)) && (DateTime.Now < Convert.ToDateTime("25/01/" + vitiddl1.Text.Remove(0, 5))))//janar
            {
                return 6;
            }
            if (DateTime.Now > Convert.ToDateTime("25/01/" + vitiddl1.Text.Remove(0, 5)) && (DateTime.Now < Convert.ToDateTime("25/02/" + vitiddl1.Text.Remove(0, 5))))//shkurt
            {
                return 7;
            }
            if (DateTime.Now > Convert.ToDateTime("25/02/" + vitiddl1.Text.Remove(0, 5)) && (DateTime.Now < Convert.ToDateTime("25/03/" + vitiddl1.Text.Remove(0, 5))))//mars
            {
                return 8;
            }
            if (DateTime.Now > Convert.ToDateTime("25/03/" + vitiddl1.Text.Remove(0, 5)) && (DateTime.Now < Convert.ToDateTime("25/04/" + vitiddl1.Text.Remove(0, 5))))//prill
            {
                return 9;
            }
            if (DateTime.Now > Convert.ToDateTime("25/04/" + vitiddl1.Text.Remove(0, 5)) && (DateTime.Now < Convert.ToDateTime("25/05/" + vitiddl1.Text.Remove(0, 5))))//maj
            {
                return 10;

            }

            return 0;
        }
        decimal tot,tot1 = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
              tot = tot + Convert.ToDecimal(e.Row.Cells[5].Text);
              Label4.Text = tot.ToString("# ##0.00");
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                tot1 = tot1 + Convert.ToDecimal(e.Row.Cells[4].Text);
                Label5.Text = tot1.ToString("# ##0.00");
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // determine the value of the UnitsInStock field
                int nr_keste =
                 Convert.ToInt32(DataBinder.Eval(e.Row.DataItem,
                 "keste_pa"));
                if (nr_keste  < kesti_kuq())
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.Green;
                    e.Row.ForeColor = System.Drawing.Color.White;
                    if (CheckBox1.Checked == true)
                        e.Row.Visible = false;
                } 

            }
           
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            bind();
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
            //********
            sb.Append("PAGESA PER SHKOLLEN<br><br>");
            sb.Append("Viti shkollor : ");
            sb.Append(vitiddl1.SelectedItem.Text);
            sb.Append("<br><br>");
            sb.Append("KLASA : ");
            sb.Append(Klasaddl.SelectedItem.Text);
            sb.Append(Indeksiddl.SelectedItem.Text);
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
        decimal tot3, tot4 = 0;
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label8.Visible = true;
            Label9.Visible = true;
            Label11.Visible = true;
            Label10.Visible = true;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                tot3 = tot3 + Convert.ToDecimal(e.Row.Cells[5].Text);
                Label9.Text = tot3.ToString("# ##0.00");
            }
           

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                tot4 = tot4 + Convert.ToDecimal(e.Row.Cells[4].Text);
                Label11.Text = tot4.ToString("# ##0.00");
            }
          
        }

     

      

    }
}