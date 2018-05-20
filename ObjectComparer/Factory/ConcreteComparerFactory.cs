using System;

namespace ObjectComparer
{
    public class ConcreteComparerFactory : ComparerFactory
    {
        public override ITypeComparer GetComparerType(ComparerType comparerType)
        {
            switch (comparerType)
            {
                case ComparerType.Premitive:
                    return new PremitiveTypeComparer();
                case ComparerType.Reference:
                    return new ReferenceTypeComparer();
                case ComparerType.Null:
                    return new NullTypeComparer();
                default:
                    throw new ApplicationException(string.Format("comparerType '{0}' cannot be created", comparerType));
            }
        }
    }
}
