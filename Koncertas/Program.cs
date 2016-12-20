using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koncertas
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(@"data source=VIOLETA-PC\SQLEXPRESS;initial catalog=Koncertas;integrated security=True;MultipleActiveResultSets=True;");
            conn.Open();
            DataSet ds = new DataSet();
            Daina efDaina = new Daina();
            //dai.Metai = 2016;
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = new SqlCommand("SELECT Pavadinimas, Autorius, Metai FROM Daina", conn);
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Daina(Pavadinimas, Autorius, Metai) VALUES (@1p, @2p, @3p)", conn);
            insertCommand.Parameters.Add(new SqlParameter("@1p", SqlDbType.NVarChar, 50, "Pavadinimas"));
            insertCommand.Parameters.Add(new SqlParameter("@2p", SqlDbType.NVarChar, 50, "Autorius"));
            insertCommand.Parameters.Add(new SqlParameter("@3p", SqlDbType.Int, 10, "Metai"));
            dAdapter.InsertCommand = insertCommand;
            dAdapter.Fill(ds, "Daina");

            DataRow newRow = ds.Tables[0].NewRow();
            newRow["Pavadinimas"] = "Show Must Go On";
            newRow["Autorius"] = "QUEENS";
            newRow["Metai"] = 1976;
            ds.Tables[0].Rows.Add(newRow);

            dAdapter.Update(ds.Tables[0]);
            conn.Close();
            dAdapter.Dispose();
            KoncertasEntities3 ke = new KoncertasEntities3();
            //ke.Daina.
//            var context = new DataBaseContext();
        }
    }
}
