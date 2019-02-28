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
    public partial class Aktiv_Pasiv : System.Web.UI.Page
    {
        
      
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!Page.IsPostBack)
            {
                hide();
                vitiddl1.Text = gjej_vitin();
                
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
          
            hide();
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
                if (ka_keste(Convert.ToInt64(Nxenesiddl.SelectedValue)) == false)
                {
                    //kestelbl.Text = "Nxenesi nuk i jane konfiguruar kestet !";
                  
                    hide();
                }
                else
                {
                   
                    keste_pa_pag_check();
                  
                    show();
                    if (ka_pag_keste_tegjitha(Convert.ToInt64(Nxenesiddl.SelectedValue)))                     
                         {
                        
                          hide();
                         } 
                }
            }
            else
            {
              
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
                if (ka_keste(Convert.ToInt64(Nxenesiddl.SelectedValue)) == false)
                {
                    //kestelbl.Text = "Nxenesi nuk i jane konfiguruar kestet !";
                   
                    hide();
                }
                else
                {
                    

                    keste_pa_pag_check();
                  
                    show();

                                
                    if (ka_pag_keste_tegjitha(Convert.ToInt64(Nxenesiddl.SelectedValue)))
                    {
                       
                        hide();
                    } 
                }
            }
         
           
           
        }

        protected void keste_pa_pag_check() // kestet e transportit 
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Transporti tr = new Transporti();
            var keste_p = from c in financa_sh.Transportis
                          where (c.Id_nxenesi.ToString() == Nxenesiddl.SelectedValue) && (c.Paguar == false)
                          select new { c.Nr_kesti, c.Vlera, c.Paguar,c.Aktiv };
            GridView1.DataSource = keste_p;
            GridView1.Columns[2].Visible = true;
            GridView1.DataBind();
            GridView1.Columns[2].Visible = false;
          
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

          
                //int[] v = { 0, 0, 0, 0, 0, 0, 0, 0, 0,0 };

                //for (int i = 0; i < GridView1.Rows.Count; i++)
                //{
                //    CheckBox chbTemp = GridView1.Rows[i].FindControl("CheckBox1") as CheckBox;
                //    if (chbTemp.Checked == true)
                //    {
                //        v[i] = 1;
                //        if ((chbTemp.Enabled == true) && (chbTemp.Checked == false))
                //        kestetotlbl.Text = (Convert.ToDecimal(GridView1.Rows[i].Cells[1].Text) + Convert.ToDecimal(kestetotlbl.Text)).ToString();
                //    }
                //    if (chbTemp.Checked==false)
                //        v[i] = 2;
                //    if (chbTemp.Enabled == false)
                //        v[i]=0;
                //}

                //int nr_check = 0;
                //for (int i = 0; i < GridView1.Rows.Count; i++)
                //{
                //    CheckBox chbTemp = GridView1.Rows[i].FindControl("CheckBox1") as CheckBox;

                //    if ((chbTemp.Checked == true)&&(chbTemp.Enabled==true))
                //        nr_check = nr_check + 1;

                //}

                //kestetotlbl.Text = (Convert.ToDecimal(GridView1.Rows[0].Cells[1].Text) * nr_check).ToString();

                //    v = v.Where(val => val != 0).ToArray(); //heq zerot nga array v
                //for (int j = 0; j < v.Length-1; j++)
                //{                                        
                //        if ((v[j] > v[j+1]) && (v[j + 1] != 0))
                //        {
                //            kestetotlbl.Text = "0";
                //            msbox("Lejohet te zgjidhen vetem keste te njepasnjeshem !");
                //            keste_pa_pag_check();
                //        }
                //    }

                //valutalbl.Text = valuta();


            
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
         
            Button1.Visible = false;
            GridView1.Visible = false;
         

        }
        protected void show()
        {
            
          
            Button1.Visible = true;
            GridView1.Visible = true;
           
        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Kestet k = new Kestet();
          
            CheckBox chbTemp1 = GridView1.Rows[0].FindControl("CheckBox1") as CheckBox;
       
//aktiv = true ne tabelen e kesteve te transportit
           var keste_pa = from c in financa_sh.Transportis
                          where (c.Id_nxenesi.ToString() == Nxenesiddl.SelectedValue) && (c.Paguar == false)
                          select c;
         

           int count = 0;
           foreach (var d in keste_pa)
            {
                
                CheckBox chbTemp = GridView1.Rows[count].FindControl("CheckBox1") as CheckBox;

              
                    if (chbTemp.Checked == false)
                        d.Aktiv = false;
                    else
                        d.Aktiv = true;
                count = count + 1;
              
              
            }

       
            financa_sh.SubmitChanges();
            GridViewRow row = GridView1.Rows[0];
               
            msbox("Pagesa u krye !");
            hide();
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







        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                CheckBox cb1 = (CheckBox)e.Row.FindControl("CheckBox1");
                if (cb1.Checked)
                {

                    e.Row.BackColor = System.Drawing.Color.MediumSeaGreen;
                    e.Row.ForeColor = System.Drawing.Color.White;

                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.Crimson;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
              
                //
            }
        }



       


        





    }
}
       

       
