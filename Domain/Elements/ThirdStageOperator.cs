namespace Domain.Elements
{
    public class ThirdStageOperator : Element, IOperator
    {
        public ThirdStageOperator(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}