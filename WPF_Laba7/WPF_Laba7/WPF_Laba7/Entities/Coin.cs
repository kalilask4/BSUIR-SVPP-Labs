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
        public int CoinId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public double AvgPrice { get; set; } //the average price should be calculated based on transactions at different times
        public double CurPrice { get; set; } //the current price should ideally be loaded from binance


        static SqlConnection connection;

        public Coin()
        {
            var connString = ConfigurationManager
                .ConnectionStrings["DemoConnection"]
                .ConnectionString;

            connection = new SqlConnection(connString);
        }
        static Coin()
        {
            var connString = ConfigurationManager
                .ConnectionStrings["DemoConnection"]
                .ConnectionString;

            connection = new SqlConnection(connString);
        }

        //public static IEnumerable<Coin> GetAllCoins()
        //{
        //    var commandString = "Select * FROM Coin";
        //}

    
    
    
    
    }







}
