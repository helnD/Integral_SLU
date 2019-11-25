namespace Domain.Analyzers
{
    public interface IParser
    {
        bool Check(string expression, int index);
    }
}