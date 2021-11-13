using P03_Telephony.Contracts;

namespace P03_Telephony.Models
{
    public abstract class Phone : ICallable
    {
        public abstract string Call(string number);
    }
}
