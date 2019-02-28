using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace financa_shkolla.Account.p1
{
    public partial class aaa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Attributes.Add("autocomplete", "off");
            TextBox2.Attributes.Add("autocomplete", "off");
         
          
            //RadioButton1.Checked = false;
            //RadioButton2.Checked = false;
            //RadioButton3.Checked = false;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }



        protected void Button1_Click(object sender, EventArgs e)
        {

           if (DropDownList1.SelectedItem.Text == "Shkolla")
            anullo_keste_shkolla();

           if (DropDownList1.SelectedItem.Text == "Transporti")
               anullo_keste_trans();

           if (DropDownList1.SelectedItem.Text == "Prenotim")
               anullo_prenotim();

        }

        protected void anullo_keste_shkolla()
        {

            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Pagesa p = new Pagesa();
            Kestet k = new Kestet();
            Arka a = new Arka();
            //anullon pagesen    
            if (TextBox1.Text == "")
                return;
            var pag_id = from c in financa_sh.Pagesas
                         where (c.Id_pagesa == Convert.ToInt64(TextBox1.Text))
                         select c;
            if (pag_id.Count() == 0)
                return;
            foreach (var v in pag_id)
            {
                v.Anulluar = true;
                v.Koment = TextBox2.Text;
            }

            //fshin kestet nqs ka 
            var kestet_p = from c in financa_sh.Kestets
                           where (c.Id_pagesa == Convert.ToInt64(TextBox1.Text))
                           select c;
            foreach (var v in kestet_p)
            {
                v.Paguar = false;
                v.Id_pagesa = 0;               
            }
            //anullon transaksionin 
            var arka_pag = from c in financa_sh.Arkas                       
                           where (c.Id_transaksioni == pag_id.FirstOrDefault().Id_transaksioni)
                           select c;


            var vlera_fundit = from t in financa_sh.Arkas
                               orderby t.Id_transaksioni descending
                               select new { t.Tot_E, t.Tot_L, t.Tot_S };
            if (pag_id.FirstOrDefault().Monedha.Trim() == "EUR")
            {
                a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E - pag_id.FirstOrDefault().Totali;
                a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L + 0;
                a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S + 0;
            }
            if (pag_id.FirstOrDefault().Monedha.Trim() == "USD")
            {
                a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S - pag_id.FirstOrDefault().Totali;
               
                a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L + 0;
                a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E + 0;
            }
            if (pag_id.FirstOrDefault().Monedha.Trim() == "LEK")
            {
                a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L - pag_id.FirstOrDefault().Totali;
                a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S + 0;
                a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E + 0;
            }
            a.Data = DateTime.Now;
            a.Modifikuar_nga = HttpContext.Current.User.Identity.Name;
            a.Vendndodhja =arka_pag.FirstOrDefault().Vendndodhja;
            a.Vlera = -pag_id.FirstOrDefault().Totali;
            a.Valuta = arka_pag.FirstOrDefault().Valuta;
           
            a.Koment= "Anulluar pagesa shkolla nr : " + pag_id.FirstOrDefault().Id_pagesa.ToString();
            financa_sh.Arkas.InsertOnSubmit(a);



                //a.Anulluar = true;
                //a.Koment = "Anulluar pagese nr :" +TextBox1.Text;
                //if (pag_id.FirstOrDefault().Monedha.Trim() == "EUR")
                //    a.Tot_E = a.Tot_E - pag_id.FirstOrDefault().Totali;
                //if (pag_id.FirstOrDefault().Monedha.Trim() == "USD")
                //    a.Tot_S = a.Tot_S - pag_id.FirstOrDefault().Totali;
                //if (pag_id.FirstOrDefault().Monedha.Trim() == "LEK")
                //    a.Tot_L = a.Tot_L - pag_id.FirstOrDefault().Totali;
                //financa_sh.Arkas.InsertOnSubmit(a);
          


            // gjen pagesat qe ka bere nxenesi
            var kestet_id = from c in financa_sh.Kestets
                            where (c.Id_nxenesi == kestet_p.FirstOrDefault().Id_nxenesi)
                            select c;
            //nqs ka bere pagesa te mevoneshme nuk ben submit
            int i = kestet_id.Count();
            foreach (var v in kestet_id)
            {
                if (v.Id_pagesa > Convert.ToInt64(TextBox1.Text))
                {
                    msbox("Pagesa nuk mund te anullohet sepse nxenesi ka pagesa te metejshme !");
                    return;
                }

            }
            financa_sh.SubmitChanges();
            msbox("Pagesa u anullua me sukses !");
        }







        protected void anullo_keste_trans()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Pagesa p = new Pagesa();
            Kestet k = new Kestet();
            Arka a = new Arka();
            //anullon pagesen    
            if (TextBox1.Text == "")
                return;
            var pag_id = from c in financa_sh.Pagesas
                         where (c.Id_pagesa == Convert.ToInt64(TextBox1.Text))
                         select c;
            if (pag_id.Count() == 0)
                return;
            foreach (var v in pag_id)
            {
                v.Anulluar = true;
                v.Koment = TextBox2.Text;
            }

            //fshin kestet nqs ka 
            var kestet_p = from c in financa_sh.Transportis
                           where (c.Id_pagesa == Convert.ToInt64(TextBox1.Text))
                           select c;
            foreach (var v in kestet_p)
            {
                v.Paguar = false;
                v.Id_pagesa = 0;
            }
            //anullon transaksionin 
            var arka_pag = from c in financa_sh.Arkas
                           where (c.Id_transaksioni == pag_id.FirstOrDefault().Id_transaksioni)
                           select c;


            var vlera_fundit = from t in financa_sh.Arkas
                               orderby t.Id_transaksioni descending
                               select new { t.Tot_E, t.Tot_L, t.Tot_S };
            if (pag_id.FirstOrDefault().Monedha.Trim() == "EUR")
            {
                a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E - pag_id.FirstOrDefault().Totali;
                a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L + 0;
                a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S + 0;
            }
            if (pag_id.FirstOrDefault().Monedha.Trim() == "USD")
            {
                a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S - pag_id.FirstOrDefault().Totali;

                a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L + 0;
                a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E + 0;
            }
            if (pag_id.FirstOrDefault().Monedha.Trim() == "LEK")
            {
                a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L - pag_id.FirstOrDefault().Totali;
                a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S + 0;
                a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E + 0;
            }
            a.Data = DateTime.Now;
            a.Modifikuar_nga = HttpContext.Current.User.Identity.Name;
            a.Vendndodhja = arka_pag.FirstOrDefault().Vendndodhja;
            a.Vlera = -pag_id.FirstOrDefault().Totali;
            a.Valuta = arka_pag.FirstOrDefault().Valuta;

            a.Koment = "Anulluar pagesa transporti nr : " + pag_id.FirstOrDefault().Id_pagesa.ToString();
            financa_sh.Arkas.InsertOnSubmit(a);


            // gjen pagesat qe ka bere nxenesi
            var kestet_id = from c in financa_sh.Transportis
                            where (c.Id_nxenesi == kestet_p.FirstOrDefault().Id_nxenesi)
                            select c;
            //nqs ka bere pagesa te mevoneshme nuk ben submit
            int i = kestet_id.Count();
            foreach (var v in kestet_id)
            {
                if (v.Id_pagesa > Convert.ToInt64(TextBox1.Text))
                {
                    msbox("Pagesa nuk mund te anullohet sepse nxenesi ka pagesa te metejshme !");
                    return;
                }

            }
            financa_sh.SubmitChanges();
            msbox("Pagesa u anullua me sukses !");
        }


        protected void anullo_prenotim()

        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Pagesa p = new Pagesa();
            Kestet k = new Kestet();
            Arka a = new Arka();
            //anullon pagesen    
            if (TextBox1.Text == "")
                return;
            var pag_id = from c in financa_sh.Pagesas
                         where (c.Id_pagesa == Convert.ToInt64(TextBox1.Text))
                         select c;
            if (pag_id.Count() == 0)
                return;
            foreach (var v in pag_id)
            {
                v.Anulluar = true;
                v.Koment = TextBox2.Text;
            }

            //ben paguar false prenotimin e nxenesit me id e dhene
            var kestet_p = from c in financa_sh.Prenotimis
                           where (c.Id_pagesa == Convert.ToInt64(TextBox1.Text))
                           select c;
            foreach (var v in kestet_p)
            {
                v.Paguar = false;
                v.Id_pagesa = 0;
            }
            //anullon transaksionin 
            var arka_pag = from c in financa_sh.Arkas
                           where (c.Id_transaksioni == pag_id.FirstOrDefault().Id_transaksioni)
                           select c;


            var vlera_fundit = from t in financa_sh.Arkas
                               orderby t.Id_transaksioni descending
                               select new { t.Tot_E, t.Tot_L, t.Tot_S };
            if (pag_id.FirstOrDefault().Monedha.Trim() == "EUR")
            {
                a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E - pag_id.FirstOrDefault().Totali;
                a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L + 0;
                a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S + 0;
            }
            if (pag_id.FirstOrDefault().Monedha.Trim() == "USD")
            {
                a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S - pag_id.FirstOrDefault().Totali;

                a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L + 0;
                a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E + 0;
            }
            if (pag_id.FirstOrDefault().Monedha.Trim() == "LEK")
            {
                a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L - pag_id.FirstOrDefault().Totali;
                a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S + 0;
                a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E + 0;
            }
            a.Data = DateTime.Now;
            a.Modifikuar_nga = HttpContext.Current.User.Identity.Name;
            a.Vendndodhja = arka_pag.FirstOrDefault().Vendndodhja;
            a.Vlera = -pag_id.FirstOrDefault().Totali;
            a.Valuta = arka_pag.FirstOrDefault().Valuta;

            a.Koment = "Anulluar pagesa prenotimi nr : " + pag_id.FirstOrDefault().Id_pagesa.ToString();
            financa_sh.Arkas.InsertOnSubmit(a);


            // gjen pagesat qe ka bere nxenesi te transportit dhe te kesteve
            var kestet_id = from c in financa_sh.Kestets
                            where (c.Id_nxenesi == kestet_p.FirstOrDefault().Id_nxenesi)
                            select c;

              var trans_id = from c in financa_sh.Transportis
                            where (c.Id_nxenesi == kestet_p.FirstOrDefault().Id_nxenesi)
                            select c;
            //nqs ka bere pagesa te mevoneshme nuk ben submit
            int i = kestet_id.Count();
            foreach (var v in kestet_id)
            {
                //if ((kestet_id.Count() > 0) || (trans_id.Count()>0) )
                if (v.Id_pagesa > Convert.ToInt64(TextBox1.Text))
                {
                    msbox("Pagesa nuk mund te anullohet sepse nxenesi ka pagesa shkolle te metejshme !");
                    return;
                }

            }

            foreach (var v in trans_id)
            {
                
                if (v.Id_pagesa > Convert.ToInt64(TextBox1.Text))
                {
                    msbox("Pagesa nuk mund te anullohet sepse nxenesi ka pagesa transporti te metejshme !");
                    return;
                }

            }

            financa_sh.SubmitChanges();
            msbox("Pagesa u anullua me sukses !");
        }

        protected void msbox(string msg)
        {
           

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<script type = 'text/javascript'>");

            sb.Append("window.onload=function(){");

            sb.Append("alert('");

            sb.Append(msg);

            sb.Append("')};");

            sb.Append("</script>");

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

     

     

       
        protected void Button2_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Pagesa p = new Pagesa();
            if ((DropDownList1.SelectedItem.Text== "Shkolla" )) 
            {
                var pag_id = from c in financa_sh.Kestets
                             from pag in financa_sh.Pagesas
                             where (c.Id_pagesa == Convert.ToInt64(TextBox1.Text)) && (c.Id_pagesa == pag.Id_pagesa)
                             select new { c.Id_nxenesi, pag.Id_pagesa, pag.Data, pag.Totali, pag.Monedha, pag.Nr_kestesh, pag.Skonto, pag.Penaliteti, pag.Koment };
            GridView1.DataSource = pag_id.Distinct();
            GridView1.DataBind();
            }

            if ((DropDownList1.SelectedItem.Text == "Transporti"))
            {
                var pag_id = from c in financa_sh.Transportis
                             from pag in financa_sh.Pagesas
                             where (c.Id_pagesa == Convert.ToInt64(TextBox1.Text)) && (c.Id_pagesa == pag.Id_pagesa)
                             select new { c.Id_nxenesi, pag.Id_pagesa, pag.Data, pag.Totali, pag.Monedha, pag.Nr_kestesh, pag.Skonto, pag.Penaliteti, pag.Koment };
                GridView1.DataSource = pag_id.Distinct();
                GridView1.DataBind();
            }
            if ((DropDownList1.SelectedItem.Text == "Prenotim"))
            {
                var pag_id = from c in financa_sh.Prenotimis
                             from pag in financa_sh.Pagesas
                             where (c.Id_pagesa == Convert.ToInt64(TextBox1.Text)) && (c.Id_pagesa == pag.Id_pagesa)
                             select new { c.Id_nxenesi, pag.Id_pagesa, pag.Data, pag.Totali, pag.Monedha, pag.Nr_kestesh, pag.Skonto, pag.Penaliteti, pag.Koment };
                GridView1.DataSource = pag_id.Distinct();
                GridView1.DataBind();
            }
        

        }

    }
}