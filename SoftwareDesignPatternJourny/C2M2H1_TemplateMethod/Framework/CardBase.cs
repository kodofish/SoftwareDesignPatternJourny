namespace C2M2H1_TemplateMethod.Framework
{
    public abstract record CardBase<T> : IComparable<T>, IEquatable<T?>
    {
        public abstract int CompareTo(T? other);
        public abstract bool Equals(T? other);
    }
}