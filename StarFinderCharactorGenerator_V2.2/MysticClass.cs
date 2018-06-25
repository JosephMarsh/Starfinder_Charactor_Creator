using System;

namespace StarFinderCharactorGenerator_V2._2
{
    public class MysticClass : PlayerClass
    {
        /// <summary>
        /// This class stores data for the Mystic class and modifies the
        /// super class PlayerClass with relevent data specific to this player
        /// class.
        /// </summary>

        private new int ClassID = 2;// set Envoy ID number
        private const int CON_MOD = 6;
        private const int HP = 6;

        //------------------------------1      2     3     4     5       6     7       8      9    10      11     12     13    14      15    16     17     18      19     20
        public bool[] isClassSkill = { false, false, true, false, true,  true, true,  false,  true,  true,   true,  true, true, false, false, true, true, false, false, true, false };

        public int[] getsConnectionPower = { 0, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7 };//[class level] first address skipped 
        public int[] getsConnectionSpell = { 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 6, 6 };//[class level] first address skipped
        public int[] channelSkillMod = { 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7 };//[class level] first address skipped

        public int[][] SpellsPerDay//[class level][spell level] firs address should be skipped as they are infinite
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
        }//end SpellsPerDay

        public int[][] SpellsKnown//[class level] first address skipped [spell level]first address NOT skipped as you do get a number of zero level spells known
        {
            get
            {
                spellsknown[0] = new int[] { -1, -1, -1, -1, -1, -1, -1 };//skipped
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
        }//end SpellsKnown

        public string[][] ClassFeatures
        {
            get
            {
                classFeatures[0] = new string[] { "error: Class level = 0" };//not used
                ClassFeatures[1] = new string[] { "Connection", "Healing Touch", "Connection Power x " + 
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString()};
                ClassFeatures[2] = new string[] {"Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString()};
                ClassFeatures[3] = new string[] {"Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization"};
                ClassFeatures[4] = new string[] {"Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization"};
                ClassFeatures[5] = new string[] { "Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization"};
                ClassFeatures[6] = new string[] {"Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization" };
                ClassFeatures[7] = new string[] {"Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization" };
                ClassFeatures[8] = new string[] {"Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization" };
                ClassFeatures[9] = new string[] {"Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization" };
                ClassFeatures[10] = new string[] {"Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization",
                    "Telepathic Bond" };
                ClassFeatures[11] = new string[] {"Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization",
                    "Telepathic Bond"};
                ClassFeatures[12] = new string[] { "Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization",
                    "Telepathic Bond" };
                ClassFeatures[13] = new string[] { "Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization",
                    "Telepathic Bond" };
                ClassFeatures[14] = new string[] { "Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization",
                    "Telepathic Bond" };
                ClassFeatures[15] = new string[] { "Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization",
                    "Telepathic Bond" };
                ClassFeatures[16] = new string[] { "Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization",
                    "Telepathic Bond" };
                ClassFeatures[17] = new string[] { "Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization",
                    "Telepathic Bond" };
                ClassFeatures[18] = new string[] { "Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization",
                    "Telepathic Bond" };
                ClassFeatures[19] = new string[] { "Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization",
                    "Telepathic Bond", "Transcendence" };
                ClassFeatures[20] = new string[] { "Connection", "Healing Touch", "Connection Power x " +
                    getsConnectionPower[ClassLevel].ToString(),"Connection spell x " + getsConnectionSpell[ClassLevel].ToString(),
                    "Mind Link", "Channel Skill + " + channelSkillMod[ClassLevel].ToString(), "Weapon Specialization",
                    "Telepathic Bond", "Transcendence", "Enlightenment" };
                return classFeatures;
            }
        }//end ClassFeatures

        int SkillsPerLevel
        {
            get
            {
                skillsPerLevel = 6;
                return skillsPerLevel;
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
       
        public int HPMod
        {
            get
            {
                return HP;
            }
        }

        public string ClassName
        {
            get
            {
                return classNames[ClassID];
            }
        }

        public int ConMod
        {
            get
            {
                return CON_MOD;
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
                refSaves = weakSaves;
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

    }//end MysticClass
}//end namespace
