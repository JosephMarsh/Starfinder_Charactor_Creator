using System;
using System.Collections.Generic;

namespace StarFinderCharactorGenerator_V2._2
{
    public class Toon

    /// <summary>
    /// This class stores charactor data for from1
    /// This is where finalized data should be stored.
    /// </summary>

    {
        //unique data
        public string ToonName { set; get; }
        public string PlayerName { set; get; }
        public string Concept { set; get; }
        public string NotesAndIdeas { set; get; }
        private int playerLevel;//Property (Level) returns sum of classes 1 and 2
        private int playerBAB;
        private bool heavyArmor = false;//default is false
        public string Deity { set; get; }

        //Weapon stuff 
        private bool[] weaponProficiency = new bool[7];//basic melee[0], advanced melee[1], small arms[2], long arms[3], sniper[4], heavy[5], granades[6]
        private string[] proficiencies = { "Basic Melee Weapons", "Advanced Melee Weapons", "Small Arms", "Longarms", "Sniper Weapons", "heavy Weapons", "granades" };

        //ability score stuff
        private int[] toonAtributes = { 10, 10, 10, 10, 10, 10 }; //parrallel with AttributeNames, ability Mods and AtributeBrief Base stats at toon creation.
        private int[] abilityMods = { 0, 0, 0, 0, 0, 0 };//staring value after stat roll but before any adjustments or corrections.
        public readonly string[] attributeNames = { "Charsima", "Constitution", "Dexterity", "Intelligence", "Strength", "Wisdom" };
        public readonly string[] attributeBrief = { "Cha", "Con", "Dex", "Int", "Str", "Wis" }; //6, 3, 4, 2, 1, 5 as they appear on the official Characer sheet
        private int[] abilityScoresFinal = { 0, 0, 0, 0, 0, 0 };//as ability scores will apear on the final toon
        public readonly int[] curentXP = { 0, 0, 1300, 3300, 6000, 10000, 15000, 23000, 34000, 50000, 71000, 105000, 145000, 210000, 295000, 425000, 600000, 850000, 1200000, 1700000, 2400000 };
        public readonly int[] nextLevelXP = { 0, 1300, 3300, 6000, 10000, 15000, 23000, 34000, 50000, 71000, 105000, 145000, 210000, 295000, 425000, 600000, 850000, 1200000, 1700000, 2400000, 0 };
        public readonly int[] featsPerLevel = { 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10 };

        //Race stuff goes here
        public readonly string[] raceNames = { "Android", "Human", "Kasatha", "Lashunta[Damaya]",
            "Lashunta[Korasha]", "Shirren", "Vesk", "Yoski", "other" };
        public int[] raceMods = { 0, 0, 0, 0, 0, 0 };
        public int PlayerRaceId { set; get; } //0-7.
        public string OtherRaceName { set; get; }
        public int RaceHPMod { set; get; }
        public int[] RacialskillMod = new int[22];
        public int RacialACBonus = 0;

        //Theme stuff 
        public int[] themeMods = { 0, 0, 0, 0, 0, 0 };
        public bool[] isThemeClassSkill = new bool[22];//stored sepeatly from Class class skills for latter comparison.
        public int PlayerThemeId { set; get; }//0-9 with 9 beeing themeless
        public string[] themeBenifits = new string[4];//strores an array of beifits based on the level of the character. 

        //class stuff
        public bool MultiClass { set; get; }
        public readonly string[] ClassNames = { "Envoy", "Mechanic", "Mystic", "Operative", "Solarian", "Soldier", "Technomancer" };
        public int ClassID1 { set; get; }
        public int ClassID2 { set; get; }//incase of multiclassing.
        public int Class1Level { set; get; }
        public int Class2Level { set; get; }//incase of multiclassing.
        public int Class1ConMod { set; get; }
        public int Class2ConMod { set; get; }
        public int Class1HPMod { set; get; }
        public int Class2HPMod { set; get; }
        public int BAB1 { set; get; }
        public int BAB2 { set; get; }
        private string[] class1Features = new string[21];
        private string[] class2Features = new string[21];//incase of multiclassing.
        public int[] MysticSpellsPerDay; //first is ignored [classlevel][number of spells per day per level]
        public int[] TechnoSpellsPerDay { get; set; } //first is ignored [number of spells per day per level]
        public int[] MysticSpellsknown { get; set; } //first is ignored [number of spells per day per level]
        public int[] TechnoSpellsknown { get; set; } //first is ignored [number of spells per day per level]
        private int[] mysticBonusSpells { get; set; } //first is ignored [number of spells per day per level]
        private int[] technoBonusSpells { get; set; } //first is ignored [number of spells per day per level]


        //Skills stuff
        private int[] skills = new int[22];//stores final skill level values
        private int[] skillranks = new int[22];//stores purchased skill ranks independant from the final values.
        public string[] skillNames = {"Acrobatics", "Athletics", "Bluff", "Computer",
            "Computers", "Culture", "Diplomacy", "Disguise", "Engineering", "Intimidate", "Life Science",
            "Medicine", "Mysticism", "Perception", "Physical Science", "Piloting", "Profession",
            "Sense Motive", "Sleight of Hand", "Stealth", "Survival", "" };
        private int class1SkillsperLevel;
        private int class2SkillsperLevel;
        //  1     2       3     4     5       6     7       8      9      10      11     12     13    14      15    16     17     18      19     20
        private bool[] isClassSkill = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        public int[] abilityUsedForSkill = { 2, 4, 0, 3, 3, 0, 0, 3, 0, 3, 3, 5, 5, 3, 2, -1, -1, 5, 2, 2, 5, -1 };//number is associated with its location in player attribute array
        public int[] unnamedSkillBounus = new int[22];
        public bool[] isTrainedOnlySkill = { false, false, false, true, true, false, false, true, false, true, true,
            true, false, true, false, true, true, false, true, false, false, false };


        //Abilites
        public List<string> abilityList = new List<string>();
        public List<string> FeatList = new List<string>();
        public int UnspentFeats { get; set;}
        public int UnspentComatFeats { get; set; }



        public int[] MysticBonusSpells
        {
            get
            {
                mysticBonusSpells = calcualteBonusSpells(toonAtributes[5]);
                return mysticBonusSpells;
            }
        }
        public int[] TechnoBonusSpells
        {
            get
            {
                technoBonusSpells = calcualteBonusSpells(toonAtributes[3]);
                return technoBonusSpells;
            }
        }


        private int[] calcualteBonusSpells(int score)//use to calculate bonus spells per level
        {
            int[] a = { -1, -1, -1, -1, -1, -1 };
            if (score < 12)
            {
                a = new int[] { 0, 0, 0, 0, 0, 0 };
            }
            else if (score < 14)
            {
                a = new int[] { 1, 0, 0, 0, 0, 0 };
            }
            else if (score < 16)
            {
                a = new int[] { 1, 1, 0, 0, 0, 0 };
            }
            else if (score < 18)
            {
                a = new int[] { 1, 1, 1, 0, 0, 0 };
            }
            else if (score < 20)
            {
                a = new int[] { 1, 1, 1, 1, 0, 0 };
            }
            else if (score < 22)
            {
                a = new int[] { 2, 1, 1, 1, 1, 0 };
            }
            else if (score < 24)
            {
                a = new int[] { 2, 2, 1, 1, 1, 1 };
            }
            else if (score < 26)
            {
                a = new int[] { 2, 2, 2, 1, 1, 1 };
            }
            else if (score < 28)
            {
                a = new int[] { 2, 2, 2, 2, 1, 1 };
            }
            else if (score < 30)
            {
                a = new int[] { 3, 2, 2, 2, 2, 1 };
            }
            else if (score < 32)
            {
                a = new int[] { 3, 3, 2, 2, 2, 2 };
            }//end if

            return a;
        } // end Calcualte bonus Spells


        public bool HeavyArmor
        {
            get
            {
                return heavyArmor;
            }
            set// if one class gives access to heavy the others can't deny access
            {
                if (heavyArmor == true)
                {
                    heavyArmor = true;
                }
                else
                {
                    heavyArmor = value;
                }
            }
        }

        public bool[] profiencies
        {
            get
            {
                return weaponProficiency;
            }
            set
            {
                bool[] a = value;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == true)
                    {
                        weaponProficiency[i] = true;
                    }
                }
            }//end set
        }// end profiencies

        public string[] GetClass1Features
        {
            get
            {
                return class1Features;
            }
        }

        public string[] SetClass1Features
        {
            set
            {
                class1Features = value;
            }
        }

        public string[] GetClass2Features
        {
            get
            {
                return class2Features;
            }
        }

        public string[] SetClass2Features
        {
            set
            {
                class2Features = value;
            }
        }

        public int Class1SkillsPerLevel
        {
            set
            {
                class1SkillsperLevel = value;
            }
        }

        public int Class2SkillsPerLevel
        {
            set
            {
                class2SkillsperLevel = value;
            }
        }

        public int skillPoints
        {
            get
            {
                return (Class2Level * (class2SkillsperLevel + abilityMods[3])) + (Class1Level * (class1SkillsperLevel + abilityMods[3]));
            }
        }


        public bool[] IsClassSkill
        {
            set
            {
                for (int i = 0; i < isClassSkill.Length; i++)
                {
                    if (!isClassSkill[i]) //should only change if the value is false.
                    {
                        isClassSkill[i] = value[i];
                    }
                    for (int j = 0; j < isThemeClassSkill.Length; j++)//if the class skill is also granted by theme player gets a plus 1
                    {
                        if(isThemeClassSkill[j] && isClassSkill[j])
                        {
                            unnamedSkillBounus[j] = 1;
                        }
                    }
                }
            }//end set
            get
            {
                return isClassSkill;
            }
        }//end IsClassSkill

        public int PlayerLevel
        {
            get
            {
                playerLevel = Class1Level + Class2Level;
                return playerLevel;
            }
        }

        public int PlayerBAB
        {
            get
            {
                if (MultiClass)
                {
                    playerBAB = BAB1 + BAB2;
                }
                else
                {
                    playerBAB = BAB1;
                }
                return playerBAB;
            }
        }//end PlayerBAB

        public int[] AbilityScores
        {
            get
            {
                for (int i = 0; i < abilityScoresFinal.Length; i++)
                {
                    toonAtributes[i] = (themeMods[i] + raceMods[i]);
                }
                return abilityScoresFinal;
            }
        }

        public int StaminaPoints
        {
            get
            {
                if((Class1Level * (Class1ConMod + abilityMods[1])) + (Class2Level * (Class2ConMod + abilityMods[1])) < 0)
                {
                    return 0;
                }
                else
                {
                    return (Class1Level * (Class1ConMod  + abilityMods[1])) + (Class2Level * (Class2ConMod + abilityMods[1]));
                }
            }
        }//end StaminaPoints

        public int HitPoints
        {
            get
            {
                return (Class1HPMod * Class1Level) + ( Class2HPMod * Class2Level) + RaceHPMod;
            }
        }

        public bool[] Is_TrainedOnlySkill
        {
            set
            {
                isTrainedOnlySkill = value;
            }
            get
            {
                return isTrainedOnlySkill;
            }
        }

        public int[] AbilityModForSkill
        {
            get
            {
                return abilityUsedForSkill;
            }
            set
            {
                abilityUsedForSkill = value;
            }
        }

        public int[] Skills
        {
            get
            {
                return skills;
            }
            set
            {
                skills = value;
            }
        }

        public int[] AbilityMods
        {
            get
            {
                return abilityMods;
            }
            set
            {
                abilityMods = value;
            }
        }

        public int[] ToonAtributes//set only, sets base attributes use once at start
        {
            set
            {
                toonAtributes = value;
            }
            get
            {
                return toonAtributes;
            }
        }

    }
}
