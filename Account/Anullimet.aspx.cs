using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace financa_shkolla.Account
{
    public partial class Anullimet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!Page.IsPostBack)
            vitiddl1.SelectedValue = DateTime.Today.Year.ToString();
            bind();
        }

        protected void vitiddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind();
        }
        protected void bind()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Arka a = new Arka();
            var fat_anulluara = from c in financa_sh.Pagesas
                                where (c.Anulluar == true) && (c.Data.Year.ToString().Trim() == vitiddl1.SelectedItem.Text)
                                select new {c.Id_pagesa,c.Data,c.Totali,c.Monedha,c.Nr_kestesh,c.Koment };
            GridView1.DataSource = fat_anulluara;
            GridView1.DataBind();

        }

    }
}