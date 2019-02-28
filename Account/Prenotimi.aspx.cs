using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace financa_shkolla.Account
{
    public partial class Prenotimi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                vitiddl0.Text = gjej_vitin();
                bind();
            }
                 
        }

        public string gjej_vitin()
        {
            if (DateTime.Now.Month >= 7)
                return (DateTime.Now.Year).ToString() + "-" + (DateTime.Now.Year + 1).ToString();
            else
                return
                 (DateTime.Now.Year - 1).ToString() + "-" + (DateTime.Now.Year).ToString();
        }

        //lidh tabelen  ne db me gridview
        public void bind()

        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Nxenesi nxenesit = new Nxenesi();
            
            var nxensi_klasa = from c in financa_sh.Nxenesis
                               from d in financa_sh.Prenotimis
                               where (c.Klasa == DropDownList1.SelectedValue) && (c.Indeksi == DropDownList2.SelectedValue) && (c.Viti_shkollor == vitiddl0.SelectedValue) && (c.Id_nxenesi == d.Id_nxenesi)
                               select new
                               {
                                   c.Id_nxenesi,
                                   c.Emri,
                                   c.Mbiemri,   
                                   d.Paguar                        
                               };


            GridView1.DataSource = nxensi_klasa;

            GridView1.Columns[3].Visible = true;
            GridView1.DataBind();
            GridView1.Columns[3].Visible = false;
            
        }




       


        protected int cmimi_pren()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Cmimet cm = new Cmimet();
            var cp = from c in financa_sh.Cmimets
                     where (c.Klasa ==Convert.ToInt16(DropDownList1.SelectedItem.Text)) && (c.Viti_shkollor == vitiddl0.SelectedItem.Text)
                     select c;
           
            if (cp.Count()== 0)
                return 0;
            else
                return cp.FirstOrDefault().Prenotimi;
        
        }

        protected string Valuta_pren()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Cmimet cm = new Cmimet();
            var cp = from c in financa_sh.Cmimets
                     where (c.Klasa == Convert.ToInt16(DropDownList1.SelectedItem.Text))&&(c.Viti_shkollor == vitiddl0.SelectedItem.Text)
                     select c;
            return cp.FirstOrDefault().Valuta_prenotimi.Trim();

        }

        //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridView1.EditIndex = e.NewEditIndex;
        //    bind();
        //}

        protected void msbox(string msg)
        {
            //string message = "Hello! Mudassar.";

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<script type = 'text/javascript'>");

            sb.Append("window.onload=function(){");

            sb.Append("alert('");

            sb.Append(msg);

            sb.Append("')};");

            sb.Append("</script>");

           Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", sb.ToString(),true);
        }


        protected void msbox1(string msg)
        {
            //string message = "Hello! Mudassar.";

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");

            sb.Append("return confirm('");

            sb.Append(msg);

            sb.Append("')};");

            sb.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(), "CheckBox1", sb.ToString());
        }

        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    long id = Convert.ToInt64(GridView1.DataKeys[e.RowIndex].Value);
        //    DataClasses1DataContext financa_sh = new DataClasses1DataContext();
        //    Prenotimi nxenesit = new Prenotimi();
        //    Pagesa pag = new Pagesa();
        //    Arka a = new Arka();
        //    if (cmimi_pren() > 0)
        //    {
        //        if (Convert.ToBoolean(((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox1")).Checked) == false)
        //        {
        //            msbox("Per te hequr prenotimin duhet te anulloni faturen perkatese !");
        //            GridView1.EditIndex = -1;
        //            bind();
        //            return;
        //        }
        //        var pr_id = financa_sh.Prenotimis.Single
        //                      (p => p.Id_nxenesi == id);

        //        pr_id.Paguar = Convert.ToBoolean(((CheckBox)GridView1.Rows[e.RowIndex].FindControl("CheckBox1")).Checked);
        //        financa_sh.SubmitChanges();
        //        // insert te tabela e arkes
        //        var vlera_fundit = from t in financa_sh.Arkas
        //                           orderby t.Id_transaksioni descending
        //                           select new { t.Tot_E, t.Tot_L, t.Tot_S };
        //        if (Valuta_pren() == "EUR")
        //        {
        //            a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E + cmimi_pren();
        //            a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L + 0;
        //            a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S + 0;
        //        }
        //        if (Valuta_pren() == "USD")
        //        {
        //            a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S + cmimi_pren();
        //            a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L + 0;
        //            a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E + 0;
        //        }
        //        if (Valuta_pren() == "LEK")
        //        {
        //            a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L + cmimi_pren();
        //            a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E + 0;
        //            a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S + 0;
        //        }
        //        a.Vendndodhja = "Cash";
        //        a.Data = DateTime.Now;
        //        a.Modifikuar_nga = HttpContext.Current.User.Identity.Name;
        //        a.Vlera = cmimi_pren();
        //        a.Valuta = Valuta_pren();
        //        a.Koment = "Pagese prenotimi shkolla.";
        //        financa_sh.Arkas.InsertOnSubmit(a);
        //        financa_sh.SubmitChanges();

        //        // gjej id e  transaksionit e fundit
        //        var tr_fundit = from t in financa_sh.Arkas
        //                        orderby t.Id_transaksioni descending
        //                        select t.Id_transaksioni;

        //        //insert te tabela e pageses
        //        pag.Data = DateTime.Now;
        //        pag.Monedha = Valuta_pren();
        //        pag.Totali = cmimi_pren();
        //        pag.Skonto = 0;
        //        pag.Penaliteti = 0;
        //        pag.Id_transaksioni = tr_fundit.FirstOrDefault();
        //        pag.Nr_kestesh = 0;
        //        pag.Koment = "Pagese prenotimi";
        //        pag.Anulluar = false;

        //        financa_sh.Pagesas.InsertOnSubmit(pag);
        //        financa_sh.SubmitChanges();

        //        //insert te tabela se prenotimit 
        //        var pg_fundit = from t in financa_sh.Pagesas
        //                        orderby t.Id_pagesa descending
        //                        select t.Id_pagesa;

        //        var nx_p = from c in financa_sh.Prenotimis
        //                   where (c.Id_nxenesi == id)
        //                   select c;
        //        int count = 0;
        //        foreach (var d in nx_p)
        //        {
        //            CheckBox chbTemp = GridView1.Rows[count].FindControl("CheckBox1") as CheckBox;
        //            if (chbTemp.Checked)
        //            {
        //                d.Paguar = true;
        //                d.Id_pagesa = pg_fundit.FirstOrDefault();
        //            }
        //            count = count + 1;
        //        }
        //        financa_sh.SubmitChanges();



        //        GridView1.EditIndex = -1;
        //        bind();

        //    }
        //    else msbox("Klases nuk i jane konfiguruar cmimet per vitin shkollor perkates !");
        //}

        //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    e.Cancel = true;
        //    GridView1.EditIndex = -1;
        //    bind();        
        //}

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //bool myObj = (bool)e.Row.DataItem;
                
                    CheckBox cb = (CheckBox)e.Row.FindControl("CheckBox1");
                   if( cb.Checked == false)
                   {
                       cb.Enabled = true;
                    e.Row.BackColor = System.Drawing.Color.Crimson;
                    e.Row.ForeColor = System.Drawing.Color.White;



                }
                else
                {
                    cb.Enabled = false;
                    e.Row.BackColor = System.Drawing.Color.MediumSeaGreen;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }

              


            }
        }

        protected void vitiddl0_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList1.SelectedIndex = 0;
            DropDownList2.SelectedIndex = 0;
            bind();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.SelectedIndex = 0;
            bind();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind();
        }

        protected void CheckBox1_CheckedChanged1(object sender, EventArgs e)
        {

            long id;
            bool pag_tru;
            bool chk_enabled;
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();


         //   String scriptText =
         //"return confirm('Do you want to submit the page?')";
         //   ClientScript.RegisterOnSubmitStatement(this.GetType(),
         //       "alert", scriptText);

            msbox1("aaa");

            if (cmimi_pren() > 0)
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    Prenotimi nxenesit = new Prenotimi();
                    Pagesa pag = new Pagesa();
                    Arka a = new Arka();
                   

                    id = Convert.ToInt64((GridView1.Rows[i].Cells[3].Text).ToString());
                    var pr_id = financa_sh.Prenotimis.Single
                                               (p => p.Id_nxenesi == id);
                    pr_id.Paguar = Convert.ToBoolean(((CheckBox)GridView1.Rows[i].FindControl("CheckBox1")).Checked);// paguan kestet qe jane checked dhe pag = false per ato qe sjane te checkuara
                    pag_tru = pr_id.Paguar;
                    chk_enabled = Convert.ToBoolean(((CheckBox)GridView1.Rows[i].FindControl("CheckBox1")).Enabled);
                    financa_sh.SubmitChanges();

                    if (pag_tru && chk_enabled) 
                    {
                        // insert te tabela e arkes
                        var vlera_fundit = from t in financa_sh.Arkas
                                           orderby t.Id_transaksioni descending
                                           select new { t.Tot_E, t.Tot_L, t.Tot_S };
                        if (Valuta_pren() == "EUR")
                        {
                            a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E + cmimi_pren();
                            a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L + 0;
                            a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S + 0;
                        }
                        if (Valuta_pren() == "USD")
                        {
                            a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S + cmimi_pren();
                            a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L + 0;
                            a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E + 0;
                        }
                        if (Valuta_pren() == "LEK")
                        {
                            a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L + cmimi_pren();
                            a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E + 0;
                            a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S + 0;
                        }
                        a.Vendndodhja = "Cash";
                        a.Data = DateTime.Now;
                        a.Modifikuar_nga = HttpContext.Current.User.Identity.Name;
                        a.Vlera = cmimi_pren();
                        a.Valuta = Valuta_pren();
                        a.Koment = "Pagese prenotimi shkolla.";
                        financa_sh.Arkas.InsertOnSubmit(a);
                        financa_sh.SubmitChanges();

                        // gjej id e  transaksionit e fundit
                        var tr_fundit = from t in financa_sh.Arkas
                                        orderby t.Id_transaksioni descending
                                        select t.Id_transaksioni;

                        //insert te tabela e pageses
                        pag.Data = DateTime.Now;
                        pag.Monedha = Valuta_pren();
                        pag.Totali = cmimi_pren();
                        pag.Skonto = 0;
                        pag.Penaliteti = 0;
                        pag.Id_transaksioni = tr_fundit.FirstOrDefault();
                        pag.Nr_kestesh = 0;
                        pag.Koment = "Pagese prenotimi";
                        pag.Anulluar = false;

                        financa_sh.Pagesas.InsertOnSubmit(pag);
                        financa_sh.SubmitChanges();

                        // gjej id e  pag e fundit
                        var pg_fundit = from t in financa_sh.Pagesas
                                        orderby t.Id_pagesa descending
                                        select t.Id_pagesa;
                        var pren = from c in financa_sh.Prenotimis
                                   where (c.Id_nxenesi == id)
                                   select c;
                        foreach (var d in pren)
                            d.Id_pagesa = pg_fundit.FirstOrDefault();
                        financa_sh.SubmitChanges();
                    }
                
                }

                  
             

                
              
            

                //insert te tabela se prenotimit 
                //var pg_fundit = from t in financa_sh.Pagesas
                //                orderby t.Id_pagesa descending
                //                select t.Id_pagesa;

                //var nx_p = from c in financa_sh.Prenotimis
                //           where (c.Id_nxenesi == id)
                //           select c;
                //int count = 0;
                //foreach (var d in nx_p)
                //{
                //    CheckBox chbTemp = GridView1.Rows[count].FindControl("CheckBox1") as CheckBox;
                //    if (chbTemp.Checked)
                //    {
                //        d.Paguar = true;
                //        d.Id_pagesa = pg_fundit.FirstOrDefault();
                //    }
                //    count = count + 1;
                //}
                //financa_sh.SubmitChanges();



                GridView1.EditIndex = -1;
                bind();

            }
            else msbox("Klases nuk i jane konfiguruar cmimet per vitin shkollor perkates !");
        }

     

      
    }
}