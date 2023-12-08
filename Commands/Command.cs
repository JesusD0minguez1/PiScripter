using PiScripter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiScripter.Commands
{
    internal class Command : ICommand
    {
        private string Cmd;
        private string imm12;
        private string Rd;
        private string Rn;

        Dictionary<String, String> Commands = new Dictionary<String, String>()
        {
            {"ADD", "0100"},
            {"SUB", "0010"},
            {"ORR","1100"}
        };

        public Command(string Command,string Rd, string Rn, string imm12)
        {
            this.Cmd = Command;
            this.Rd = Rd;
            this.Rn = Rn;
            this.imm12 = imm12;
        }

        private string  ConvertRegister(string register)
        {
            register = register.Replace("R", "");
            int num = Convert.ToInt32(register);
            register = Convert.ToString(num, 2);
            register = register.PadLeft(4, '0');
            return register;
        }

        private string ConvertImm12()
        {
            if (this.imm12.Contains("0x")) { this.imm12 = this.imm12.Replace("0x", ""); }
            if (this.imm12.Contains("Ox")) { this.imm12 = this.imm12.Replace("Ox", ""); }


            int num = Convert.ToInt32(this.imm12, fromBase: 16);
            this.imm12 = Convert.ToString(num, toBase: 2);
            this.imm12 = this.imm12.PadLeft(12, '0');

            return this.imm12;
        }

        public string Execute()
        {
            string Cond = "1110";
            string Sbit = "0";
            this.Rd = ConvertRegister(this.Rd);
            this.Rn = ConvertRegister(this.Rn);
            if(this.Cmd == "SUB") { Sbit = "1"; }
            this.Cmd = Commands[this.Cmd];
            Console.WriteLine(this.Cmd);
            

            string Instruction = Cond + "001" + this.Cmd + Sbit + this.Rn + this.Rd + ConvertImm12();

            return Instruction;
        }

        public string ExecuteImmedate()
        {

            return null;
        }
    }
}
