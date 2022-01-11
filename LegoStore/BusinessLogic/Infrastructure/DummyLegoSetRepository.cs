using System.Collections.Generic;
using BusinessLogic.Core;

namespace BusinessLogic.Infrastructure
{
    public class DummyLegoSetRepository : ILegoSetRepository
    {
        private List<LegoSet> _inMemorySets = new List<LegoSet>();

        public bool Add(LegoSet set)
        {
            _inMemorySets.Add(set);
            return true;
        }

        public bool Remove(LegoSet set)
        {
            _inMemorySets.Remove(set);
            return true;
        }
    }
}