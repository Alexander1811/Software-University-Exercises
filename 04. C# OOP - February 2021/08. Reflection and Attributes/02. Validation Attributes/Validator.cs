namespace P02_ValidationAttributes
{
    using System.Linq;
    using System.Reflection;

    using P02_ValidationAttributes.Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj
                .GetType()
                .GetProperties()
                .ToArray();

            foreach (PropertyInfo property in properties)
            {
                MyValidationAttribute[] attributes = property
                    .GetCustomAttributes()
                    .Where(attribute => attribute is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                object value = property.GetValue(obj);

                foreach (MyValidationAttribute attribute in attributes)
                {
                    bool isValid = attribute.IsValid(value);

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
