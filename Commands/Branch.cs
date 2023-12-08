using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiScripter.Commands
{
    internal class Branch
    {
        private string Cond = "1110";
        private bool linkBit = false;
        private string hex;

        public Branch(bool linkBit, string hex)
        {
            this.linkBit = linkBit;
            this.hex = hex;
        }

        public Branch(string Condition, bool linkBit, string hex)
        {
            if (Condition != null){ this.Cond = Condition; }
            this.linkBit = linkBit;
            this.hex = hex;
        
        }

        private string Conver()
        {
            //if (this.hex.Contains("-")) { this.hex = this.hex.Replace("-", ""); }

            int num = Convert.ToInt32(this.hex, fromBase: 10);
            this.hex = Convert.ToString(num, toBase: 2);
            if (this.hex.Count() > 8) {
                this.hex = this.hex.Substring(8, 24);
            }
            this.hex = this.hex.PadLeft(24, '0');
          
            return this.hex;
        }



        public string Execute()
        {
            string instruction;
            if(this.Cond == "PL") { this.Cond = "0101"; }

            if (linkBit) { instruction = Cond + "1011" + Conver(); }
            else { instruction = Cond + "1010" + Conver(); }
            int num = instruction.Length;

            return instruction;
        }





    }
}
