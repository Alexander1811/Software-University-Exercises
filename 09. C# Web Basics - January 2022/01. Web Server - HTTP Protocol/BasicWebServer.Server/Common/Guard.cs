namespace BasicWebServer.Server.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Guard
    {
        public static void AgainstNull(object value, string name = null)
        {
            if (value == null)
            {
                name ??= "Value";

                throw new ArgumentNullException($"{value} cannot be null.");
            }
        }
    }
}
