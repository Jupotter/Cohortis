using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.Entity;
using System.Data.Entity;
using MySql.Data.MySqlClient;

namespace SquadManager.DB
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Connection
    {
        MySqlConnection connection;
        string connectionString = "server=cohortis.eu;port=3306;database=cohortis_dev;uid=cohortis_dev;pwd=sanctus;persistsecurityinfo=true";

        public void StartConnect()
        {
            connection = new MySqlConnection(connectionString);
            
            connection.Open();
        }

        public List<joueur> getPlayer()
        {

            DbSet<joueur> res;
            MySqlTransaction tr = connection.BeginTransaction();
            using (CohorisDB cdb = new CohorisDB(connection, false))
            {
               
                res = cdb.Joueur;
                List<joueur> result = res.ToList<joueur>();
                return result;
            }


      
              
        }
    }
}

