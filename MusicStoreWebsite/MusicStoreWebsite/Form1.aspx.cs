using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using MusicStoreLibrary;

namespace MusicStoreWebsite
{
    public partial class Form1 : System.Web.UI.Page
    {
        static List<SongOBJ> arraySongs = new List<SongOBJ>();
        priceCalc calculator = new priceCalc();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DBConnect db = new DBConnect();
                GridView1.DataSource = db.GetDataSet("Select * from Songs");
                GridView1.DataBind();
                if (arraySongs.Count != 0)
                {
                    GridView2.DataSource = arraySongs;
                    GridView2.DataBind();
                }
            }
        }
        public void show2()
        {
            if (arraySongs.Count != 0)
            {
                GridView2.DataSource = arraySongs;
                GridView2.DataBind();
                  
            }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Totals:";
                e.Row.Cells[2].Text = calculator.returnQuantity().ToString();
                e.Row.Cells[4].Text = "$"+calculator.returnTotalC().ToString();
            }
        }

        public void visibilityController(string view)
        {
            switch (view)
            {
                case "Song":
                    GridView1.Visible = true;
                    GridView2.Visible = false;
                    gvStats.Visible = false;
                    gvSubscriptions.Visible = false;
                    lblInfo.Visible = false;
                    break;
                case "Purchase":
                    GridView1.Visible = false;
                    GridView2.Visible = true;
                    gvStats.Visible = false;
                    gvSubscriptions.Visible = false;
                    lblInfo.Visible = true;
                    break;
                case "SearchStats":
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    gvStats.Visible = true;
                    gvSubscriptions.Visible = false;
                    lblInfo.Visible = false;
                    break;
                case "SearchSubsriptions":
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    gvStats.Visible = false;
                    gvSubscriptions.Visible = true;
                    lblInfo.Visible = false;
                    break;
            }
        }
        public void calculatePrice()
        {
            foreach (SongOBJ s in arraySongs)
            {
                calculator.calcTotalCost(s);
                calculator.getTotals(s, Subscription.SelectedValue);
                calculator.updateTotals(s, Subscription.SelectedValue);
            }
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            bool valid = true;
            string errorResponse = "";
            if (txtName.Text == "")
            {
                errorResponse += "Empty Name, ";
                valid = false;
            }
            if (txtPhone.Text == "")
            {
                errorResponse += "Empty Phone #, ";
                valid = false;
            }
            if (txtCreditCard.Text == "")
            {
                errorResponse += "Empty CC #, ";
                valid = false;
            }
            if (txtCCExpMonth.Text == "")
            {
                errorResponse += "Empty ExpMonth, ";
                valid = false;
            }
            if (txtCCExpYear.Text == "")
            {
                errorResponse += "Empty ExpYear, ";
                valid = false;
            }

            if(valid == false)
            {
                lblError.Text = errorResponse;
                return;
            }
            if (valid == true)
            {
                lblError.Text = "";
                lblInfo.Text = "Name: " + txtName.Text+ "<br/>Phone Number: " + txtPhone.Text + "<br/>Credit Card #: " + txtCreditCard.Text+"<br/> Expiration Date: " + txtCCExpMonth.Text+ "/" + txtCCExpYear.Text+ "<br/> Subscription Type: " + Subscription.SelectedItem;
            }

            SongOBJ placeholderSong;
            int q = 0;
            arraySongs.Clear();
            
            bool flag = false;
            for(int row = 0; row < GridView1.Rows.Count; row++)
            {
                CheckBox Cbox;
                Cbox = (CheckBox)GridView1.Rows[row].FindControl("chkSongs");
                if (Cbox.Checked)
                {
                    flag = true;
                    
                    string quantity = "";
                    TextBox T = (TextBox)GridView1.Rows[row].FindControl("txtQuantity");
                    quantity = T.Text;
                    try
                    {
                         q = int.Parse(quantity);
                    }
                    catch {
                        errorResponse += "Quantity must be a number,";
                    }

                    if(quantity == "" || quantity == " " ||  q <= 0)
                    {
                        lblError.Text += "<br/> Row "+ (row+1) + " Needs to have a quantity > 0";
                    }
                    else
                    {
                        string songID = GridView1.Rows[row].Cells[1].Text;
                        string songTitle = GridView1.Rows[row].Cells[2].Text;
                        DropDownList format = (DropDownList)GridView1.Rows[row].FindControl("FormatList");
                        string f = format.SelectedValue;
                        string price = GridView1.Rows[row].Cells[6].Text;
                        placeholderSong = new SongOBJ(songID, songTitle, f, quantity, price);
                        arraySongs.Add(placeholderSong);
                    }
                }
            }
            
            calculatePrice();
            if (flag == false)
            {
                lblError.Text += "<br/> Please select atleast one song";
           }
            show2();
            visibilityController("Purchase");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            switch (searchFunctionList.SelectedValue)
            {
                case "Song":
                    
                    gvStats.DataSource = db.GetDataSet("Select SongTitle, MusicArtist AS Artist, Genre, TotalPurchases from Songs");
                    gvStats.DataBind();
                    break;
                case "Genre":
                    
                    gvStats.DataSource = db.GetDataSet("Select Genre, SUM(TotalPurchases) AS Total from Songs GROUP BY Genre");
                    gvStats.DataBind();
                    break;

            }
            visibilityController("SearchStats");
        }

        protected void viewSubscriptionInfo_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();

            switch (SubscriptionSearchFunctionList.SelectedValue)
            {
                case "Month":
                    gvSubscriptions.DataSource = db.GetDataSet("Select MonthlyTotal FROM PurchaseTypes");
                    break;
                case "One-Time":
                    gvSubscriptions.DataSource = db.GetDataSet("Select OneTimePurchaseTotal FROM PurchaseTypes");
                    break;
                case "Annual":
                    gvSubscriptions.DataSource = db.GetDataSet("Select AnnualTotal FROM PurchaseTypes");
                    break;
                case "All":
                    gvSubscriptions.DataSource = db.GetDataSet("Select * FROM PurchaseTypes");
                    break;
            }
            gvSubscriptions.DataBind();
            visibilityController("SearchSubsriptions");
        }

        protected void Songs_Click(object sender, EventArgs e)
        {
            visibilityController("Song");
        }
    }
}