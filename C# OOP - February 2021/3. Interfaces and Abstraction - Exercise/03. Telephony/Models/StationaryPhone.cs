using _03._Telephony.Contracts;

namespace _03._Telephony.Models
{
    public class StationaryPhone : Phone, IBrowsable
    {
        public override string Call(string number)
        {
            Validator.ThrowIfIsInvalidNumber(number);

            return $"Dialing... {number}";
        }

        public string Browse(string url)
        {
            Validator.ThrowIfIsInvalidURL(url);

            return $"Browsing: {url}!";
        }
    }
}
