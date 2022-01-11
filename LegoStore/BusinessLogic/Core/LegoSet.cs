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

        int SerialNumber { get; }

        string Name { get; }

        DateTime ReleaseDate { get; }
    }
}