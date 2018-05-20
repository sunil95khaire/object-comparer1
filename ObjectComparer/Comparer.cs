namespace ObjectComparer
{
    public static class Comparer
    {
        public static bool AreSimilar<T>(T first, T second)
        {
            ComparerFactory factory = new ConcreteComparerFactory();
           
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                var referenceType = factory.GetComparerType(ComparerType.Null);
                return referenceType.Compare(first, second);
            }
            else if (first.GetType().IsArray)
            {
                var premitiveType = factory.GetComparerType(ComparerType.Premitive);
                return premitiveType.Compare(first, second);
            }
            else
            {
                var referenceType = factory.GetComparerType(ComparerType.Reference);
                return referenceType.Compare(first, second);
            }
        }        
    }
}
