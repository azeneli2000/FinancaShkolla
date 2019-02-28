using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace financa_shkolla.Account
{
    public partial class Nxenesit : System.Web.UI.Page
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

        //lidh tabelen nxenesit ne db me gridview
        public void bind()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Nxenesi nxenesit = new Nxenesi();

            var nxensi_klasa = from c in financa_sh.Nxenesis
                               where (c.Klasa == DropDownList1.SelectedValue) && (c.Indeksi == DropDownList2.SelectedValue) && (c.Viti_shkollor == vitiddl0.SelectedValue)
                               select new
                               {
                                   c.Id_nxenesi,
                                   c.Emri,
                                   c.Mbiemri,
                                   c.Atesia,
                                   c.Memesia,
                                   c.Ditelindja,
                                   c.Nr_amza,
                                   c.Nr_tel,
                                   c.Viti_shkollor,
                                   c.Klasa,
                                   c.Indeksi,
                                  trans = (from t in financa_sh.Transportis
                                           where (c.Id_nxenesi == t.Id_nxenesi)
                                           group t by t into nr
                                           select nr.Count().Equals(0))
                               };


            GridView1.DataSource = nxensi_klasa;
            GridView1.DataBind();
        }

       

    
    

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            GridView1.EditIndex = -1;
            bind();        
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            long id = Convert.ToInt64(GridView1.DataKeys[e.RowIndex].Value);
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Nxenesi nxenesit = new Nxenesi();

            var nxensi_id = financa_sh.Nxenesis.Single
                              (p => p.Id_nxenesi == id);
            nxensi_id.Emri = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox5")).Text);
            nxensi_id.Mbiemri = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox6")).Text);
            nxensi_id.Atesia = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox7")).Text);
            nxensi_id.Memesia = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox8")).Text);
            nxensi_id.Ditelindja = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox33")).Text);
            nxensi_id.Nr_amza = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2")).Text);//****
            nxensi_id.Nr_tel = Convert.ToString(((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox9")).Text);
            nxensi_id.Viti_shkollor = Convert.ToString(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("vitiddl")).SelectedItem.Text);
            nxensi_id.Klasa = Convert.ToString(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList11")).SelectedItem.Text);
            nxensi_id.Indeksi = Convert.ToString(((DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList22")).SelectedItem.Text);
            financa_sh.SubmitChanges();
            GridView1.EditIndex = -1;
            bind();

        }



        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            long id = Convert.ToInt64(GridView1.DataKeys[e.RowIndex].Value);
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            if (ka_pagesa(id) == false)
            {
                var nxensi_id = financa_sh.Nxenesis.Single
                                  (p => p.Id_nxenesi == id);
                financa_sh.Nxenesis.DeleteOnSubmit(nxensi_id);
                financa_sh.SubmitChanges();
                // fshin prenotimin
                var nxensi_id_p = financa_sh.Prenotimis.Single
                                    (p => p.Id_nxenesi == id);
                financa_sh.Nxenesis.DeleteOnSubmit(nxensi_id);
                financa_sh.SubmitChanges();

                bind();
            }

            else
                msbox("Nxenesi nuk mund te fshihet pasi i jane konfiguruar kestet per kete vit shkollor !");
                    
               

        }


        protected bool ka_pagesa(long id_nx)
    {
        DataClasses1DataContext financa_sh = new DataClasses1DataContext();
        Nxenesi nxenesit = new Nxenesi();
        Skonto sk = new Skonto();
        Transporti tr = new Transporti();
        bool ka_trans, ka_keste,ka_prenotim;
            var trans = from c in financa_sh.Transportis
                    where (c.Id_nxenesi == id_nx)
                    select c;
            if (trans.Count() == 0)
                ka_trans = false;
            else
                ka_trans = true;

            var ka_skonto = from c in financa_sh.Skontos
                        where (c.Id_nxenesi == id_nx)
                        select c;
            if (ka_skonto.Count() == 0)
                ka_keste = false;
            else
                ka_keste = true;

            var prenotim = from c in financa_sh.Prenotimis
                            where (c.Id_nxenesi == id_nx)
                            select c;
            if (prenotim.FirstOrDefault().Paguar == false)
                ka_prenotim = false;
            else
                ka_prenotim = true;

            return (ka_keste || ka_trans|| ka_prenotim);



    }

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

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Nxenesi nxenesit = new Nxenesi();
            Prenotimi p = new Prenotimi();
            if (e.CommandName.Equals("Insert"))
            {
                nxenesit.Emri = Convert.ToString(((TextBox)GridView1.FooterRow.FindControl("TextBox5")).Text);
                nxenesit.Mbiemri = Convert.ToString(((TextBox)GridView1.FooterRow.FindControl("TextBox6")).Text);
                nxenesit.Atesia = Convert.ToString(((TextBox)GridView1.FooterRow.FindControl("TextBox7")).Text);
                nxenesit.Memesia = Convert.ToString(((TextBox)GridView1.FooterRow.FindControl("TextBox8")).Text);
                nxenesit.Ditelindja = Convert.ToString(((TextBox)GridView1.FooterRow.FindControl("TextBox33")).Text);
                nxenesit.Nr_amza = Convert.ToString(((TextBox)GridView1.FooterRow.FindControl("TextBox2")).Text);
                nxenesit.Nr_tel = Convert.ToString(((TextBox)GridView1.FooterRow.FindControl("TextBox9")).Text);
                
                nxenesit.Viti_shkollor = Convert.ToString(((DropDownList)GridView1.FooterRow.FindControl("vitiddl")).SelectedItem.Text);
                nxenesit.Klasa = Convert.ToString(((DropDownList)GridView1.FooterRow.FindControl("DropDownList11")).SelectedItem.Text);
                nxenesit.Indeksi = Convert.ToString(((DropDownList)GridView1.FooterRow.FindControl("DropDownList22")).SelectedItem.Text);
                financa_sh.Nxenesis.InsertOnSubmit(nxenesit);
                financa_sh.SubmitChanges();
                var nx_fundit = from t in financa_sh.Nxenesis
                                orderby t.Id_nxenesi descending
                                select t.Id_nxenesi;
                p.Id_nxenesi = nx_fundit.FirstOrDefault();
                p.Paguar = false;
               
                financa_sh.Prenotimis.InsertOnSubmit(p);
                financa_sh.SubmitChanges();

                var pg_fundit = from t in financa_sh.Pagesas
                                orderby t.Id_pagesa descending
                                select t.Id_pagesa;
                p.Id_pagesa = pg_fundit.FirstOrDefault();
                bind();

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Nxenesi nxenesit = new Nxenesi();
            Prenotimi p = new Prenotimi();
            nxenesit.Emri = Convert.ToString(Emritxt.Text);
            nxenesit.Mbiemri = Convert.ToString(Mbiemritxt.Text);
            nxenesit.Atesia = Convert.ToString(Atesiatxt.Text);
            nxenesit.Memesia = Convert.ToString(Memesiatxt.Text);
            nxenesit.Nr_amza = Convert.ToString(Amzatxt.Text);
            nxenesit.Nr_tel = Convert.ToString(Teltxt.Text);
            nxenesit.Ditelindja = Convert.ToString(Ditelindjatxt.Text);
            nxenesit.Viti_shkollor = Convert.ToString(vitiddl0.SelectedItem.Text);
            nxenesit.Klasa = Convert.ToString(DropDownList1.SelectedItem.Text);
            nxenesit.Indeksi = Convert.ToString(DropDownList2.SelectedItem.Text);
            financa_sh.Nxenesis.InsertOnSubmit(nxenesit);
            financa_sh.SubmitChanges();

            // insert te tebela e prenotimit
            var nx_fundit = from t in financa_sh.Nxenesis
                            orderby t.Id_nxenesi descending
                            select t.Id_nxenesi;
            p.Id_nxenesi = nx_fundit.FirstOrDefault();
            p.Paguar = false;
            financa_sh.Prenotimis.InsertOnSubmit(p);
            financa_sh.SubmitChanges();

            bind();
            hide_control();
        }

        void show_control()
        {
                Emritxt.Visible = true;
                Mbiemritxt.Visible = true;
                Atesiatxt.Visible = true;
                Memesiatxt.Visible = true;
                Amzatxt.Visible = true;
                Teltxt.Visible = true;
                Ditelindjatxt.Visible = true;    
                Button2.Visible = true;
                Label11.Visible = true;
                Label12.Visible = true;
                Label15.Visible = true;
                Label16.Visible = true;
                Label15.Visible = true;
                Label16.Visible = true;
                Label18.Visible = true;
                Label19.Visible = true;
                Label14.Visible = true;
                RequiredFieldValidator19.Visible = true;  
                RequiredFieldValidator20.Visible = true;
                RequiredFieldValidator21.Visible = true;
                RequiredFieldValidator22.Visible = true;
                RequiredFieldValidator23.Visible = true;
                RequiredFieldValidator24.Visible = true;
                RequiredFieldValidator25.Visible = true;
                RequiredFieldValidator26.Visible = true;
               
          
        }


        void hide_control()
        {

            Emritxt.Visible = false;
            Mbiemritxt.Visible = false;
            Atesiatxt.Visible = false;
            Memesiatxt.Visible = false;
            Amzatxt.Visible = false;
            Teltxt.Visible = false;
            Button2.Visible = false;
            Label11.Visible = false;
            Label12.Visible = false;
            Label15.Visible = false;
            Label16.Visible = false;
            Label15.Visible = false;
            Label16.Visible = false;
            Label18.Visible = false;
            Label19.Visible = false;
            Label14.Visible = false;
            Ditelindjatxt.Visible = false;
            RequiredFieldValidator19.Visible = false;
            RequiredFieldValidator20.Visible = false;
            RequiredFieldValidator21.Visible = false;
            RequiredFieldValidator22.Visible = false;
            RequiredFieldValidator23.Visible = false;
            RequiredFieldValidator24.Visible = false;
            RequiredFieldValidator25.Visible = false;
            RequiredFieldValidator26.Visible = false;
        }


        void clear_textbox()
        {
            Emritxt.Text = "";
            Mbiemritxt.Text = "";
            Atesiatxt.Text = "";
            Memesiatxt.Text = "";
            Amzatxt.Text = "";
            Ditelindjatxt.Text = "";
            Teltxt.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            bind();
            if (GridView1.Rows.Count == 0)
            {
                show_control();
                clear_textbox();
            }
            else
            {
                hide_control();
            }
        }

       
      
    }
}