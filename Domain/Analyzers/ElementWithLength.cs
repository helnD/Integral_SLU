using Domain.Elements;

namespace Domain.Analyzers
{
    public class ElementWithLength
    {
        public ElementWithLength(Element element, int length)
        {
            Element = element;
            Length = length;
        }

        public Element Element { get; }
        public int Length { get; }
    }
}