using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarFinderCharactorGenerator_V2._2
{
    class Feat
    {
        public string Name { set; get; }
        public bool Is_Combat { set; get; }
        public string[] Prerequisites { set; get; }
        public string Benifits { set; get; }
        public string Normal { set; get; }
        public string Special { set; get; }

        public Feat(string Name, bool Is_Combat, string[] Prerequisites,string Benifits, string Normal, string Special)
        {
            this.Name = Name;
            this.Is_Combat = Is_Combat;
            this.Prerequisites = Prerequisites;
            this.Benifits = Benifits;
            this.Normal = Normal;
            this.Special = Special;
        }

        public Feat(string Name, string[] Prerequisites, string Benifits, string Normal, string Special)
        {
            this.Name = Name;
            Is_Combat = false;
            this.Prerequisites = Prerequisites;
            this.Benifits = Benifits;
            this.Normal = Normal;
            this.Special = Special;
        }
        public Feat(string Name, string[] Prerequisites, string Benifits, string Normal)
        {
            this.Name = Name;
            Is_Combat = false;
            this.Prerequisites = Prerequisites;
            this.Benifits = Benifits;
            this.Normal = Normal;
            Special= "none";
        }
        public Feat(string Name, bool Is_Combat, string[] Prerequisites, string Benifits, string Normal)
        {
            this.Name = Name;
            this.Is_Combat = Is_Combat;
            this.Prerequisites = Prerequisites;
            this.Benifits = Benifits;
            this.Normal = Normal;
            Special = "none";
        }

        public Feat(string Name, int i)
        {
            this.Name = Name;
            Is_Combat = false;
            Prerequisites = new string[i];
            Benifits = "none";
            Normal = "none";
            Special = "none";
        }
        public Feat(string Name, string Benifits)
        {
            
            this.Name = Name;
            Is_Combat = false;
            Prerequisites = new string[0];
            this.Benifits = Benifits;
            Normal = "none";
            Special = "none";
        }
        public Feat(string Name, string Benifits, bool Is_Combat)
        {

            this.Name = Name;
            this.Is_Combat = Is_Combat;
            Prerequisites = new string[0];
            this.Benifits = Benifits;
            Normal = "none";
            Special = "none";
        }

    }
}
