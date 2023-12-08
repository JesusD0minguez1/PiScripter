using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiScripter.Commands
{
    internal class BranchX
    {
        private string Cond = "1110";
        private string rn;

        public BranchX(string Rn)
        {
           this.rn = Rn;
        }


        private void ConvertRegister()
        {
            this.rn = this.rn.Replace("R", "");
            int num = Convert.ToInt32(this.rn);
            this.rn = Convert.ToString(num, 2);
            this.rn = this.rn.PadLeft(4, '0');

        }


        public string Execute()
        {
            ConvertRegister();
            string instruction = Cond + "000100101111111111110001" + this.rn;
            
            return instruction;
        }

    }
}
