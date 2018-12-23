﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumSharp.Core;

namespace NumSharp.UnitTest.Selection
{
    [TestClass]
    public class IndexingTest
    {
        [TestMethod]
        public void IndexAccessorGetter()
        {
            var nd = np.arange(12).reshape(3, 4);

            Assert.IsTrue(nd.Storage.GetData<int>(1, 1) == 5);
            Assert.IsTrue(nd.Storage.GetData<int>(2, 0) == 8);

        }

        [TestMethod]
        public void IndexAccessorSetter()
        {
            var nd = np.arange(12).reshape(3, 4);

            Assert.IsTrue(nd.Storage.GetData<int>(0, 3) == 3);
            Assert.IsTrue(nd.Storage.GetData<int>(1, 3) == 7);

            // set value
            nd.Storage.SetData(10, 0, 0);
            Assert.IsTrue(nd.Storage.GetData<int>(0, 0) == 10);
            Assert.IsTrue(nd.Storage.GetData<int>(1, 3) == 7);
        }
        [TestMethod]
        public void BoolArray()
        {
            NDArray A = new double[] {1,2,3};

            NDArray booleanArr = new bool[]{false,false,true};

            A[booleanArr.MakeGeneric<bool>()] = 1;

            Assert.IsTrue( System.Linq.Enumerable.SequenceEqual(A.Storage.GetData<int>(),new int[] {1,2,1} ));

            A = new double[,] {{1,2,3},{4,5,6}};

            booleanArr = new bool[,] {{true,false,true},{false,true,false}};

            A[booleanArr.MakeGeneric<bool>()] = -2;

            Assert.IsTrue( System.Linq.Enumerable.SequenceEqual(A.Storage.GetData<int>(),new int[] {-2,4,2,-2, -2,6} ));

            
        }
    }
}
