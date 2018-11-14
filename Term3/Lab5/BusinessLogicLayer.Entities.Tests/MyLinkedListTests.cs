using BusinessLogicLayer.Entities.MyLinkedList;
using System;
using Xunit;

namespace BusinessLogicLayer.Entities.Tests
{
    public class MyLinkedListTests
    {
        [Fact]
        public void Indexer_GetItemAtIndex0_ReturnsItem()
        {
            //arrange
            int index = 0;
            int expected = 1;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3 };

            //act
            int actual = list[index];

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Indexer_GetItemAtIndexNegative1_ThrowsIndexOutOfRangeException()
        {
            //arrange
            int index = -1;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3 };

            //act

            //assert
            Assert.Throws<IndexOutOfRangeException>(() => list[index]);
        }

        [Fact]
        public void Indexer_GetItemFromEmptyCollection_ThrowsInvalidOperationException()
        {
            //arrange
            int index = 0;
            MyLinkedList<int> list = new MyLinkedList<int>();

            //act

            //assert
            Assert.Throws<InvalidOperationException>(() => list[index]);
        }

        [Fact]
        public void Add_AddOneItemToCollection_CollectionSizeIncreased()
        {
            //arrange
            int item = 0;
            int expected = 1;
            MyLinkedList<int> list = new MyLinkedList<int>();

            //act
            list.Add(item);
            int actual = list.Count;

            //assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Insert_InsertItemAtIndex0_CollectionSizeIncreased()
        {
            //arrange
            int index = 0;
            int item = 0;
            int expected = 1;
            MyLinkedList<int> list = new MyLinkedList<int>();

            //act
            list.Insert(index, item);
            int actual = list.Count;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Insert_InsertItemAtIndex1_CollectionSizeIncreased()
        {
            //arrange
            int index = 1;
            int item = 0;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3 };
            int expected = 4;

            //act
            list.Insert(index, item);
            int actual = list.Count;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Insert_InsertAtNotValidIndex_ThrowsIndexOutOfRangeException()
        {
            //arrange
            int index = -1;
            int item = 0;
            MyLinkedList<int> list = new MyLinkedList<int>();

            //act

            //assert
            Assert.Throws<IndexOutOfRangeException>(() => list.Insert(index, item));
        }

        [Fact]
        public void Remove_RemoveItemFromEmptyList_ThrowsInvalidOperationException()
        {
            //arrange
            int item = 0;
            MyLinkedList<int> list = new MyLinkedList<int>();

            //act

            //assert
            Assert.Throws<InvalidOperationException>(() => list.Remove(item));
        }

        [Fact]
        public void Remove_RemoveExistentItem_ReturnTrue()
        {
            //arrane
            bool expected = true;
            int item = 1;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3 };

            //act
            bool actual = list.Remove(item);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Remove_RemoveLastItemInList_ReturnTrue()
        {
            //arrane
            bool expected = true;
            int item = 3;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3 };

            //act
            bool actual = list.Remove(item);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Remove_RemoveNotexistentItem_ReturnFalse()
        {
            //arrange
            int item = 0;
            bool expected = false;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3 };

            //act 
            bool actual = list.Remove(item);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveAt_RemoveItemFromEmptyList_ThrowsInvalidOperationException()
        {
            //arrange
            int index = 0;
            MyLinkedList<int> list = new MyLinkedList<int>();

            //act 

            //assert
            Assert.Throws<InvalidOperationException>(() => list.RemoveAt(index));
        }

        [Fact]
        public void RemoveAt_RemoveItemAtIndexNegative1_ThrowsIndexOutOfRangeException()
        {
            //arrange
            int index = -1;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3 };

            //act 

            //assert
            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(index));
        }

        [Fact]
        public void RemoveAt_RemoveItemAtIndex3InListOf3Items_ThrowsIndexOutOfRangeException()
        {
            //arrange
            int index = 3;
            MyLinkedList<int> list = new MyLinkedList<int>() { 1, 2, 3 };

            //act 

            //assert
            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(index));
        }
    }
}
