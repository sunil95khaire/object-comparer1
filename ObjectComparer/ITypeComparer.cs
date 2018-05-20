namespace ObjectComparer
{
    public interface ITypeComparer
    {
        bool Compare<T>(T first, T second);        
    }
}
