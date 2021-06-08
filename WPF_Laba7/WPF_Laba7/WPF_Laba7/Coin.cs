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
        //public double AvgPrice { get; set; } //the average price should be calculated based on transactions at different times
        public double CrtPrice { get; set; } //the current price should ideally be loaded from binance
        //public double AvgCost { get; set; } //Amount*AvgPrice
        public double CrtCost { get; set; } //Amount*CurPrice


        public static void newConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connString);
            connection.Open();
        }


        public static IEnumerable<Coin> getAllCoin()
        {
            newConnection();
            var commandString = "SELECT * FROM Coin";
            SqlCommand sqlCommand = new SqlCommand(commandString, connection);
            var reader = sqlCommand.ExecuteReader();    //запрос возвращает данные
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var title = reader.GetString(1);
                    var amount = reader.GetDouble(2);
                    var crtPrice = reader.GetDouble(3);
                    var crtCost = reader.GetDouble(4);

                    var coin = new Coin
                    {
                        CoinId = id,
                        Title = title,
                        Amount = amount,
                        CrtPrice = crtPrice,
                        CrtCost = crtCost
                    };

                    yield return coin;
                }
            }
            connection.Close();
        }






        public override string ToString()
        {
            return $"{CoinId}. {Title}, amount - {Amount}, current price ${CrtPrice}, cost ${CrtCost})";

        }


    }







}
