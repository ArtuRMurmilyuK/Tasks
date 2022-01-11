using System;

namespace BusinessLogic.Core
{
    public class LegoSet
    {
        public LegoSet(int serialNumber, string name, DateTime releaseDate)
        {
            SerialNumber = serialNumber;
            Name = name;
            ReleaseDate = releaseDate;
        }

        public int SerialNumber { get; }

        public string Name { get; }

        public DateTime ReleaseDate { get; }
    }
}