namespace Domain.LES
{
    public class Element
    {

        public Element(int number, double value)
        {
            Number = number;
            Value = value;
        }
        
        public int Number { get; }
        public double Value { get; }
    }
}