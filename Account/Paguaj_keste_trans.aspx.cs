using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Xml.Linq;
using System.Web.Configuration;
using System.IO;

namespace financa_shkolla.Account
{
    public partial class Paguaj_keste_trans : System.Web.UI.Page
    {
        static decimal sk = 0, pen = 0;
      
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!Page.IsPostBack)
            {
                hide();
                vitiddl1.Text = gjej_vitin();
                bind_bankat();
            }
            datepicker.Attributes.Add("autocomplete", "off");
            datepicker0.Attributes.Add("autocomplete", "off");
            datepicker1.Attributes.Add("autocomplete", "off");
            kursi.Attributes.Add("autocomplete", "off");
        }

        protected void bind_bankat()
        {
            XDocument xmlContent = new XDocument();
            string constr = Server.MapPath("~/Account/Bankat.xml").ToString();

            if (File.Exists(constr))
            {
                xmlContent = XDocument.Load(constr);
                var content = from data in xmlContent.Descendants("Banka")
                              select new { emri = ((string)data.Element("Emri")) };
                int i = content.Count();
                DropDownList1.DataSource = content;
                DropDownList1.DataValueField = "emri";
                DropDownList1.DataTextField = "emri";
                DropDownList1.DataBind();

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
            hide();
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
            hide();
        }


        protected bool ka_prenotim(long ID)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Prenotimi nxenesit = new Prenotimi();
            var pr = from c in financa_sh.Prenotimis
                     where (c.Id_nxenesi == ID) && (c.Paguar == false)
                     select new { c };
            if (pr.Count() == 0)
                return true;
            else return false;


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

                if (ka_prenotim(Convert.ToInt64(Nxenesiddl.SelectedValue)) == true)
                {
                    if (ka_keste(Convert.ToInt64(Nxenesiddl.SelectedValue)) == false)
                    {
                        //kestelbl.Text = "Nxenesi nuk i jane konfiguruar kestet !";
                        Button2.Visible = true;
                        kestelbl.ForeColor = System.Drawing.Color.Red;
                        hide();
                    }
                    else
                    {
                        kestelbl.Text = "";
                        keste_pa_pag_check();

                        show();
                        kestetotlbl.Text = "0";
                        valutalbl.Text = valuta();
                        totalilbl.Text = kestetotlbl.Text;
                        valutalbl0.Text = valutalbl.Text;
                        if (ka_pag_keste_tegjitha(Convert.ToInt64(Nxenesiddl.SelectedValue)))
                        {
                            kestelbl.Text = "Nxenesi i ka paguar te gjitha kestet !";
                            kestelbl.ForeColor = System.Drawing.Color.Green;
                            hide();
                        }
                    }
                }
                else
                  kestelbl.Text ="Nxenesi nuk ka paguar prenotimin !";
            }
            else
            {
                kestelbl.Text = "";
                hide();
                Atesialbl.Text = "";
                Memesialbl.Text = "";
                Amzalbl.Text = "";
                Tellbl.Text = "";
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
                   if (ka_prenotim(Convert.ToInt64(Nxenesiddl.SelectedValue)) == true)
                {
                if (ka_keste(Convert.ToInt64(Nxenesiddl.SelectedValue)) == false)
                {
                    //kestelbl.Text = "Nxenesi nuk i jane konfiguruar kestet !";
                    Button2.Visible = true;
                    kestelbl.ForeColor = System.Drawing.Color.Red;
                    hide();
                }
                else
                {
                    kestelbl.Text = "";

                    keste_pa_pag_check();
                  
                    show();

                    kestetotlbl.Text = "0";
                    valutalbl.Text = valuta();
                    totalilbl.Text = kestetotlbl.Text;
                    valutalbl0.Text = valutalbl.Text;
                    if (ka_pag_keste_tegjitha(Convert.ToInt64(Nxenesiddl.SelectedValue)))
                    {
                        kestelbl.Text = "Nxenesi i ka paguar te gjitha kestet !";
                        kestelbl.ForeColor = System.Drawing.Color.Green;
                        hide();
                    } 
                }
                }
                   else
                       kestelbl.Text = "Nxenesi nuk ka paguar prenotimin !";
            }
         
           
           
        }

        protected void keste_pa_pag_check() // kestet e transportit te papaguara
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Transporti tr = new Transporti();
            var keste_p = from c in financa_sh.Transportis
                          where (c.Id_nxenesi.ToString() == Nxenesiddl.SelectedValue)// && (c.Paguar == false)
                          select new { c.Nr_kesti, c.Vlera, c.Paguar,c.Aktiv };
            GridView1.DataSource = keste_p;
            GridView1.Columns[3].Visible = true;
            GridView1.DataBind();
            GridView1.Columns[3].Visible = false;
          // 

        }





        protected bool ka_keste(Int64 ID)//shikon nqs ka keste
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Kestet nx_keste = new Kestet();
            Transporti tr = new Transporti();
            var nx_k = from c in financa_sh.Transportis
                       where (c.Id_nxenesi == ID)
                       select new { c.Id_nxenesi };
            if (nx_k.Count() == 0)
                return false;
            else
                return true;


        }



        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            int[] v = { 0, 0, 0, 0, 0, 0, 0, 0, 0,0 };

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chbTemp = GridView1.Rows[i].FindControl("CheckBox1") as CheckBox;
                if (chbTemp.Checked == true)
                {
                    v[i] = 1;
                    if ((chbTemp.Enabled == true) && (chbTemp.Checked == false))
                    kestetotlbl.Text = (Convert.ToDecimal(GridView1.Rows[i].Cells[1].Text) + Convert.ToDecimal(kestetotlbl.Text)).ToString();
                }
                if (chbTemp.Checked==false)
                    v[i] = 2;
                if (chbTemp.Enabled == false)
                    v[i]=0;
            }

            int nr_check = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chbTemp = GridView1.Rows[i].FindControl("CheckBox1") as CheckBox;

                if ((chbTemp.Checked == true)&&(chbTemp.Enabled==true))
                    nr_check = nr_check + 1;
              
            }
          
            kestetotlbl.Text = (Convert.ToDecimal(GridView1.Rows[0].Cells[1].Text) * nr_check).ToString();

            //for (int i = 0; i<GridView1.Rows.Count; i++)
            //{
            //    CheckBox chbTemp = GridView1.Rows[i].FindControl("CheckBox1") as CheckBox;
            //   if (i==0)
            //    {
                    

            //    }
                
                //else
                //    kestetotlbl.Text = (Convert.ToDecimal(kestetotlbl.Text) - Convert.ToDecimal(GridView1.Rows[i].Cells[1].Text)).ToString();
                
            //}
                v = v.Where(val => val != 0).ToArray(); //heq zerot nga array v
            for (int j = 0; j < v.Length-1; j++)
            {                                        
                    if ((v[j] > v[j+1]) && (v[j + 1] != 0))
                    {
                        kestetotlbl.Text = "0";
                        msbox("Lejohet te zgjidhen vetem keste te njepasnjeshem !");
                        keste_pa_pag_check();
                    }
                }

            valutalbl.Text = valuta();
            totalilbl.Text = kestetotlbl.Text;
            valutalbl0.Text = valutalbl.Text;
            kursi.Text = "";
            DropDownList2.SelectedValue = valutalbl.Text;
            sk = 0;
            pen = 0;

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

        protected string valuta()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Cmimet cm = new Cmimet();
            var cmimet_valuta = from c in financa_sh.Cmimets
                                where (c.Viti_shkollor == vitiddl1.Text)
                                select c.Valuta_trans;
            return cmimet_valuta.FirstOrDefault().ToString().Trim();


        }
        

        protected void hide()
        {
           
            Label1.Visible = false;
            Label6.Visible = false;
            Label4.Visible = false;
            kestetotlbl.Visible = false;
            valutalbl.Visible = false;
            valutalbl0.Visible = false;
            totalilbl.Visible = false;
            datepicker0.Visible = false;
            datepicker1.Visible = false;
            datepicker.Visible = false;
           
            Label5.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            Label9.Visible = false;
            penlbl.Visible = false;
            Kursilbl.Visible = false;
            skontolbl.Visible = false;
            Button1.Visible = false;
            GridView1.Visible = false;
            DropDownList1.Visible = false;
            DropDownList2.Visible = false;
            Label10.Visible = false;
            kursi.Visible = false;

        }
        protected void show()
        {
            
            Label1.Visible = true;
            Label6.Visible = true;
            Label4.Visible = true;
            kestetotlbl.Visible = true;
            valutalbl.Visible = true;
            valutalbl0.Visible = true;
            totalilbl.Visible = true;
            datepicker0.Visible = true;
            datepicker1.Visible = true;
            datepicker.Visible = true;
           
            Label5.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            skontolbl.Visible = true;
            penlbl.Visible = true;
            Kursilbl.Visible = true;
            Button1.Visible = true;
            GridView1.Visible = true;
            DropDownList1.Visible = true;
            DropDownList2.Visible = true;
            Label10.Visible = true;
            kursi.Visible = true;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (DropDownList2.SelectedItem.Text == valutalbl.Text)
                
           {
                    valutalbl0.Text = DropDownList2.SelectedItem.Text;
                    totalilbl.Text = kestetotlbl.Text;
                    
           }
           kursi.Text = "";
           Kursilbl.Text = "1";
        }

        protected void kursi_TextChanged(object sender, EventArgs e)
        {
            if (kestetotlbl.Text != "0")
                if (DropDownList2.SelectedItem.Text != valutalbl.Text)
                {
                    Kursilbl.Text = kursi.Text;
                    totalilbl.Text = (Convert.ToDecimal(kestetotlbl.Text) * Convert.ToDecimal(Kursilbl.Text)).ToString();
                    valutalbl0.Text = DropDownList2.SelectedItem.Text;
                    kursi.Text = "";
                }
                else
                {
                    kursi.Text = "";
                    Kursilbl.Text = "1";

                }
            else
            {
                kursi.Text = "";
                Kursilbl.Text = "1";
            }
        }
  
        protected void datepicker_TextChanged(object sender, EventArgs e)
        {
           // sk = sk + Convert.ToDecimal(datepicker.Text);
            if (penlbl.Text =="0")
            {
            skontolbl.Text = datepicker.Text;
            totalilbl.Text = (Convert.ToDecimal(kestetotlbl.Text) - (Convert.ToDecimal(kestetotlbl.Text) * Convert.ToDecimal(skontolbl.Text) / 100)).ToString();
            }
                datepicker.Text = "";
           
        }

     

        protected void Button1_Click(object sender, EventArgs e)
        {

            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Kestet k = new Kestet();
            Pagesa pag = new Pagesa();
            Arka a = new Arka();
            CheckBox chbTemp1 = GridView1.Rows[0].FindControl("CheckBox1") as CheckBox;
         
           
            int j =0;
            // gjen sa chckbox jane te chekuara
           for (int i = 0; i < GridView1.Rows.Count; i++)
           {

               CheckBox chbTemp = GridView1.Rows[i].FindControl("CheckBox1") as CheckBox;

               if ((chbTemp.Checked) && (chbTemp.Enabled == true))
                   j = j + 1;
           }
           if (j > 0)
           {

               //insert te tabela e arkes
               var vlera_fundit = from t in financa_sh.Arkas
                                  orderby t.Id_transaksioni descending
                                  select new { t.Tot_E, t.Tot_L, t.Tot_S };
               if (valutalbl0.Text == "EUR")
               {
                   a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E + Convert.ToDecimal(totalilbl.Text);
                   a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L + 0;
                   a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S + 0;
               }
               if (valutalbl0.Text == "USD")
               {
                   a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S + Convert.ToDecimal(totalilbl.Text);
                   a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L + 0;
                   a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E + 0;
               }
               if (valutalbl0.Text == "LEK")
               {
                   a.Tot_L = vlera_fundit.FirstOrDefault().Tot_L + Convert.ToDecimal(totalilbl.Text);
                   a.Tot_E = vlera_fundit.FirstOrDefault().Tot_E + 0;
                   a.Tot_S = vlera_fundit.FirstOrDefault().Tot_S + 0;
               }

               a.Vendndodhja = DropDownList1.SelectedItem.Text;
               a.Data = DateTime.Now;
               a.Modifikuar_nga = HttpContext.Current.User.Identity.Name;
               a.Vlera = Convert.ToDecimal(totalilbl.Text);
               a.Valuta = valutalbl0.Text;
               financa_sh.Arkas.InsertOnSubmit(a);
               financa_sh.SubmitChanges();


               // gjej id e  transaksionit e fundit
               var tr_fundit = from t in financa_sh.Arkas
                               orderby t.Id_transaksioni descending
                               select t.Id_transaksioni;

               //insert te tabela e pageses
               pag.Data = DateTime.Now;
               pag.Monedha = valutalbl0.Text;
               pag.Totali = Convert.ToDecimal(totalilbl.Text);
               pag.Skonto = Convert.ToDecimal(skontolbl.Text);
               pag.Penaliteti = Convert.ToDecimal(penlbl.Text);
               pag.Id_transaksioni = tr_fundit.FirstOrDefault();
               pag.Nr_kestesh = j;
               pag.Koment = datepicker0.Text;
               pag.Anulluar = false;

               financa_sh.Pagesas.InsertOnSubmit(pag);
               financa_sh.SubmitChanges();



               // gjej id e  pag e fundit
               var pg_fundit = from t in financa_sh.Pagesas
                               orderby t.Id_pagesa descending
                               select t.Id_pagesa;
               //paguar = true ne tabelen e kesteve te transportit
               var keste_pa = from c in financa_sh.Transportis
                              where (c.Id_nxenesi.ToString() == Nxenesiddl.SelectedValue) //&& (c.Paguar == false)
                              select c;
               int numer_keste = 0;
               int count = 0;
               foreach (var d in keste_pa)
               {

                   CheckBox chbTemp = GridView1.Rows[count].FindControl("CheckBox1") as CheckBox;

                   if (chbTemp.Checked && chbTemp.Enabled)
                   {
                       d.Paguar = true;
                       d.Id_pagesa = pg_fundit.FirstOrDefault();
                       numer_keste = numer_keste + 1;
                   }
                   count = count + 1;


               }


               financa_sh.SubmitChanges();
               GridViewRow row = GridView1.Rows[0];
               string s;
               s = (row.Cells[0].Text);

               if (s != "0")
                   in_koment(tr_fundit.FirstOrDefault(), "Pagese trans Nr keste : " + numer_keste.ToString() + " Skonto : " + skontolbl.Text + "% Pen : " + penlbl.Text + "%");
               else
                   in_koment(tr_fundit.FirstOrDefault(), "Pagese trans Nr keste : " + "P + " + (numer_keste - 1).ToString() + " Skonto : " + skontolbl.Text + "% Pen : " + penlbl.Text + "%");
               msbox("Pagesa u krye !");
               hide();
           }
           else
               msbox("Duhet te zgjidhni te pakten nje kest !");
        }
       


        protected void in_koment(long id_tr, string koment)
        {

            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Kestet k = new Kestet();
            Pagesa pag = new Pagesa();
            Arka a = new Arka();
            var kom_tr = from c in financa_sh.Arkas
                         where c.Id_transaksioni == id_tr
                         select c;

            kom_tr.FirstOrDefault().Koment = koment;
            financa_sh.SubmitChanges();

        }

        protected bool ka_keste1(Int64 id)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Skonto sk = new Skonto();
            var s_nxenesi = from c in financa_sh.Transportis
                            where (c.Id_nxenesi == id)
                            select new { c.Id_nxenesi };
            if (s_nxenesi.Count() == 0)
                return false;
            else
                return true;


        }


        protected bool ka_pag_keste_tegjitha(Int64 id)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Kestet sk = new Kestet();
            var s_nxenesi = from c in financa_sh.Transportis
                            where (c.Id_nxenesi == id)&&(c.Paguar==false)
                            select new { c.Id_nxenesi };
            if (s_nxenesi.Count() == 0)
                return true;
            else
                return false;


        }

        protected void Nxenesiddl_DataBound(object sender, EventArgs e)
        {
            for (int r = 0; r < Nxenesiddl.Items.Count; r++)
            {

                if (ka_keste1(Convert.ToInt64(Nxenesiddl.Items[r].Value)) == false)
                    Nxenesiddl.Items[r].Attributes.Add("style", "color:red");
                if ((ka_pag_keste_tegjitha(Convert.ToInt64(Nxenesiddl.Items[r].Value)) == true) && (ka_keste1(Convert.ToInt64(Nxenesiddl.Items[r].Value)) == true))
                    Nxenesiddl.Items[r].Attributes.Add("style", "color:green");
            }
        }

        protected void datepicker1_TextChanged(object sender, EventArgs e)
        {
            if (skontolbl.Text == "0")
            {
                penlbl.Text = datepicker1.Text;
                totalilbl.Text = (Convert.ToDecimal(kestetotlbl.Text) + (Convert.ToDecimal(kestetotlbl.Text) * Convert.ToDecimal(penlbl.Text) / 100)).ToString();
            }
                datepicker1.Text = "";
        }

        protected decimal gjej_cmimin(int klasa)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            var cmimi = from c in financa_sh.Cmimets
                        where (c.Klasa == klasa)
                        select c;
            if (cmimi.Count() == 0)
                return 0;
            else
                return cmimi.FirstOrDefault().Cmimi_trans;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            if (gjej_cmimin(Convert.ToInt16(Klasaddl.SelectedItem.Text)) > 0)
            {
                decimal c = gjej_cmimin(Convert.ToInt16(Klasaddl.SelectedItem.Text));
                decimal k = c / 10;
                Transporti tr1 = new Transporti();
                tr1.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                tr1.Nr_kesti = 1;
                tr1.Aktiv = true;
                tr1.Paguar = false;
                tr1.Id_pagesa = 0;
                tr1.Vlera = k;
                financa_sh.Transportis.InsertOnSubmit(tr1);

                Transporti tr2 = new Transporti();
                tr2.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                tr2.Nr_kesti = 2;
                tr2.Aktiv = true;
                tr2.Paguar = false;
                tr2.Id_pagesa = 0;
                tr2.Vlera = k;
                financa_sh.Transportis.InsertOnSubmit(tr2);

                Transporti tr3 = new Transporti();
                tr3.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                tr3.Nr_kesti = 3;
                tr3.Aktiv = true;
                tr3.Paguar = false;
                tr3.Id_pagesa = 0;
                tr3.Vlera = k;
                financa_sh.Transportis.InsertOnSubmit(tr3);

                Transporti tr4 = new Transporti();
                tr4.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                tr4.Nr_kesti = 4;
                tr4.Aktiv = true;
                tr4.Paguar = false;
                tr4.Id_pagesa = 0;
                tr4.Vlera = k;
                financa_sh.Transportis.InsertOnSubmit(tr4);

                Transporti tr5 = new Transporti();
                tr5.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                tr5.Nr_kesti = 5;
                tr5.Aktiv = true;
                tr5.Paguar = false;
                tr5.Id_pagesa = 0;
                tr5.Vlera = k;
                financa_sh.Transportis.InsertOnSubmit(tr5);

                Transporti tr6 = new Transporti();
                tr6.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                tr6.Nr_kesti = 6;
                tr6.Aktiv = true;
                tr6.Paguar = false;
                tr6.Id_pagesa = 0;
                tr6.Vlera = k;
                financa_sh.Transportis.InsertOnSubmit(tr6);

                Transporti tr7 = new Transporti();
                tr7.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                tr7.Nr_kesti = 7;
                tr7.Aktiv = true;
                tr7.Paguar = false;
                tr7.Id_pagesa = 0;
                tr7.Vlera = k;
                financa_sh.Transportis.InsertOnSubmit(tr7);

                Transporti tr8 = new Transporti();
                tr8.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                tr8.Nr_kesti = 8;
                tr8.Aktiv = true;
                tr8.Paguar = false;
                tr8.Id_pagesa = 0;
                tr8.Vlera = k;
                financa_sh.Transportis.InsertOnSubmit(tr8);

                Transporti tr9 = new Transporti();
                tr9.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                tr9.Nr_kesti = 9;
                tr9.Aktiv = true;
                tr9.Paguar = false;
                tr9.Id_pagesa = 0;
                tr9.Vlera = k;
                financa_sh.Transportis.InsertOnSubmit(tr9);

                Transporti tr10 = new Transporti();
                tr10.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                tr10.Nr_kesti = 10;
                tr10.Aktiv = true;
                tr10.Paguar = false;
                tr10.Id_pagesa = 0;
                tr10.Vlera = k;
                financa_sh.Transportis.InsertOnSubmit(tr10);


                financa_sh.SubmitChanges();
                Button2.Visible = false;
                msbox("Kestet u krijuan !");
            }
            else
                msbox("Klasa e zgjedhur nuk ka cmim per vitin shkollor");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //bool myObj = (bool)e.Row.DataItem;
                if (e.Row.Cells[3].Text == "False")
                {
                    CheckBox cb = (CheckBox)e.Row.FindControl("CheckBox1");
                    cb.Enabled = false;
                    e.Row.BackColor = System.Drawing.Color.Gray;
                    e.Row.ForeColor = System.Drawing.Color.WhiteSmoke;

                   
                   
                }
                CheckBox cb1 = (CheckBox)e.Row.FindControl("CheckBox1");
                if (cb1.Checked)
                {
                    cb1.Enabled = false;
                    e.Row.BackColor = System.Drawing.Color.MediumSeaGreen;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
                

            }
           //
        }



       


        





    }
}
       

       
