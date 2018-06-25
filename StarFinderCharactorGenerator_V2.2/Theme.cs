using System;
/// <summary>
/// This is a reference class that stores data related to Themes
/// </summary>

namespace StarFinderCharactorGenerator_V2._2
{
    public class Theme

        
    {
        private string[][] benifits = new string[10][]; 
        public int[][] themes = new int[10][];
        //ability buffs based on selected theme   {cha,con,dex,int,str,wis}
        public readonly int[] acePilotTheme =     { 0, 0, 1, 0, 0, 0 };
        public readonly int[] bountyHunterTheme = { 0, 1, 0, 0, 0, 0 };
        public readonly int[] iconTheme =         { 1, 0, 0, 0, 0, 0 };
        public readonly int[] mercenaryTheme =    { 0, 0, 0, 0, 1, 0 };
        public readonly int[] outLawTheme =       { 0, 0, 1, 0, 0, 0 };
        public readonly int[] priestTheme =       { 0, 0, 0, 0, 0, 1 };
        public readonly int[] scholarTheme =      { 0, 0, 0, 1, 0, 0 };
        public readonly int[] spacefarerTheme =   { 0, 1, 0, 0, 0, 0 };
        public readonly int[] xenoSeekerTheme =   { 1, 0, 0, 0, 0, 0 };
        public readonly int[] themeless =         { 0, 0, 0, 0, 0, 0 }; //bonus chosen by user

        public string[] ThemeNames = { "AcePilot", "bountyHunter", "Icon",
            "Mercenary", "Outlaw", "Priest", "Scholar", "Spacefarer", "Xenoseeker", "Themless" }; //0-9

        //benifits gained at 1st, 6th 12th and 18th level.
        public readonly string [] aceBenefits = { "Theme Knowledge (Ace)","Lone Wolf", "Need for Speed", "Master Pilot" };
        public readonly string[] bountyHunterBenefits = { "Theme Knowledge (Bounty Hunter)", "Swift Hunter", "Relentless", "Master Hunter" };
        public readonly string[] iconBenefits = { "Theme Knowledge (Icon)", "Celeberity", "Megacelebrity", "Master Icon" };
        public readonly string[] MercBenefits = { "Theme Knowledge (Merc)", "Grunt", "Squad Leader", "Commander" };
        public readonly string[] outlawBenefits = { "Theme Knowledge (Outlaw)", "Legal Corruption", "Black Market Connection", "Master Outlaw" };
        public readonly string[] PriestBenefits = { "Theme Knowledge (Priest)", "Mantle of the Clergy", "Divine Boon", "True Communion" };
        public readonly string[] scolarBenefits = { "Theme Knowledge (Scholar)", "Tip of the Tongue", "Research Maven", "Master Scholar" };
        public readonly string[] SpacerBenefits = { "Theme Knowledge (Spacer)", "Eager Dabbler", "Jack of all Trades", "Master Explorer" };
        public readonly string[] xenoBenefits = { "Theme Knowledge (Xeno)", "Quick Pidgin", "First Contact", "Brilliant Discovery" };
        public readonly string[] themlessBenefits = { "General Knowledge (Themeless)", "Certainty", "Extensive Studies", "Steely Determination" };

        public string[][] ThemeBenefits
        {
            get
            {
                benifits[0] = aceBenefits;
                benifits[1] = bountyHunterBenefits;
                benifits[2] = iconBenefits;
                benifits[3] = MercBenefits;
                benifits[4] = outlawBenefits;
                benifits[5] = PriestBenefits;
                benifits[6] = scolarBenefits;
                benifits[7] = SpacerBenefits;
                benifits[8] = xenoBenefits;
                benifits[9] = themlessBenefits;
                return benifits;
            }
        }//ThemeBenefits

        public int[][] GetThemes
        {
            get
            {
                themes[0] = acePilotTheme;
                themes[1] = bountyHunterTheme;
                themes[2] = iconTheme;
                themes[3] = mercenaryTheme;
                themes[4] = outLawTheme;
                themes[5] = priestTheme;
                themes[6] = scholarTheme;
                themes[7] = spacefarerTheme;
                themes[8] = xenoSeekerTheme;
                themes[9] = themeless;
                return themes;
            }//end get
        }// end get Themes;

        public int[] theme(int themeId)
        {
            themes[0] = acePilotTheme;
            themes[1] = bountyHunterTheme;
            themes[2] = iconTheme;
            themes[3] = mercenaryTheme;
            themes[4] = outLawTheme;
            themes[5] = priestTheme;
            themes[6] = scholarTheme;
            themes[7] = spacefarerTheme;
            themes[8] = xenoSeekerTheme;
            themes[9] = themeless;
            return themes[themeId];
        }

        public Theme()
        {
        }
    }
}
