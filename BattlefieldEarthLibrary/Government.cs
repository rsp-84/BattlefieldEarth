namespace BattlefieldEarthLibrary
{
    public class Government
    {
        //Fields

        //Properties
        public string Description { get; set; }
        public int MilBonusStrength { get; set; }
        public GovernmentType GovType { get; set; }

        //Ctors
        public Government(GovernmentType govType)
        {
            GovType = govType;

            switch (govType)
            {
                case GovernmentType.Monarchy:
                    MilBonusStrength = 0;
                    Description = "Political system based upon the undivided sovereignty or rule of a single person.";
                    break;
                case GovernmentType.Fascism:
                    MilBonusStrength = 15;
                    Description = "Authorian ultranationalism with forcibile suppression of opposition.";
                    break;
                case GovernmentType.Dictatorship:
                    MilBonusStrength = 30;
                    Description = "One person possesses absolute power without limitations.";
                    break;
                case GovernmentType.Republic:
                    MilBonusStrength = -10;
                    Description = "Ruled by representatives of the citizen body.";
                    break;
                case GovernmentType.Democracy:
                    MilBonusStrength = 5;
                    Description = "The people have the authority to choose their governing legislation.";
                    break;
                default:
                    break;
            }
        }

        //Methods
        public override string ToString()
        {
            return string.Format("Government: {0} - {1}\nBonus Military Strength: {2}\n",
                GovType,
                Description,
                MilBonusStrength
                );
        }
    }
}
