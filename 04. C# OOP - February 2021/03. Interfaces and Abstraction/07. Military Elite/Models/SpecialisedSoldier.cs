using P07_MilitaryElite.Contracts;
using P07_MilitaryElite.Enums;

namespace P07_MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {

        protected SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; private set; }
    }
}
