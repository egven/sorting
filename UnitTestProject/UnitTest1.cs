using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WayInfo;
using SortingTool;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        // корректно заданная цепочка пунктов отправления и назначения
        IWayPart[] testData = new IWayPart[] 
        { 
            new WayPart("ee", "dd"),
            new WayPart("dd", "cc"),
            new WayPart("cc", "bb"),
            new WayPart("bb", "aa") 
        };

        /// <summary>
        /// Формирует тестовый список из тестовых данных
        /// </summary>
        /// <param name="testCombination">поледовательность тестовых данных (индексы)</param>
        /// <returns></returns>
        IList<IWayPart> makeTestList(int[] testCombination)
        {
            List<IWayPart> list = new List<IWayPart>(testCombination.Length);
            for (int i = 0; i < testCombination.Length; i++)
                list.Add(testData[testCombination[i]]);

            return list;
        }

        [TestMethod]
        public void StartAndFinishPointsTogetherAtFirstTest()
        {
            int[] testCombination = new int[] { 0, 3, 2, 1};

            IList<IWayPart> list = makeTestList(testCombination);

            Assert.IsTrue(Sorting.sort(list));

            for (int i = 0; i < testCombination.Length; i++)
                Assert.AreSame(list[i], testData[i]);
        }

        [TestMethod]
        public void StartAndFinishPointsTogetherLastTest()
        {
            int[] testCombination = new int[] { 2, 1, 0, 3 };

            IList<IWayPart> list = makeTestList(testCombination);

            Assert.IsTrue(Sorting.sort(list));

            for (int i = 0; i < testCombination.Length; i++)
                Assert.AreSame(list[i], testData[i]);
        }

        [TestMethod]
        public void OddElementCountTest()
        {
            int[] testCombination = new int[] { 2, 1, 3 };

            IList<IWayPart> list = makeTestList(testCombination);

            Assert.IsTrue(Sorting.sort(list));

            int indexShift = testCombination.Min();
            for (int i = 0; i < testCombination.Length; i++)
                Assert.AreSame(list[i], testData[indexShift + i]);
        }

        [TestMethod]
        public void EmptyLisTest()
        {
            IList<IWayPart> list = new List<IWayPart>();

            Assert.IsTrue(Sorting.sort(list));
        }

        [TestMethod]
        public void OneElementTest()
        {
            int[] testCombination = new int[] { 0 };

            IList<IWayPart> list = makeTestList(testCombination);

            Assert.IsTrue(Sorting.sort(list));

            for (int i = 0; i < testCombination.Length; i++)
                Assert.AreSame(list[i], testData[i]);
        }

        [TestMethod]
        public void RepeatingElementsTest()
        {
            int[] testCombination = new int[] { 0, 1, 1 };

            IList<IWayPart> list = makeTestList(testCombination);

            Assert.IsFalse(Sorting.sort(list));
        }

        [TestMethod]
        public void IncompatibleElementsTest()
        {
            int[] testCombination = new int[] { 0, 3 };

            IList<IWayPart> list = makeTestList(testCombination);

            Assert.IsFalse(Sorting.sort(list));
        }

        [TestMethod]
        public void ToStringTest()
        {
            string from = "city1";
            string to = "city2";
            WayPart part = new WayPart(from, to);

            Assert.AreEqual(part.ToString(), from + " " + to);
        } 
    }
}
