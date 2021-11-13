using System.Collections.Generic;
using System.Linq;

namespace P03_OldestFamilyMember
{
    public class Family
    {
        private readonly List<Person> members;

        public Family()
        {
            this.members = new List<Person>();
        }

        public void AddMember(Person member) 
        {
            this.members.Add(member);
        }

        public Person GetOldestMember() 
        {
            Person oldestMember = members
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();

            return oldestMember;
        }
    }
}
