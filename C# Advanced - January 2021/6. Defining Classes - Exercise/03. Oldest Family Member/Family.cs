using System.Collections.Generic;
using System.Linq;

namespace _03._Oldest_Family_Member
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
            Person oldestMember = members.OrderByDescending(p => p.Age).FirstOrDefault();
            return oldestMember;
        }
    }
}
