using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Xml.Linq;
using System.Web.Configuration;
using System.IO;

using System.Text;
namespace financa_shkolla.Account
{
     
    public partial class Paguaj_keste : System.Web.UI.Page
    {
        static decimal sk = 0, pen = 0;


        public bool Print_check
        {
            get
            {
                object viewState = this.ViewState["Print_check"];

                return (viewState == null) ? false : (bool)viewState;
            }
            set
            {
                this.ViewState["Print_check"] = value;
            }
        }


        //Ora
        public string Ora
        {
            get
            {
                object viewState = this.ViewState["Ora"];

                return (viewState == null) ? string.Empty : (string)viewState;
            }
            set
            {
                this.ViewState["Ora"] = value.ToString();
            }
        }


        //Data
        public string Data
        {
            get
            {
                object viewState = this.ViewState["Data"];

                return (viewState == null) ? string.Empty : (string)viewState;
            }
            set
            {
                this.ViewState["Data"] = value.ToString();
            }
        }



        //Nr_fat
        public string Nr_fat
        {
            get
            {
                object viewState = this.ViewState["Nr_fat"];

                return (viewState == null) ? string.Empty : (string)viewState;
            }
            set
            {
                this.ViewState["Nr_fat"] = value.ToString();
            }
        }



        //Kestet
        public string Nr_keste
        {
            get
            {
                object viewState = this.ViewState["Nr_keste"];

                return (viewState == null) ? string.Empty : (string)viewState;
            }
            set
            {
                this.ViewState["Nr_keste"] = value.ToString();
            }
        }



        // EMRI
 public  string Emri
 {
  get 
  {
   object viewState = this.ViewState["Emri"];

   return (viewState == null) ? string.Empty : (string)viewState;
  }
  set 
  { 
   this.ViewState["Emri"] = value.ToString(); 
  }
 }




 //Vlera
 public string Vlera
 {
     get
     {
         object viewState = this.ViewState["Vlera"];

         return (viewState == null) ? string.Empty : (string)viewState;
     }
     set
     {
         this.ViewState["Vlera"] = value.ToString();
     }
 }


//Skonto
 public string Skonto
 {
     get
     {
         object viewState = this.ViewState["Skonto"];

         return (viewState == null) ? string.Empty : (string)viewState;
     }
     set
     {
         this.ViewState["Skonto"] = value.ToString();
     }
 }


 //Pen
 public string Pen
 {
     get
     {
         object viewState = this.ViewState["Pen"];

         return (viewState == null) ? string.Empty : (string)viewState;
     }
     set
     {
         this.ViewState["Pen"] = value.ToString();
     }
 }



 //Totali
 public string Totali
 {
     get
     {
         object viewState = this.ViewState["Totali"];

         return (viewState == null) ? string.Empty : (string)viewState;
     }
     set
     {
         this.ViewState["Totali"] = value.ToString();
     }
 }

 //Kursi
 public string Kursi
 {
     get
     {
         object viewState = this.ViewState["Kursi"];

         return (viewState == null) ? string.Empty : (string)viewState;
     }
     set
     {
         this.ViewState["Kursi"] = value.ToString();
     }
 }


 //Financieri
 public string Fin
 {
     get
     {
         object viewState = this.ViewState["Fin"];

         return (viewState == null) ? string.Empty : (string)viewState;
     }
     set
     {
         this.ViewState["Fin"] = value.ToString();
     }
 }

     
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.ServerVariable = "aaa";
            this.Data = DateTime.Now.ToString();
           this.Ora= DateTime.Now.TimeOfDay.ToString();
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
            prenotimi.Text =  gjej_prenotimin().ToString();
           
        }

        protected string nderto_printimin()
        {
            string p = "sdfasdfsadf";
            
           // p = p + "MANDATARKETIMI";
            //p = p + "DATA :" + DateTime.Now.ToString();
            //p = p + "EMRI :" + Nxenesiddl.SelectedItem.Text;
            return p;

            }
      
        protected int gjej_prenotimin()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            var pren = from p in financa_sh.Cmimets
                       where p.Viti_shkollor == vitiddl1.SelectedItem.Text
                       select p;
            if (pren.Count() != 0)
                return pren.FirstOrDefault().Prenotimi;
            else
                return 0;
        }


        protected void printo_fature()
        {
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
            sb.Append((DateTime.Now).ToString());
            sb.Append("<br>");            
            sb.Append("Nr : ");
            sb.Append(nr_fat.Text);
            sb.Append("<br>");

            sb.Append("&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<b><u>MANDAT ARKETIMI</u></b>");
            sb.Append("<br><br>");
        
            sb.Append("Nxenesi : ");
            sb.Append(Nxenesiddl.SelectedItem.Text);
            sb.Append("<br>");
            sb.Append("Numer kestesh : ");
            sb.Append(nr_keste.Text);
            sb.Append("<br>");
            sb.Append("Vlera : ");
            sb.Append(kestetotlbl.Text);
            sb.Append(" ");
            sb.Append(valutalbl.Text);
            sb.Append("<br>");
            if (Convert.ToDecimal(skontolbl.Text) != 0)
            {
                sb.Append("Skonto : ");
                sb.Append(skontolbl.Text);
                sb.Append(" %");
                sb.Append("<br>");
            }
            if (Convert.ToDecimal(penlbl.Text) != 0)
            {
                sb.Append("Kamata : ");
                sb.Append(penlbl.Text);
                sb.Append(" %");
                sb.Append("<br>");
            }
            if (Convert.ToDecimal(Kursilbl.Text) != 1)
            {
                sb.Append("Kembimi : ");
                sb.Append(valutalbl.Text);
                sb.Append("-");
                sb.Append(valutalbl0.Text);
                sb.Append(" : ");
                sb.Append(Kursilbl.Text);
            }
            sb.Append("<br><br>");
            sb.Append("<b>TOTALI : ");
            sb.Append(totalilbl.Text); sb.Append("</b>");
            sb.Append(" "); 
            sb.Append(valutalbl0.Text); 

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

            // GridView1.DataBind();
         protected void printo_fature1()
        {
             
            StringBuilder sb = new StringBuilder();

        sb.Append("<script type = 'text/javascript'>");
        sb.Append("function print() {");
        sb.Append(@"document.jzebra.append(""PRINTED USING JZEBRA PRINTED USING JZEBRA PRINTED USING JZEBRA PRINTED USING JZEBRAp RINTED USING JZEBRA PRINTED USING JZEBRA "");");
        sb.Append("document.jzebra.print();");
        sb.Append(@"document.jzebra.append(""x1D\x56\x31\"");");
        sb.Append("}");
        sb.Append("</script>");
        ClientScript.RegisterClientScriptBlock(this.GetType(), "FaturaPrint1", sb.ToString()); 
        
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
            prenotimi.Text = gjej_prenotimin().ToString();
            menjehere.Visible = false;
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
            menjehere.Visible = false;
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
                               
                //shikon nqs ka keste ose prenotim
                if ((ka_keste(Convert.ToInt64(Nxenesiddl.SelectedValue)) == false) || (ka_prenotim(Convert.ToInt64(Nxenesiddl.SelectedValue)) == false))
                {
                    kestelbl.Text = "Nxenesi nuk ka keste ose prenotim !";
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
            {
                kestelbl.Text = "";
                hide();
                Atesialbl.Text = "";
                Memesialbl.Text = "";
                Amzalbl.Text = "";
                Tellbl.Text = "";
            }
            menjehere.Visible = false;
        }

        protected bool ka_prenotim(long ID)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Prenotimi nxenesit = new Prenotimi();
            var pr = from c in financa_sh.Prenotimis
                     where (c.Id_nxenesi == ID) && (c.Paguar==false)
                     select new {c};
            if (pr.Count() == 0)
                return true;
            else return false;


        }

        protected void Nxenesiddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Nxenesi nxenesit = new Nxenesi();

            Nxenesiddl.DataBind();

            var nxenesi_id = from c in financa_sh.Nxenesis
                             where (c.Id_nxenesi.ToString() == Nxenesiddl.SelectedValue)
                             select new { c.Atesia, c.Memesia, c.Ditelindja, c.Nr_amza, c.Nr_tel };

            Emri = Nxenesiddl.SelectedItem.Text.ToString();// per scriptin e printimit
            
            if (Nxenesiddl.Text != "")
            {
                //vendos gjeneralitetet
                Atesialbl.Text = "ATESIA  : " + nxenesi_id.FirstOrDefault().Atesia.ToString();
                Memesialbl.Text = "MEMESIA  : " + nxenesi_id.FirstOrDefault().Memesia.ToString();
                Tellbl.Text = "TEL  : " + nxenesi_id.FirstOrDefault().Nr_tel.ToString();
                Amzalbl.Text = "AMZA  : " + nxenesi_id.FirstOrDefault().Nr_amza.ToString();
              
                //shikon nqs ka keste ose prenotim

                if ((ka_keste(Convert.ToInt64(Nxenesiddl.SelectedValue)) == false) || (ka_prenotim(Convert.ToInt64(Nxenesiddl.SelectedValue)) == false))
                {
                    kestelbl.Text = "Nxenesi nuk ka keste ose prenotim !";
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


            menjehere.Visible = false;
        }

        protected void keste_pa_pag_check()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            var keste_p = from c in financa_sh.Kestets                       
                          where (c.Id_nxenesi.ToString() == Nxenesiddl.SelectedValue) // && (c.Paguar == false)
                          select new { c.Nr_kesti, c.Vlera, c.Paguar,c.Aktiv };
            GridView1.DataSource = keste_p;
            GridView1.Columns[3].Visible = true;
            GridView1.DataBind();
            GridView1.Columns[3].Visible = false;
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


      
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            int[] v = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 };

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chbTemp = GridView1.Rows[i].FindControl("CheckBox1") as CheckBox;
                if (chbTemp.Checked == true)
                {
                    v[i] = 1;
                    kestetotlbl.Text = (Convert.ToDecimal(GridView1.Rows[i].Cells[1].Text) + Convert.ToDecimal(kestetotlbl.Text)).ToString();
                }
                if (chbTemp.Checked == false)
                    v[i] = 2;
                if (chbTemp.Enabled == false)
                    v[i] = 0;
            }
            int nr_check = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chbTemp = GridView1.Rows[i].FindControl("CheckBox1") as CheckBox;

                if ((chbTemp.Checked == true) && (chbTemp.Enabled == true))
                    nr_check = nr_check + 1;

            }
           this.Nr_keste = nr_check.ToString();
            if (nr_check == 10)
                menjehere.Visible = true;
            else
            {
                menjehere.Visible = false;
                menjehere.Checked = false;
            }
            CheckBox chbTemp1 = GridView1.Rows[0].FindControl("CheckBox1") as CheckBox;
            if ((chbTemp1.Enabled == true) && (chbTemp1.Checked == true))
                kestetotlbl.Text = (Convert.ToDecimal(GridView1.Rows[1].Cells[1].Text) * (nr_check - 1) + Convert.ToDecimal(GridView1.Rows[0].Cells[1].Text)).ToString();
            else
                kestetotlbl.Text = (Convert.ToDecimal(GridView1.Rows[1].Cells[1].Text) * nr_check).ToString();

            v = v.Where(val => val != 0).ToArray(); //heq zerot nga array v
            for (int j = 0; j < v.Length - 1; j++)
            {
                if ((v[j] > v[j + 1]) && (v[j + 1] != 0))
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
            this.Vlera = kestetotlbl.Text + " " + valutalbl.Text;
            this.Totali = totalilbl.Text + " " + valutalbl0.Text;
            

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
                                select c.Valuta;
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
            datepicker2.Visible = false;
            Label12.Visible = false;

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
            datepicker2.Visible = true;
            Label12.Visible = true;


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
            if (Kursilbl.Text != "")
                this.Kursi = Kursilbl.Text;
            else
                this.Kursi = "0";
        }
  
        protected void datepicker_TextChanged(object sender, EventArgs e)
        {
           // sk = sk + Convert.ToDecimal(datepicker.Text);
            if (penlbl.Text =="0")
            {
            skontolbl.Text = datepicker.Text;
            if (menjehere.Checked == true)
            {
                totalilbl.Text = (Convert.ToDecimal(kestetotlbl.Text) + gjej_prenotimin() - ((Convert.ToDecimal(kestetotlbl.Text) + gjej_prenotimin()) * Convert.ToDecimal(skontolbl.Text) / 100) - 0).ToString();
                totalilbl.Text = Math.Round(Convert.ToDecimal(totalilbl.Text), 2).ToString();
                datepicker2.Text = (Convert.ToDecimal(kestetotlbl.Text)+gjej_prenotimin() - Convert.ToDecimal(totalilbl.Text)).ToString();
                datepicker2.Enabled = false;
            }
            else
            {
                totalilbl.Text = (Convert.ToDecimal(kestetotlbl.Text) - (Convert.ToDecimal(kestetotlbl.Text) * Convert.ToDecimal(skontolbl.Text) / 100)).ToString();
                totalilbl.Text = Math.Round(Convert.ToDecimal(totalilbl.Text), 2).ToString();
                datepicker2.Text = (Convert.ToDecimal(kestetotlbl.Text) - Convert.ToDecimal(totalilbl.Text)).ToString();
            }
               
            }
                datepicker.Text = "";
                if (skontolbl.Text != "")
                    this.Skonto = skontolbl.Text;
                else
                    this.Skonto = "0";
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

               if ((chbTemp.Checked)&&(chbTemp.Enabled==true))
                   j = j + 1;
           }
            if (j>0)
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
            a.Vlera=Convert.ToDecimal(totalilbl.Text);
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

           var keste_pa = from c in financa_sh.Kestets
                          where (c.Id_nxenesi.ToString() == Nxenesiddl.SelectedValue) //&& (c.Paguar == false)
                          select c;
            var pren = from c in financa_sh.Prenotimis
                            where (c.Id_nxenesi.ToString() == Nxenesiddl.SelectedValue) 
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

           nr_fat.Text = pg_fundit.FirstOrDefault().ToString();
            
            financa_sh.SubmitChanges();
            GridViewRow row = GridView1.Rows[0];
            string s;
            s =(row.Cells[0].Text);           
            if (s !="0")
                  in_koment(tr_fundit.FirstOrDefault(), "Pagese Nr keste : " + numer_keste.ToString() + " Skonto : " + skontolbl.Text + "% Pen : " + penlbl.Text+"%");      
            else
                in_koment(tr_fundit.FirstOrDefault(), "Pagese Nr keste : "+ "P + " + (numer_keste-1).ToString() + " Skonto : " +skontolbl.Text + "% Pen : " + penlbl.Text+ "%");
           
            nr_keste.Text = numer_keste.ToString();
            printo_fature();

            hide();
            menjehere.Visible = false;
            skontolbl.Text = "0";
            Kursilbl.Text = "";
            penlbl.Text = "0";

           
          
            msbox("Pagesa u krye !");
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
            var s_nxenesi = from c in financa_sh.Skontos
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
            var s_nxenesi = from c in financa_sh.Kestets
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

                if ((ka_keste1(Convert.ToInt64(Nxenesiddl.Items[r].Value)) == false) || (ka_prenotim(Convert.ToInt64(Nxenesiddl.Items[r].Value)) == false))
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
                if (penlbl.Text != "")
                    this.Pen = penlbl.Text;
                else
                    this.Pen = "0";
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
            menjehere.Visible = false;
        }

        protected void datepicker2_TextChanged(object sender, EventArgs e)
        {
            if (kestetotlbl.Text != "0")
            {
                skontolbl.Text = Convert.ToString(Math.Round(Convert.ToDecimal(datepicker2.Text) / (Convert.ToDecimal(kestetotlbl.Text)) * 100, 2));
                // = datepicker.Text;
                totalilbl.Text = (Convert.ToDecimal(kestetotlbl.Text) - Convert.ToDecimal(datepicker2.Text)).ToString();
            }
            datepicker2.Text = "";
        }

        protected void menjehere_CheckedChanged(object sender, EventArgs e)
        {
            if (menjehere.Checked == true)
            {
                datepicker2.Enabled = false;
                datepicker1.Enabled = false;
            }
            else
            {
                datepicker2.Enabled = true;
                datepicker1.Enabled = false;
            }
        }

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //   Server.Transfer("~/Printimi.aspx");
            
        //}

        //protected void Button2_Click1(object sender, EventArgs e)
        //{
        //    printo_fature1();
        //}

        //protected void Button3_Click(object sender, EventArgs e)
        //{

        //}


  

     
       

     
       


        





    }
}
       

       
