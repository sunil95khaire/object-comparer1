namespace ObjectComparer
{
    public abstract class ComparerFactory
    {
        public abstract ITypeComparer GetComparerType(ComparerType comparerType);        
    }
}
