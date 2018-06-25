using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarFinderCharactorGenerator_V2._2
{
    class TechnomancerClass : PlayerClass
    {

        /// <summary>
        /// This class stores data for the Technomancer class and modifies the
        /// super class PlayerClass with relevent data specific to this player
        /// class.
        /// </summary>


        private const int HP = 5;
        private const int MECH_CON_MOD = 5;
        private new int ClassID = 6;
                                       //  1     2      3     4       5       6     7      8      9    10     11    12   13     14     15    16     17    18      19     20
        private bool[] isClassSkill = { false, false, false, true, false, false, false, true, false, true, false, true, false, true, true, true, false, true, false, false, false };//
        
        public int ConMod
        {
            get
            {
                return MECH_CON_MOD ;
            }
        }

        public bool HeavyArmor
        {
            get
            {
                heavyArmor = false;
                return heavyArmor;
            }
        }

        public int[][] SpellsPerDay//[class level][spell level] first address should be skipped as they are infinite
        {
            get
            {
                spellsPerDay[0] = new int[] { -1, -1, -1, -1, -1, -1, -1 };//skipped
                spellsPerDay[1] = new int[] { -1, 2, 0, 0, 0, 0, 0 };
                spellsPerDay[2] = new int[] { -1, 2, 0, 0, 0, 0, 0 };
                spellsPerDay[3] = new int[] { -1, 3, 0, 0, 0, 0, 0 };
                spellsPerDay[4] = new int[] { -1, 3, 2, 0, 0, 0, 0 };
                spellsPerDay[5] = new int[] { -1, 4, 2, 0, 0, 0, 0 };
                spellsPerDay[6] = new int[] { -1, 4, 3, 0, 0, 0, 0 };
                spellsPerDay[7] = new int[] { -1, 4, 3, 2, 0, 0, 0 };
                spellsPerDay[8] = new int[] { -1, 4, 4, 2, 0, 0, 0 };
                spellsPerDay[9] = new int[] { -1, 5, 4, 3, 0, 0, 0 };
                spellsPerDay[10] = new int[] { -1, 5, 4, 3, 2, 0, 0 };
                spellsPerDay[11] = new int[] { -1, 5, 4, 4, 2, 0, 0 };
                spellsPerDay[12] = new int[] { -1, 5, 5, 4, 3, 0, 0 };
                spellsPerDay[13] = new int[] { -1, 5, 5, 4, 3, 2, 0 };
                spellsPerDay[14] = new int[] { -1, 5, 5, 4, 4, 2, 0 };
                spellsPerDay[15] = new int[] { -1, 5, 5, 5, 4, 3, 0 };
                spellsPerDay[16] = new int[] { -1, 5, 5, 5, 4, 3, 2 };
                spellsPerDay[17] = new int[] { -1, 5, 5, 5, 4, 4, 2 };
                spellsPerDay[18] = new int[] { -1, 5, 5, 5, 5, 4, 3 };
                spellsPerDay[19] = new int[] { -1, 5, 5, 5, 5, 5, 4 };
                spellsPerDay[20] = new int[] { -1, 5, 5, 5, 5, 5, 5 };
                return spellsPerDay;
            }
        }// end SpellsPerDay

        public int[][] SpellsKnown//[class level] first address skipped [spell level]first address NOT skipped as you do get a number of zero level spells known
        {
            get
            {
                spellsknown[0] = new int[] { -1, -1, -1, -1, -1, -1, 0 };//skipped
                spellsknown[1] = new int[] { 4, 2, 0, 0, 0, 0, 0 };
                spellsknown[2] = new int[] { 5, 3, 0, 0, 0, 0, 0 };
                spellsknown[3] = new int[] { 6, 4, 0, 0, 0, 0, 0 };
                spellsknown[4] = new int[] { 6, 4, 2, 0, 0, 0, 0 };
                spellsknown[5] = new int[] { 6, 4, 3, 0, 0, 0, 0 };
                spellsknown[6] = new int[] { 6, 4, 4, 0, 0, 0, 0 };
                spellsknown[7] = new int[] { 6, 5, 4, 2, 0, 0, 0 };
                spellsknown[8] = new int[] { 6, 5, 4, 3, 0, 0, 0 };
                spellsknown[9] = new int[] { 6, 5, 4, 4, 0, 0, 0 };
                spellsknown[10] = new int[] { 6, 5, 5, 4, 2, 0, 0 };
                spellsknown[11] = new int[] { 6, 6, 5, 4, 3, 0, 0 };
                spellsknown[12] = new int[] { 6, 6, 5, 4, 4, 0, 0 };
                spellsknown[13] = new int[] { 6, 6, 5, 5, 4, 2, 0 };
                spellsknown[14] = new int[] { 6, 6, 6, 5, 4, 3, 0 };
                spellsknown[15] = new int[] { 6, 6, 6, 5, 4, 4, 0 };
                spellsknown[16] = new int[] { 6, 6, 6, 5, 5, 4, 2 };
                spellsknown[17] = new int[] { 6, 6, 6, 6, 5, 4, 3 };
                spellsknown[18] = new int[] { 6, 6, 6, 6, 5, 4, 4 };
                spellsknown[19] = new int[] { 6, 6, 6, 6, 5, 5, 4 };
                spellsknown[20] = new int[] { 6, 6, 6, 6, 6, 5, 5 };
                return spellsknown;
            }
        }// end SpellsKnown

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

        public bool[] areProfiencies//basic melee[0], advanced melee[1], small arms[2], long arms[3], sniper[4], heavy[5], granades[6]
        {
            get
            {
                weaponProficiency[0] = true;//Basic Melee
                weaponProficiency[2] = true;//small arms
                return weaponProficiency;
            }
        }

    }
}
