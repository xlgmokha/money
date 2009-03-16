namespace MoMoney.Domain.Core
{
    public class Percent
    {
        readonly long whole;
        readonly long fraction;

        public Percent(long whole) : this(whole, 0)
        {
        }

        public Percent(long whole, int fraction)
        {
            this.whole = whole;
            this.fraction = fraction;
        }

        static public implicit operator Percent(int whole)
        {
            return new Percent(whole);
        }

        public bool Equals(Percent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.whole == whole && other.fraction == fraction;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Percent)) return false;
            return Equals((Percent) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (whole.GetHashCode()*397) ^ fraction.GetHashCode();
            }
        }
    }
}