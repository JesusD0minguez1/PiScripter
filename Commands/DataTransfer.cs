using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiScripter.Commands
{
    internal class DataTransfer
    {
        private string Rn;
        private string Rd;
        private string Cmd;

        public DataTransfer(string Cmd,string Rn, string Rd)
        {
            this.Cmd = Cmd;
            this.Rn = Rn;
            this.Rd = Rd;
        }

        private string ConvertRegister(string register)
        {
            register = register.Replace("R", "");
            int num = Convert.ToInt32(register);
            register = Convert.ToString(num, 2);
            register = register.PadLeft(4, '0');
            return register;
        }

        public string Execute()
        {
            string Cond = "1110";
            string Lbit = "0";
            this.Rn = ConvertRegister(this.Rn);
            this.Rd = ConvertRegister(this.Rd);

            if (Cmd == "LDR")
            {
                Lbit = "1";
            }
            else{ Lbit = "0"; }
            string Instruction = Cond + "0100000" + Lbit + this.Rn + this.Rd + "000000000000";
            return Instruction;

        }



    }
}
