﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Exam;

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
                    Assert.AreEqual(redBlackTree.Search(i).Data, new RedBlackTreeNode<int>(i).Data);
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
                    Assert.AreEqual(list.Search(i).Data, new RedBlackTreeNode<int>(i).Data);
                else
                {
                    Assert.AreEqual(list.Search(i), null);
                }
            }
        }

        [TestMethod]
        public void SLcircularList_SmallListTests()
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
    }

}
