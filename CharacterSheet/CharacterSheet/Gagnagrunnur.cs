using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CharacterSheet
{
    class Gagnagrunnur
    {
        private string server;
        private string database;
        private string uid;
        private string password;
        string tengistrengur = null;
        string fyrirspurn = null;

        MySqlConnection sqltenging;
        MySqlCommand nySQLskipun;
        MySqlDataReader sqllesari = null;

        public void TengingVidGagnagrunn()
        {
            server = "10.200.10.24";
            database = "0802992579_lokaverkefni";
            uid = "0802992579";
            password = "mypassword";

            tengistrengur = "server=" + server + ";userid=" + uid + ";password=" + password + ";database=" + database;
            sqltenging = new MySqlConnection(tengistrengur);

        }

        private bool OpenConnection()
        {
            try
            {
                sqltenging.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

        }

        private bool CloseConnection()
        {
            try
            {
                sqltenging.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

        }

        public List<string> AllCharacters()
        {
            List<string> faerslur = new List<string>();
            string lina = null;
            if (OpenConnection() == true)
              {
                  fyrirspurn = "SELECT characters.name, class.class, stats.level, race.race FROM characters " +
                            "INNER JOIN class ON characters.ClassID=Class.ClassID " +
                              "INNER JOIN race ON characters.RaceID=Race.RaceID" +
                              "INNER JOIN stats ON characters.CharacterID= stats.CharacterID" ;
                  nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                  sqllesari = nySQLskipun.ExecuteReader();

                  while (sqllesari.Read())
                  {
                      for (int i = 0; i < sqllesari.FieldCount; i++)
                      {
                          lina += (sqllesari.GetValue(i).ToString()) + ':';
                      }
                      faerslur.Add(lina);
                      lina = null;
                  }
                  sqllesari.Close();
                  CloseConnection();
              }
            /*
            lina = "1:Jon the Great:Barbarian:2:Human";
            faerslur.Add(lina);*/
            
            return faerslur;
        }

        public List<string> Spells()
        {
            List<string> faerslur = new List<string>();
            string lina = null;
            if (OpenConnection() == true)
            {
                fyrirspurn = "SELECT characters.name, class.class, stats.level, race.race FROM characters " +
                            "INNER JOIN class ON characters.CharacterID=Class.ClassID " +
                            "INNER JOIN race ON characters.CharacterID=Race.RaceID" +
                            "INNER JOIN stats ON characters.CharacterID= Stats.CharacterID;";
                nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                sqllesari = nySQLskipun.ExecuteReader();

                while (sqllesari.Read())
                {
                    for (int i = 0; i < sqllesari.FieldCount; i++)
                    {
                        lina += (sqllesari.GetValue(i).ToString()) + ':';
                    }
                    faerslur.Add(lina);
                    lina = null;
                }
                sqllesari.Close();
                CloseConnection();
            }
            /*
            lina = "Burning Hands:As you hold your hands spread, a thin sheet of fla...:1";
            faerslur.Add(lina);
            lina = "Healing Word:A creature of your choice that you can see within ...:0";
            faerslur.Add(lina);
            lina = "Bless:(a sprinkling of holy water) You bless up to 3 cre...:0";
            faerslur.Add(lina);
            lina = "Cure Wounds:A creature you touch regains a number of hit point...:0";
            faerslur.Add(lina);
            lina = "Fog Cloud:You create a 20-foot-radius sphere of fog centered...:0";
            faerslur.Add(lina);
            */
            return faerslur;
        }


        public string[] FinnaCharacter(int CharacterID)
        {
            string[] gogn = new string[4];
           if (OpenConnection() == true)
            {
                //query-in sem á að keyrast (má líka fyrir ofan if setninguna
                fyrirspurn = "SELECT characters.name, class.class, race.race, alignment.alignment FROM characters " +
                            "INNER JOIN class ON characters.ClassID=Class.ClassID " +
                            "INNER JOIN race ON characters.RaceID=Race.RaceID" +
                            "INNER JOIN stats ON characters.AlignmentID= Alignment.AlignmentID" +
                            "WHERE CharacterID = '" + CharacterID + "'";
                //create command and assign the the query(fyrirspurn) and connection(tengingu)
                nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                sqllesari = nySQLskipun.ExecuteReader();
                while (sqllesari.Read())
                {
                    for (int i = 0; i < 4; i++)
                    {
                        gogn[i] = sqllesari.GetValue(i).ToString();
                    }
                }
                sqllesari.Close();
                CloseConnection();
            }
            /*
            gogn[0] = "Jonh the great";
            gogn[1] = "Bard";
            gogn[2] = "Dwarf";
            gogn[3] = "Lawfull Neutral";
            */
            return gogn;
        }



        public int[] FinnaStats(int CharacterID)
        {
            int[] gogn = new int[18];
            if (OpenConnection() == true)
            {
                //query-in sem á að keyrast (má líka fyrir ofan if setninguna
                fyrirspurn = "SELECT * FROM stats WHERE CharacterID ='" + CharacterID + "'";
                //create command and assign the the query(fyrirspurn) and connection(tengingu)
                nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                sqllesari = nySQLskipun.ExecuteReader();
                while (sqllesari.Read())
                {
                    for (int i = 0; i < 18; i++)
                    {
                        if (i != 0)
                        { gogn[i] = Int32.Parse(sqllesari.GetValue(i).ToString()); }
                    }
                }
                sqllesari.Close();
                CloseConnection();
            }
            /*
            gogn[0] = 1;
            gogn[1] = 2;
            gogn[2] = 200;
            gogn[3] = 8;
            gogn[4] = 150;
            gogn[5] = 100;
            gogn[6] = 14;
            gogn[7] = 13;
            gogn[8] = 11;
            gogn[9] = 12;
            gogn[10] = 9;
            gogn[11] = 16;
            gogn[12] = 2;
            gogn[13] = 0;
            gogn[14] = -1;
            gogn[15] = -3;
            gogn[16] = 5;
            gogn[17] = 0;
            */

            return gogn;
        }


        public bool[] FinnaAbilities(int CharacterID)
        {
            bool[] gogn = new bool[25];
           if (OpenConnection() == true)
            {
                //query-in sem á að keyrast (má líka fyrir ofan if setninguna
                fyrirspurn = "SELECT * FROM abilitis WHERE CharacterID ='" + CharacterID + "'";
                //create command and assign the the query(fyrirspurn) and connection(tengingu)
                nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                sqllesari = nySQLskipun.ExecuteReader();
                while (sqllesari.Read())
                {
                    for (int i = 0; i < 25; i++)
                    {
                        if (i != 0) { 
                            if (Convert.ToInt32(sqllesari.GetValue(i).ToString()) == 1)
                            { gogn[i] = true; }
                            else
                            { gogn[i] = false; }
                        }
                    }
                }
                sqllesari.Close();
                CloseConnection();
            }
            /*
            gogn[0] = true;
            gogn[1] = false;
            gogn[2] = false;
            gogn[3] = false;
            gogn[4] = true;
            gogn[5] = true;
            gogn[6] = false;
            gogn[7] = false;
            gogn[8] = true;
            gogn[9] = true;
            gogn[10] = false;
            gogn[11] = true;
            gogn[12] = true;
            gogn[13] = false;
            gogn[14] = true;
            gogn[15] = false;
            gogn[16] = true;
            gogn[17] = false;
            gogn[18] = false;
            gogn[19] = true;
            gogn[20] = true;
            gogn[21] = false;
            gogn[22] = true;
            gogn[23] = false;
            gogn[24] = true;
            gogn[25] = false;
            */

            return gogn;
        }


        public void UppfaeraCharacter(int CharacterID, int[] stats, bool[] abilities)
        {
            int[] gogn = new int[25];
            if (OpenConnection() == true)
            {
                /*query-in sem á að keyrast (má líka fyrir ofan if setninguna*/
                fyrirspurn = "UPDATE stats " +
                "SET level='" + stats[1] + "', " +
                "XP='" + stats[2] + "', " +
                "AC='" + stats[3] + "', " +
                "MaxHP='" + stats[4] + "', " +
                "HP='" + stats[5] + "', " +
                "STR='" + stats[6] + "', " +
                "DEX='" + stats[7] + "', " +
                "CON='" + stats[8] + "', " +
                "INTE='" + stats[9] + "', " +
                "WIS='" + stats[10] + "', " +
                "CHA='" + stats[11] + "', " +
                "STR_MOD='" + stats[12] + "', " +
                "DEX_MOD='" + stats[13] + "', " +
                "CON_MOD='" + stats[14] + "', " +
                "INT_MOD='" + stats[15] + "', " +
                "WIS_MOD='" + stats[16] + "', " +
                "CHA_MOD='" + stats[17] + "' " +
                "WHERE CharacterId ='" + CharacterID + "'";
                /*create command and assign the the query(fyrirspurn) and connection(tengingu)
                 nySQLskipun = new MySqlCommand(fyrirspurn, sqltenging);
                 /*ExecuteNonQuery: Used to execute a command that will not reutrn any data*/
                nySQLskipun.ExecuteNonQuery();

                for (int i = 0; i < 26; i++)
                {
                    if (abilities[i] == true)
                    { gogn[i] = 1; }
                    else
                    { gogn[i] = 0; }
                }

               
                fyrirspurn = "UPDATE abilities " +
                "SET STR_ST='" +gogn[1] + "', " +
                "Athletics='" + gogn[2] + "', " +
                "DEX_ST='" + gogn[3] + "', " +
                "Acrobatics='" + gogn[4] + "', " +
                "SleightOfHand='" + gogn[5] + "', " +
                "Stealth='" + gogn[6] + "', " +
                "CON_ST='" + gogn[7] + "', " +
                "INT_ST='" + gogn[8] + "', " +
                "Arcana='" + gogn[9] + "', " +
                "History='" + gogn[10] + "', " +
                "Investigation='" + gogn[11] + "', " +
                "Nature='" + gogn[12] + "', " +
                "Religion='" + gogn[13] + "', " +
                "WIS_ST='" + gogn[14] + "', " +
                "Insight='" + gogn[15] + "', " +
                "Animalhandling='" + gogn[16] + "', " +
                "Medicine='" + gogn[17] + "', " +
                "Perception='" + gogn[18] + "', " +
                "Survival='" + gogn[19] + "', " +
                "Cha_ST='" + gogn[20] + "', " +
                "Deception='" + gogn[21] + "', " +
                "Intimidation='" + gogn[22] + "', " +
                "Preformance='" + gogn[23] + "', " +
                "Persuasion='" + gogn[24] + "' " +
                "WHERE CharacterId ='" + CharacterID + "'";
                CloseConnection();
            }
        }

    }
}

