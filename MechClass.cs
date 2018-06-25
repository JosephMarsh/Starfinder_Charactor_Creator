using System;

namespace StarFinderCharactorGenerator_V2._2
{
    public class MechanicClass : PlayerClass
    {
        public const int HP = 6;
        private const int MECH_CON_MOD = 6;
        private new int ClassID = 1;// set Mechanic ID number
        public readonly int[] getsMechanicTrick = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10 };//first address is ignored
        private readonly string mechTrick = "Mechanic Trick";


        public int ConMod
        {
            get
            {
                return MECH_CON_MOD * ClassLevel;
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
                refSaves = strongSaves;
                return refSaves;
            }
        }

        public int[] WillSaves
        {
            get
            {
                willSaves = weakSaves;
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


        public string[][] ClassFeatures
        {
            get
            {
                classFeatures[1] = new string[] { "Artificial Intelligence", bypass(ClassLevel), "Custom Rig" };
                classFeatures[2] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig",
                        mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString()};
                classFeatures[3] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig",
                        mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization"};
                classFeatures[4] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig",
                        mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization"};
                classFeatures[5] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig",
                        mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization","Remote Hack"};
                classFeatures[6] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig",
                        mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization","Remote Hack"};
                classFeatures[7] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig","Expert Rig",
                        mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization","Remote Hack",
                        miracleWorker(ClassLevel)};
                classFeatures[8] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig","Expert Rig",
                        mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization","Remote Hack",
                        miracleWorker(ClassLevel)};
                classFeatures[9] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig","Expert Rig",
                        mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization","Remote Hack",
                        miracleWorker(ClassLevel),"Override"};
                classFeatures[10] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig","Expert Rig",
                        mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization","Remote Hack",
                        miracleWorker(ClassLevel),"Override"};
                classFeatures[11] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig","Expert Rig",
                        mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization","Remote Hack",
                        miracleWorker(ClassLevel),"Override","Coodinated Assault +1"};
                classFeatures[12] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig","Expert Rig",
                        mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization","Remote Hack",
                        miracleWorker(ClassLevel),"Override","Coodinated Assault +1"};
                classFeatures[13] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig","Expert Rig", "Advanced Rig",
                        mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization","Remote Hack",
                        miracleWorker(ClassLevel),"Override","Coodinated Assault +1"};
                classFeatures[14] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig","Expert Rig", "Advanced Rig",
                        mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization","Remote Hack",
                        miracleWorker(ClassLevel),"Override","Coodinated Assault +1"};
                classFeatures[15] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig","Expert Rig", "Advanced Rig",
                        mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization","Remote Hack",
                        miracleWorker(ClassLevel),"Override","Coodinated Assault +1"};
                classFeatures[16] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig","Expert Rig", "Advanced Rig",
                        mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization","Remote Hack",
                        miracleWorker(ClassLevel),"Override","Coodinated Assault +1"};
                classFeatures[17] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig","Expert Rig", "Advanced Rig",
                        mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization","Remote Hack",
                        miracleWorker(ClassLevel),"Override","Coodinated Assault +2","Control Net"};
                classFeatures[18] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig","Expert Rig", "Advanced Rig",
                        mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization","Remote Hack",
                        miracleWorker(ClassLevel),"Override","Coodinated Assault +2","Control Net"};
                classFeatures[19] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig","Expert Rig", "Advanced Rig",
                        "Superior Rig", mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization",
                        "Remote Hack",miracleWorker(ClassLevel),"Override","Coodinated Assault +2","Control Net","Ghost in the Machine"};
                classFeatures[20] = new string[] { "Artificial Intelligence",bypass(ClassLevel),"Custom Rig","Expert Rig", "Advanced Rig",
                        "Superior Rig", mechTrick + " X" + getsMechanicTrick [ClassLevel].ToString(), "Overload", "Weapon Specialization",
                        "Remote Hack",miracleWorker(ClassLevel),"Override","Coodinated Assault +2","Control Net","Ghost in the Machine",
                        "Tech Master" };
                return classFeatures;
            }
        }// end ClassFeatures


        public string bypass(int level)
        {
            string exp;
            if (level < 5)
            {
                exp = "Bypass +1";
            }
            else if (level < 9)
            {
                exp = "Bypass +2";
            }
            else if (level < 13)
            {
                exp = "Bypass +3";
            }
            else if (level < 17)
            {
                exp = "Bypass +4";
            }
            else if (level < 20)
            {
                exp = "Bypass +5";
            }
            else if (level == 20)
            {
                exp = "Bypass +6";
            }
            else
            {
                exp = "Error";
            }//end if
            return exp;
        }//end Expertise

        public string miracleWorker(int level)
        {
            string exp;
            if (level < 11 && level > 6)
            {
                exp = "Miracle Worker 1/day";
            }
            else if (level < 15)
            {
                exp = "Miracle Worker 2/day";
            }
            else if (level < 19)
            {
                exp = "Miracle Worker 3/day";
            }
            else if (level == 19 || level == 20)
            {
                exp = "Miracle Worker 4/day";
            }
            else
            {
                exp = "Error";
            }//end if
            return exp;
        }//end MiracleWorker

        public int BAB
        {
            get
            {
                return bassAttackBonusByClassIDByLevels[ClassID][ClassLevel];
            }
        }




    }//end  Class
}//End Namespace
