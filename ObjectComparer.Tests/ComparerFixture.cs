using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectComparer.Tests
{
    [TestClass]
    public class ComparerFixture
    {
        [TestMethod]
        public void Null_values_are_similar_test()
        {
            string first = null, second = null;
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void ClassA_values_are_similar_test()
        {
            //Initialize objects and comparer
            var first = new ClassA { StringProperty = "String", IntProperty = 1, Marks = new[] { 12, 23, 34 } };
            var second = new ClassA { StringProperty = "String", IntProperty = 1, Marks = new[] { 12, 23, 34 } };
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void ClassA_values_are_non_similar_test()
        {
            var first = new ClassA { StringProperty = "String", IntProperty = 1, Marks = new[] { 12, 23, 34 } };
            var second = new ClassA { StringProperty = "String", IntProperty = 2, Marks = new[] { 2, 23, 34 } };
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Array_values_are_similar_test()
        {
            var first = new[] { 1, 2, 3 };
            var second = new[] { 1, 2, 3 };
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Array_values_are_non_similar_test()
        {
            var first = new[] { 1, 2, 3 };
            var second = new[] { 1, 2 };
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Dynamic_type_values_are_similar_test()
        {
            dynamic first = new
            {
                Field1 = "A",
                Field2 = 5,
                Field3 = true
            };
            dynamic second = new
            {
                Field1 = "A",
                Field2 = 5,
                Field3 = true
            };
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }

        [TestMethod]
        public void Dynamic_type_values_are_non_similar_test()
        {
            dynamic first = new
            {
                Field1 = "A",
                Field2 = 5,
                Field3 = true
            };
            dynamic second = new
            {
                Field1 = "A",
                Field2 = 5,
                Field3 = false
            };
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }
    }

    public class ClassA
    {
        public string StringProperty { get; set; }

        public int IntProperty { get; set; }

        public SubClassA SubClass { get; set; }

        public int[] Marks { get; set; }
    }

    public class SubClassA
    {
        public bool BoolProperty { get; set; }
    }
}
