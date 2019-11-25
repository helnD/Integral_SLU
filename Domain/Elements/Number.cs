namespace Domain.Elements
{
    public class Number : Element
    {
        public Number(float value)
        {
            Value = value;
        }

        public float Value { get; }
    }
}