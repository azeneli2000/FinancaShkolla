using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace financa_shkolla.Account
{
    public partial class Skonto1 : System.Web.UI.Page
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
            Klasaddl.SelectedIndex = 0;
            Indeksiddl.SelectedIndex = 0;

        }

        protected void Klasaddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Indeksiddl.SelectedIndex = 0;
        }

        protected void bind()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Skonto sk = new Skonto();
            Nxenesi nx = new Nxenesi();


            var sk_nx = from c in financa_sh.Skontos
                        from c1 in financa_sh.Nxenesis
                        where (c1.Id_nxenesi == c.Id_nxenesi) && (c1.Klasa == Klasaddl.SelectedItem.Text) && (c1.Indeksi == Indeksiddl.SelectedItem.Text) && (c1.Viti_shkollor == vitiddl1.SelectedItem.Text)
                        select new { c1.Id_nxenesi, c1.Emri, c1.Mbiemri, c.Ulje_1, c.Ulje_2, c.Ulje_3, c.Ulje_4, c.Ulje_5, c.Ulje_6, c.Ulje_7, c.Ulje_8, c.Ulje_9, c.Ulje_10, c.Ulje_11, c.Ulje_12 };

            GridView1.DataSource = sk_nx;
            GridView1.DataBind();
        }

        protected void Indeksiddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind();
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            long id = Convert.ToInt64(GridView1.DataKeys[e.RowIndex].Value);

            Skonto sk = new Skonto();
            Kestet k = new Kestet();
            Pagesa pag = new Pagesa();
            Arka a = new Arka();

            //fshin skontot nga tabela e skontove
            var skonto_id = from c in financa_sh.Skontos
                            where (c.Id_nxenesi == id)
                            select c;

            //kontrollon nese ka pagesa
            var join_pg = from pg in financa_sh.Pagesas
                          from ks in financa_sh.Kestets
                          where (pg.Id_pagesa == ks.Id_pagesa) && (pg.Anulluar == false)
                          select pg;


            //foreach (var v in join_pg)
            //{
            //    v.Anulluar = true;
            //    v.Koment = "Anulluar";
            //};

            //var join_pg1 = from pg in financa_sh.Pagesas
            //              from ks in financa_sh.Kestets
            //              where (pg.Id_pagesa == ks.Id_pagesa)
            //              select ks;


            //foreach (var v in join_pg1)
            //{
            //    v.Paguar = false;

            //};

            //fshin kestet
            var kestet_id = from p in financa_sh.Kestets
                            where (p.Id_nxenesi == id)
                            select p;

           
            if (join_pg.Count() == 0)
            {
                financa_sh.Skontos.DeleteAllOnSubmit(skonto_id);
                financa_sh.Kestets.DeleteAllOnSubmit(kestet_id);

                //financa_sh.Pagesas.DeleteAllOnSubmit(join_pg);

                financa_sh.SubmitChanges();
                bind();
            }
            else
            {
                msbox("Kestet nuk u fshine pasi jane bere pagesa !");
            }

            ////ANULLON transaksionet e bera e bera
            //var ar = from ak in financa_sh.Arkas
            //         from p in join_pg
            //         where (ak.Id_transaksioni == p.Id_transaksioni)
            //         select ak;

            //foreach (var v in ar)
            //{
            //    v.Anulluar = true;
            //    v.Koment = "Fshirje kestesh";
            //};
      
            




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