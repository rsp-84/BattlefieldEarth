using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlefieldEarthLibrary
{
    public class Military
    {
        //Fields

        //Properties
        public int Spies { get; set; }
        public int Troops { get; set; }
        public int Jets { get; set; }
        public int Turrets { get; set; }
        public int Tanks { get; set; }
        public int Missiles { get; set; }

        //ctors
        public Military(int spies, int troops, int jets, int turrets, int tanks, int missiles)
        {
            Spies = spies;
            Troops = troops;
            Jets = jets;
            Turrets = turrets;
            Tanks = tanks;
            Missiles = missiles;
        }

        //methods
        public override string ToString()
        {
            return string.Format("MILITARY FORCES:\nSpies: {0}\nTroops: {1}\nJets: {2}\nTurrets: {3}\nTanks: {4}\nMissiles: {5}\n",
                Spies,
                Troops,
                Jets,
                Turrets,
                Tanks,
                Missiles
                );
        }
    }
}
