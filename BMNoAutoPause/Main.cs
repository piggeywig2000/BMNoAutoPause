using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMNoAutoPause.Patches;

namespace BMNoAutoPause
{
    public static class Main
    {
        public static void OnModStart()
        {
            Console.WriteLine("NoAutoPause: Patching methods");
            MainGameStagePatch.CreateDetour();
        }
    }
}
