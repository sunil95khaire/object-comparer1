namespace ObjectComparer
{
    internal class NullTypeComparer : ITypeComparer
    {
        public bool Compare<T>(T first, T second)
        {
            return ReferenceEquals(first, second);
        }
    }
}