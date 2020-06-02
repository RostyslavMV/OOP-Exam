using System;
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
            foreach(RedBlackTreeNode<int> node in redBlackTree)
            {
                Assert.IsTrue(node.Color ==  NodeColor.Black||node.Color == NodeColor.Red);
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
}
