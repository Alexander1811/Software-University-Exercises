using System.Collections.Generic;
using System.Linq;

namespace P04_OpinionPoll
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
        public List<Person> GetMembersAbove30()
        {
            List<Person> membersAbove30 = members
                .OrderBy(a => a.Name)
                .Where(p => p.Age > 30)
                .ToList();

            return membersAbove30;
        }
    }
}
