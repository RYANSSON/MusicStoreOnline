using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
namespace MusicStoreLibrary
{
    public class priceCalc
    {
        int fMultiplyer = 0;
        int totalQ = 0;
        double TotalCost = 0;
        bool first = true;
        public void calcTotalCost(SongOBJ s)
        {
            switch (s.Format)
            {
                case "Vinyl":
                    fMultiplyer = 10;
                    break;
                case "Download":
                    fMultiplyer = 2;
                    break;
                case "Stream":
                    fMultiplyer = 1;
                    break;
            }
            try
            {
                s.totalCost = (int.Parse(s.price) + fMultiplyer) * int.Parse(s.Quantity);
            }
            catch
            {
                
            }  
        }
        public void getTotals(SongOBJ s, string Type)
        {
            try
            {
                if (first == true)
                {
                    switch (Type)
                    {
                        case "1":
                            break;
                        case "200":
                            TotalCost += 200;
                            break;
                        case "20":
                            TotalCost += 20;
                            break;
                    }
                    first = false;
                }
                totalQ += int.Parse(s.quantity);
                TotalCost += s.totalCost;
            }
            catch
            {
                
            }
        }
        public void updateTotals(SongOBJ s, string type)
        {
            DBConnect db = new DBConnect();
            db.DoUpdate("UPDATE Songs SET TotalPurchases = TotalPurchases + '" + s.Quantity + "' WHERE SongID = '" + s.songID + "'");
            switch (type)
            {
                case "1":
                    db.DoUpdate("UPDATE PurchaseTypes SET OneTimePurchaseTotal = OneTimePurchaseTotal + '" + s.Quantity + "'");
                    break;
                case "200":
                    db.DoUpdate("UPDATE PurchaseTypes SET AnnualTotal = AnnualTotal + '" + s.Quantity + "'");
                    break;
                case "20":
                    db.DoUpdate("UPDATE PurchaseTypes SET MonthlyTotal = MonthlyTotal + '" + s.Quantity + "'");
                    break;
            }
            
            
        }
        public int returnQuantity()
        {
            return totalQ;
        }
        public double returnTotalC()
        {
            return TotalCost;
        }
    }
}
