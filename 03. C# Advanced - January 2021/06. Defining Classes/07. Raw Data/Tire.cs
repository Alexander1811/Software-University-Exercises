namespace P07_RawData
{
    public class Tire
    {
        private double pressure;
        private int age;

        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public double Pressure
        {
            get
            {
                return pressure;
            }
            set
            {
                pressure = value;
            }
        }
    }
}