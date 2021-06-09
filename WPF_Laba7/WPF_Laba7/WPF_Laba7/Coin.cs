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

        public void Update()
        {
            newConnection();
            var commandString = "UPDATE Coin SET Amount=@amount, CrtPrice=@crtPrice, CrtCost=@crtCost " +
                "WHERE (Title=@Title)";
            SqlCommand updateCommand = new SqlCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("Coinid", CoinId),
                    new SqlParameter("Title", Title),
                    new SqlParameter("Amount", Amount),
                    new SqlParameter("CrtPrice", CrtPrice),
                    new SqlParameter("CrtCost", CrtCost),
                });
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateCoin(Coin coinNew)
        {
            //if (coinNew.Title?.Length > 0) Title = coinNew.Title;
            if (coinNew.Amount >= 0) Amount = coinNew.Amount;
            if (coinNew.CrtPrice >= 0) CrtPrice = coinNew.CrtPrice;
            if (coinNew.CrtCost >= 0) CrtCost = coinNew.CrtCost;
        }

        public static Coin Find(string title)
        {
            foreach (var coin in getAllCoin())
            {
                if (coin.Title == title)
                    return coin;
            }
            return null;
        }

        public void Insert()
        {
            newConnection();
            var commandString = "INSERT INTO Coin(Title, Amount, CrtPrice, CrtCost) values(@title, @amount, @crtPrice, @crtCost)";
            SqlCommand sqlCommand = new SqlCommand(commandString, connection);
            sqlCommand.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("Title", Title),
                    new SqlParameter("Amount", Amount),
                    new SqlParameter("CrtPrice", CrtPrice),
                    new SqlParameter("CrtCost", CrtCost),
                });
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }


        public static void Delete(int id)
        {
            newConnection();
            var commandString = "DELETE FROM Coin WHERE (CoinId=@id)";
            SqlCommand sqlCommand = new SqlCommand(commandString, connection);
            sqlCommand.Parameters.AddWithValue("id", id);
            sqlCommand.ExecuteNonQuery(); //запрос выполняется не возвращая данные
            connection.Close();
        }


        public override string ToString()
        {
            return $"{CoinId}. {Title}, amount - {Amount}, current price ${CrtPrice}, cost ${CrtCost})";

        }


    }







}
