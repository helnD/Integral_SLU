namespace Domain.Elements
{
    public class SecondStageOperator : Element, IOperator
    {
        public SecondStageOperator(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}