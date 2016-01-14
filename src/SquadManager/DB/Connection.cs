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
        public static Connection Current;
        MySqlConnection connection;
        string connectionString = "server=cohortis.eu;port=3306;database=cohortis_dev;uid=cohortis_dev;pwd=sanctus;persistsecurityinfo=true";

        public void StartConnect()
        {
            connection = new MySqlConnection(connectionString);

            connection.Open();
            Current = this;
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

        public joueur getPlayerByID(int ID)
        {

            joueur res = null;
            MySqlTransaction tr = connection.BeginTransaction();
            using (CohorisDB cdb = new CohorisDB(connection, false))
            {
                foreach (joueur item in cdb.Joueur)
                {
                    if(item.IDJoueur == ID)
                    {
                        res = item;
                    }
                }

                
              
            }


            return res;



        }
        public List<Build> getBuild(string name)
        {
            using (CohorisDB cdb = new CohorisDB(connection, false))
            {
                List<Build> res = new List<Build>();
                if (name == null || name == "")
                {
                    res = cdb.lBuild.ToList<Build>();
                    return res;
                }
                List<Build> l = cdb.lBuild.ToList<Build>();
                int idplayer = getPlayerId(name);
                foreach (Build item in l)
                {
                    if (item.IDCreator == idplayer)
                    {
                        res.Add(item);
                    }
                }
                return res;
            }
        }

        public int getPlayerId(string name)
        {
            List<joueur> lj = getPlayer();
            foreach (joueur j in lj)
            {
                if (j.NomJoueur == name)
                {
                    return j.IDJoueur;
                }
            }
            return -1;
        }

        public void AddPlayer(string name, bool Lead)
        {
            using (CohorisDB cdb = new CohorisDB(connection, false))
            {
                cdb.Joueur.Add(new joueur() { NomJoueur = name, Lead = Lead });
                cdb.SaveChanges();
            }
        }

        public void AddBuild(string name, string link, string nomcreateur, string classe, string role, bool valide,string description)
        {
            using (CohorisDB cdb = new CohorisDB(connection, false))
            {
                cdb.lBuild.Add(new Build()
                {
                    Nom = name,
                    IDCreator = getPlayerId(nomcreateur),
                    IDClasse = getClasseID(classe),
                    IDRole = getRoleID(role),
                    Validé = valide,
                    Desctiption = description,
                    Link = link
                   
                });
                cdb.SaveChanges();
            }
        }
       

        public void AddRole(string name)
        {
            using (CohorisDB cdb = new CohorisDB(connection, false))
            {
                cdb.lRole.Add(new Role() { Nom = name });
                cdb.SaveChanges();
            }

        }

        public void AddBuildJoue(int IDbuild, int IdJoueur)
        {
            using (CohorisDB cdb = new CohorisDB(connection, false))
            {
                cdb.lBJouer.Add(new BuildJoue() { IDBuild = IDbuild, IDJoueur = IdJoueur });
                cdb.SaveChanges();
            }
        }

        public int getClasseID(string name)
        {
            using (CohorisDB cdb = new CohorisDB(connection, false))
            {

                List<Classe> lc = cdb.lClasse.ToList<Classe>();
                foreach (Classe c in lc)
                {
                    if (c.Nom == name)
                    {
                        return c.ID;
                    }
                }
                return -1;
            }

        }

        public int getRoleID(string name)
        {
            using (CohorisDB cdb = new CohorisDB(connection, false))
            {

                List<Role> lc = cdb.lRole.ToList<Role>();
                foreach (Role c in lc)
                {
                    if (c.Nom == name)
                    {
                        return c.ID;
                    }
                }
                return -1;
            }

        }

        public void updatePlayer(joueur toUpdate)
        {
            string query = " UPDATE `joueurs` SET `NomJoueur`='" + toUpdate.NomJoueur + "',`Lead`=" + toUpdate.Lead + " WHERE IDJoueur=" + toUpdate.IDJoueur;


            ExectQuery(query);
        }

        public void UpdateBuild(Build toUpdate)
        {
            string query = ("UPDATE `Builds` SET `Nom`=" + toUpdate.Nom + ",`Link`=" + toUpdate.Link + ",`IDCreator`=" + toUpdate.IDCreator + ",`IDClasse`=" + toUpdate.IDClasse + ",`IDRole`=" + toUpdate.IDRole + ",`Validé`=" + toUpdate.Validé + ",`Description`="+toUpdate.Desctiption+" WHERE IDBuild=" + toUpdate.IDBuild);
            ExectQuery(query);
        }

        public void RemoveBuildJoue(BuildJoue toRemove)
        {
            string query = "DELETE FROM `BuildJoues` WHERE IDJoueur= "+toRemove.IDJoueur+" AND IDBuild ="+ toRemove.IDBuild;
            ExectQuery(query);
        }
       
        

        public void ExectQuery(string query)
        {
            using (CohorisDB cdb = new CohorisDB(connection, false))
            {

                cdb.Database.ExecuteSqlCommand(query);
            }
        }


    }
}


