using System.Globalization;

namespace Sit.Framework.Portal.Sql.Generating
{
    public struct Length
    {
        public static Length Max = new Length(uint.MaxValue);
        public static Length Empty;
        
        public Length(uint value) : this()
        {
            Value = value;
        }

        public uint Value { get; set; }

        public static bool operator !=(Length left, Length right)
        {
            return left.Value != right.Value;
        }

        public static bool operator ==(Length left, Length right)
        {
            return left.Value == right.Value;
        }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }

        public bool Equals(Length other)
        {
            return other.Value == Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof (Length)) return false;
            return Equals((Length) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}