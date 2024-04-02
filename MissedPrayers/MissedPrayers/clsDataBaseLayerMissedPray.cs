using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MissedPrayers
{
  static   class clsDataBaseLayerMissedPray
    {


        static string connectionString = "Data source=.;initial catalog=MIssedPrayes;Integrated security = true;";


    public        static void GetPrayes(ref int TotalPraies, ref int numFager, ref int numZohir, ref int numAsair,
            ref int numMagrub, ref int numAsha, ref int PrayPlan ,ref int totalPraiesToDoBerDay)
        { 

        SqlConnection connection = new SqlConnection(connectionString);

            string qurey = "SELECT * FROM tbMissedPray WHERE ID = '1';";


            SqlCommand command = new SqlCommand(qurey, connection);

            try
            {
                connection.Open()
                    ;
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    TotalPraies = (int)reader["TotalPraies"];
                    numFager = (int)reader["numFager"];
                    numZohir = (int)reader["numZahir"];
                    numAsair = (int)reader["numAsair"];
                    numMagrub = (int)reader["numMagrub"];
                    numAsha = (int)reader["numAshai"];
                    PrayPlan = (int)reader["PrayPerDay"];
                    totalPraiesToDoBerDay = (int)reader["totalPrayPlanPerDay"];

                    reader.Close();






                }
                
            }
            catch
            {
                MessageBox.Show("DataBaseErro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                connection.Close();
            }




        }


        public static bool UpdatePrayes(ref int TotalPraies, ref int numFager, ref int numZohir, ref int numAsair,
            ref int numMagrub, ref int numAsha, ref int PrayPlan, ref int totalPraiesToDoBerDay)
        {
            //bool isSaved = false;
            int rowAffected = 0;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"update tbMissedPray set ID = 1," +
                           "numFager = @numFager," +
                           "numZahir = @numZohir," +
                           "numAsair = @numAsair," +
                           "numMagrub = @numMagrub," +
                           "numAshai = @numAsha," +
                           "TotalPraies = @TotalPraies," +
                           "totalPrayPlanPerDay = @totalPraiesToDoBerDay," +
                           "PrayPerDay = @PrayPlan" +
                           "where ID = 1";

            string lol = $"  update tbMissedPray  set numFager = {numFager},numZahir = {numZohir},numAsair = {numAsair},numMagrub = {numMagrub},numAshai = {numAsha},TotalPraies = {TotalPraies},totalPrayPlanPerDay = {totalPraiesToDoBerDay},PrayPerDay = {PrayPlan} where ID = 1    ";

            SqlCommand command = new SqlCommand(lol, connection);
            //command.Parameters.AddWithValue("@numFager", numFager);
            //command.Parameters.AddWithValue("@numZohir", numZohir);
            //command.Parameters.AddWithValue("@numAsair", numAsair);
            //command.Parameters.AddWithValue("@numMagrub", numMagrub);
            //command.Parameters.AddWithValue("@numAsha", numAsha);
            //command.Parameters.AddWithValue("@TotalPraies", TotalPraies);
            //command.Parameters.AddWithValue("@totalPraiesToDoBerDay", totalPraiesToDoBerDay);
            //command.Parameters.AddWithValue("@PrayPlan", PrayPlan);

            try
            {
                connection.Open();

                rowAffected = command.ExecuteNonQuery();
            }
            catch
            {
                 
            }
            finally
            {
                connection.Close();
            }

            return (rowAffected>0);
        }


    }
}
