using System;
using System.Collections.Generic;
using System.Linq;

namespace LInQAndList
{
    public class ListOfParticipants : IListOfParticipants
    {
        private List<Participants> _listParticipants = new();
        public void Add(int age, string name, string lastName)
        {
            _listParticipants.Add(new Participants{ Age = age, LastName = lastName, Name = name});
        }

        public void DeleteByNameAndLastName(string name, string lastName)
        {
            var selectedUser = _listParticipants.First(x => x.Name == name && x.LastName == lastName);
            _listParticipants.Remove(selectedUser);
        }

        public IEnumerable<Participants> FetchByName(string name)
        {
            var selectedUsers = from user in _listParticipants
                where user.Name == name
                select user;

            return selectedUsers;
        }

        public IEnumerable<Participants> FetchByAge(int age)
        {
            var selectedUsers = from user in _listParticipants
                where user.Age == age
                select user;

            return selectedUsers;
        }

        public void Show()
        {
            foreach (var user in _listParticipants)
            {
                Console.WriteLine($"{user.Name} - {user.LastName} - {user.Age}");
            }
        }
    }
}