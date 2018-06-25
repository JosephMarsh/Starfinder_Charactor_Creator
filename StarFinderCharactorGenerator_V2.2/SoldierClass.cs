using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarFinderCharactorGenerator_V2._2
{
    class SoldierClass : PlayerClass
    {
        /// <summary>
        /// This class stores data for the Soldier class and modifies the
        /// super class PlayerClass with relevent data specific to this player
        /// class.
        /// </summary>

        private new int ClassID = 5;
        private const int HP = 7;
        private const int CON_MOD = 7;
        private const int SKILLS_PER_LV = 4; 

        public readonly int[] getsCombatFeat = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10 };//first address skipped
        public readonly int[] getsGearBoost = { 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5 };//first address skipped
        //--------------------------------------  1     2       3     4     5       6     7     8    9      10     11     12     13    14     15    16     17     18    19     20
        public readonly bool[] isClassSkill = { true, true, false, false, false, false, false, true, true, false, true, false, false, false, true, true, false, false, false, true, false };// last address spare
        public readonly string[] ClassSkills = { "Acrobatics", "Athletics", "Engineering", "Intimidate", "Medicine", "Piloting", "Profession", "Survival" };
        


        public int ConMod
        {
            get
            {
                return CON_MOD;
            }
        }

        int SkillsPerLevel
        {
            get
            {
                skillsPerLevel = SKILLS_PER_LV; // 4
                return SKILLS_PER_LV;
            }
        }

        public bool HeavyArmor
        {
            get
            {
                heavyArmor = true;
                return heavyArmor;
            }
        }

        public bool[] areProfiencies//basic melee[0], advanced melee[1], small arms[2], long arms[3], sniper[4], heavy[5], granades[6]
        {
            get
            {
                for (int i = 0; i < weaponProficiency.Length; i++)
                {
                    weaponProficiency[i] = true;//Soldiers get all the toys
                }
                return weaponProficiency;
            }
        }

        public int HPMod
        {
            get
            {
                return HP;
            }
        }

        public int BAB
        {
            get
            {
                return ClassBABs[ClassID][ClassLevel];
            }
        }
    }// end SoldierClass
}//end name space
