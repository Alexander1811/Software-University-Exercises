using _07._Military_Elite.Contracts;
using _07._Military_Elite.Enums;

namespace _07._Military_Elite.Models
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
