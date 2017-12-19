using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ClasDemoCatchesDB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private Model1 catchdb = new Model1();
        private String ConnectionString = @"Data Source=(localdb)\v11.0;Initial Catalog=CatchDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public List<Catch> GetCatches()
        {
            return catchdb.Catches.ToList();
        }

        public List<Catch> GetCatchesv2()
        {
            List < Catch > liste = new List<Catch>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                String sql = "SELECT * FROM Catch";
                SqlCommand command = new SqlCommand(sql,conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Catch c = new Catch
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Art = reader.GetString(2),
                        Weigth = reader.GetDecimal(3),
                        Location = reader.GetString(4),
                        Week = reader.GetInt32(5)
                    };
                    liste.Add(c);
                }

            }

            return liste;
        }

        public Catch GetOneCatch(string id)
        {
            int idint = Int32.Parse(id);
            return catchdb.Catches.ToList().Find(c => c.Id == idint);
        }
    }
}
