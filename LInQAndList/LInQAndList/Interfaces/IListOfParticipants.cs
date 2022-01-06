using System.Collections.Generic;

namespace LInQAndList
{
    interface IListOfParticipants
    {
         
        void Add(int age, string name, string lastName);
        void DeleteByNameAndLastName(string name, string lastName);
        IEnumerable<Participants> FetchByName(string name);
        IEnumerable<Participants> FetchByAge(int age);
        void Show();
    }
}