using System;
using System.Collections;
using System.Collections.Generic;

namespace issue67
{

    public class QueueScript<T> : IEnumerable<T>
    {
        private T[] mArray;
        private int mHead;       // 队列中的第一个元素
        private int mTail;       // 队列中的最后一个元素
        private int mSize;       // 队列大小
        private const int mMinimumGrow = 4;
        private const int mShrinkThreshold = 32;
        private const int mGrowFactor = 200;
        private const int mDefaultCapacity = 4;
        private static T[] mEmptyArray = new T[0];

        public QueueScript()
        {
            mArray = mEmptyArray;
        }

        public QueueScript(int capacity)
        {
            if (capacity < 0)
            {
                throw new IndexOutOfRangeException();
            }

            mArray = new T[capacity];
            mHead = 0;
            mTail = 0;
            mSize = 0;
        }

        public int Count
        {
            get { return mSize; }
        }

        public void Enqueue(T item)
        {
            if (mSize == mArray.Length)
            {
                // 容量每次翻倍
                int newCapacity = mArray.Length * 2;
                if (newCapacity < mArray.Length + mMinimumGrow)
                {
                    newCapacity = mArray.Length + mMinimumGrow;
                }
                SetCapacity(newCapacity);
            }

            mArray[mTail] = item;
            //mArray.Length是大于等于队列的实际数据的，利用除留余数法，获得当前的索引值
            mTail = (mTail + 1) % mArray.Length;
            mSize++;
        }

        public T Dequeue()
        {
            if (mSize == 0)
            {
                throw new InvalidOperationException();
            }

            T removed = mArray[mHead];
            mArray[mHead] = default(T);
            //mArray.Length是大于等于队列的实际数据的，利用除留余数法，获得当前的索引值
            mHead = (mHead + 1) % mArray.Length;
            mSize--;
            return removed;
        }

        public bool Contains(T item)
        {
            int index = mHead;
            int count = mSize;

            EqualityComparer<T> c = EqualityComparer<T>.Default;
            while (count-- > 0)
            {
                if (((Object)item) == null)
                {
                    if (((Object)mArray[index]) == null)
                        return true;
                }
                else if (mArray[index] != null && c.Equals(mArray[index], item))
                {
                    return true;
                }
                //mArray.Length是大于等于队列的实际数据的，利用除留余数法，获得当前的索引值
                index = (index + 1) % mArray.Length;
            }

            return false;
        }

        private void SetCapacity(int capacity)
        {
            T[] newArray = new T[capacity];
            if (mSize > 0)
            {
                if (mHead < mTail)
                {
                    Array.Copy(mArray, mHead, newArray, 0, mSize);
                }
                else
                {
                    Array.Copy(mArray, mHead, newArray, 0, mArray.Length - mHead);
                    Array.Copy(mArray, 0, newArray, mArray.Length - mHead, mTail);
                }
            }

            mArray = newArray;
            mHead = 0;
            mTail = (mSize == capacity) ? 0 : mSize;
        }

        public void Clear()
        {
            if (mHead < mTail)
                Array.Clear(mArray, mHead, mSize);
            else
            {
                Array.Clear(mArray, mHead, mArray.Length - mHead);
                Array.Clear(mArray, 0, mTail);
            }

            mHead = 0;
            mTail = 0;
            mSize = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        internal T GetElement(int i)
        {
            return mArray[(mHead + i) % mArray.Length];
        }


        public struct Enumerator : IEnumerator<T>
        {
            private QueueScript<T> _q;
            private int _index;   // -1 = not started, -2 = ended/disposed
            private T _currentElement;

            internal Enumerator(QueueScript<T> q)
            {
                _q = q;
                _index = -1;
                _currentElement = default(T);
            }

            public void Dispose()
            {
                _index = -2;
                _currentElement = default(T);
            }

            public bool MoveNext()
            {
                if (_index == -2)
                    return false;

                _index++;

                if (_index == _q.mSize)
                {
                    _index = -2;
                    _currentElement = default(T);
                    return false;
                }

                _currentElement = _q.GetElement(_index);
                return true;
            }

            public T Current
            {
                get
                {
                    if (_index < 0)
                    {
                        throw new InvalidOperationException();
                    }
                    return _currentElement;
                }
            }

            Object IEnumerator.Current
            {
                get
                {
                    if (_index < 0)
                    {
                        throw new InvalidOperationException();
                    }
                    return _currentElement;
                }
            }

            void IEnumerator.Reset()
            {
                _index = -1;
                _currentElement = default(T);
            }
        }
    }
}
