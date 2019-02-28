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
    public partial class Arka1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = HttpContext.Current.User.Identity.Name;
            //Calendar1.SelectedDate = DateTime.UtcNow;
            //Calendar2.SelectedDate = DateTime.UtcNow;
            if (!Page.IsPostBack)
            {
                bind_bankat();
               // bind_users();
                DateTime neser = DateTime.Today.AddHours(24);
                Calendar1.SelectedDate = Calendar1.TodaysDate;
                Calendar2.SelectedDate = neser;
                string s12 = Calendar2.SelectedDate.ToString();
            }
        }

    
        protected void bind_bankat()
        {
            XDocument xmlContent = new XDocument();
           string constr = Server.MapPath("~/Account/Bankat.xml").ToString();

            if (File.Exists(constr))
            {
                 xmlContent = XDocument.Load(constr);
                 var content = from data in xmlContent.Descendants("Banka")
                               select new {emri= ((string)data.Element("Emri")) };
                 int i = content.Count();
                vendndodhjaddl.DataSource = content;
                 vendndodhjaddl.DataValueField = "emri";
                 vendndodhjaddl.DataTextField = "emri";
                 vendndodhjaddl.DataBind();
                              
            }
             
            
        }
        protected void bind_users()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            var us = from u in financa_sh.aspnet_Users
                     select u.UserName;
            Userddl.DataSource = us;
            Userddl.DataBind();

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            bind();

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // determine the value of the UnitsInStock field
                int vl =
                 Convert.ToInt32(DataBinder.Eval(e.Row.DataItem,
                 "Vlera"));
                if (vl < 0)
                {
                    e.Row.BackColor = System.Drawing.Color.Crimson;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.MediumSeaGreen;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind();
        }
        protected void bind()
        {
            DataClasses1DataContext financa_sh = new DataClasses1DataContext();
            Arka a = new Arka();
            //  if (Calendar1.SelectedDate == {01/01/0001}) || (Calendar2.SelectedDate == {01/01/0001})
            //{
            //}
           
            var transaksionet_s = from c in financa_sh.Arkas
                                  where (c.Modifikuar_nga.Trim() == Userddl.SelectedItem.Text) && (c.Vendndodhja.Trim() == vendndodhjaddl.SelectedItem.Text) && (c.Data >= Calendar1.SelectedDate) && (c.Data <= Calendar2.SelectedDate)
                                  select new { c.Data, c.Vlera,c.Valuta, c.Modifikuar_nga, c.Tot_E, c.Tot_L, c.Tot_S, c.Vendndodhja, c.Koment, pg = (from p in  financa_sh.Pagesas
                                                                                                                                    where (p.Id_transaksioni == c.Id_transaksioni)
                                                                                                                                    select p).FirstOrDefault().Id_pagesa.ToString()};

            var transaksionet_all = from c in financa_sh.Arkas
                                    where (c.Data >= Calendar1.SelectedDate) && (c.Data <= Calendar2.SelectedDate)
                                    select new { c.Data, c.Vlera,c.Valuta, c.Modifikuar_nga, c.Tot_E, c.Tot_L, c.Tot_S, c.Vendndodhja, c.Koment,pg = (from p in  financa_sh.Pagesas
                                                                                                                                    where (p.Id_transaksioni == c.Id_transaksioni)
                                                                                                                                    select p).FirstOrDefault().Id_pagesa.ToString()};
            if (CheckBox1.Checked == true)
            {
                GridView1.DataSource = transaksionet_all;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = transaksionet_s;
                GridView1.DataBind();
            }

        }
    }
}