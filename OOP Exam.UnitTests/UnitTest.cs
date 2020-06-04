using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Exam.BPlusTree;
using System;
using System.Collections.ObjectModel;

namespace OOP_Exam.UnitTests
{
    [TestClass]
    public class RedBlackTreeTests
    {
        [TestMethod]
        public void RedBlackTree_AddingSearchingDeleting()
        {
            // Arrange
            var redBlackTree = new RedBlackTree<int>();
            // Act
            for (int i = 0; i < 1000; i++)
            {
                redBlackTree.Add(i);
            }
            redBlackTree.Remove(17);
            redBlackTree.Remove(93);
            // Assert
            for (int i = 0; i < 1000; i++)
            {
                if (i != 17 && i != 93)
                    Assert.AreEqual(redBlackTree.Search(i).Data, i);
                else
                {
                    Assert.AreEqual(redBlackTree.Search(i), null);
                }
            }
        }
        [TestMethod]
        public void RedBlackTree_Colors()
        {
            // Arrange
            var redBlackTree = new RedBlackTree<int>();
            // Act
            for (int i = 0; i < 1000; i++)
            {
                redBlackTree.Add(i);
            }
            // Assert
            foreach (RedBlackTreeNode<int> node in redBlackTree)
            {
                Assert.IsTrue(node.Color == NodeColor.Black || node.Color == NodeColor.Red);
            }
        }
        [TestMethod]
        public void RedBlackTree_LeftMostRightMost_MinimumMaximum()
        {
            // Arrange
            var redBlackTree = new RedBlackTree<int>();
            // Act
            for (int i = 0; i < 1000; i++)
            {
                redBlackTree.Add(i);
            }
            // Assert
            Assert.AreEqual(redBlackTree.LeftMost.Data, 0);
            Assert.AreEqual(redBlackTree.RightMost.Data, 999);
        }
    }

    [TestClass]
    public class SLcircularListTest
    {
        [TestMethod]
        public void SLcircularList_AddToEndSearchRemove()
        {
            // Arrange
            var list = new SLcircularList<int>();
            // Act
            for (int i = 0; i < 100; i++)
            {
                list.AddToEnd(i);
            }
            list.Remove(15);
            list.Remove(94);
            // Assert
            for (int i = 0; i < 100; i++)
            {
                if (i != 15 && i != 94)
                    Assert.AreEqual(list.Search(i).Data, i);
                else
                {
                    Assert.AreEqual(list.Search(i), null);
                }
            }
        }
        [TestMethod]
        public void SLcircularList_AddToBeginSearchRemove()
        {
            // Arrange
            var list = new SLcircularList<int>();
            // Act
            for (int i = 0; i < 100; i++)
            {
                list.AddToBegin(i);
            }
            list.Remove(15);
            list.Remove(94);
            // Assert
            for (int i = 0; i < 100; i++)
            {
                if (i != 15 && i != 94)
                    Assert.AreEqual(list.Search(i).Data, i);
                else
                {
                    Assert.AreEqual(list.Search(i), null);
                }
            }
        }

        [TestMethod]
        public void SLcircularList_SmallList()
        {
            // Arrange
            var list1 = new SLcircularList<int>(1);
            var list2 = new SLcircularList<int>(1);
            var list3 = new SLcircularList<int>();
            // Act
            for (int i = 0; i < 2; i++)
            {
                list3.AddToEnd(i);
            }
            list1.Search(1);
            list2.AddToEnd(2);
            list1.Remove(1);
            list2.Remove(1);
            list2.Remove(2);
            for (int i = 0; i < 2; i++)
            {
                list3.Remove(i);
            }
            // Assert
            Assert.AreEqual(list1.StartNode, null);
            Assert.AreEqual(list2.StartNode, null);
            Assert.AreEqual(list3.StartNode, null);
        }

        [TestMethod]
        public void SLcircularList_AddAfter()
        {
            // Arrange
            var list = new SLcircularList<int>(1);
            // Act
            for (int i = 0; i < 100; i++)
            {
                list.AddAfter(1, i);
            }
            for (int i = 100; i < 200; i++)
            {
                list.AddAfter(35, i);
            }
            // Assert
            for (int i = 0; i < 200; i++)
            {
                Assert.AreEqual(list.Search(i).Data, i);
            }
            Assert.IsFalse(list.AddAfter(350, 4));
        }

        [TestMethod]
        public void SLcircularList_AddAfterSmallList()
        {
            // Arrange
            var list = new SLcircularList<int>(1);
            // Act
            list.AddAfter(1, 2);
            list.AddAfter(1, 3);
            // Assert
            Assert.AreEqual(list.StartNode.Data, 1);
            Assert.AreEqual(list.StartNode.Next.Data, 3);
            Assert.AreEqual(list.StartNode.Next.Next.Data, 2);
        }
    }
    [TestClass]
    public class BPTreeTests
    {
        [TestMethod]
        public void BPTree_BuildDeleteTryGet()
        {
            // Arrange
            var tree = new BPTree<int, int>();
            int res;
            // Act
            for (int i = 99; i >= 0; i--)
            {
                tree.Add(i, i);
            }
            // Assert
            for (int i = 0; i < 100; i++)
            {
                tree.TryGet(i, out res);
                Assert.AreEqual(res, i);
            }
            int removeResult;
            Assert.IsTrue(tree.Remove(5, out removeResult));
            Assert.IsFalse(tree.Remove(137, out removeResult));
            Assert.IsFalse(tree.TryGet(137, out res));
        }

        [TestMethod]
        public void BPTree_IENumerator()
        {
            // Arrange
            var tree = new BPTree<int, int>();
            // Act
            for (int i = 0; i < 100; i++)
            {
                tree.Add(i, i);
            }
            // Assert
            int prevElement = -1;
            foreach (var element in tree)
            {
                Assert.IsTrue(element > prevElement);
                prevElement = element;
            }
        }
    }

    [TestClass]
    public class SortsCompareTest
    {
        [TestMethod]
        public void InsertionSort_Test()
        {
            // Arrange
            var collectionInsertion = new Collection<int>();
            var collectionMerge = new Collection<int>();
            var collectionHeap = new Collection<int>();
            var collectionRadix = new Collection<int>();
            Random random = new Random();
            // Act

            for (int i = 0; i < 1000; i++)
            {
                var number = random.Next(0, 10000);
                collectionInsertion.Add(number);
                collectionMerge.Add(number);
                collectionHeap.Add(number);
                collectionRadix.Add(number);
            }
            InsertionSort<int>.Sort(collectionInsertion);
            collectionMerge = MergeSort<int>.Sort(collectionMerge);
            HeapSort<int>.Sort(collectionHeap);
            RadixSort.Sort(collectionRadix);
            // Assert
            for (int i = 0; i < collectionInsertion.Count; i++)
            {
                Assert.AreEqual(collectionInsertion[i], collectionMerge[i]);
                Assert.AreEqual(collectionHeap[i], collectionMerge[i]);
                Assert.AreEqual(collectionRadix[i], collectionHeap[i]);
            }
        }
    }
    [TestClass]
    public class InsertionSortTests
    {
        [TestMethod]
        public void InsertionSort_Test()
        {
            // Arrange
            var collection = new Collection<int>();
            Random random = new Random();
            // Act

            for (int i = 0; i < 1000; i++)
            {
                collection.Add(random.Next(-10000, 10000));
            }
            InsertionSort<int>.Sort(collection);
            // Assert
            int prevElement = -10001;
            foreach (var element in collection)
            {
                Assert.IsTrue(element >= prevElement);
                prevElement = element;
            }
        }
    }
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void MergeSort_Test()
        {
            // Arrange
            var collection = new Collection<int>();
            Random random = new Random();
            // Act

            for (int i = 0; i < 1000; i++)
            {
                collection.Add(random.Next(-10000, 10000));
            }
            collection = MergeSort<int>.Sort(collection);
            // Assert
            int prevElement = -10001;
            foreach (var element in collection)
            {
                Assert.IsTrue(element >= prevElement);
                prevElement = element;
            }
        }
    }
    [TestClass]
    public class HeapSortTests
    {
        [TestMethod]
        public void HeapSort_Test()
        {
            // Arrange
            var collection = new Collection<int>();
            Random random = new Random();
            // Act

            for (int i = 0; i < 1000; i++)
            {
                collection.Add(random.Next(-10000, 10000));
            }
            HeapSort<int>.Sort(collection);
            // Assert
            int prevElement = -10001;
            foreach (var element in collection)
            {
                Assert.IsTrue(element >= prevElement);
                prevElement = element;
            }
        }
    }
    [TestClass]
    public class RadixSortTests
    {
        [TestMethod]
        public void RadixSort_Test()
        {
            // Arrange
            var collection = new Collection<int>();
            Random random = new Random();
            // Act

            for (int i = 0; i < 1000; i++)
            {
                collection.Add(random.Next(0, 10000));
            }
            RadixSort.Sort(collection);
            // Assert
            int prevElement = -10001;
            foreach (var element in collection)
            {
                Assert.IsTrue(element >= prevElement);
                prevElement = element;
            }
        }
    }

    [TestClass]
    public class SeparateChainingHashTable
    {
        [TestMethod]
        public void SeparateChainingHashTable_GetAddRemove()
        {
            // Arrange
            var hashTable = new SeparateChainingHashTable<int, string>();
            // Act
            for (int i = 0; i < 100; i++)
            {
                hashTable.Add(i, i.ToString());
            }
            hashTable.Remove(50);
            hashTable.Remove(40);
            // Assert
            for (int i = 0; i < 100; i++)
            {
                if (i != 40 && i != 50)
                    Assert.AreEqual(i.ToString(), hashTable.Get(i));
                else Assert.AreEqual(null, hashTable.Get(i));
            }
        }
    }
}
