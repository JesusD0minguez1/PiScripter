using PiScripter.Interfaces;
using PiScripter.Commands;
using PiScripter.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiScripter.Commands
{
    internal class Delay
    {

        MOVW MOVW = new MOVW("R6", "1000000000");
        MOVT MOVT = new MOVT("R6", "1000000000");
        Command sub = new Command("SUB", "R6", "R6", "1");

        public string[] ExecuteDelay()
        {
            string movwCMD = MOVW.Execute();
            string movtCMD = MOVT.Execute();
            string subCMD = sub.Execute();

            string instruction = "01011010111111111111111111111101";
            return new string[] { movwCMD,movtCMD,subCMD,instruction};
        }

    }
}
