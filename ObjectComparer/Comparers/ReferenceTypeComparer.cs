using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using Dynamitey;

namespace ObjectComparer
{
    public class ReferenceTypeComparer : ITypeComparer
    {
        /// <summary>
        /// Compares the two objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public bool Compare<T>(T first, T second)
        {
            if (ReferenceEquals(first, second))
                return true;

            //Compare the types
            if (first.GetType() != second.GetType())
                return false;

            //Get all property infos of the second object
            var propertyInfos = second.GetType().GetProperties();

            //Compare the property values of the first and second object
            foreach (var propertyInfo in propertyInfos)
            {
                var othersValue = propertyInfo.GetValue(second);
                var currentsValue = propertyInfo.GetValue(first);
                if (othersValue == null && currentsValue == null)
                    continue;

                //Comparison if the property is a generic (IList type)
                if ((currentsValue is IList && propertyInfo.PropertyType.IsGenericType) ||
                    (othersValue is IList && propertyInfo.PropertyType.IsGenericType))
                {
                    //here we work with dynamics because don't need to care about the generic type
                    dynamic cur = currentsValue;
                    dynamic oth = othersValue;
                    if (cur != null && cur.Count > 0)
                    {
                        var result = false;
                        foreach (object cVal in cur)
                        {
                            foreach (object oVal in oth)
                            {
                                //Recursively call the Equal method
                                var areEqual = Equals(cVal, oVal);
                                if (!areEqual) continue;

                                result = true;
                                break;
                            }
                        }
                        if (result == false)
                            return false;
                    }
                }
                else
                {
                    //Comparison for properties of a non collection type
                    var curType = currentsValue.GetType();

                    //Comparison for primitive types
                    if (curType.IsValueType || currentsValue is string)
                    {
                        var areEquals = currentsValue.Equals(othersValue);
                        if (areEquals == false)
                            return false;
                    }
                    else
                    {
                        dynamic cur = currentsValue;
                        dynamic oth = othersValue;

                        if (cur is object && oth is object) return true;
                        
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
            return true;
        }
    }
}
