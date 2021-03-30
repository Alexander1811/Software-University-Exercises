namespace _02._Validation_Attributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            string str = (string)obj;

            return !string.IsNullOrEmpty(str);
        }
    }
}
