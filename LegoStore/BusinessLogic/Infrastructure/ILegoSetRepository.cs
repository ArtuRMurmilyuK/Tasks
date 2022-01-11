using BusinessLogic.Core;

namespace BusinessLogic.Infrastructure
{
    interface ILegoSetRepository
    {
        bool Add(LegoSet set);

        bool Remove(LegoSet set);
    }
}