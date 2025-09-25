using Achar.Domain.Testing.Enum;

namespace Achar.Domain.Testing
{
    public class LocationInstruction
    {
        public ElementSelectTypeEnum ByEnum { get; set; }

        public string Value { get; set; }

        public bool FromRoot { get; set; }

        public int? Index { get; set; }

        public override string ToString() => $"[selector: {ByEnum}, value: {Value}]";
    }
}