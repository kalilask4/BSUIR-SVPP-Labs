using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Laba7.Entities
{
    class Coin
    {

        static SqlConnection connection;

        public int CoinId { get; set; }
        public string Title { get; set; }
        public double Amount { get; set; }
        public double AvgPrice { get; set; } //the average price should be calculated based on transactions at different times
        public double CurPrice { get; set; } //the current price should ideally be loaded from binance
        public double AvgCost { get; set; } //Amount*AvgPrice
        public double CurCost { get; set; } //Amount*CurPrice


        public static void newConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connString);
            connection.Open();
        }

        public override string ToString()
        {
            return $"{CoinId}. {Title}, Amount - {Amount}, CurPrice ${CurPrice}, Cost ${CurCost})";

        }





        //public Coin()
        //{
        //    var connString = ConfigurationManager
        //        .ConnectionStrings["DemoConnection"]
        //        .ConnectionString;

        //    connection = new SqlConnection(connString);
        //}
        //static Coin()
        //{
        //    var connString = ConfigurationManager
        //        .ConnectionStrings["DemoConnection"]
        //        .ConnectionString;

        //    connection = new SqlConnection(connString);
        //}

        //public static IEnumerable<Coin> GetAllCoins()
        //{
        //    var commandString = "Select * FROM Coin";
        //}





    }







}
