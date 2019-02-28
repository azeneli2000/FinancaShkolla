using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace financa_shkolla.Account
{
    public partial class Cmimet1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack == false)
            {
                vitiddl1.Text = gjej_vitin();
                bind();
            }
            TextBox1.Attributes.Add("autocomplete", "off");
            TextBox2.Attributes.Add("autocomplete", "off");
            TextBox3.Attributes.Add("autocomplete", "off");
          
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

            bind();


        }

        protected void modifiko()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Cmimet cm = new Cmimet();
            var sk = from c in financa_sh.Skontos
                     select c;
            if (sk.Count() == 0)
            {
                var cm_viti = from c in financa_sh.Cmimets
                              where (c.Viti_shkollor == vitiddl1.SelectedItem.Text) && (c.Klasa == Convert.ToInt16(Klasaddl.SelectedItem.Text))
                              select c;
                cm_viti.FirstOrDefault().Cmimi = Convert.ToInt32(TextBox1.Text);
                cm_viti.FirstOrDefault().Cmimi_trans = Convert.ToDecimal(TextBox2.Text);
                cm_viti.FirstOrDefault().Prenotimi = Convert.ToInt32(TextBox3.Text);

                cm_viti.FirstOrDefault().Valuta = DropDownList1.SelectedItem.Text;
                cm_viti.FirstOrDefault().Valuta_trans = DropDownList2.SelectedItem.Text;
                cm_viti.FirstOrDefault().Valuta_prenotimi = DropDownList3.SelectedItem.Text;
                financa_sh.SubmitChanges();
                msbox("Cmimet u modifikuan !");
            }
            else
                msbox("Cmimet nuk mund te modifikohen pasi jane konfigurar keste !");
        }
        public void bind()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Cmimet cm = new Cmimet();
            var cm_viti = from c in financa_sh.Cmimets
                          where (c.Viti_shkollor == vitiddl1.SelectedItem.Text) && (c.Klasa == Convert.ToInt16(Klasaddl.SelectedItem.Text))
                          select new { c.Cmimi, c.Valuta, c.Prenotimi, c.Valuta_prenotimi, c.Cmimi_trans, c.Valuta_trans };
            if (cm_viti.Count() > 0)
            {
                TextBox1.Text = cm_viti.FirstOrDefault().Cmimi.ToString();
                DropDownList1.SelectedValue = cm_viti.FirstOrDefault().Valuta.ToString().Trim();
                TextBox2.Text = cm_viti.FirstOrDefault().Cmimi_trans.ToString().Trim();
                DropDownList2.SelectedValue = cm_viti.FirstOrDefault().Valuta_trans.ToString().Trim();
                TextBox3.Text = cm_viti.FirstOrDefault().Prenotimi.ToString().Trim();
                DropDownList3.SelectedValue = cm_viti.FirstOrDefault().Valuta_prenotimi.ToString().Trim();
                Button1.Visible = true;
                Button2.Visible = false;
            }
            else
            {
                TextBox1.Text = "";
                DropDownList1.SelectedValue = "EUR";
                TextBox2.Text = "";
             DropDownList2.SelectedValue = "EUR";
                TextBox3.Text = "";
                DropDownList3.SelectedValue = "EUR";
                Button2.Visible = true;
                Button1.Visible = false;
            }

        }

        public void OnConfirm(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                modifiko();
            }
            else
            {
               // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            
            }
        }

        protected void Klasaddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind();
        }
        public void vendos()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Cmimet cm = new Cmimet();
            cm.Klasa = Convert.ToInt16(Klasaddl.SelectedItem.Text);
            cm.Viti_shkollor = vitiddl1.SelectedItem.Text;
            cm.Cmimi =Convert.ToInt32( TextBox1.Text);
            cm.Cmimi_trans = Convert.ToDecimal(TextBox2.Text);
            cm.Prenotimi = Convert.ToInt16(TextBox3.Text);
            cm.Valuta = DropDownList1.SelectedItem.Text;
            cm.Valuta_prenotimi = DropDownList3.SelectedItem.Text;
            cm.Valuta_trans = DropDownList2.SelectedItem.Text;
            financa_sh.Cmimets.InsertOnSubmit(cm);
            financa_sh.SubmitChanges();

            bind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            vendos();
            msbox("Cmimet u hodhen !");
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

    }
}