using _03._Telephony.Contracts;

namespace _03._Telephony.Models
{
    public abstract class Phone : ICallable
    {
        public abstract string Call(string number);
    }
}
