using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreLibrary
{
    public class SongOBJ
    {
        public string songID;
        public string songTitle;
        public string quantity;
        public string price;
        public string format;
        public double totalCost;


        public SongOBJ()
        {

        }
        public SongOBJ(string id, string title, string Format,string quan, string Price)
        {
            songID = id;
            songTitle = title;
            quantity = quan;
            price = Price;
            format = Format;
            
        }

        public string SongID
        {
            get { return songID; }
            set { songID = value; }
        }
        public string SongTitle
        {
            get { return songTitle; }
            set { songTitle = value; }
        }
        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Format
        {
            get { return format; }
            set { format = value; }
        }
        public double TotalCost 
        {
            get { return totalCost; }
            set { totalCost = value; }
        }
    }
}
