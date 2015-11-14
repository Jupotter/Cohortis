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

        public void StartConnect()
        {
            string connectionString = "server=cohortis.eu;port=3306;database=cohortis_dev;uid=root;password=sanctus;";
            connection = new MySqlConnection(connectionString);

        }

        public List<joueur> getPlayer()
        {
            List<joueur> res = new List<joueur>();
            MySqlTransaction tr = connection.BeginTransaction();
            using (CohorisDB cdb = new CohorisDB(connection, false))
            {
                res = cdb.lJoueur;
            }
                return res;
        }
    }
}

