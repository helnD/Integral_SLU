namespace Domain.Elements
{
    public class FirstStageOperator : Element, IOperator
    {
        public FirstStageOperator(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}