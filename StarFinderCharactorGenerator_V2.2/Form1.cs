using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace StarFinderCharactorGenerator_V2._2
{

    public partial class Form1 : Form 
    {
        
        Information Info = new Information();//stores readonly info
        Toon player = new Toon(); //stores Charactor data
        Race race = new Race();
        Theme theme = new Theme();
        PlayerClass classes = new PlayerClass();
        EnvoyClass envoy = new EnvoyClass();
        MechanicClass mech = new MechanicClass();
        SolarianClass solar = new SolarianClass();
        OperativeClass operative = new OperativeClass();
        SoldierClass soldier = new SoldierClass();
        MysticClass mystic = new MysticClass();
        TechnomancerClass tech = new TechnomancerClass();

        public TextBox[] raceSelectStats = new TextBox[6];
        public bool re_Roll_1s = false;
        public int rollMode = 1; //1 Standard, 2 Classic, 3 Heroic, 4 Die Pool, 5 Point buy 6 for god and 7 for Core
        public int[][] raceMods = new int[8][];
        public int[][] themes = new int[10][];
        public int[] diepool;
        public int[] statboxes = new int[6];
        public int[] previousValue = new int[6];
        public int[] newValue = new int[6];
        public bool result;
        public Button[] DieButtons;
        public bool[] isFull = new bool[24];
        public bool[] statBoxCounter = new bool[24];
        public static int statBoxInc = 0;
        public static TextBox[] attributeModifyers = new TextBox[6];
        public static Button[] dieButtons = new Button[24];
        public static NumericUpDown[] attributeScores = new NumericUpDown[6];
        public int[] abilityScoreCost = new int[6];
        public int pointBuyPoints = 10;
        public int total = 0;


        public Form1()
        {
            InitializeComponent();
            initComboBox(); //assigns a stat to each box
            Button[] DieButtons = {buttonDieA01, buttonDieA02, buttonDieA03,
                buttonDieB04, buttonDieB05, buttonDieB06, buttonDieC07, buttonDieC08,
                buttonDieC09, buttonDieD10, buttonDieD11, buttonDieD12, buttonDieE13,
                buttonDieE14, buttonDieE15, buttonDieF16, buttonDieF17, buttonDieF18,
                buttonDieA19, buttonDieB20, buttonDieC21, buttonDieD22, buttonDieE23,
                buttonDieF24 };
          
            NumericUpDown[] attributeScores ={numericScoreA, numericScoreB, numericScoreC,
                numericScoreD, numericScoreE, numericScoreF };

            TextBox[] attributeModifyers = {textBoxModA, textBoxModB, textBoxModC, textBoxModD,
                textBoxModE, textBoxModF };
            raceMods = race.RaceMods;
            themes = theme.GetThemes;
        }

        private void comboBoxA_SelectedIndexChanged(object sender, EventArgs e){}
        private void comboBoxB_SelectedIndexChanged(object sender, EventArgs e){}
        private void comboBoxC_SelectedIndexChanged(object sender, EventArgs e){}
        private void comboBoxD_SelectedIndexChanged(object sender, EventArgs e){}
        private void comboBoxE_SelectedIndexChanged(object sender, EventArgs e){}
        private void comboBoxF_SelectedIndexChanged(object sender, EventArgs e){}

       

        private void showStatInfoInInfoBox(int selected)
        {
            switch (selected)
            {
                case 0:
                    infoBox1.Text = Info.charismaStat;
                    break;
                case 1:
                    infoBox1.Text = Info.consitutionStat;
                    break;
                case 2:
                    infoBox1.Text = Info.dexterityStat;
                    break;
                case 3:
                    infoBox1.Text = Info.intellienceStat;
                    break;
                case 4:
                    infoBox1.Text = Info.strengthStat;
                    break;
                case 5:
                    infoBox1.Text = Info.wisdomStat;
                    break;

            }
        }

        private void ComboBoxCommited(object sender, EventArgs e)
        {
            ComboBox c =(ComboBox)sender;
            showStatInfoInInfoBox(c.SelectedIndex);

            int[] statboxes = { comboBoxA.SelectedIndex, comboBoxB.SelectedIndex, comboBoxC.SelectedIndex,
                comboBoxD.SelectedIndex, comboBoxE.SelectedIndex, comboBoxF.SelectedIndex };// stores selection values in an array for comparason.
            result = statboxes.Distinct().Count() == statboxes.Count();
            if (result)
            {
                buttonCommit.Enabled = true;
                buttonCommit3.Enabled = true;
            }
            else
            {
                buttonCommit3.Enabled = false;
                buttonCommit.Enabled = false;
            }//check to see if any of the selections match and if so, disable the commit button

            
        }// end ComboBoxCommited
        public void initComboBox()
        {
            comboBoxA.Items.Clear();
            comboBoxB.Items.Clear();
            comboBoxC.Items.Clear();
            comboBoxD.Items.Clear();
            comboBoxE.Items.Clear();
            comboBoxF.Items.Clear();
            comboBoxRaceSelect.Items.Clear();
            comboBoxStep2PickAny.Items.Clear();
            comboBoxThemeSelection.Items.Clear();
            comboBoxStep2PickAny.Items.Clear();
            comboBoxStep3ClassSkill.Items.Clear();
            comboBoxStep3PickAny.Items.Clear();

            comboBoxA.Items.AddRange(player.attributeBrief);
            comboBoxB.Items.AddRange(player.attributeBrief);
            comboBoxC.Items.AddRange(player.attributeBrief);
            comboBoxD.Items.AddRange(player.attributeBrief);
            comboBoxE.Items.AddRange(player.attributeBrief);
            comboBoxF.Items.AddRange(player.attributeBrief);
            comboBoxRaceSelect.Items.AddRange(race.raceNames);
            comboBoxStep2PickAny.Items.AddRange(player.attributeBrief);
            comboBoxThemeSelection.Items.AddRange(theme.ThemeNames);
            comboBoxStep3PickAny.Items.AddRange(player.attributeBrief);
            comboBoxStep3ClassSkill.Items.AddRange(player.skillNames);
            comboBoxStep3ClassSkill.Items.Remove(22);//removes the last space which was left blank for future expansion possibilies.

            //sets stat boxes in die roller to starting values.
            comboBoxA.SelectedIndex = 4; //str
            comboBoxB.SelectedIndex = 2; //dex
            comboBoxC.SelectedIndex = 1; //con
            comboBoxD.SelectedIndex = 3; //Int
            comboBoxE.SelectedIndex = 5; //Wis
            comboBoxF.SelectedIndex = 0; //Cha

            

        }//end initComboBox

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            Button[] DieButtons = {buttonDieA01, buttonDieA02, buttonDieA03,
                buttonDieB04, buttonDieB05, buttonDieB06, buttonDieC07, buttonDieC08,
                buttonDieC09, buttonDieD10, buttonDieD11, buttonDieD12, buttonDieE13,
                buttonDieE14, buttonDieE15, buttonDieF16, buttonDieF17, buttonDieF18,
                buttonDieA19, buttonDieB20, buttonDieC21, buttonDieD22, buttonDieE23,
                buttonDieF24 };

            NumericUpDown[] attributeScores ={numericScoreA, numericScoreB, numericScoreC,
                numericScoreD, numericScoreE, numericScoreF };

            TextBox[] attributeModifiers = {textBoxModA, textBoxModB, textBoxModC, textBoxModD,
                textBoxModE, textBoxModF };

            if (rollMode == 1)//standard die roll mode
            {
                standardDieRoll(diepool); //rolls dice and stores them in the Diepool array
                UpdateButtons(DieButtons, diepool);//populates the die pool buttons with with the values in the die pool array 
                updateAttributeScores(attributeScores, diepool);//poputates attribute fields
                updateMods(attributeModifiers, attributeScores);// update stat bunuses 

            }//end standard mode
            else if (rollMode == 2)//classic mode
            {
                classicDieRoll(diepool);
                UpdateButtons(DieButtons, diepool);//populates the die pool buttons with with the values in the die pool array 
                updateAttributeScores(attributeScores, diepool);//poputates attribute fields
                updateMods(attributeModifiers, attributeScores);// update stat bunuses 

            }//end classic mode
            else if (rollMode == 3)//heroic mode
            {
                heroicDieRoll(diepool);
                UpdateButtons(DieButtons, diepool);//populates the die pool buttons with with the values in the die pool array
                updateAttributeScores(attributeScores, diepool);
                updateMods(attributeModifiers, attributeScores);// update stat bunuses 
            }//end heroic 
            else if (rollMode == 4)//die pool mode
            {
                resetArrows();
                enableDisable_Buttons(true);
                statBoxInc = 0;
                resetAttributeScores(rollMode);
                resetMods();
                groupDice.Enabled = true;
                diePoolRoll(diepool);
                UpdateButtons(DieButtons, diepool);//populates the die pool buttons with with the values in the die pool array
                
                Array.Clear(isFull, 0, isFull.Length);


            }//die pool mode 
        }//end buttonRoll_Click

        private int rollD6()
        {
            int num;
            int num2;

            if (re_Roll_1s)
            {
                do
                {
                    do
                    {
                        num  = RandomNumber.Between(1, 7);
                        num2 = RandomNumber.Between(1, 7);
                    } while (num != num2 || (num > 6)); // tires to ensure that the next number will be 
                    //more random while not precluding repeated rolls... tries to any way

                } while (num == 1);//will loop till number is > 1 to re roll 1s
            }
            else
            {
                do
                {
                    num = RandomNumber.Between(1, 7);
                    num2 = RandomNumber.Between(1, 7);
                } while ((num < 1)|| (num > 6));//end loop
            }//end if 

            return num;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)// re-roll 1s check box
        {
            if (checkBox1.Checked)
            {
                re_Roll_1s = true;
                
            }
            else
            {
                re_Roll_1s = false;
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void radioButtonCore_CheckedChanged(object sender, EventArgs e)
        {
            rollMode = 7;
            initComboBox();
            resetMods();
            resetAttributeScores(rollMode);

            
            groupStatSelection.Enabled = false;
            groupD24.Visible = false;
            buttonRoll.Enabled = false;
            groupDice.Enabled = false;
            groupArrows.Visible = false;
            groupScores.Enabled = false;
            infoBox1.Text = Info.rollModeCore;
            resetArrows();
            statBoxInc = 0;
            Array.Clear(isFull, 0, isFull.Length);//fills a bool array with false.
            buttonCommitCore.Enabled = true;
            radioButton10Points.Enabled = true;
            radioButton15Points.Enabled = true;
            radioButton20Points.Enabled = true;
        }

        private void radioBStandard_CheckedChanged(object sender, EventArgs e)
        {
            rollMode = 1;
            initComboBox();
            resetAttributeScores(rollMode);
            resetMods();
            diepool = new int[18];
            groupD24.Visible = false;
            buttonRoll.Enabled = true;
            groupStatSelection.Enabled = true;
            groupDice.Enabled = false;
            groupArrows.Visible = false;
            groupScores.Enabled = false;
            infoBox1.Text = Info.rollModeStandard;
            resetArrows();
            statBoxInc = 0;
            Array.Clear(isFull, 0, isFull.Length);//fills a bool array with false.
            buttonCommitCore.Enabled = false;
            radioButton10Points.Enabled = false;
            radioButton15Points.Enabled = false;
            radioButton20Points.Enabled = false;

        }

        private void radioBClassic_CheckedChanged(object sender, EventArgs e)
        {
            rollMode = 2;

            initComboBox();
            resetAttributeScores(rollMode);
            resetMods();
            diepool = new int[18];
            groupD24.Visible = false;
            buttonRoll.Enabled = true;
            groupDice.Enabled = false;
            groupArrows.Visible = false;
            groupStatSelection.Enabled = true;
            groupScores.Enabled = false;
            infoBox1.Text = Info.rollModeClassic;
            resetArrows();
            statBoxInc = 0;
            Array.Clear(isFull, 0, isFull.Length);//fills a bool array with false.
            buttonCommitCore.Enabled = false;
            radioButton10Points.Enabled = false;
            radioButton15Points.Enabled = false;
            radioButton20Points.Enabled = false;

        }

        private void radioBHeroic_CheckedChanged(object sender, EventArgs e)//Heroic mode selected
        {

            rollMode = 3;
            initComboBox();
            resetAttributeScores(rollMode);
            resetMods();

            diepool = new int[18];
            groupD24.Visible = false;
            buttonRoll.Enabled = true;
            groupDice.Enabled = false;
            groupArrows.Visible = false;
            groupStatSelection.Enabled = true;
            groupScores.Enabled = false;
            infoBox1.Text = Info.rollModeHeroic;
            resetArrows();
            statBoxInc = 0;
            Array.Clear(isFull, 0, isFull.Length);//fills a bool array with false.
            buttonCommitCore.Enabled = false;
            radioButton10Points.Enabled = false;
            radioButton15Points.Enabled = false;
            radioButton20Points.Enabled = false;

        }// end radioBHeroic_CheckedChanged

        private void radioBPointBuy_CheckedChanged(object sender, EventArgs e)//point buy selected
        {

            rollMode = 5;
            initComboBox();
            resetMods();
            resetAttributeScores(rollMode);
            

            groupStatSelection.Enabled = false;
            groupD24.Visible = false;
            buttonRoll.Enabled = false;
            groupDice.Enabled = false;
            groupArrows.Visible = false;
            groupScores.Enabled = true;
            infoBox1.Text = Info.rollModepointBuy;
            resetArrows();
            statBoxInc = 0;
            Array.Clear(isFull, 0, isFull.Length);//fills a bool array with false.

            buttonCommitCore.Enabled = false;
            radioButton10Points.Enabled = false;
            radioButton15Points.Enabled = false;
            radioButton20Points.Enabled = false;


        }//end point buy selected

        private void radioBGod_CheckedChanged(object sender, EventArgs e)
        {
            NumericUpDown[] attributeScores ={numericScoreA, numericScoreB, numericScoreC,
                numericScoreD, numericScoreE, numericScoreF };
            rollMode = 6;

            initComboBox();
            resetMods();
            resetAttributeScores(rollMode);

            groupStatSelection.Enabled = false;
            groupD24.Visible = false;
            buttonRoll.Enabled = false;
            groupDice.Enabled = false;
            groupArrows.Visible = false;
            groupScores.Enabled = true;
            infoBox1.Text = Info.rollModeGod;

        }//end radioBGod_CheckedChanged

        private void radioDiePoolChanged(object sender, EventArgs e)
        {
            Button[] DieButtons = {buttonDieA01, buttonDieA02, buttonDieA03,
                buttonDieB04, buttonDieB05, buttonDieB06, buttonDieC07, buttonDieC08,
                buttonDieC09, buttonDieD10, buttonDieD11, buttonDieD12, buttonDieE13,
                buttonDieE14, buttonDieE15, buttonDieF16, buttonDieF17, buttonDieF18,
                buttonDieA19, buttonDieB20, buttonDieC21, buttonDieD22, buttonDieE23,
                buttonDieF24 };
            rollMode = 4;

            initComboBox();
            resetAttributeScores(rollMode);
            resetMods();
            diepool = new int[24];
            groupStatSelection.Enabled = true;
            groupD24.Visible = true;
            groupArrows.Visible = true;
            buttonRoll.Enabled = true;
            groupDice.Enabled = true;
            groupScores.Enabled = false;
            enableDisable_Buttons(true);
            infoBox1.Text = Info.rollModeDicePool;
            UpdateButtons(DieButtons, diepool);//populates the die pool buttons with with the values in the die pool array

            buttonCommitCore.Enabled = false;
            radioButton10Points.Enabled = false;
            radioButton15Points.Enabled = false;
            radioButton20Points.Enabled = false;

        }// end radioDiePoolChanged


        private int[] standardDieRoll(int[] dice )
        {
            // rolls 4 dice drops the lowest and adds the 3 hightest to an array argunent
            int a = -1;
            for (int x = 1; x < 7; x++)
            {
                int[] d6s = new int[4];

                for (int i = 0; i <= d6s.Length - 1; i++)
                {
                    d6s[i] = rollD6();
                }//end for
                Array.Sort(d6s);
                a++;
                dice[a] = d6s[1];
                a++;
                dice[a] = d6s[2];
                a++;
                dice[a] = d6s[3];
            }//end for
            return dice;
        }// end standardDieRoll

        private int[] heroicDieRoll(int[] dice)
        {
            // rolls 4 dice drops the lowest and adds the 3 hightest to an array argunent
            int a = -1;
            for (int x = 1; x < 7; x++)
            {
                int[] d6s = new int[3];

                for (int i = 0; i <= d6s.Length - 1; i++)
                {
                    d6s[i] = rollD6();
                }//end for
                Array.Sort(d6s);
                a++;
                dice[a] = d6s[1];
                a++;
                dice[a] = d6s[2];
                a++;
                dice[a] = 6;
            }//end for
            return dice;
        }//end heroic 

        private int[] classicDieRoll(int[] dice)
        {
            // rolls a number of D6s and populates an array with their outcomes.
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = rollD6();
            }//end for

            return dice;
        }// end standardDieRoll

        private int[] diePoolRoll(int[] dice)
        {
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = rollD6();
            }
            return dice;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void calculatePointsSpent(NumericUpDown[] stat)
        {
            for (int i = 0; i < stat.Length; i++)
            {
                if(stat[i].Value == 10)
                {
                    abilityScoreCost[i] = 0;
                }
                else if(stat[i].Value == 11)
                {
                    abilityScoreCost[i] = 1;
                }
                else if(stat[i].Value == 9)
                {
                    abilityScoreCost[i] = -1;
                }
                else if (stat[i].Value == 8)
                {
                    abilityScoreCost[i] = -2;
                }
                else if (stat[i].Value == 12)
                {
                    abilityScoreCost[i] = 2;
                }
                else if (stat[i].Value == 7)
                {
                    abilityScoreCost[i] = -4;
                }
                else if (stat[i].Value == 13)
                {
                    abilityScoreCost[i] = 3;
                }
                else if (stat[i].Value == 14)
                {
                    abilityScoreCost[i] = 5;
                }
                else if (stat[i].Value == 15)
                {
                    abilityScoreCost[i] = 7;
                }
                else if (stat[i].Value == 16)
                {
                    abilityScoreCost[i] = 10;
                }
                else if (stat[i].Value == 17)
                {
                    abilityScoreCost[i] = 13;
                }
                else if (stat[i].Value == 18)
                {
                    abilityScoreCost[i] = 17;
                }
                else
                {
                    abilityScoreCost[i] = 0;
                }// end if 
            }//end for
        }//end calculatePointsSpent
        void UpdateButtons(Button[] button, int [] die)//updates the butons with number from the die pool
        {
            for (int i = 0; i <= die.Length -1; i++)
            {
                button[i].Text = die[i].ToString();
            }
        }//end update buttons 

        private void NumberBoxChanged (object sender, EventArgs e)
        {
            NumericUpDown b = (NumericUpDown)sender;
            NumericUpDown[] attributeScores ={numericScoreA, numericScoreB, numericScoreC,
                numericScoreD, numericScoreE, numericScoreF };

            TextBox[] attributeModifyers = {textBoxModA, textBoxModB, textBoxModC, textBoxModD,
                textBoxModE, textBoxModF };
            NumericUpDown change = (NumericUpDown)sender;
            updateMods(attributeModifyers, attributeScores);
            calculatePointsSpent(attributeScores);
            textBoxPointCost.Text = abilityScoreCost.Sum().ToString();
        }// NumberBoxChanged

        private void updateAttributeScores(NumericUpDown[] scoreBox ,int [] die )
        {
            //takes every third value from the array and assigns it to the atribut Numaric buttons
            int a = 0;
            int subtotal;
            for (int i = 0; i < 6; i++)
            {
                subtotal = (die[0 + a] + die[1 + a] + die[2 + a]);
                scoreBox[i].Value = subtotal;
                a += 3;
            }
        }//end updateAttributeScores

        private void resetAttributeScores( int mode)//sets attributes to 0 or 10 based on a bool value
        {
            NumericUpDown[] attributeScores ={numericScoreA, numericScoreB, numericScoreC,
                numericScoreD, numericScoreE, numericScoreF };
            TextBox[] attributeModifyers = {textBoxModA, textBoxModB, textBoxModC, textBoxModD,
                textBoxModE, textBoxModF };
            for (int i = 0; i < AttScores().Length; i++)
            {
                if (mode == 5 ) //point buy mode
                {
                    enableAttScores(true);
                    attributeModifyers[i].Text = 0.ToString();
                    attributeScores[i].Value = 10;
                    attributeScores[i].Maximum = 18;
                    attributeScores[i].Minimum = 7;
                }
                else if(mode == 6)
                {
                    enableAttScores(true);
                    attributeScores[i].Value = 10;
                    attributeScores[i].Maximum = 100;
                    attributeScores[i].Minimum = 0;
                    attributeModifyers[i].Text = 0.ToString();
                }
                else if (mode == 7)
                {
                    enableAttScores(false);
                    attributeModifyers[i].Text = 0.ToString();
                    attributeScores[i].Value = 10;
                }
                else
                {

                    attributeScores[i].Maximum = 100;
                    attributeScores[i].Minimum = 0;
                    attributeScores[i].Value = 0;
                }//end if
            }//end for
        }// end resetAttributeScores


        public void enableAttScores(bool on_Off)
        {
            NumericUpDown[] numbs = AttScores();
            for (int i = 0; i < numbs.Length; i++)
            {
                numbs[i].Enabled = on_Off;
            }
        }

        public NumericUpDown[] AttScores()
        {
            NumericUpDown[] attributeScores ={numericScoreA, numericScoreB, numericScoreC,
                numericScoreD, numericScoreE, numericScoreF };
            return attributeScores;
        }

        private int modCalc(int stat)
        {
            int modifier;
            modifier =  (int)Math.Floor((double)(stat - 10d) / 2d);

            return modifier;
        }//end modCalc

        private void resetMods()
        {
            TextBox[] attributeModifyers = {textBoxModA, textBoxModB, textBoxModC, textBoxModD,
                textBoxModE, textBoxModF };

            for (int i = 0; i < attributeModifyers.Length; i++)
            {
                attributeModifyers[i].Clear();
            }// end for
        }//end reset mods

        private void updateMods(TextBox[] mod, NumericUpDown[] Score)
        {
            //takes the value of the numberupdown runs mod calc
            //translates it to a string then iputs that value in each textbox.
            for (int i = 0; i < mod.Length; i++)
            {
                mod[i].Text = modCalc((int)Score[i].Value).ToString();
            }
        }//end Update Mods



        private int incrementStatBoxes()
        {
            int statBox = 0;
            if (statBoxInc < 3)
            {
                statBox = 0;
            }
            else if (statBoxInc >= 3 && statBoxInc< 6)
            {
                statBox = 1;
            }
            else if (statBoxInc >= 6 && statBoxInc < 9)
            {
                statBox = 2;
            }
            else if (statBoxInc >= 9 && statBoxInc < 12)
            {
                statBox = 3;
            }
            else if (statBoxInc >= 12 && statBoxInc < 15)
            {
                statBox = 4;
            }
            else
            {
                statBox = 5;
            }//end if

            return statBox;
        }// incrementStatBoxes

        private bool[] resetBools(bool[] bools)
        {
            bools = new bool[bools.Length];
            return bools;
        }
        private void enableDisable_Buttons(bool on_off)
        {
            Button[] dieButtons = {buttonDieA01, buttonDieA02, buttonDieA03,
                buttonDieB04, buttonDieB05, buttonDieB06, buttonDieC07, buttonDieC08,
                buttonDieC09, buttonDieD10, buttonDieD11, buttonDieD12, buttonDieE13,
                buttonDieE14, buttonDieE15, buttonDieF16, buttonDieF17, buttonDieF18,
                buttonDieA19, buttonDieB20, buttonDieC21, buttonDieD22, buttonDieE23,
                buttonDieF24 };

            for (int i = 0; i < dieButtons.Length; i++)
            {
                dieButtons[i].Enabled = on_off;
            }
        }//enableDisable_Buttons

        private void Button_ScoreUpdater(int a, int[] dice, bool[] on_off,ref int statBoxInc)
        {
            NumericUpDown[] attributeScores ={numericScoreA, numericScoreB, numericScoreC,
                numericScoreD, numericScoreE, numericScoreF };

            Button[] dieButtons = {buttonDieA01, buttonDieA02, buttonDieA03,
                buttonDieB04, buttonDieB05, buttonDieB06, buttonDieC07, buttonDieC08,
                buttonDieC09, buttonDieD10, buttonDieD11, buttonDieD12, buttonDieE13,
                buttonDieE14, buttonDieE15, buttonDieF16, buttonDieF17, buttonDieF18,
                buttonDieA19, buttonDieB20, buttonDieC21, buttonDieD22, buttonDieE23,
                buttonDieF24 };
            TextBox[] attributeModifyers = {textBoxModA, textBoxModB, textBoxModC, textBoxModD,
                textBoxModE, textBoxModF };

            if (!on_off[a])
            {
                
                attributeScores[incrementStatBoxes()].Value = diepool[a] + attributeScores[incrementStatBoxes()].Value;
                on_off[a] = true;
                dieButtons[a].Text = "0";
                statBoxInc++;
                dieButtons[a].Enabled = false;
            }
            else
            {
                attributeScores[incrementStatBoxes()].Value -= diepool[a];
                dieButtons[a].Text = diepool[a].ToString();
                on_off[a] = false;
                statBoxInc--;
            }
            updateMods(attributeModifyers, attributeScores);
            if (statBoxInc == 18)
            {
                enableDisable_Buttons(false);
            }//end if

            switch (incrementStatBoxes())//moves arrows to indicate the box getting updated.
            {
                case 0:
                    resetArrows();
                    infoBox1.Text = Info.strengthStat;
                    break;
                case 1:
                    arrow1.Visible = false;
                    arrow2.Visible = true;
                    infoBox1.Text = Info.dexterityStat;
                    break;
                case 2:
                    arrow2.Visible = false;
                    arrow3.Visible = true;
                    infoBox1.Text = Info.consitutionStat;
                    break;
                case 3:
                    arrow3.Visible = false;
                    arrow4.Visible = true;
                    infoBox1.Text = Info.intellienceStat;
                    break;
                case 4:
                    arrow4.Visible = false;
                    arrow5.Visible = true;
                    infoBox1.Text = Info.wisdomStat;
                    break;
                case 5:
                    arrow5.Visible = false;
                    arrow6.Visible = true;
                    infoBox1.Text = Info.charismaStat;
                    break;
            }//end switch

        }//end Button_ScoreUpdater

        private void ResetDicePool_Click(object sender, EventArgs e)
        {

            Button[] DieButtons = {buttonDieA01, buttonDieA02, buttonDieA03,
                buttonDieB04, buttonDieB05, buttonDieB06, buttonDieC07, buttonDieC08,
                buttonDieC09, buttonDieD10, buttonDieD11, buttonDieD12, buttonDieE13,
                buttonDieE14, buttonDieE15, buttonDieF16, buttonDieF17, buttonDieF18,
                buttonDieA19, buttonDieB20, buttonDieC21, buttonDieD22, buttonDieE23,
                buttonDieF24 };

            NumericUpDown[] attributeScores ={numericScoreA, numericScoreB, numericScoreC,
                numericScoreD, numericScoreE, numericScoreF };

            TextBox[] attributeModifyers = {textBoxModA, textBoxModB, textBoxModC, textBoxModD,
                textBoxModE, textBoxModF };

            resetArrows();
            resetAttributeScores(rollMode);
            resetMods();
            enableDisable_Buttons(true);
            statBoxInc = 0;

            UpdateButtons(DieButtons, diepool);//populates the die pool buttons with with the values in the die pool array

            Array.Clear(isFull, 0, isFull.Length);//fills a bool array with false.

        }// end ResetDicePool_Click

        private void resetArrows()
        {
            arrow1.Visible = true;
            arrow2.Visible = false;
            arrow3.Visible = false;
            arrow4.Visible = false;
            arrow5.Visible = false;
            arrow6.Visible = false;
        }//end reset Arrows

        private void buttonDieA01_Click(object sender, EventArgs e)
        {   
            int x = 0;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }//buttonDieA01_Click

        private void buttonDieA02_Click(object sender, EventArgs e)
        {
            int x = 1;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieA03_Click(object sender, EventArgs e)
        {
            int x = 2;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieB04_Click(object sender, EventArgs e)
        {
            int x = 3;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieB05_Click(object sender, EventArgs e)
        {
            int x = 4;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieB06_Click(object sender, EventArgs e)
        {
            int x = 5;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieC07_Click(object sender, EventArgs e)
        {
            int x = 6;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieC08_Click(object sender, EventArgs e)
        {
            int x = 7;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieC09_Click(object sender, EventArgs e)
        {
            int x = 8;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieD10_Click(object sender, EventArgs e)
        {
            int x = 9;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieD11_Click(object sender, EventArgs e)
        {
            int x = 10;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieD12_Click(object sender, EventArgs e)
        {
            int x = 11;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieE13_Click(object sender, EventArgs e)
        {
            int x = 12;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieE14_Click(object sender, EventArgs e)
        {
            int x = 13;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieE15_Click(object sender, EventArgs e)
        {
            int x = 14;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieF16_Click(object sender, EventArgs e)
        {
            int x = 15;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieF17_Click(object sender, EventArgs e)
        {
            int x = 16;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieF18_Click(object sender, EventArgs e)
        {
            int x = 17;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieA19_Click(object sender, EventArgs e)
        {
            int x = 18;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieB20_Click(object sender, EventArgs e)
        {
            int x = 19;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieC21_Click(object sender, EventArgs e)
        {
            int x = 20;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieD22_Click(object sender, EventArgs e)
        {
            int x = 21;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieE23_Click(object sender, EventArgs e)
        {
            int x = 22;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void buttonDieF24_Click(object sender, EventArgs e)
        {
            int x = 23;
            Button_ScoreUpdater(x, diepool, isFull, ref statBoxInc);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Application written by Joseph Marsh \rRandomNumber class by Scott Lilly \rSome Descriptions Coppied from Official Starfinder Core Rule Book.\rStarfinder is not owned by me.\rStarfinder is property of Paizo Inc.",
                "About this Application" );
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit? Your changes will not be saved.", "Question",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonCommit_Click(object sender, EventArgs e)//sends all stats to Player object and ends the stat rolling step.
        {

            TextBox[] finalStats = { textBoxStr, textBoxDex, textBoxCon, textBoxInt,
                textBoxWis, textBoxCha };
            ComboBox[] StatNames = { comboBoxA, comboBoxB, comboBoxC, comboBoxD, comboBoxE, comboBoxF };
            NumericUpDown[] attributeScores ={numericScoreA, numericScoreB, numericScoreC,
                numericScoreD, numericScoreE, numericScoreF };
            TextBox[] attributeModifiers = {textBoxModA, textBoxModB, textBoxModC, textBoxModD,
                textBoxModE, textBoxModF };

            if (attributeScores[5].Value == 0|| attributeScores[4].Value == 0 
                || attributeScores[3].Value == 0 || attributeScores[2].Value == 0 
                || attributeScores[1].Value == 0 || attributeScores[0].Value == 0 )//sanity check
            {
                MessageBox.Show("looks like one of your Stats may not have been filled? Make sure you didn't forget something...",
                    "Uh Oh!", MessageBoxButtons.OK, MessageBoxIcon.Error);//should error if something was left blank.
            }
            else
            {

                if (MessageBox.Show("Are you sure you want to commit to these stats? Unless you chose Core, You will not be able to alter them latter.",
                    "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)//confirm quit
                {

                    for (int x = 0; x < 6; x++)
                    {
                        if (StatNames[x].Text == "Str")
                        {
                            textBoxStr.Text = attributeScores[x].Value.ToString();
                            textBoxStrMod2.Text = attributeModifiers[x].Text;
                        }
                        else if (StatNames[x].Text == "Dex")
                        {
                            textBoxDex.Text = attributeScores[x].Value.ToString();
                            textBoxDexMod2.Text = attributeModifiers[x].Text;
                        }
                        else if (StatNames[x].Text == "Con")
                        {
                            textBoxCon.Text = attributeScores[x].Value.ToString();
                            textBoxConMod2.Text = attributeModifiers[x].Text;
                        }
                        else if (StatNames[x].Text == "Int")
                        {
                            textBoxInt.Text = attributeScores[x].Value.ToString();
                            textBoxIntMod2.Text = attributeModifiers[x].Text;
                        }
                        else if (StatNames[x].Text == "Wis")
                        {
                            textBoxWis.Text = attributeScores[x].Value.ToString();
                            textBoxWisMod2.Text = attributeModifiers[x].Text;
                        }
                        else if (StatNames[x].Text == "Cha")
                        {
                            textBoxCha.Text = attributeScores[x].Value.ToString();
                            textBoxChaMod2.Text = attributeModifiers[x].Text;
                        }//end inner if

                    }//end for

                    //scores are added to the player object note that sats are alphabetical
                    player.ToonAtributes[0] = int.Parse(textBoxCha.Text);//Cha
                    player.ToonAtributes[1] = int.Parse(textBoxCon.Text);//Con
                    player.ToonAtributes[2] = int.Parse(textBoxDex.Text);//Dex
                    player.ToonAtributes[3] = int.Parse(textBoxInt.Text);//Int
                    player.ToonAtributes[4] = int.Parse(textBoxStr.Text);//Str
                    player.ToonAtributes[5] = int.Parse(textBoxWis.Text);//Wis

                    //Ability mods are added to the player object 
                    player.AbilityMods[0] = int.Parse(textBoxChaMod2.Text);//Cha
                    player.AbilityMods[1] = int.Parse(textBoxConMod2.Text);//Con
                    player.AbilityMods[2] = int.Parse(textBoxDexMod2.Text);//Dex
                    player.AbilityMods[3] = int.Parse(textBoxIntMod2.Text);//Int
                    player.AbilityMods[4] = int.Parse(textBoxStrMod2.Text);//Str
                    player.AbilityMods[5] = int.Parse(textBoxWisMod2.Text);//Wis


                    //kill all non esential interfaces.
                    groupD24.Enabled = false;
                    groupDice.Enabled = false;
                    groupScores.Enabled = false;
                    groupScores.Enabled = false;
                    GroupDieSelectAndRoll.Enabled = false;
                    groupStatSelection.Enabled = false;
                    groupStep1.Enabled = true;
                    if(rollMode == 7)
                    {
                        infoBox1.Text = Info.afterCommitPressedCore;
                    }
                    else
                    {
                        infoBox1.Text = Info.afterCommitPressed;
                    }
                    infoBox2.Text = Info.step1;
                    infoBox2.Enabled = true;
                    groupArrows.Visible = false;
                    buttonCommitCore.Enabled = false;
                    groupD24.TabStop = false;
                    groupDice.TabStop = false;
                    groupScores.TabStop = false;
                    groupBoxFinalStats.TabStop = false;


                }//end outer if for confirmation message

            }//End sanity check

        }//end buttonCommit_Click

        private void step1CommitButton_Click(object sender, EventArgs e)
        {
         
            if (textBoxStep1PlayerName.Text == "" || textBoxStep1CharName.Text == "" || textBoxStep1Concept.Text == "")
            {
                MessageBox.Show("looks like one one of your fields was not filled in? Make sure you didn't forget something... or just pess yes and keep going.  What do I care?",
                    "Uh Oh!", MessageBoxButtons.OK, MessageBoxIcon.Error);//should error if something was left blank.
            }
            if (MessageBox.Show("Are you sure you want to commit? You will not be able to alter your concept, name, or charactor's name but your notes will remain editable.",
                "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                groupStep1.Enabled = false;
                player.PlayerName = textBoxStep1PlayerName.Text;
                player.ToonName = textBoxStep1CharName.Text;
                player.Concept = textBoxStep1Concept.Text;

                richTextBoxNotes1.Text += "\r-------------------- (Step 1) --------------------\rCharacter name: " + 
                    textBoxStep1CharName.Text + "\rConcept: "+ textBoxStep1Concept.Text + 
                    "\rPlayer Name: " + textBoxStep1PlayerName.Text + "\r--------------------(Step 2)--------------------\r";
                player.NotesAndIdeas = richTextBoxNotes1.Text;

                richTextBoxNotes2.Text = richTextBoxNotes1.Text;
                groupBoxStep2.Visible = true;
                groupBoxStep2.Enabled = true;
                groupBoxFinalStats.Enabled = false;
            }//end if 
        }//end step1CommitButton_Click

        private void StepTwoRaceCommited(object sender, EventArgs e)
        {
            DebugStrip.Text = comboBoxRaceSelect.SelectedIndex.ToString();
            switch (comboBoxRaceSelect.SelectedIndex)
            {
                case 0://Android
                    poputlateRaceStatboxes(0);
                    comboBoxStep2PickAny.Visible = false;
                    labelStep2PickAny.Visible = false;
                    labelRaceName.Visible = false;
                    textBoxCustomRaceNameInput.Visible = false;
                    enableRacialSkillCombosBoxes(false, false, false, -1, -1, -1);
                    infoBox2.Text = Info.androidDiscription;
                    break;

                case 1://human
                    poputlateRaceStatboxes(1);
                    comboBoxStep2PickAny.Visible = true;
                    labelStep2PickAny.Visible = true;
                    labelRaceName.Visible = false;
                    textBoxCustomRaceNameInput.Visible = false;
                    enableRacialSkillCombosBoxes(false,false,false,-1,-1,-1);
                    infoBox2.Text = Info.humanDiscription;
                    break;

                case 2://Kasatha
                    poputlateRaceStatboxes(2);
                    comboBoxStep2PickAny.Visible = false;
                    labelStep2PickAny.Visible = false;
                    labelRaceName.Visible = false;
                    textBoxCustomRaceNameInput.Visible = false;
                    enableRacialSkillCombosBoxes(true,false, true, 0, 1, 5);//acrobatics and Athletics
                    infoBox2.Text = Info.kasathasDiscription;
                    break;

                case 3://Lashunta D
                    poputlateRaceStatboxes(3);
                    comboBoxStep2PickAny.Visible = false;
                    labelStep2PickAny.Visible = false;
                    labelRaceName.Visible = false;
                    textBoxCustomRaceNameInput.Visible = false;
                    enableRacialSkillCombosBoxes(true, true, false, -1, -1, -1);
                    infoBox2.Text = Info.lashuntasDiscription;
                    break;

                case 4://Lashunta K
                    poputlateRaceStatboxes(4);
                    comboBoxStep2PickAny.Visible = false;
                    labelStep2PickAny.Visible = false;
                    labelRaceName.Visible = false;
                    textBoxCustomRaceNameInput.Visible = false;
                    enableRacialSkillCombosBoxes(true, true, false, -1, -1, -1);
                    infoBox2.Text = Info.lashuntasDiscription;
                    break;

                case 5://Shirren
                    poputlateRaceStatboxes(5);
                    comboBoxStep2PickAny.Visible = false;
                    labelStep2PickAny.Visible = false;
                    labelRaceName.Visible = false;
                    textBoxCustomRaceNameInput.Visible = false;
                    enableRacialSkillCombosBoxes(true, false, false, 5, 6, -1);
                    infoBox2.Text = Info.shirrensDiscription;
                    break;

                case 6://Vesk
                    poputlateRaceStatboxes(6);
                    comboBoxStep2PickAny.Visible = false;
                    labelStep2PickAny.Visible = false;
                    labelRaceName.Visible = false;
                    textBoxCustomRaceNameInput.Visible = false;
                    enableRacialSkillCombosBoxes(false, false, false,-1,-1,-1 );
                    infoBox2.Text = Info.veskDiscription;
                    break;

                case 7://Yoski
                    poputlateRaceStatboxes(7);
                    comboBoxStep2PickAny.Visible = false;
                    labelStep2PickAny.Visible = false;
                    labelRaceName.Visible = false;
                    textBoxCustomRaceNameInput.Visible = false;
                    enableRacialSkillCombosBoxes(true, false,true, 8, 19, 20 );
                    infoBox2.Text = Info.yoskiDiscription;
                    break;

                case 8://other
                    poputlateRaceStatboxes(8);
                    comboBoxStep2PickAny.Visible = true;
                    labelStep2PickAny.Visible = true;
                    labelRaceName.Visible = true;
                    textBoxCustomRaceNameInput.Visible = true;
                    enableRacialSkillCombosBoxes(true, true, false, -1, -1, -1);
                    infoBox2.Text = Info.customRaceDiscription;
                    break;

                case 9://spare
                    poputlateRaceStatboxes(9);
                    break;

            }//end Switch
        }//end StepTwoRaceCommited

        public void enableRacialSkillCombosBoxes(bool on_Off,bool en_Dis, bool no3, int pos1, int pos2 , int pos3)
        {
            //reset comboboxes

            comboBoxStep2RacialSkill1.Text = "";
            comboBoxStep2RacialSkill2.Text = "";
            comboBoxStep2RacialSkill3.Text = "";

            comboBoxStep2RacialSkill1.Items.Clear();
            comboBoxStep2RacialSkill2.Items.Clear();
            comboBoxStep2RacialSkill3.Items.Clear();

            comboBoxStep2RacialSkill1.Items.AddRange(player.skillNames);
            comboBoxStep2RacialSkill2.Items.AddRange(player.skillNames);
            comboBoxStep2RacialSkill3.Items.AddRange(player.skillNames);

            //enable
            comboBoxStep2RacialSkill1.Enabled = en_Dis;
            comboBoxStep2RacialSkill2.Enabled = en_Dis;
            labelStep2Racial1.Enabled = en_Dis;
            labelStep2Racial2.Enabled = en_Dis;


            //if skills need to be chosen, disable commit
            buttonStep2Commit.Enabled = !en_Dis; 
       
            
            //show or hide
            comboBoxStep2RacialSkill1.Visible = on_Off;
            comboBoxStep2RacialSkill2.Visible = on_Off;
            comboBoxStep2RacialSkill3.Visible = no3;
            labelStep2Racial1.Visible = on_Off;
            labelStep2Racial2.Visible = on_Off;
            labelStep2Racial3.Visible = no3;

            //set combo position -1 is defualt
            comboBoxStep2RacialSkill1.SelectedIndex = pos1;
            comboBoxStep2RacialSkill2.SelectedIndex = pos2;
            comboBoxStep2RacialSkill3.SelectedIndex = pos3;
        }

        private void StepThreeThemeCommited(object sender, EventArgs e)
        {
            DebugStrip.Text = comboBoxRaceSelect.SelectedIndex.ToString();

            if (comboBoxThemeSelection.SelectedIndex == 9)
            {
                comboBoxStep3PickAny.Visible = true;
                labelStep3PickAny.Visible = true;
            }
            else
            {
                comboBoxStep3PickAny.Visible = false;
                labelStep3PickAny.Visible = false;
            }

            switch (comboBoxThemeSelection.SelectedIndex)
            {
                case 0://Ace Pilot
                    refreshSkillsStep3();
                    poputlateThemeStatboxes(0);
                    infoBox3.Text = Info.acePilot;
                    comboBoxStep3ClassSkill.Enabled = false;
                    comboBoxStep3ClassSkill.SelectedIndex = 15;
                    break;
                case 1://Bounty Hunter
                    refreshSkillsStep3();
                    poputlateThemeStatboxes(1);
                    infoBox3.Text = Info.bountyHunter;
                    comboBoxStep3ClassSkill.Enabled = false;
                    comboBoxStep3ClassSkill.SelectedIndex = 20;
                    break;
                case 2://Icon
                    refreshSkillsStep3();
                    poputlateThemeStatboxes(2);
                    infoBox3.Text = Info.icon;
                    comboBoxStep3ClassSkill.Enabled = false;
                    comboBoxStep3ClassSkill.SelectedIndex = 5;
                    break;
                case 3://Merc
                    refreshSkillsStep3();
                    poputlateThemeStatboxes(3);
                    infoBox3.Text = Info.mercenary;
                    comboBoxStep3ClassSkill.Enabled = false;
                    comboBoxStep3ClassSkill.SelectedIndex = 1;
                    break;
                case 4://Outlaw
                    refreshSkillsStep3();
                    poputlateThemeStatboxes(4);
                    infoBox3.Text = Info.outlaw;
                    comboBoxStep3ClassSkill.Enabled = false;
                    comboBoxStep3ClassSkill.SelectedIndex = 18;
                    break;
                case 5://Priest
                    refreshSkillsStep3();
                    poputlateThemeStatboxes(5);
                    infoBox3.Text = Info.priest;
                    comboBoxStep3ClassSkill.Enabled = false;
                    comboBoxStep3ClassSkill.SelectedIndex = 12;
                    break;
                case 6://Scholar
                    pickTwoSkillsStep3(10, 14);
                    poputlateThemeStatboxes(6);
                    infoBox3.Text = Info.scholar;
                    comboBoxStep3ClassSkill.Enabled = true;
                    break;
                case 7://Spacer
                    refreshSkillsStep3();
                    poputlateThemeStatboxes(7);
                    infoBox3.Text = Info.spacefarer;
                    comboBoxStep3ClassSkill.Enabled = false;
                    comboBoxStep3ClassSkill.SelectedIndex = 14;
                    break;
                case 8://Xeno
                    refreshSkillsStep3();
                    poputlateThemeStatboxes(8);
                    infoBox3.Text = Info.xenoSeeker;
                    comboBoxStep3ClassSkill.Enabled = false;
                    comboBoxStep3ClassSkill.SelectedIndex = 10;
                    break;
                case 9://Themless
                    refreshSkillsStep3();
                    poputlateThemeStatboxes(9);
                    infoBox3.Text = Info.themeless;
                    comboBoxStep3ClassSkill.Enabled = true;

                    break;
            }//end Switch
        }//end Step Three Theme Commited
        
        private void pickTwoSkillsStep3(int one, int two)
        {
            comboBoxStep3ClassSkill.Items.Clear();
            comboBoxStep3ClassSkill.Text = "";
            comboBoxStep3ClassSkill.Items.Add(player.skillNames[one]);
            comboBoxStep3ClassSkill.Items.Add(player.skillNames[two]);
            comboBoxStep3ClassSkill.SelectedIndex = -1;
        }//end pickTwoSkillsStep3

        private void refreshSkillsStep3()
        {
            comboBoxStep3ClassSkill.Items.Clear();
            comboBoxStep3ClassSkill.Text = "";
            comboBoxStep3ClassSkill.Items.AddRange(player.skillNames);
            comboBoxStep3ClassSkill.SelectedIndex = -1;
        }

        private void poputlateRaceStatboxes(int race)
        {
            TextBox[] raceSelectStats = { textBoxStep2Cha, textBoxStep2Con, textBoxStep2Dex,
                textBoxStep2Int, textBoxStep2Str, textBoxStep2Wis };

            for (int i = 0; i < raceSelectStats.Length; i++)
            {
                raceSelectStats[i].Text = Convert.ToString(raceMods[race][i] + player.ToonAtributes[i]);
            }

        }//end populate Race Stat Boxes

        private void poputlateThemeStatboxes(int t)
        {
            TextBox[] themeSelectStats = { textBoxStep3Cha, textBoxStep3Con, textBoxStep3Dex,
                textBoxStep3Int, textBoxStep3Str, textBoxStep3Wis };

            for (int i = 0; i < themeSelectStats.Length; i++)
            {

                themeSelectStats[i].Text = calcThemeStatsInCoreMode(t,i);
            }
        }//end populate Race Stat Boxes

        private string calcThemeStatsInCoreMode (int t, int i)
        {
            int num = themes[t][i] + player.raceMods[i] + player.ToonAtributes[i];
            if (num >= 18)
            {
                num = 18;
            }
            return num.ToString();
        }

        private void BriefConceptEntered(object sender, EventArgs e)
        {
            infoBox2.Text = Info.briefConcept;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to quit? Those Space Gobies won't sleigh themselves now...",
                "Closing so soon?", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }

        private void Step2Commit_Click(object sender, EventArgs e)
        {
            
            if (comboBoxRaceSelect.SelectedIndex <0 ||( (comboBoxRaceSelect.SelectedIndex == 1 || comboBoxRaceSelect.SelectedIndex == 8) &&
                comboBoxStep2PickAny.SelectedIndex< 0))
            {
                MessageBox.Show("looks like one of your Stats may not have been filled? Make sure you didn't forget something...",
                   "Uh Oh!", MessageBoxButtons.OK, MessageBoxIcon.Error);//should error if something was left blank.
            }
            else
            {
                player.PlayerRaceId = comboBoxRaceSelect.SelectedIndex;

                if (comboBoxRaceSelect.SelectedIndex == 1)//human
                {
                    player.raceMods[comboBoxStep2PickAny.SelectedIndex] = 2; //adds 2 to the array in the position corrospondant to the stat it modifies.
                    DebugStrip.Text = comboBoxStep2PickAny.SelectedIndex + " " + true.ToString();

                }
                else if (comboBoxRaceSelect.SelectedIndex == 8)//other
                {
                    player.raceMods[comboBoxStep2PickAny.SelectedIndex] = 2; //adds 2 to the array in the position corrospondant to the stat it modifies.
                    DebugStrip.Text = comboBoxStep2PickAny.SelectedIndex + " " + true.ToString() + " " + textBoxCustomRaceNameInput.Text;
                    player.OtherRaceName = textBoxCustomRaceNameInput.Text;

                }
                else
                {
                    player.raceMods = race.RaceMods[comboBoxRaceSelect.SelectedIndex]; //replaces the array in player with selected array in race
                    DebugStrip.Text = comboBoxRaceSelect.SelectedIndex.ToString() + " " + false.ToString();
                }

                player.NotesAndIdeas = richTextBoxNotes2.Text;
                player.NotesAndIdeas = player.NotesAndIdeas + "\rRace: " + race.raceNames[comboBoxRaceSelect.SelectedIndex];
                
                groupBoxStep2.Enabled = false;
                groupBoxStep3.Visible = true;
                groupBoxStep3.Enabled = true;
                infoBox3.Visible = true;
                infoBox3.Enabled = true;

                if (comboBoxStep2RacialSkill1.Visible && comboBoxStep2RacialSkill2.Visible && comboBoxStep2RacialSkill3.Visible)
                {
                    player.RacialskillMod[comboBoxStep2RacialSkill1.SelectedIndex] = 2;
                    player.RacialskillMod[comboBoxStep2RacialSkill2.SelectedIndex] = 2;
                    player.RacialskillMod[comboBoxStep2RacialSkill2.SelectedIndex] = 2;
                    player.NotesAndIdeas = player.NotesAndIdeas + "\r\tRacial skills:" + "\r\t\t" + comboBoxStep2RacialSkill1.SelectedItem.ToString() + " +2" +
                        "\r\t\t" + comboBoxStep2RacialSkill2.SelectedItem.ToString() + " +2" + "\r\t\t" + comboBoxStep2RacialSkill3.SelectedItem.ToString() + " +2";
                }
                else if (comboBoxStep2RacialSkill1.Visible && comboBoxStep2RacialSkill2.Visible)
                {
                    player.RacialskillMod[comboBoxStep2RacialSkill1.SelectedIndex] = 2;
                    player.RacialskillMod[comboBoxStep2RacialSkill2.SelectedIndex] = 2;
                    player.NotesAndIdeas = player.NotesAndIdeas + "\r\tRacial skills:" + "\r\t\t" + comboBoxStep2RacialSkill1.SelectedItem.ToString() + " +2" +
                        "\r\t\t" + comboBoxStep2RacialSkill2.SelectedItem.ToString() + " +2";
                }

                if(comboBoxRaceSelect.SelectedIndex == 0)//if android
                {
                    player.NotesAndIdeas = player.NotesAndIdeas + "\r\tRacial skills:" + "\r\t\t" + player.skillNames[17].ToString() + " -2";
                    player.RacialskillMod[17] = -2;
                }
                player.RaceHPMod = race.raceHPMod[comboBoxRaceSelect.SelectedIndex];
                richTextBoxNotes3.Text = player.NotesAndIdeas;
                comboBoxThemeSelection.Focus();
            }//end outer if
            
        }//End Step 2 Commit

        private void Step3Commit_Click(object sender, EventArgs e)
        {
            
            int tempStep3 =0;//stores skill id
            if (comboBoxRaceSelect.SelectedIndex < 0 || ((comboBoxRaceSelect.SelectedIndex == 1 || comboBoxRaceSelect.SelectedIndex == 8) &&
    comboBoxStep2PickAny.SelectedIndex < 0)|| (comboBoxStep3ClassSkill.SelectedIndex < 0))
            {
                MessageBox.Show("looks like one of your Stats may not have been filled? Make sure you didn't forget something...",
                   "Uh Oh!", MessageBoxButtons.OK, MessageBoxIcon.Error);//should error if something was left blank.
            }
            else
            {
                player.PlayerThemeId = comboBoxThemeSelection.SelectedIndex;

                if (comboBoxThemeSelection.SelectedIndex == 9)
                {
                    player.themeMods[comboBoxStep3PickAny.SelectedIndex] = 1;

                }
                else
                {
                    player.themeMods = themes[comboBoxThemeSelection.SelectedIndex];
                }// inner end if 

                if (comboBoxThemeSelection.SelectedIndex == 6)//if scholar
                {
                    if(comboBoxStep3ClassSkill.SelectedIndex == 0)
                    {
                        player.isThemeClassSkill[10] = true;
                        tempStep3 = 10;
                    }
                    if (comboBoxStep3ClassSkill.SelectedIndex == 1)
                    {
                        player.isThemeClassSkill[14] = true;
                        tempStep3 = 14;
                    }
                }else
                {
                    player.isThemeClassSkill[comboBoxStep3ClassSkill.SelectedIndex] = true;
                    tempStep3 = comboBoxStep3ClassSkill.SelectedIndex;
                }
                player.themeBenifits[0] = theme.ThemeBenefits[comboBoxThemeSelection.SelectedIndex][0];
                DebugStrip.Text = theme.ThemeNames[comboBoxThemeSelection.SelectedIndex];
                player.NotesAndIdeas = richTextBoxNotes3.Text;
                player.NotesAndIdeas = player.NotesAndIdeas + "\rTheme: " + theme.ThemeNames[comboBoxThemeSelection.SelectedIndex] +
                    "\r\tClass Skill from Theme: " + player.skillNames[tempStep3] + "\r\tTheme Benefit: " +
                    player.themeBenifits[0];
                richTextBoxNotes3.Text = player.NotesAndIdeas;
                richTextBoxNotes4.Text = player.NotesAndIdeas;
                groupBoxStep3.Enabled = false;
                groupBoxStep4.Enabled = true;
                groupBoxStep4.Visible = true;
                comboBoxStep4Class1.Items.AddRange(player.ClassNames);
                comboBoxStep4Class1.SelectedIndex = 1;
                infoBox3.Enabled = false;
            }// end outer if

        }//end step 3 commit

        private void step2RacialSkill_Commited(object sender, EventArgs e)
        {
            //if the boxes are enabled and they have the same thing in them and not default
            if(comboBoxStep2RacialSkill2.Enabled && ((comboBoxStep2RacialSkill2.SelectedIndex == comboBoxStep2RacialSkill1.SelectedIndex) ||
                (comboBoxStep2RacialSkill2.SelectedIndex == -1 || comboBoxStep2RacialSkill1.SelectedIndex == -1)))
            {
                buttonStep2Commit.Enabled = false;
            }
            else
            {
                buttonStep2Commit.Enabled = true;
            }
        }

        private void Step4ClassCommitted(object sender, EventArgs e)
        {
            switch(comboBoxStep4Class1.SelectedIndex)
            {
                case 0:
                    infoBox3.Text = Info.envoyDiscription + cr() + tab_Cr(envoy.ClassSkillNames);
                    break;

            }

            
            if(comboBoxStep4Class1.SelectedIndex == comboBoxStep4Class2.SelectedIndex)
            {
                buttonStep4Commit.Enabled = false;
            }
            else
            {
                buttonStep4Commit.Enabled = true;
            }
        }

        public string tab_Cr(string[] text)
        {
            //takes an array of strings and prints them in a series of tabs and carrage returns.
            string output = "";
            for (int i = 0; i < text.Length; i++)
            {
                    output += cr() + text[i];

            }
            output += cr();
            return output;
            
        }
        private static string cr()
        {
            string cr = System.Environment.NewLine;
            return cr;
        }
        private void checkBoxToggleMulticlass_CheckedChanged(object sender, EventArgs e){}

        private void multiclass_Checked(object sender, EventArgs e)
        {
            if (checkBoxToggleMulticlass.Checked)
            {
                player.MultiClass = true;
                comboBoxStep4Class2.Visible = true;
                numericUpDownStep4Level2.Visible = true;
                comboBoxStep4Class2.Items.Clear();
                comboBoxStep4Class2.Items.AddRange(player.ClassNames);
                comboBoxStep4Class2.SelectedIndex = -1;
                comboBoxStep4Class2.SelectedItem = -1;
                comboBoxStep4Class2.Enabled = true;
                numericUpDownStep4Level2.Enabled = true;
                buttonStep4Commit.Enabled = false;
            }
            else
            {
                player.MultiClass = false;
                comboBoxStep4Class2.Visible = false;
                numericUpDownStep4Level2.Visible = false;
                comboBoxStep4Class2.SelectedIndex = -1;
                comboBoxStep4Class2.SelectedItem = -1;
                comboBoxStep4Class2.Enabled = true;
                numericUpDownStep4Level2.Enabled = false;
                numericUpDownStep4Level2.Value = 0;
                if(numericUpDownStep4Level2.Value < 20)
                {
                    numericUpDownStep4Level2.Maximum = numericUpDownStep4Level2.Value + 1;
                }
                buttonStep4Commit.Enabled = true;

            }
            if (comboBoxStep4Class1.SelectedIndex == comboBoxStep4Class2.SelectedIndex)
            {
                buttonStep4Commit.Enabled = false;
            }
        }

        private void Step4ClassLevels(object sender, EventArgs e)
        {
            if (numericUpDownStep4Level1.Value + numericUpDownStep4Level2.Value == 20)
            {
                numericUpDownStep4Level1.Maximum = numericUpDownStep4Level1.Value ;
                numericUpDownStep4Level2.Maximum = numericUpDownStep4Level2.Value ;
            }
            else
            {
                numericUpDownStep4Level1.Maximum = numericUpDownStep4Level1.Value + 1;
                numericUpDownStep4Level2.Maximum = numericUpDownStep4Level2.Value + 1;
            }

            if (numericUpDownStep4Level2.Enabled)//checks to see if multiclass is enabled and if so makes sure that the same class isn't picked twice.
            {
                if(numericUpDownStep4Level2.Value < 1)
                {
                    buttonStep4Commit.Enabled = false;
                }
                else if(numericUpDownStep4Level2.Visible && numericUpDownStep4Level2.Value >= 1 && comboBoxStep4Class2.SelectedIndex>-1)
                {
                    buttonStep4Commit.Enabled = true;
                }
            }
        }

        private void buttonStep4Commit_Click(object sender, EventArgs e)
        {
           
            player.ClassID1 = comboBoxStep4Class1.SelectedIndex;
            player.ClassID2 = comboBoxStep4Class2.SelectedIndex;

            player.Class1Level = (int)numericUpDownStep4Level1.Value;
            player.Class2Level = (int)numericUpDownStep4Level2.Value;

            richTextBoxNotes4.Text = richTextBoxNotes4.Text + "\rClass: " + player.ClassNames[comboBoxStep4Class1.SelectedIndex] +
                " - Level: " + numericUpDownStep4Level1.Value.ToString();

            if (checkBoxToggleMulticlass.Checked)
            {
                richTextBoxNotes4.Text = richTextBoxNotes4.Text + "\rClass 2: " + player.ClassNames[comboBoxStep4Class2.SelectedIndex] +
                " - Level: " + numericUpDownStep4Level2.Value.ToString();
            }
            player.NotesAndIdeas = richTextBoxNotes4.Text;
            richTextBoxNotes4.Enabled = false;
            groupBoxStep4.Enabled = false;
            groupBoxStep5.Visible = true;
            groupBoxStep5.Enabled = true; 
            richTextBoxNotes5.Text = player.NotesAndIdeas;
            textBoxStep5PrimaryAbilityScore.Text = classes.KeyAttributes[player.ClassID1];
            textBoxStep5SecondaryScore.Text = classes.SecoundaryAttributes[player.ClassID1];

            if(rollMode == 7)//core mode
            {
                
                for (int i = 0; i < player.ToonAtributes.Length; i++)
                {
                    manageStep5PointBuyStats(i).Value = player.ToonAtributes[i] + player.raceMods[i] + player.themeMods[i];
                    previousValue[i] = player.ToonAtributes[i] + player.raceMods[i] + player.themeMods[i];
                }//end for

                if (checkBoxToggleMulticlass.Checked)//calcuates number of extra attribute points due to leveling up incase of multiclass
                {
                    numericUpDownStep5LevelPoints.Value = Convert.ToInt32(Math.Floor((numericUpDownStep4Level2.Value + numericUpDownStep4Level1.Value)/5));
                }
                else//calcuates number of extra attribute points due to leveling up
                {
                    numericUpDownStep5LevelPoints.Value = Convert.ToInt32(Math.Floor(numericUpDownStep4Level1.Value / 5));
                    
                }//end if
                pointBuyPoints += (int)numericUpDownStep5LevelPoints.Value;
                numericUpDownStep5PBPoints.Value = pointBuyPoints;
            }
            else
            {
                groupBoxStep5.Enabled = false;
            }//end outer if roll mode 7

        }//end buttonStep4Commit_Click


        private NumericUpDown manageStep5PointBuyStats(int i)
        {
            NumericUpDown[] stats = { numericUpDownStep5Cha, numericUpDownStep5Con, numericUpDownStep5Dex,
                numericUpDownStep5Int, numericUpDownStep5Str, numericUpDownStep5Wis };
            return stats[i];
        }

        private void comboBoxStep4Classes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxStep4Class1.SelectedIndex == comboBoxStep4Class2.SelectedIndex)
            {
                buttonStep4Commit.Enabled = false;
            }
            if(comboBoxStep4Class2.Visible && numericUpDownStep4Level2.Value<= 0)
            {
                buttonStep4Commit.Enabled = false;
            }
        }




        private void Step5AbilityScoreChanged(object sender, EventArgs e)
        {
            
            if (numericUpDownStep5PBPoints.Value < -14)
            {
                for (int i = 0; i < 6; i++)
                {
                    manageStep5PointBuyStats(i).Maximum = manageStep5PointBuyStats(i).Value;
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    manageStep5PointBuyStats(i).Maximum = 18;
                }
            }


            for (int i = 0; i < previousValue.Length; i++)
            {
                newValue[i] = (int)manageStep5PointBuyStats(i).Value;//captures stats as they are now for a running total of points sepent so far
                previousValue[i] = player.ToonAtributes[i] + player.raceMods[i] + player.themeMods[i];//captures stats as they where previously recorded for a base line.
            }
            total = (previousValue[0] - newValue[0]) + (previousValue[1] - newValue[1]) +
                (previousValue[2] - newValue[2]) + (previousValue[3] - newValue[3]) + 
                (previousValue[4] - newValue[4]) + (previousValue[5] - newValue[5]) ;
            numericUpDownStep5PBPoints.Value = total + pointBuyPoints;

            

        }

        private void numericUpDownStep5PBPoints_ValueChanged(object sender, EventArgs e)
        {
            
            if (numericUpDownStep5PBPoints.Value < 0 )
            {
                for (int i = 0; i < 6; i++)
                {
                    labelCheater.Visible = true;
                }
            }
            else
            {
                labelCheater.Visible = false;
            }
        }

        private void step5Commit_Click(object sender, EventArgs e)
        {


            groupBoxStep6.Enabled = true;
            groupBoxStep5.Enabled = false;
            textBoxStep6Class1.Text = player.Class1Level.ToString();
            textBoxStep6Level.Text = player.PlayerLevel.ToString();
            if (player.MultiClass)
            {
                textBoxStep6Class2.Text = player.Class2Level.ToString();
            }
            classAssignment();//after this point all non info data should be pulled from player
            

            if (rollMode == 7)//if in Core mode do this first
            {
                //assign attributes to player class
                player.ToonAtributes[0] = (int)numericUpDownStep5Cha.Value;
                player.ToonAtributes[1] = (int)numericUpDownStep5Con.Value;
                player.ToonAtributes[2] = (int)numericUpDownStep5Dex.Value;
                player.ToonAtributes[3] = (int)numericUpDownStep5Int.Value;
                player.ToonAtributes[4] = (int)numericUpDownStep5Str.Value;
                player.ToonAtributes[5] = (int)numericUpDownStep5Wis.Value;
            }

            //Calculate and display Attribues
            textBoxStep6Cha.Text = player.ToonAtributes[0].ToString();
            textBoxStep6Con.Text = player.ToonAtributes[1].ToString();
            textBoxStep6Dex.Text = player.ToonAtributes[2].ToString();
            textBoxStep6Int.Text = player.ToonAtributes[3].ToString();
            textBoxStep6Str.Text = player.ToonAtributes[4].ToString();
            textBoxStep6Wis.Text = player.ToonAtributes[5].ToString();
            //calculate and display mods
            textBoxStep6ChaMod.Text = modCalc(player.ToonAtributes[0]).ToString();
            textBoxStep6ConMod.Text = modCalc(player.ToonAtributes[1]).ToString();
            textBoxStep6DexMod.Text = modCalc(player.ToonAtributes[2]).ToString();
            textBoxStep6IntMod.Text = modCalc(player.ToonAtributes[3]).ToString();
            textBoxStep6StrMod.Text = modCalc(player.ToonAtributes[4]).ToString();
            textBoxStep6WisMod.Text = modCalc(player.ToonAtributes[5]).ToString();
            //assign mods to player class
            player.AbilityMods[0] = modCalc(player.ToonAtributes[0]);
            player.AbilityMods[1] = modCalc(player.ToonAtributes[1]);
            player.AbilityMods[2] = modCalc(player.ToonAtributes[2]);
            player.AbilityMods[3] = modCalc(player.ToonAtributes[3]);
            player.AbilityMods[4] = modCalc(player.ToonAtributes[4]);
            player.AbilityMods[5] = modCalc(player.ToonAtributes[5]);
            //Base attack bonus stuff
            textBoxStep6BAB.Text = player.PlayerBAB.ToString();
            textBoxStep6BABDex.Text = (player.PlayerBAB + player.AbilityMods[2]).ToString();
            textBoxStep6BABStr.Text = (player.PlayerBAB + player.AbilityMods[4]).ToString();
            //HP and SP
            textBoxStep6SP.Text = player.StaminaPoints.ToString();
            textBoxStep6HP.Text = player.HitPoints.ToString(); 

        }

        private void classAssignment()//class data is apllied to the player(Toon) class here
        {
            int classPicked = player.ClassID1;
            int loops = 1;
            if (player.MultiClass)//if multiclass chosen, do class 2 first then class 1
            {
                classPicked = player.ClassID2;
                loops = 2;
            }//else do class 1

            do
            {
                switch (classPicked)
                {
                    case 0:
                        if (loops == 2)//Envoy Class selection
                        {
                            envoy.ClassLevel = player.Class2Level;
                            player.Class2ConMod = envoy.ConMod;
                            player.Class2HPMod = envoy.HPMod;
                            player.BAB2 = envoy.BAB;
                            player.SetClass2Features = envoy.ClassFeatures[player.Class2Level];
                            
                        }
                        else
                        {
                            envoy.ClassLevel = player.Class1Level;
                            player.Class1ConMod = envoy.ConMod;
                            player.Class1HPMod = envoy.HPMod;
                            player.BAB1 = envoy.BAB;
                            player.SetClass1Features = envoy.ClassFeatures[player.Class1Level];

                        }//end if

                        player.IsClassSkill = envoy.isClassSkill;
                        player.profiencies = envoy.areProfiencies;
                        break;//end case 0

                    case 1:
                        if (loops == 2)//Mechanic Class selection
                        {
                            mech.ClassLevel = player.Class2Level;
                            player.Class2ConMod = mech.ConMod;
                            player.Class2HPMod = mech.HPMod;
                            player.BAB2 = mech.BAB;
                            player.SetClass2Features = mech.ClassFeatures;
                        }
                        else
                        {
                            mech.ClassLevel = player.Class1Level;
                            player.Class1ConMod = mech.ConMod;
                            player.Class1HPMod = mech.HPMod;
                            player.BAB1 = mech.BAB;
                            player.SetClass1Features = mech.ClassFeatures;

                        }//end if

                        player.IsClassSkill = mech.isClassSkill;
                        player.profiencies = mech.areProfiencies;
                        break;//end case 1

                    case 2:
                        if (loops == 2)//Mystic Class selection
                        {
                            mystic.ClassLevel = player.Class2Level;
                            player.Class2ConMod = mystic.ConMod;
                            player.Class2HPMod = mystic.HPMod;
                            player.BAB2 = mystic.BAB;
                        }
                        else
                        {
                            mystic.ClassLevel = player.Class1Level;
                            player.Class1ConMod = mystic.ConMod;
                            player.Class1HPMod = mystic.HPMod;
                            player.BAB1 = mystic.BAB;
                        }//end if

                        player.IsClassSkill = mystic.isClassSkill;
                        player.profiencies = mystic.areProfiencies;
                        player.MysticSpellsPerDay = mystic.SpellsPerDay[mystic.ClassLevel];
                        break;//end case 2

                    case 3:
                        if (loops == 2)//Operative class selection
                        {
                            operative.ClassLevel = player.Class2Level;
                            player.Class2ConMod = operative.ConMod;
                            player.Class2HPMod = operative.HPMod;
                            player.BAB2 = operative.BAB;
                        }
                        else
                        {
                            operative.ClassLevel = player.Class1Level;
                            player.Class1ConMod = operative.ConMod;
                            player.Class1HPMod = operative.HPMod;
                            player.BAB1 = operative.BAB;  
                        }//end if

                        player.IsClassSkill = operative.isClassSkill;
                        player.profiencies = operative.areProfiencies;
                        break;//end case 3

                    case 4:
                        if (loops == 2)//Solarian Class Selection
                        {
                            solar.ClassLevel = player.Class2Level;
                            player.Class2ConMod = solar.ConMod;
                            player.Class2HPMod = solar.HPMod;
                            player.BAB2 = solar.BAB;

                        }
                        else
                        {
                            solar.ClassLevel = player.Class1Level;
                            player.Class1ConMod = solar.ConMod;
                            player.Class1HPMod = solar.HPMod;
                            player.BAB1 = solar.BAB;
                            
                        }//end if 

                        player.profiencies = solar.areProfiencies;
                        break;//end case 4

                    case 5:
                        if (loops == 2)//Soldier
                        {
                            soldier.ClassLevel = player.Class2Level;
                            player.Class2ConMod = soldier.ConMod;
                            player.Class2HPMod = soldier.HPMod;
                            player.BAB2 = solar.BAB;
                            player.profiencies = soldier.areProfiencies;
                        }
                        else
                        {
                            soldier.ClassLevel = player.Class1Level;
                            player.Class1ConMod = soldier.ConMod;
                            player.Class1HPMod = soldier.HPMod;
                            player.BAB1 = solar.BAB;
                            player.profiencies = soldier.areProfiencies;
                        }// end if 

                        break;//end case 5

                    case 6:
                        if (loops == 2)//Technomancer
                        {
                            tech.ClassLevel = player.Class2Level;
                            player.Class2ConMod = tech.ConMod;
                            player.Class2HPMod = tech.HPMod;
                            player.BAB2 = tech.BAB;
                        }
                        else
                        {
                            tech.ClassLevel = player.Class1Level;
                            player.Class1ConMod = tech.ConMod;
                            player.Class1HPMod = tech.HPMod;
                            player.BAB1 = tech.BAB;
                        }//end if

                        player.TechnoSpellsPerDay = tech.SpellsPerDay[tech.ClassLevel];
                        player.profiencies = tech.areProfiencies;
                        break;//end case 6

                }//end switch 

                loops--;
                classPicked = player.ClassID1;//incase of multiclassing, set class1 stats
            } while (loops != 0);//end do while

        }//end classAssignment

        private void numericUpDownStep5PBPoints_ClientSizeChanged(object sender, EventArgs e)
        {
        }

        private void radioButton10Points_CheckedChanged(object sender, EventArgs e)
        {
            pointBuyPoints = 10;
        }

        private void radioButton15Points_CheckedChanged(object sender, EventArgs e)
        {
            pointBuyPoints = 15;
        }

        private void radioButton20Points_CheckedChanged(object sender, EventArgs e)
        {
            pointBuyPoints = 20;
        }
    }//end form 1



    public class feats
    {
        public string FeatName { set; get; }
        public string Description { set; get; }
        public int SkillModified1 { set; get; }
        public int SkillModified2 { set; get; }
        public int AttributeModified { set; get; }

    }//end feats

    public class Race
    {
        /// <summary>
        /// Libraray for Race data.
        /// </summary>
        public int[][] races = new int[9][];
        public int[] raceHPMod = { 4, 4, 4, 4, 4, 6, 6, 2, 4 };

        public readonly int[] androidMods =     { -2, 0, 2, 2, 0, 0 };
        public readonly int[] humanMods =       {  0, 0, 0, 0, 0, 0 };
        public readonly int[] kasathaMods =     { 0, 0, 0, -2, 2, 2 };
        public readonly int[] lashuntaDMods =   { 2, -2, 0, 2, 0, 0 };
        public readonly int[] lashuntaKMods =   { 2, 0, 0, 0, 2, -2 };
        public readonly int[] shirrenMods =     { -2, 2, 0, 0, 0, 2 };
        public readonly int[] veskMods =        { 0, 2, 0, -2, 2, 0 };
        public readonly int[] YoskiMods =       { 0, 0, 2, 2, -2, 0 };
        public readonly int[] otherRaceMods =   { 0, 0, 0, 0,  0, 0 };
        public readonly string[] raceNames = { "Android", "Human", "Kasatha", "Lashunta[Damaya]",
            "Lashunta[Korasha]", "Shirren", "Vesk", "Yoski", "other" };

        public string getRaceName(int raceID)
        {
            return raceNames[raceID];
        }



        public int[][] RaceMods
        {
            get
            {
                races[0] = androidMods;
                races[1] = humanMods;
                races[2] = kasathaMods;
                races[3] = lashuntaDMods;
                races[4] = lashuntaKMods;
                races[5] = shirrenMods;
                races[6] = veskMods;
                races[7] = YoskiMods;
                races[8] = otherRaceMods;
                return races;
            }
        }


        public int[] getClassArray(int classId)//race stat mods
        {
            races[0] = androidMods;
            races[1] = humanMods;
            races[2] = kasathaMods;
            races[3] = lashuntaDMods;
            races[4] = lashuntaKMods;
            races[5] = shirrenMods;
            races[6] = veskMods;
            races[7] = YoskiMods;
            races[8] = otherRaceMods;
            return races[classId];
        }
        

    }//end race


    public static class RandomNumber
    {
        //this class was orrigonally published by Scott Lilly
        //then slighly modified by Joseph Marsh
        //code was found on https://scottlilly.com/create-better-random-numbers-in-c/

        private static readonly RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        public static int Between(int minValue, int maxValue)
        {
            byte[] rando = new byte[1];

            rng.GetBytes(rando);

            double valueOfChar = Convert.ToDouble(rando[0]);

            // We are using Math.Max, and substracting 0.00000000001, 
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            double numMultiplier = Math.Max(0, (valueOfChar / 255d) - 0.00000000001d);

            // We need to add one to the range, to allow for the rounding done with Math.Floor
            int range = maxValue - minValue + 1;

            double randValue = Math.Floor(numMultiplier * range);

            return (int)(minValue + randValue);
        }
    }
}
