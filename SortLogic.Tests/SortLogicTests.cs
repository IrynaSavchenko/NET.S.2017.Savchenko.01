using System;
using NUnit.Framework;

namespace SortLogic.Tests
{
    [TestFixture]
    public class SortLogicTests
    {
        public static TestCaseData[] ArraysForTest => new TestCaseData[]
        {
            new TestCaseData(new [] {-18, 9, 0, 4, -13, -15, 10}, new [] {-18, -15, -13, 0, 4, 9, 10}),
            new TestCaseData(new [] {21, 19, 11, 8, 2, -3}, new [] {-3, 2, 8, 11, 19, 21}),
            new TestCaseData(new [] {20, 18, -15, 9, 5, -4}, new [] {-15, -4, 5, 9, 18, 20})
        };

        #region Quick Sort

        [Test, TestCaseSource(nameof(ArraysForTest))]
        public void QuickSort_ValidArray_SortedArray(int[] array, int[] sortedArray)
        {
            Sort_ValidArray_SortedArray(array, sortedArray, Sort.QuickSort);
        }

        [Test]
        public void QuickSort_Null_ThrowsArgumentNullException()
        {
            Sort_Null_ThrowsArgumentNullException(Sort.QuickSort);
        }

        [Test]
        public void QuickSort_EmptyArray_ThrowsArgumentException()
        {
            Sort_EmptyArray_ThrowsArgumentException(Sort.QuickSort);
        }

        #endregion

        #region MergeSort

        [Test, TestCaseSource(nameof(ArraysForTest))]
        public void MergeSort_ValidArray_SortedArray(int[] array, int[] sortedArray)
        {
            Sort_ValidArray_SortedArray(array, sortedArray, Sort.MergeSort);
        }

        [Test]
        public void MergeSort_Null_ThrowsArgumentNullException()
        {
            Sort_Null_ThrowsArgumentNullException(Sort.MergeSort);
        }

        [Test]
        public void MergeSort_EmptyArray_ThrowsArgumentException()
        {
            Sort_EmptyArray_ThrowsArgumentException(Sort.MergeSort);
        }

        #endregion

        #region Common

        private void Sort_ValidArray_SortedArray(int[] array, int[] sortedArray, Action<int[]> method)
        {
            method(array);
            Assert.AreEqual(array, sortedArray);
        }

        private void Sort_Null_ThrowsArgumentNullException(Action<int[]> method)
        {
            Assert.Throws<ArgumentNullException>(() => method(null));
        }

        private void Sort_EmptyArray_ThrowsArgumentException(Action<int[]> method)
        {
            Assert.Throws<ArgumentException>(() => method(new int[] { }));
        }

        #endregion
    }
}
