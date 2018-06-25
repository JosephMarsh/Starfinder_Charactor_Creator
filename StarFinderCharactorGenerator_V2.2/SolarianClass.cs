using System;


namespace StarFinderCharactorGenerator_V2._2
{
    class SolarianClass : PlayerClass
    {
        /// <summary>
        /// This class stores data for the Solarian class and modifies the
        /// super class PlayerClass with relevent data specific to this player
        /// class.
        /// </summary>

        private new int ClassID = 4;
        private const int HP = 7;
        private const int CON_MOD = 7;
        private const int SKILLS_PER_LV = 4;
        public int[] SidrealInfluences = { 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 4, 4, 4, 4, 4, 4, 4, 4, 6, 6 };//first possition is skipped
        public int[] StellarRevelations = { 0, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12 };//first possition skipped, - 2 as the first two are pickied for you.
        private string[] solarManifestation;


                                                //1     2       3     4     5     6      7     8       9    10     11    12     13    14    15   16      17     18     19     20
        public readonly bool[] isClassSkill = { true, true, false, false, false, true, false, false, true, false, false, true, true, true, false, true, true, false, true, false, };
        public readonly string[] ClassSkills = { "Acrobatics", "Athletics", "Diplomacy", "Intimidate", "Mysticism",
            "Perception", "Physical Science", "Profession", "Sense Motive", "Stealth" };

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

        public string[] ClassFeatures
        {
            get
            {
                classFeatures[0] = new string[] { "error!" };//not used
                classFeatures[1] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[1]};
                classFeatures[2] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[1],stelRev(2)};
                classFeatures[3] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[3], stelRev(3), sidInf(3), "Weapon Specialization" };
                classFeatures[4] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[4], stelRev(4), sidInf(4), "Weapon Specialization" };
                classFeatures[5] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[5], stelRev(5), sidInf(5), "Weapon Specialization" };
                classFeatures[6] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[6], stelRev(6), sidInf(6), "Weapon Specialization" };
                classFeatures[7] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[7], stelRev(7), sidInf(7), "Weapon Specialization", "Flashing Strikes" };
                classFeatures[8] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[8], stelRev(8), sidInf(8), "Weapon Specialization", "Flashing Strikes" };
                classFeatures[9] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[9], stelRev(9), sidInf(9), "Weapon Specialization", "Flashing Strikes","Zenith Revelations" };
                classFeatures[10] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[10], stelRev(10), sidInf(10), "Weapon Specialization", "Flashing Strikes","Zenith Revelations" };
                classFeatures[11] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[11], stelRev(11), sidInf(11), "Weapon Specialization", "Flashing Strikes","Zenith Revelations" };
                classFeatures[12] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[12], stelRev(12), sidInf(12), "Weapon Specialization", "Flashing Strikes","Zenith Revelations","Solarian's Onslaught" };
                classFeatures[13] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[13], stelRev(13), sidInf(13), "Weapon Specialization", "Flashing Strikes","Zenith Revelations","Solarian's Onslaught" };
                classFeatures[14] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[14], stelRev(14), sidInf(14), "Weapon Specialization", "Flashing Strikes","Zenith Revelations","Solarian's Onslaught" };
                classFeatures[15] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[15], stelRev(15), sidInf(15), "Weapon Specialization", "Flashing Strikes","Zenith Revelations","Solarian's Onslaught" };
                classFeatures[16] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[16], stelRev(16), sidInf(16), "Weapon Specialization", "Flashing Strikes","Zenith Revelations","Solarian's Onslaught" };
                classFeatures[17] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[17], stelRev(17), sidInf(17), "Weapon Specialization", "Flashing Strikes","Zenith Revelations X 2","Solarian's Onslaught" };
                classFeatures[18] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[18], stelRev(18), sidInf(18), "Weapon Specialization", "Flashing Strikes","Zenith Revelations X 2","Solarian's Onslaught" };
                classFeatures[19] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[19], stelRev(19), sidInf(19), "Weapon Specialization", "Flashing Strikes","Zenith Revelations X 2","Solarian's Onslaught" };
                classFeatures[20] = new string[] { "Skill Adept", "Solar Manifestation","Stellar Mode","Stellar Revelation(Black Hole, Supernova)",
                SolMan[20], stelRev(20), sidInf(20), "Weapon Specialization", "Flashing Strikes","Zenith Revelations X 2","Solarian's Onslaught",
                "Stellar Paragon"};


                return classFeatures[ClassLevel];
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
        public string[] SolMan
        {
            get
            {
                solarManifestation[1] = "+1 AC, Solar Weapon: 1d6";
                solarManifestation[2] = "+1 AC, Solar Weapon: 1d6";
                solarManifestation[3] = "+1 AC, Solar Weapon: 1d6";
                solarManifestation[4] = "+1 AC, Solar Weapon: 1d6";
                solarManifestation[5] = "+1 AC, Resisance 5, Solar Weapon: 1d6";
                solarManifestation[6] = "+1 AC, Resisance 5, Solar Weapon: 2d6";
                solarManifestation[7] = "+1 AC, Resisance 5, Solar Weapon: 2d6";
                solarManifestation[8] = "+1 AC, Resisance 5, Solar Weapon: 2d6";
                solarManifestation[9] = "+1 AC, Resisance 5, Solar Weapon: 3d6";
                solarManifestation[10] = "+2 AC, Resisance 10, Solar Weapon: 3d6";
                solarManifestation[11] = "+2 AC, Resisance 10, Solar Weapon: 3d6";
                solarManifestation[12] = "+2 AC, Resisance 10, Solar Weapon: 4d6";
                solarManifestation[13] = "+2 AC, Resisance 10, Solar Weapon: 5d6";
                solarManifestation[14] = "+2 AC, Resisance 10, Solar Weapon: 6d6";
                solarManifestation[15] = "+2 AC, Resisance 15, Solar Weapon: 7d6";
                solarManifestation[16] = "+2 AC, Resisance 15, Solar Weapon: 8d6"; 
                solarManifestation[17] = "+2 AC, Resisance 15, Solar Weapon: 9d6";
                solarManifestation[18] = "+2 AC, Resisance 15, Solar Weapon: 10d6";
                solarManifestation[19] = "+2 AC, Resisance 15, Solar Weapon: 11d6";
                solarManifestation[20] = "+2 AC, Resisance 20, Solar Weapon: 12d6";
                return solarManifestation;
            }
        }

        private string stelRev(int a)
        {
            string b;
            b = "Stellar Revelation x " + (StellarRevelations[a]-2).ToString();
            return b;
        }
        private string sidInf(int a)
        {
            string b;
            b = "Sidreal Influence x " + SidrealInfluences[a].ToString();
            return b;
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
        public bool[] areProfiencies//basic melee[0], advanced melee[1], small arms[2], long arms[3], sniper[4], heavy[5], granades[6]
        {
            get
            {
                weaponProficiency[0] = true;//Basic Melee
                weaponProficiency[1] = true;//Advanced Melee
                weaponProficiency[2] = true;//Small Arms
                return weaponProficiency;
            }
        }
        public int[] FortSaves
        {
            get
            {
                fortSaves = strongSaves;
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
    }
}
