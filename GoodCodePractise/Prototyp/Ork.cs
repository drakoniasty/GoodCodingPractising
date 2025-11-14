using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodCodePractise.Prototyp
{
    internal class Ork
    {
        private string name;
        public string Name { get; set; }
        private string familyName;
        public string FamilyName { get; set; }
        private int strenght;
        public string Strenght
        {
            get
            {
                return (this.strenght).ToString();
            }
            set
            {
                try
                {
                    this.strenght = Convert.ToInt32(value);
                }
                catch 
                {
                    throw new Exception("Musi to być liczba całkowita");
                }
            }
        }

        private string weapon;
        public string Weapon { get; set; }
        public Ork(string name, string familyname, string strenght, string weapon)
        {
            this.Name = name;
            this.FamilyName = familyname;
            this.Strenght = strenght;
            this.Weapon = weapon;
        }
    }
}
