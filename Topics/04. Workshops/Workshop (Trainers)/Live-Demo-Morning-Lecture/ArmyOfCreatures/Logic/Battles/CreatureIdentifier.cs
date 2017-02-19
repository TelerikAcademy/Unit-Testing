namespace ArmyOfCreatures.Logic.Battles
{
    using System;
    using System.Globalization;

    public sealed class CreatureIdentifier
    {
        private CreatureIdentifier(string creatureType, int armyNumber)
        {
            this.CreatureType = creatureType;
            this.ArmyNumber = armyNumber;
        }

        public string CreatureType { get; private set; }

        public int ArmyNumber { get; private set; }

        public static CreatureIdentifier CreatureIdentifierFromString(string valueToParse)
        {
            if (valueToParse == null)
            {
                throw new ArgumentNullException("valueToParse");
            }

            var stringParts = valueToParse.Split('(');

            var creatureType = stringParts[0];
            var armyNumber = int.Parse(stringParts[1].Trim('(', ')'), CultureInfo.InvariantCulture);

            return new CreatureIdentifier(creatureType, armyNumber);
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", this.CreatureType, this.ArmyNumber);
        }
    }
}
