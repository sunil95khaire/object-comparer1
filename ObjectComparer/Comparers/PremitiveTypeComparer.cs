namespace ObjectComparer
{
    public class PremitiveTypeComparer : ITypeComparer
    {
        public bool Compare<T>(T first, T second)
        {
            dynamic cur = first;
            dynamic oth = second;
            
            var result = false;
            foreach (object cVal in cur)
            {
                result = false;
                foreach (object oVal in oth)
                {
                    var areEqual = Equals(cVal, oVal);
                    if (!areEqual) continue;

                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}
