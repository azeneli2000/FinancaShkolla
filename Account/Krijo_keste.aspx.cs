using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

using System.Xml.Linq;
using System.Web.Configuration;
using System.IO;
namespace financa_shkolla.Account
{
  

    public partial class Krijo_keste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                vitiddl1.Text = gjej_vitin();
               
            }
            TextBox1.Attributes.Add("autocomplete", "off");         
            komenttxt.Attributes.Add("autocomplete", "off");
           
          
        }


        protected void bind_uljet()
        {
            XDocument xmlContent = new XDocument();
            string constr = Server.MapPath("~/Account/Uljet.xml").ToString();

            if (File.Exists(constr))
            {
                xmlContent = XDocument.Load(constr);
                var content = from data in xmlContent.Descendants("Ulje")
                              select new { emri = ((string)data.Element("Emri")), per = ((string)data.Element("Pershkrimi")) };
                int i = content.Count();
              
                foreach (var v in content)
                {
                    mydiv.Controls.Add(new LiteralControl(v.emri.ToString() + " = " + v.per.ToString())); //Add some test text

                    mydiv.Controls.Add(new LiteralControl("<br/>")); //Add line break
                    mydiv.Attributes.Add("style","color : blue;");
                   // mydiv.Visible = false; //e ben te padukshem
                }
                
            }


        }
        protected void clear_b_label()
        {
            b1.Text = "";
            b2.Text = "";
            b3.Text = "";
            b4.Text = "";
            b5.Text = "";
            b6.Text = "";
            bb1.Text = "";
            bb2.Text = "";
            bb3.Text = "";
            bb4.Text = "";
            bb5.Text = "";
            bb6.Text = "";

            u1.Text = "";
            u2.Text = "";
            u3.Text = "";
            u4.Text = "";
            u5.Text = "";
            u6.Text = "";
            uu1.Text = "";
            uu2.Text = "";
            uu3.Text = "";
            uu4.Text = "";
            uu5.Text = "";
            uu6.Text = "";



        }

        protected void vendos_cmimin(string klasa)
        {
            //vendos cmimin dhe prenotimin dhe gjithe labelat e tjere i ben 0
            if (klasa != "")
            {
                DataClasses1DataContext financa_sh = new DataClasses1DataContext();
                var cmimi_klasa = from c in financa_sh.Cmimets
                                  where (c.Klasa == Convert.ToInt16(Klasaddl.Text)) && (c.Viti_shkollor == vitiddl1.Text)
                                  select new { c.Cmimi, c.Valuta, c.Prenotimi, c.Valuta_prenotimi };
                if (cmimi_klasa.Count() == 0)
                {
                    Cmimilbl.Text = "Klasa nuk ka cmim !";
                    Valutalbl.Text = "";
                    Prenotimilbl.Text = "";
                    v_prenotimilbl.Text = "";
                    skontoddl.Visible = false;
                    TextBox1.Visible = false;
                    Krijo.Visible = false;
                    LinkButton1.Visible = false;
                    komenttxt.Visible = false;

                    Label3.Visible = false;
                    Label4.Visible = false;
                    totalilbl.Text = "";
                    kestetlbl.Text = "";
                    skonto_tot.Text = "";
                    vlera_tot.Text = "";
                    clear_b_label();
                    //fillestarddl.Visible = false;
                    //fillestarlbl.Visible = false;
                }
                else
                {
                    Cmimilbl.Text = "CMIMI   : " + cmimi_klasa.FirstOrDefault().Cmimi.ToString();
                    Valutalbl.Text = "  " + cmimi_klasa.FirstOrDefault().Valuta.ToString();
                    Prenotimilbl.Text = "PRENOTIMI    :           " + cmimi_klasa.FirstOrDefault().Prenotimi.ToString();
                    v_prenotimilbl.Text = "  " + cmimi_klasa.FirstOrDefault().Valuta_prenotimi.ToString();

                    Krijo.Visible = false;
                    LinkButton1.Visible = false;
                    komenttxt.Visible = false;
                    skontoddl.Visible = false;
                    TextBox1.Visible = false;
                    Label3.Visible = false;
                    Label4.Visible = false;
                    totalilbl.Text = "";
                    kestetlbl.Text = "";
                    skonto_tot.Text = "";
                    vlera_tot.Text = "";
                    clear_b_label();
                    //fillestarddl.Visible = false;
                    //fillestarlbl.Visible = false;
                }
            }
            else
            {
                Cmimilbl.Text = "";
                Prenotimilbl.Text = "";
                Valutalbl.Text = "";
                v_prenotimilbl.Text = "";
                skonto_tot.Text = "";
                vlera_tot.Text = "";
                clear_b_label();
            }
        }
  

        protected void Klasaddl_SelectedIndexChanged(object sender, EventArgs e)
        {

            Indeksiddl.SelectedIndex = 0;

            DataClasses1DataContext financa_sh = new DataClasses1DataContext();

            vendos_cmimin(Klasaddl.Text);
            
            
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
            krijuar_keste.Visible = false;

        }

        protected void Indeksiddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Nxenesi nxenesit = new Nxenesi();
            vendos_cmimin(Klasaddl.Text);

            var nxensi_klasa = from c in financa_sh.Nxenesis
                               where (c.Klasa == Klasaddl.SelectedValue) && (c.Indeksi == Indeksiddl.SelectedValue) && (c.Viti_shkollor == vitiddl1.SelectedValue)
                               let emri = c.Emri
                               let mbiemri = c.Mbiemri

                               select new { c.Id_nxenesi, c.Emri, c.Mbiemri, em = emri + " " + mbiemri, c.Atesia, c.Memesia, c.Ditelindja, c.Nr_amza, c.Nr_tel };
            Nxenesiddl.DataSource = nxensi_klasa;
            Nxenesiddl.DataTextField = "em";
            Nxenesiddl.DataValueField = "Id_nxenesi";

            Nxenesiddl.DataBind();
          if (Cmimilbl.Text != "Klasa nuk ka cmim !")
            if (Nxenesiddl.Text != "")
            { //vendos gjeneralitetet
                  Atesialbl.Text = "ATESIA  : " + nxensi_klasa.FirstOrDefault().Atesia.ToString();
                  Memesialbl.Text = "MEMESIA  : " + nxensi_klasa.FirstOrDefault().Memesia.ToString();
                  Tellbl.Text = "TEL  : " + nxensi_klasa.FirstOrDefault().Nr_tel.ToString();
                  Amzalbl.Text = "AMZA  : " + nxensi_klasa.FirstOrDefault().Nr_amza.ToString();
            
                if (ka_keste(Convert.ToInt32(Nxenesiddl.SelectedValue)) == false)
                  {
                    //bej visible te gjithe kontrollet e tjera
                    krijuar_keste.Visible = false;
                    Krijo.Visible = true;
                    LinkButton1.Visible = true;
                    komenttxt.Visible = true;
                    skontoddl.Visible = true;
                    TextBox1.Visible = true;
                    Label3.Visible = true;
                    Label4.Visible = true;
                    //fillestarddl.Visible = true;
                    //fillestarlbl.Visible = true;
                    //fillestarddl.Text = "1";
                    totalilbl.Text = "VLERA TOTALE  : " + (Convert.ToInt32(Cmimilbl.Text.Remove(0, 10)) - (Convert.ToInt32(Prenotimilbl.Text.Remove(0, 25)))).ToString();
                    kestetlbl.Text = "VLERA E KESTIT  : " + (Convert.ToDecimal(totalilbl.Text.Remove(0, 16)) / 10).ToString();
                }
                else
                {
                    krijuar_keste.Visible = true;
                    skontoddl.Visible = false;
                    TextBox1.Visible = false;
                    Krijo.Visible = false;
                    LinkButton1.Visible = false;
                    komenttxt.Visible = false;
                    Label3.Visible = false;
                    Label4.Visible = false;
                    totalilbl.Text = "";
                    kestetlbl.Text = "";
                    //fillestarddl.Visible = false;
                    //fillestarlbl.Visible = false;

                }            
                   
              }
                   else
                 
                    {
                    skontoddl.Visible = false;
                    TextBox1.Visible = false;
                    Krijo.Visible = false;
                    LinkButton1.Visible = false;
                    komenttxt.Visible = false;
                    Label3.Visible = false;
                    Label4.Visible = false;
                    totalilbl.Text = "";
                    kestetlbl.Text = "";
                    krijuar_keste.Visible = false;
                    //fillestarddl.Visible = false;
                    //fillestarlbl.Visible = false;
                    }       
          


            }
         
      


        protected void vitiddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Klasaddl.SelectedIndex = 0;
            Indeksiddl.SelectedIndex=0;
            vendos_cmimin(Klasaddl.Text);
           
            
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
            skontoddl.Visible = false;
            TextBox1.Visible = false;
            Krijo.Visible = false;
            LinkButton1.Visible = false;
            komenttxt.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            totalilbl.Text = "";
            kestetlbl.Text = "";
            krijuar_keste.Visible = false;
            //fillestarddl.Visible = false;
            //fillestarlbl.Visible = false;
 
        }


        protected void Nxenesiddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Nxenesi nxenesit = new Nxenesi();

            Nxenesiddl.DataBind();

            var nxenesi_id = from c in financa_sh.Nxenesis
                             where (c.Id_nxenesi.ToString() == Nxenesiddl.SelectedValue)
                             select new { c.Atesia, c.Memesia, c.Ditelindja, c.Nr_amza, c.Nr_tel };

            if (Cmimilbl.Text != "Klasa nuk ka cmim !")
            { 
                if (Nxenesiddl.Text != "")
                { //vendos gjeneralitetet
                    Atesialbl.Text = "ATESIA  : " + nxenesi_id.FirstOrDefault().Atesia.ToString();
                    Memesialbl.Text = "MEMESIA  : " + nxenesi_id.FirstOrDefault().Memesia.ToString();
                    Tellbl.Text = "TEL  : " + nxenesi_id.FirstOrDefault().Nr_tel.ToString();
                    Amzalbl.Text = "AMZA  : " + nxenesi_id.FirstOrDefault().Nr_amza.ToString();

                    if (ka_keste(Convert.ToInt32(Nxenesiddl.SelectedValue)) == false)
                    {
                        //bej visible te gjithe kontrollet e tjera
                        krijuar_keste.Visible = false;
                        Krijo.Visible = true;
                        LinkButton1.Visible = true;               
                        komenttxt.Visible = true;
                        skontoddl.Visible = true;
                        TextBox1.Visible = true;
                        Label3.Visible = true;
                        Label4.Visible = true;
                        //fillestarddl.Visible = true;
                        //fillestarlbl.Visible = true;
                        //fillestarddl.Text = "1";
                        totalilbl.Text = "VLERA TOTALE  : " + (Convert.ToInt32(Cmimilbl.Text.Remove(0, 10)) - (Convert.ToInt32(Prenotimilbl.Text.Remove(0, 25)))).ToString();
                        kestetlbl.Text = "VLERA E KESTIT  : " + (Convert.ToDecimal(totalilbl.Text.Remove(0, 16)) / 10).ToString();
                        totalilbl.Visible = true;
                    }
                    else
                    {
                        krijuar_keste.Visible = true;
                        skontoddl.Visible = false;
                        TextBox1.Visible = false;
                        Krijo.Visible = false;
                        LinkButton1.Visible = false;
                        komenttxt.Visible = false;
                        Label3.Visible = false;
                        Label4.Visible = false;
                        totalilbl.Text = "";
                        kestetlbl.Text = "";
                        //fillestarddl.Visible = false;
                        //fillestarlbl.Visible = false;
                    }
                }
                   else
                 
                    {
                    skontoddl.Visible = false;
                    TextBox1.Visible = false;
                    Krijo.Visible = false;
                    LinkButton1.Visible = false;
                    komenttxt.Visible = false;
                    Label3.Visible = false;
                    Label4.Visible = false;
                    totalilbl.Text = "";
                    kestetlbl.Text = "";
                    krijuar_keste.Visible = false;
                    //fillestarddl.Visible = false;
                    //fillestarlbl.Visible = false;
                    }
            }  
               
            
                 
        }

       

      

        //protected void GridView1_DataBound(object sender, EventArgs e)
        //{
        //    if (GridView1.Rows.Count > 0)
        //    {
        //        Boolean hasData = true;


        //        for (int col = 0; col < GridView1.HeaderRow.Cells.Count; col++)
        //        {


        //            for (int row = 0; row < GridView1.Rows.Count; row++)
        //            {


        //                if (!String.IsNullOrEmpty(GridView1.Rows[row].Cells[col].Text)
        //                    && !String.IsNullOrEmpty(HttpUtility.HtmlDecode(GridView1.Rows[row].Cells[col].Text).Trim()))
        //                {


        //                    hasData = true;


        //                    break;


        //                }


        //            }




        //            if (!hasData)
        //            {

        //                GridView1.HeaderRow.Cells[col].Visible = false;

        //                for (int hiddenrows = 0; hiddenrows < GridView1.Rows.Count; hiddenrows++)
        //                {

        //                    GridView1.Rows[hiddenrows].Cells[col].Visible = false;

        //                }



        //            }



        //            hasData = false;


        //        }


                
        //    }

        //}

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
            decimal cs;
            //heren  e pare i bej gjithe elementet 0
            if (b1.Text == "" && b2.Text == "" && b3.Text == "" && b4.Text == "" && b5.Text == "" && b6.Text == "" && u1.Text == "" && u2.Text == "" && u3.Text == "" && u4.Text == "" && u5.Text == "" && u6.Text == "")

            for (int i = 0; i <= 11; i++)
            {
                globale.skonto_array[i] = 0;
            }
            switch (skontoddl.SelectedValue)
            {
                case "1" :
                    {                    
                    bb1.Text = skontoddl.SelectedItem.Text + ":";
                  
                      
                        b1.Text = TextBox1.Text;
                        globale.skonto_array[0] = Convert.ToDecimal(b1.Text);

                    if ((TextBox1.Text == "0") && (b1.Text != ""))//kur eshte 0
                    {
                        b1.Text = "";
                        bb1.Text = "";
                    } 
                        TextBox1.Text = "";
                    cs = apliko_skonto(globale.skonto_array);
                    //cmimi_skonto.Text = cs.ToString();
                    totalilbl.Text = "VLERA TOTALE  : " + Math.Round((cs - Convert.ToInt32(Prenotimilbl.Text.Remove(0, 25))),2).ToString();
                    kestetlbl.Text = "VLERA E KESTIT  : " +Math.Round((Convert.ToDecimal(totalilbl.Text.Remove(0, 16)) / 10),2).ToString();
                    skonto_tot.Text =  Math.Round(((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs) / Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) * 100),2).ToString() + "% = ";
                    vlera_tot.Text = Math.Round((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs), 2).ToString();
                break;
                    }
                case "2":
                    {
                        bb2.Text = skontoddl.SelectedItem.Text + ":";
                       
                        b2.Text = TextBox1.Text;
                        globale.skonto_array[1] = Convert.ToDecimal(b2.Text);
                        if ((TextBox1.Text == "0") && (b2.Text != ""))//kur eshte 0
                        {
                            b2.Text = "";
                            bb2.Text = "";
                        }
                        TextBox1.Text = "";
                        cs = apliko_skonto(globale.skonto_array);
                        
                        totalilbl.Text = "VLERA TOTALE  : " + Math.Round((cs - Convert.ToInt32(Prenotimilbl.Text.Remove(0, 25))), 2).ToString();
                        kestetlbl.Text = "VLERA E KESTIT  : " + Math.Round((Convert.ToDecimal(totalilbl.Text.Remove(0, 16)) / 10), 2).ToString();
                        skonto_tot.Text = Math.Round(((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs) / Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) * 100), 2).ToString() + "% = ";
                        vlera_tot.Text = Math.Round((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs), 2).ToString();
                        break;
                    }
                case "3":
                    {
                        bb3.Text = skontoddl.SelectedItem.Text + ":";
                       
                        b3.Text = TextBox1.Text;
                        globale.skonto_array[2] = Convert.ToDecimal(b3.Text);
                        if ((TextBox1.Text == "0") && (b3.Text != ""))//kur eshte 0
                        {
                            b3.Text = "";
                            bb3.Text = "";
                        }
                        TextBox1.Text = "";
                        cs = apliko_skonto(globale.skonto_array);

                        totalilbl.Text = "VLERA TOTALE  : " + Math.Round((cs - Convert.ToInt32(Prenotimilbl.Text.Remove(0, 25))), 2).ToString();
                        kestetlbl.Text = "VLERA E KESTIT  : " + Math.Round((Convert.ToDecimal(totalilbl.Text.Remove(0, 16)) / 10), 2).ToString();
                        skonto_tot.Text = Math.Round(((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs) / Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) * 100), 2).ToString() + "% = ";
                        vlera_tot.Text = Math.Round((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs), 2).ToString();
                        break;
                    }
                case "4":
                    {
                        bb4.Text = skontoddl.SelectedItem.Text + ":";
                        
                        b4.Text = TextBox1.Text;
                        globale.skonto_array[3] = Convert.ToDecimal(b4.Text);
                        if ((TextBox1.Text == "0") && (b4.Text != ""))//kur eshte 0
                        {
                            b4.Text = "";
                            bb4.Text = "";
                        }
                        TextBox1.Text = "";
                        cs = apliko_skonto(globale.skonto_array);

                        totalilbl.Text = "VLERA TOTALE  : " + Math.Round((cs - Convert.ToInt32(Prenotimilbl.Text.Remove(0, 25))), 2).ToString();
                        kestetlbl.Text = "VLERA E KESTIT  : " + Math.Round((Convert.ToDecimal(totalilbl.Text.Remove(0, 16)) / 10), 2).ToString();
                        skonto_tot.Text = Math.Round(((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs) / Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) * 100), 2).ToString() + "% = ";
                        vlera_tot.Text = Math.Round((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs), 2).ToString();
                        break;
                    }
                case "5":
                    {
                        bb5.Text = skontoddl.SelectedItem.Text + ":";
                       
                        b5.Text = TextBox1.Text;
                        globale.skonto_array[4] = Convert.ToDecimal(b5.Text);
                        if ((TextBox1.Text == "0") && (b5.Text != ""))//kur eshte 0
                        {
                            b5.Text = "";
                            bb5.Text = "";
                        }
                        TextBox1.Text = "";
                        cs = apliko_skonto(globale.skonto_array);

                        totalilbl.Text = "VLERA TOTALE  : " + Math.Round((cs - Convert.ToInt32(Prenotimilbl.Text.Remove(0, 25))), 2).ToString();
                        kestetlbl.Text = "VLERA E KESTIT  : " + Math.Round((Convert.ToDecimal(totalilbl.Text.Remove(0, 16)) / 10), 2).ToString();
                        skonto_tot.Text = Math.Round(((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs) / Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) * 100), 2).ToString() + "% = ";
                        vlera_tot.Text = Math.Round((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs), 2).ToString();
                        break;
                    }
                case "6":
                    {
                        bb6.Text = skontoddl.SelectedItem.Text + ":";

                        b6.Text = TextBox1.Text;
                        globale.skonto_array[5] = Convert.ToDecimal(b6.Text);
                        if ((TextBox1.Text == "0") && (b6.Text != ""))//kur eshte 0
                        {
                            b6.Text = "";
                            bb6.Text = "";
                        }
                        TextBox1.Text = "";
                        cs = apliko_skonto(globale.skonto_array);

                        totalilbl.Text = "VLERA TOTALE  : " + Math.Round((cs - Convert.ToInt32(Prenotimilbl.Text.Remove(0, 25))), 2).ToString();
                        kestetlbl.Text = "VLERA E KESTIT  : " + Math.Round((Convert.ToDecimal(totalilbl.Text.Remove(0, 16)) / 10), 2).ToString();
                        skonto_tot.Text = Math.Round(((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs) / Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) * 100), 2).ToString() + "% = ";
                        vlera_tot.Text = Math.Round((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs), 2).ToString();

                        break;
                    }

                         case "7":
                    {
                        uu1.Text = skontoddl.SelectedItem.Text + ":";
                       
                        u1.Text = TextBox1.Text;
                        globale.skonto_array[6] = Convert.ToDecimal(u1.Text);
                        if ((TextBox1.Text == "0") && (u1.Text != ""))//kur eshte 0
                        {
                            u1.Text = "";
                            uu1.Text = "";
                        }
                        TextBox1.Text = "";
                        cs = apliko_skonto(globale.skonto_array);

                        totalilbl.Text = "VLERA TOTALE  : " + Math.Round((cs - Convert.ToInt32(Prenotimilbl.Text.Remove(0, 25))), 2).ToString();
                        kestetlbl.Text = "VLERA E KESTIT  : " + Math.Round((Convert.ToDecimal(totalilbl.Text.Remove(0, 16)) / 10), 2).ToString();
                        skonto_tot.Text = Math.Round(((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs) / Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) * 100), 2).ToString() + "% = ";
                        vlera_tot.Text = Math.Round((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs), 2).ToString();

                        break;
                    }

                         case "8":
                    {
                        uu2.Text = skontoddl.SelectedItem.Text + ":";

                        u2.Text = TextBox1.Text;
                        globale.skonto_array[7] = Convert.ToDecimal(u2.Text);
                        if ((TextBox1.Text == "0") && (u2.Text != ""))//kur eshte 0
                        {
                            u2.Text = "";
                            uu2.Text = "";
                        }
                        TextBox1.Text = "";
                        cs = apliko_skonto(globale.skonto_array);

                        totalilbl.Text = "VLERA TOTALE  : " + Math.Round((cs - Convert.ToInt32(Prenotimilbl.Text.Remove(0, 25))), 2).ToString();
                        kestetlbl.Text = "VLERA E KESTIT  : " + Math.Round((Convert.ToDecimal(totalilbl.Text.Remove(0, 16)) / 10), 2).ToString();
                        skonto_tot.Text = Math.Round(((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs) / Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) * 100), 2).ToString() + "% = ";
                        vlera_tot.Text = Math.Round((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs), 2).ToString();

                        break;
                    }

                           case "9":
                    {
                        uu3.Text = skontoddl.SelectedItem.Text + ":";
                       
                        u3.Text = TextBox1.Text;
                        globale.skonto_array[8] = Convert.ToDecimal(u3.Text);
                        if ((TextBox1.Text == "0") && (u3.Text != ""))//kur eshte 0
                        {
                            u3.Text = "";
                            uu3.Text = "";
                        }
                        TextBox1.Text = "";
                        cs = apliko_skonto(globale.skonto_array);

                        totalilbl.Text = "VLERA TOTALE  : " + Math.Round((cs - Convert.ToInt32(Prenotimilbl.Text.Remove(0, 25))), 2).ToString();
                        kestetlbl.Text = "VLERA E KESTIT  : " + Math.Round((Convert.ToDecimal(totalilbl.Text.Remove(0, 16)) / 10), 2).ToString();
                        skonto_tot.Text = Math.Round(((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs) / Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) * 100), 2).ToString() + "% = ";
                        vlera_tot.Text = Math.Round((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs), 2).ToString();

                        break;
                    }
                           case "10":

                      {
                        uu4.Text = skontoddl.SelectedItem.Text + ":";
                       
                        u4.Text = TextBox1.Text;
                        globale.skonto_array[9] = Convert.ToDecimal(u4.Text);
                        if ((TextBox1.Text == "0") && (u4.Text != ""))//kur eshte 0
                        {
                            u4.Text = "";
                            uu4.Text = "";
                        }
                        TextBox1.Text = "";
                        cs = apliko_skonto(globale.skonto_array);

                        totalilbl.Text = "VLERA TOTALE  : " + Math.Round((cs - Convert.ToInt32(Prenotimilbl.Text.Remove(0, 25))), 2).ToString();
                        kestetlbl.Text = "VLERA E KESTIT  : " + Math.Round((Convert.ToDecimal(totalilbl.Text.Remove(0, 16)) / 10), 2).ToString();
                        skonto_tot.Text = Math.Round(((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs) / Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) * 100), 2).ToString() + "% = ";
                        vlera_tot.Text = Math.Round((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs), 2).ToString();

                        break;
                    }

                           case "11":
                      {
                          uu5.Text = skontoddl.SelectedItem.Text + ":";

                          u5.Text = TextBox1.Text;
                          globale.skonto_array[10] = Convert.ToDecimal(u5.Text);
                          if ((TextBox1.Text == "0") && (u5.Text != ""))//kur eshte 0
                          {
                              u5.Text = "";
                              uu5.Text = "";
                          }
                          TextBox1.Text = "";
                          cs = apliko_skonto(globale.skonto_array);

                          totalilbl.Text = "VLERA TOTALE  : " + Math.Round((cs - Convert.ToInt32(Prenotimilbl.Text.Remove(0, 25))), 2).ToString();
                          kestetlbl.Text = "VLERA E KESTIT  : " + Math.Round((Convert.ToDecimal(totalilbl.Text.Remove(0, 16)) / 10), 2).ToString();
                          skonto_tot.Text = Math.Round(((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs) / Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) * 100), 2).ToString() + "% = ";
                          vlera_tot.Text = Math.Round((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs), 2).ToString();

                          break;
                      }

                           case "12":
                      {
                          uu6.Text = skontoddl.SelectedItem.Text + ":";

                          u6.Text = TextBox1.Text;
                          //globale.skonto_array[11] = Convert.ToDecimal(u6.Text, CultureInfo.CreateSpecificCulture("en-US"));
                          globale.skonto_array[11] = Convert.ToDecimal(u6.Text);
                          if ((TextBox1.Text == "0") && (u6.Text != ""))//kur eshte 0
                          {
                              u6.Text = "";
                              uu6.Text = "";
                          }
                          TextBox1.Text = "";
                          cs = apliko_skonto(globale.skonto_array);

                          totalilbl.Text = "VLERA TOTALE  : " + Math.Round((cs - Convert.ToInt32(Prenotimilbl.Text.Remove(0, 25))), 2).ToString();
                          kestetlbl.Text = "VLERA E KESTIT  : " + Math.Round((Convert.ToDecimal(totalilbl.Text.Remove(0, 16)) / 10), 2).ToString();
                          skonto_tot.Text = Math.Round(((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs) / Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) * 100), 2).ToString() + "% = ";
                          vlera_tot.Text = Math.Round((Convert.ToDecimal(Cmimilbl.Text.Remove(0, 10)) - cs), 2).ToString();

                          break;
                      }

            
           
    }
          }

    
        protected decimal apliko_skonto (decimal [] skonto)
        {
            decimal cmimi_skontuar = Convert.ToInt32(Cmimilbl.Text.Remove(0, 10));
       for (int i = 0; i <= 11; i++)       
         if (skonto[i]!=0)       
       
             cmimi_skontuar = cmimi_skontuar-  cmimi_skontuar * skonto[i]/100;
        
            return cmimi_skontuar;
        }

        protected bool ka_keste(Int64 id)
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
 


       

      

        public static class globale
        {
            public static decimal[] skonto_array = new decimal[12];
        }

        public string gjej_vitin()
        {
            if (DateTime.Now.Month >= 7)
                return (DateTime.Now.Year).ToString() + "-" + (DateTime.Now.Year + 1).ToString();
            else
                return
                 (DateTime.Now.Year-1).ToString() + "-" + (DateTime.Now.Year).ToString();
        }

        protected void Krijo_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Skonto skoto = new Skonto();
           
           
            Kestet kesti3 = new Kestet();
            Kestet kesti4 = new Kestet();
            Kestet kesti5 = new Kestet();
            Kestet kesti6 = new Kestet();
            Kestet kesti7 = new Kestet();
            Kestet kesti8 = new Kestet();
            Kestet kesti9 = new Kestet();
            Kestet kesti10 = new Kestet();
            
            //fut skontot te tabela e skontove

            skoto.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
          
            if (b1.Text != "")
                skoto.Ulje_1 = Convert.ToDecimal(b1.Text);
            if (b2.Text != "")
                skoto.Ulje_2 = Convert.ToDecimal(b2.Text);
            if (b3.Text != "")
                skoto.Ulje_3 = Convert.ToDecimal(b3.Text);
            if (b4.Text != "")
                skoto.Ulje_4 = Convert.ToDecimal(b4.Text);
            if (b5.Text != "")
                skoto.Ulje_5 = Convert.ToDecimal(b5.Text);
            if (b6.Text != "")
                skoto.Ulje_6 = Convert.ToDecimal(b6.Text);
            if (u1.Text != "")
                skoto.Ulje_7 = Convert.ToDecimal(u1.Text);
            if (u2.Text != "")
                skoto.Ulje_8 = Convert.ToDecimal(u2.Text);
            if (u3.Text != "")
                skoto.Ulje_9 = Convert.ToDecimal(u3.Text);
            if (u4.Text != "")
                skoto.Ulje_10 = Convert.ToDecimal(u4.Text);
            if (u5.Text != "")
                skoto.Ulje_11 = Convert.ToDecimal(u5.Text);
            if (u6.Text != "")
                skoto.Ulje_12 = Convert.ToDecimal(u6.Text);
            financa_sh.Skontos.InsertOnSubmit(skoto);



            //fut kestet te tabela e kesteve
            //Kestet prenotimi = new Kestet();
            //prenotimi.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
            //prenotimi.Nr_kesti = 0;
            //prenotimi.Vlera = Convert.ToInt32(Prenotimilbl.Text.Remove(0, 25));
            //prenotimi.Skonto = 0;
            //prenotimi.Penaliteti = 0;
            //prenotimi.Paguar = false;
            //prenotimi.Aktiv = true;
            // prenotimi.Fillestar = false;
            //financa_sh.Kestets.InsertOnSubmit(prenotimi);

            //if (Convert.ToInt16(fillestarddl.SelectedItem.Text) <= 1)
            //{
                Kestet kesti1 = new Kestet();
                kesti1.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                kesti1.Nr_kesti = 1;
                kesti1.Vlera = Convert.ToDecimal(kestetlbl.Text.Remove(0, 18));
                kesti1.Skonto = 0;
                kesti1.Penaliteti = 0;
                kesti1.Paguar = false;
                kesti1.Aktiv = true;
               // kesti1.Fillestar = false;

                financa_sh.Kestets.InsertOnSubmit(kesti1);
           // }
            //if (Convert.ToInt16(fillestarddl.SelectedItem.Text) <= 2)
            //{
                Kestet kesti2 = new Kestet();
                kesti2.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                kesti2.Nr_kesti = 2;
                kesti2.Vlera = Convert.ToDecimal(kestetlbl.Text.Remove(0, 18));
                kesti2.Skonto = 0;
                kesti2.Penaliteti = 0;
                kesti2.Paguar = false;
                kesti2.Aktiv = true;
               // kesti2.Fillestar = false;
                financa_sh.Kestets.InsertOnSubmit(kesti2);
           // }
            //if (Convert.ToInt16(fillestarddl.SelectedItem.Text) <= 3)
            //{
                kesti3.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                kesti3.Nr_kesti = 3;
                kesti3.Vlera = Convert.ToDecimal(kestetlbl.Text.Remove(0, 18));
                kesti3.Skonto = 0;
                kesti3.Penaliteti = 0;
                kesti3.Paguar = false;
                kesti3.Aktiv = true;
              //  kesti3.Fillestar = false;
                financa_sh.Kestets.InsertOnSubmit(kesti3);
            //}
            //if (Convert.ToInt16(fillestarddl.SelectedItem.Text) <= 4)
            //{
                kesti4.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                kesti4.Nr_kesti = 4;
                kesti4.Vlera = Convert.ToDecimal(kestetlbl.Text.Remove(0, 18));
                kesti4.Skonto = 0;
                kesti4.Penaliteti = 0;
                kesti4.Paguar = false;
                kesti4.Aktiv = true;
             //   kesti4.Fillestar = false;
                financa_sh.Kestets.InsertOnSubmit(kesti4);
            //}
            //if (Convert.ToInt16(fillestarddl.SelectedItem.Text) <= 5)
            //{
                kesti5.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                kesti5.Nr_kesti = 5;
                kesti5.Vlera = Convert.ToDecimal(kestetlbl.Text.Remove(0, 18));
                kesti5.Skonto = 0;
                kesti5.Penaliteti = 0;
                kesti5.Paguar = false;
                kesti5.Aktiv = true;
             //   kesti5.Fillestar = false;
                financa_sh.Kestets.InsertOnSubmit(kesti5);
            //}
            //if (Convert.ToInt16(fillestarddl.SelectedItem.Text) <= 6)
            //{
                kesti6.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                kesti6.Nr_kesti = 6;
                kesti6.Vlera = Convert.ToDecimal(kestetlbl.Text.Remove(0, 18));
                kesti6.Skonto = 0;
                kesti6.Penaliteti = 0;
                kesti6.Paguar = false;
                kesti6.Aktiv = true;
             //   kesti6.Fillestar = false;
                financa_sh.Kestets.InsertOnSubmit(kesti6);
            //}
            //if (Convert.ToInt16(fillestarddl.SelectedItem.Text) <= 7)
            //{
                kesti7.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                kesti7.Nr_kesti = 7;
                kesti7.Vlera = Convert.ToDecimal(kestetlbl.Text.Remove(0, 18));
                kesti7.Skonto = 0;
                kesti7.Penaliteti = 0;
                kesti7.Paguar = false;
                kesti7.Aktiv = true;
             //   kesti7.Fillestar = false;
                financa_sh.Kestets.InsertOnSubmit(kesti7);
            //}
            //if (Convert.ToInt16(fillestarddl.SelectedItem.Text) <= 8)
            //{
                kesti8.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                kesti8.Nr_kesti = 8;
                kesti8.Vlera = Convert.ToDecimal(kestetlbl.Text.Remove(0, 18));
                kesti8.Skonto = 0;
                kesti8.Penaliteti = 0;
                kesti8.Paguar = false;
                kesti8.Aktiv = true;
             //   kesti8.Fillestar = false;
                financa_sh.Kestets.InsertOnSubmit(kesti8);
            //}
            //if (Convert.ToInt16(fillestarddl.SelectedItem.Text) <= 9)
            //{
                kesti9.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                kesti9.Nr_kesti = 9;
                kesti9.Vlera = Convert.ToDecimal(kestetlbl.Text.Remove(0, 18));
                kesti9.Skonto = 0;
                kesti9.Penaliteti = 0;
                kesti9.Paguar = false;
                kesti9.Aktiv = true;
             //   kesti9.Fillestar = false;
                financa_sh.Kestets.InsertOnSubmit(kesti9);
            //}
            //if (Convert.ToInt16(fillestarddl.SelectedItem.Text) <= 10)
            //{
                kesti10.Id_nxenesi = Convert.ToInt32(Nxenesiddl.SelectedValue);
                kesti10.Nr_kesti = 10;
                kesti10.Vlera = Convert.ToDecimal(kestetlbl.Text.Remove(0, 18));
                kesti10.Skonto = 0;
                kesti10.Penaliteti = 0;
                kesti10.Paguar = false;
                kesti10.Aktiv = true;
             //   kesti10.Fillestar = false;
                financa_sh.Kestets.InsertOnSubmit(kesti10);
          //  }  

               


          
          
            financa_sh.SubmitChanges();
          //  ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Nxenesit " + Nxenesiddl.SelectedItem.Text + " iu krijuan kestet !" + "');", true);
            msbox("Nxenesit " + Nxenesiddl.SelectedItem.Text + " iu krijuan kestet !");
            vendos_cmimin(Klasaddl.Text);
           
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

        protected void Nxenesiddl_DataBound(object sender, EventArgs e)
        {
            for (int r = 0; r < Nxenesiddl.Items.Count;r++ )
            {
                
                if (!ka_keste(Convert.ToInt64(Nxenesiddl.Items[r].Value)) == false)
                    Nxenesiddl.Items[r].Attributes.Add("style", "color:red");
                
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            bind_uljet();
            if (mydiv.Visible == false)
            {
                mydiv.Visible = true;
                return;
            }
            if (mydiv.Visible == true)
            {
                mydiv.Visible = false;
                return;
            }
        }

      

       


       

       }
     }

    
