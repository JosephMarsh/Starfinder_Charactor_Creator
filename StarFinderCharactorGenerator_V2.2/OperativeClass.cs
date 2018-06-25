using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarFinderCharactorGenerator_V2._2
{
    class OperativeClass : PlayerClass
    {
        /// <summary>
        /// This class stores data for the Operative class and modifies the
        /// super class PlayerClass with relevent data specific to this player
        /// class.
        /// </summary>

        private new int ClassID = 3;
        private const int HP = 6;
        private const int CON_MOD = 6;
        private const int SKILLS_PER_LV = 8;

        public bool[] isClassSkill = {  };

        private int[] opEdge = { 0, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6 };//first skipped, bonus type is (insight)
        private int[] opExpl = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10 };//first skipped


        public string[][] ClassFeatures //[level][feature]
        {
            get
            {
                classFeatures[0] = new string[] { "error!"};//not used
                classFeatures[1] = new string[] { "Op. edge +" + opEdge[1].ToString(), "Specialization", trickAttack(1) };
                classFeatures[2] = new string[] { "Op. edge +" + opEdge[2].ToString(), "Specialization", trickAttack(2),
                    "Evasion", "Op. Exploit x" + opExpl[2].ToString() };
                classFeatures[3] = new string[] { "Op. edge +" + opEdge[3].ToString(), "Specialization", trickAttack(3),
                    "Evasion", "Op. Exploit x" + opExpl[3].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization" };
                classFeatures[4] = new string[] { "Op. edge +" + opEdge[4].ToString(), "Specialization", trickAttack(4),
                    "Evasion", "Op. Exploit x" + opExpl[4].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization","Dibilitating Trick" };
                classFeatures[5] = new string[] { "Op. edge +" + opEdge[5].ToString(), "Specialization", trickAttack(5),
                    "Evasion", "Op. Exploit x" + opExpl[5].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization", "Dibilitating Trick", "Specialization Exploit" };
                classFeatures[6] = new string[] { "Op. edge +" + opEdge[6].ToString(), "Specialization", trickAttack(6),
                    "Evasion", "Op. Exploit x" + opExpl[6].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization", "Dibilitating Trick", "Specialization Exploit" };
                classFeatures[7] = new string[] { "Op. edge +" + opEdge[7].ToString(), "Specialization", trickAttack(7),
                    "Evasion", "Op. Exploit x" + opExpl[7].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization", "Dibilitating Trick", "Specialization Exploit", "Spec. Skill Mastery",
                    "Uncanny Agility" };
                classFeatures[8] = new string[] { "Op. edge +" + opEdge[8].ToString(), "Specialization", trickAttack(8),
                    "Evasion", "Op. Exploit x" + opExpl[8].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization", "Dibilitating Trick", "Specialization Exploit", "Spec. Skill Mastery",
                    "Uncanny Agility", "Triple Attack" };
                classFeatures[9] = new string[] { "Op. edge +" + opEdge[9].ToString(), "Specialization", trickAttack(9),
                    "Evasion", "Op. Exploit x" + opExpl[9].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization", "Dibilitating Trick", "Specialization Exploit", "Spec. Skill Mastery",
                    "Uncanny Agility", "Triple Attack" };
                classFeatures[10] = new string[] { "Op. edge +" + opEdge[10].ToString(), "Specialization", trickAttack(10),
                    "Evasion", "Op. Exploit x" + opExpl[10].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization", "Dibilitating Trick", "Specialization Exploit", "Spec. Skill Mastery",
                    "Uncanny Agility", "Triple Attack" };
                classFeatures[11] = new string[] { "Op. edge +" + opEdge[11].ToString(), "Specialization", trickAttack(11),
                    "Evasion", "Op. Exploit x" + opExpl[11].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization", "Dibilitating Trick", "Specialization Exploit", "Spec. Skill Mastery",
                    "Uncanny Agility", "Triple Attack", "Specialization Power" };
                classFeatures[12] = new string[] { "Op. edge +" + opEdge[12].ToString(), "Specialization", trickAttack(12),
                    "Evasion", "Op. Exploit x" + opExpl[12].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization", "Dibilitating Trick", "Specialization Exploit", "Spec. Skill Mastery",
                    "Uncanny Agility", "Triple Attack", "Specialization Power" };
                classFeatures[13] = new string[] { "Op. edge +" + opEdge[13].ToString(), "Specialization", trickAttack(13),
                    "Evasion", "Op. Exploit x" + opExpl[13].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization", "Dibilitating Trick", "Specialization Exploit", "Spec. Skill Mastery",
                    "Uncanny Agility", "Triple Attack", "Specialization Power", "Quad Attack" };
                classFeatures[14] = new string[] {"Op. edge +" + opEdge[14].ToString(), "Specialization", trickAttack(14),
                    "Evasion", "Op. Exploit x" + opExpl[14].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization", "Dibilitating Trick", "Specialization Exploit", "Spec. Skill Mastery",
                    "Uncanny Agility", "Triple Attack", "Specialization Power", "Quad Attack"  };
                classFeatures[15] = new string[] {"Op. edge +" + opEdge[15].ToString(), "Specialization", trickAttack(15),
                    "Evasion", "Op. Exploit x" + opExpl[15].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization", "Dibilitating Trick", "Specialization Exploit", "Spec. Skill Mastery",
                    "Uncanny Agility", "Triple Attack", "Specialization Power", "Quad Attack"  };
                classFeatures[16] = new string[] {"Op. edge +" + opEdge[16].ToString(), "Specialization", trickAttack(16),
                    "Evasion", "Op. Exploit x" + opExpl[16].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization", "Dibilitating Trick", "Specialization Exploit", "Spec. Skill Mastery",
                    "Uncanny Agility", "Triple Attack", "Specialization Power", "Quad Attack"  };
                classFeatures[17] = new string[] {"Op. edge +" + opEdge[17].ToString(), "Specialization", trickAttack(17),
                    "Evasion", "Op. Exploit x" + opExpl[17].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization", "Dibilitating Trick", "Specialization Exploit", "Spec. Skill Mastery",
                    "Uncanny Agility", "Triple Attack", "Specialization Power", "Quad Attack", "Double Dibilitation" };
                classFeatures[18] = new string[] {"Op. edge +" + opEdge[18].ToString(), "Specialization", trickAttack(18),
                    "Evasion", "Op. Exploit x" + opExpl[18].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization", "Dibilitating Trick", "Specialization Exploit", "Spec. Skill Mastery",
                    "Uncanny Agility", "Triple Attack", "Specialization Power", "Quad Attack", "Double Dibilitation" };
                classFeatures[19] = new string[] {"Op. edge +" + opEdge[19].ToString(), "Specialization", trickAttack(19),
                    "Evasion", "Op. Exploit x" + opExpl[19].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization", "Dibilitating Trick", "Specialization Exploit", "Spec. Skill Mastery",
                    "Uncanny Agility", "Triple Attack", "Specialization Power", "Quad Attack", "Double Dibilitation" };
                classFeatures[20] = new string[] {"Op. edge +" + opEdge[20].ToString(), "Specialization", trickAttack(20),
                    "Evasion", "Op. Exploit x" + opExpl[20].ToString(), "Quick Movement +" + BaseLandSpeedMod.ToString(),
                    "Weap. Specialization", "Dibilitating Trick", "Specialization Exploit", "Spec. Skill Mastery",
                    "Uncanny Agility", "Triple Attack", "Specialization Power", "Quad Attack", "Double Dibilitation",
                    "Supreme Operative" };
                return classFeatures;
            }
        }

        public int[] OperativesEdgeSkillBonus
        {
            get
            {
                return opEdge;
            }
        }


        public int SkillsPerLevel
        {
            get
            {
                skillsPerLevel = SKILLS_PER_LV;
                return SKILLS_PER_LV;
            }
        }

        public int ConMod
        {
            get
            {
                return CON_MOD;
            }
        }

        public int HPMod//use this one first to set the class HP mod. :)
        {
            get
            {
                ClassHPMod = HP;
                return ClassHPMod;
            }
        }
        public int BAB
        {
            get
            {
                return ClassBABs[ClassID][ClassLevel];
            }
        }
        public bool[] areProfiencies//basic melee[0], advanced melee[1], small arms[2], long arms[3], sniper[4], heavy[5], granades[6]
        {
            get
            {
                weaponProficiency[0] = true;//Basic Melee
                weaponProficiency[2] = true;//Small Arms
                weaponProficiency[4] = true;//Sniper Weapons
                return weaponProficiency;
            }
        }
        public int[] FortSaves
        {
            get
            {
                fortSaves = weakSaves;
                return fortSaves;
            }
        }

        public int[] RefSaves
        {
            get
            {
                refSaves = strongSaves;
                return refSaves;
            }
        }

        public int[] WillSaves
        {
            get
            {
                willSaves = strongSaves;
                return willSaves;
            }
        }


        public int[][] Saves
        {
            get
            {
                savingThrows[0] = FortSaves;
                savingThrows[1] = RefSaves;
                savingThrows[2] = WillSaves;
                return savingThrows;
            }
        }
        public int BaseLandSpeedMod
        {
            get
            {
                if (ClassLevel < 3)
                {
                    landSpeedMod = 0;
                }
                else if (ClassLevel < 9)
                {
                    landSpeedMod = 10;
                }
                else if (ClassLevel < 15)
                {
                    landSpeedMod = 20;
                }
                else if (ClassLevel < 21)
                {
                    landSpeedMod = 30;
                }
                else
                {
                    landSpeedMod = -1;//something went wrong...
                }

                return landSpeedMod; 
            }
        }
        public string trickAttack(int level)
        {
            string attack;
            if (level < 3)
            {
                attack = "Trick Attack (1d4)";
            }
            else if (level < 5)
            {
                attack = "Trick Attack (1d8)";
            }
            else if (level < 7)
            {
                attack = "Trick Attack (3d8)";
            }
            else if (level < 9)
            {
                attack = "Trick Attack (4d8)";
            }
            else if (level < 11)
            {
                attack = "Trick Attack (5d8)";
            }
            else if (level < 13)
            {
                attack = "Trick Attack (6d8)";
            }
            else if (level < 15)
            {
                attack = "Trick Attack (7d8)";
            }
            else if (level < 17)
            {
                attack = "Trick Attack (8d8)";
            }
            else if (level < 19)
            {
                attack = "Trick Attack (9d8)";
            }
            else if (level <= 20)
            {
                attack = "Trick Attack (10d8)";
            }
            else
            {
                attack = "Error out of bounds";
            }//end if
            return attack;
        }//end Expertise
    }
}
