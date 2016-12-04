using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterSheet
{
    public partial class Form1 : Form
    {
        Gagnagrunnur gagnagrunnur = new Gagnagrunnur();
        Char charact = new Char();
        int CharacterID = 0;

        public Form1()
        {
            InitializeComponent();

        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] data;
            this.tabControl1.SelectTab(2);
            dataGridCharacters.RowTemplate.Height = 50;
            List<string> list = new List<string>();
            list = gagnagrunnur.AllCharacters();

            
            
            
            for (int i = 0; i < list.Count; i++)
            {
                data = Convert.ToString(list[i]).Split(':');
                DataGridViewRow row1 = (DataGridViewRow)dataGridCharacters.Rows[i].Clone();
                row1.Cells[0].Value = data[0];
                row1.Cells[1].Value = data[1];
                row1.Cells[2].Value = data[2];
                row1.Cells[3].Value = data[3];
                row1.Cells[4].Value = data[4];
                dataGridCharacters.Rows.Add(row1);
            }

         }

        private void setjaIForm()
        {
            txtBxAlignment.Text = charact.charAlign;
            txtBxCharName.Text = charact.charName;
            txtBxClass.Text = charact.charClass;
            txtBxRace.Text = charact.charRace;
            txtBxLvl.Text = Convert.ToString(charact.level);
            txtBxXp.Text = Convert.ToString(charact.exp);
            txtBxAC.Text = Convert.ToString(charact.armor);
            txtBxHp.Text = Convert.ToString(charact.hp);
            txtBxHpMax.Text = Convert.ToString(charact.maxhp);
            txtBxStatSTR.Text = Convert.ToString(charact.STR);
            txtBxStatSTRMOD.Text = Convert.ToString(charact.STR_MOD);
            txtBxStatDEX.Text = Convert.ToString(charact.DEX);
            txtBxStatDEXMOD.Text = Convert.ToString(charact.DEX_MOD);
            txtBxStatCON.Text = Convert.ToString(charact.CON);
            txtBxStatCONMOD.Text = Convert.ToString(charact.CON_MOD);
            txtBxStatINT.Text = Convert.ToString(charact.INT);
            txtBxStatINTMOD.Text = Convert.ToString(charact.INT_MOD);
            txtBxStatWIS.Text = Convert.ToString(charact.WIS);
            txtBxStatWISMOD.Text = Convert.ToString(charact.WIS_MOD);
            txtBxStatCHR.Text = Convert.ToString(charact.CHA);
            txtBxStatCHAMOD.Text = Convert.ToString(charact.CHA_MOD);

            cbAcrobatic.Checked = charact.acrobatics;
            cbArcana.Checked = charact.arcana;
            cbAthletics.Checked = charact.athletics;
            cbCHA_ST.Checked = charact.chaSave;
            cbCON_ST.Checked = charact.conSave;
            cbDeception.Checked = charact.deception;
            cbDEX_ST.Checked = charact.dexSave;
            cbHistory.Checked = charact.history;
            cbIntimidation.Checked = charact.intimidation;
            cbINT_ST.Checked = charact.intSave;
            cbInvestigation.Checked = charact.investigation;
            cbMedicine.Checked = charact.medicine;
            cbNature.Checked = charact.nature;
            cbPerception.Checked = charact.perception;
            cbPersuasion.Checked = charact.persuasion;
            cbPreformance.Checked = charact.preformance;
            cbReligion.Checked = charact.religion;
            cbSleightOfHand.Checked = charact.sleight;
            cbStealth.Checked = charact.stealth;
            cbSTR_ST.Checked = charact.strSave;
            cbSurvival.Checked = charact.survival;
            cbWIS_ST.Checked = charact.wisSave;
            cbAnimalHandling.Checked = charact.animalhandling;
            cbInsight.Checked = charact.insight;

        }

        private void dataGridCharacters_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
         if  (e.RowIndex >= 0)
            {
                //ná id úr row sem er smellt á 
                try
                {
                   CharacterID = Convert.ToInt32(dataGridCharacters.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                catch (Exception ex)
                {
                    return;
                }
                // dataGridCharacters.
                //ná í character og setja inn
                string[] gogn = new string[4];
                gogn = gagnagrunnur.FinnaCharacter(CharacterID);
                charact.charName = gogn[0];
                charact.charClass = gogn[1];
                charact.charRace = gogn[2];
                charact.charAlign = gogn[3];
                int[] gogn1 = new int[18];
                gogn1 = gagnagrunnur.FinnaStats(CharacterID);
                statICharacter(gogn1); //setja StatICharacter
                bool[] gogn2 = new bool[25];
                gogn2 = gagnagrunnur.FinnaAbilities(1);
                abilitiesICharacter(gogn2); //setja AbilitiesICharacter
                setjaIForm();
                btnSave.Enabled = true;
                this.tabControl1.SelectTab(0);
            }

        }

        public void statICharacter(int[] gogn)
        {
            charact.level = gogn[1];
            charact.exp = gogn[2];
            charact.armor = gogn[3];
            charact.maxhp = gogn[4];
            charact.hp = gogn[5];
            charact.STR = gogn[6];
            charact.DEX = gogn[7];
            charact.CON = gogn[8];
            charact.INT = gogn[9];
            charact.WIS = gogn[10];
            charact.CHA = gogn[11];
            charact.STR_MOD = gogn[12];
            charact.DEX_MOD = gogn[13];
            charact.CON_MOD = gogn[14];
            charact.INT_MOD = gogn[15];
            charact.WIS_MOD = gogn[16];
            charact.CHA_MOD = gogn[17];
        }

        public int[] faStatCharacter()
        {
            int[] gogn = new int[18];
            gogn[0] = CharacterID;
            gogn[1] = charact.level;
            gogn[2] = charact.exp;
            gogn[3] = charact.armor;
            gogn[4] = charact.maxhp;
            gogn[5] = charact.hp;
            gogn[6] = charact.STR;
            gogn[7] = charact.DEX;
            gogn[8] = charact.CON;
            gogn[9] = charact.INT;
            gogn[10] = charact.WIS;
            gogn[11] = charact.CHA;
            gogn[12] = charact.STR_MOD;
            gogn[13] = charact.DEX_MOD;
            gogn[14] = charact.CON_MOD;
            gogn[15] = charact.INT_MOD;
            gogn[16] = charact.WIS_MOD;
            gogn[17] = charact.CHA_MOD;
            return gogn;
        }

        public void abilitiesICharacter(bool[] gogn)
        {
            charact.strSave = gogn[1];
            charact.athletics = gogn[2];
            charact.dexSave = gogn[3];
            charact.acrobatics = gogn[4];
            charact.sleight = gogn[5];
            charact.stealth = gogn[6];
            charact.conSave = gogn[7];
            charact.intSave = gogn[8];
            charact.arcana = gogn[9];
            charact.history = gogn[10];
            charact.investigation = gogn[11];
            charact.nature = gogn[12];
            charact.religion = gogn[13];
            charact.wisSave = gogn[14];
            charact.animalhandling = gogn[15];
            charact.insight = gogn[16];
            charact.medicine = gogn[17];
            charact.perception = gogn[18];
            charact.survival = gogn[19];
            charact.chaSave = gogn[20];
            charact.deception = gogn[21];
            charact.intimidation = gogn[22];
            charact.preformance = gogn[23];
            charact.persuasion = gogn[24];

        }

        public bool[] faAbiltiesCharacter()
        {
            bool[] gogn = new bool[25];
            gogn[0] = false;//dummy
            gogn[1] = charact.strSave;
             gogn[2] = charact.athletics;
             gogn[3] = charact.dexSave;
             gogn[4] = charact.acrobatics;
             gogn[5] = charact.sleight;
             gogn[6] = charact.stealth;
             gogn[7] = charact.conSave;
             gogn[8] = charact.intSave;
             gogn[9] = charact.arcana;
             gogn[10] = charact.history;
             gogn[11] = charact.investigation;
             gogn[12] = charact.nature;
             gogn[13] = charact.religion;
             gogn[14] = charact.wisSave;
             gogn[15] = charact.animalhandling;
             gogn[16] = charact.insight;
             gogn[17] = charact.medicine;
             gogn[18] = charact.perception;
             gogn[19] = charact.survival;
             gogn[20] = charact.chaSave;
             gogn[21] = charact.deception;
             gogn[22] = charact.intimidation;
             gogn[23] = charact.preformance;
             gogn[24] = charact.persuasion;
            return gogn;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            gagnagrunnur.UppfaeraCharacter(CharacterID, faStatCharacter(), faAbiltiesCharacter());
        }
    }

}