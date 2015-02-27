#region "Copyright"
/*
FOR FURTHER DETAILS ABOUT LICENSING, PLEASE VISIT "LICENSE.txt" INSIDE THE SAGEFRAME FOLDER
*/
#endregion

#region "References"
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace SageFrame.Scheduler
{  public enum LockingType
    {
        ReaderWriter = 0,
        Exclusive
    }
public class TaskList<T> : IList<T>, IDisposable
    {
        private readonly List<T> _list = new List<T>();
        private ILockStrategy _lockStrategy;

        public TaskList()
            : this(LockingType.ReaderWriter)
        {
        }

        public TaskList(ILockStrategy lockStrategy)
        {
            _lockStrategy = lockStrategy;
        }

        public TaskList(LockingType strategy) : this(LockStrategyFactory.Create(strategy))
        {
        }

        internal IList<T> BackingList
        {
            get
            {
                return _list;
            }
        }

        #region IList<T> Members

        public void Add(T item)
        {
            EnsureNotDisposed();
            EnsureWriteAccess();
            _list.Add(item);
        }

        public void Clear()
        {
            EnsureNotDisposed();
            EnsureWriteAccess();
            _list.Clear();
        }

        public bool Contains(T item)
        {
            EnsureNotDisposed();
            EnsureReadAccess();
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            EnsureNotDisposed();
            EnsureReadAccess();
            _list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                EnsureNotDisposed();
                EnsureReadAccess();
                return _list.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                EnsureNotDisposed();
                EnsureReadAccess();
                return ((ICollection<T>) _list).IsReadOnly;
            }
        }

        public bool Remove(T item)
        {
            EnsureNotDisposed();
            EnsureWriteAccess();
            return _list.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            EnsureNotDisposed();
            EnsureReadAccess();
            return _list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            EnsureNotDisposed();
            EnsureReadAccess();
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            EnsureNotDisposed();
            EnsureWriteAccess();
            _list.Insert(index, item);
        }

        public T this[int index]
        {
            get
            {
                EnsureNotDisposed();
                EnsureReadAccess();
                return _list[index];
            }
            set
            {
                EnsureNotDisposed();
                EnsureWriteAccess();
                _list[index] = value;
            }
        }

        public void RemoveAt(int index)
        {
            EnsureNotDisposed();
            EnsureWriteAccess();
            _list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator1();
        }

        #endregion

        #region "IDisposable Support"

        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // To detect redundant calls

        public void EnsureNotDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException("TaskList");
            }
        }

        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects).
                }

                _lockStrategy.Dispose();
                _lockStrategy = null;
            }
            _isDisposed = true;
        }

        ~TaskList()
        {
            Dispose(false);
        }

        #endregion

        public ILock GetReadLock()
        {
            return GetReadLock(TimeSpan.FromMilliseconds(-1));
        }

        public ILock GetReadLock(TimeSpan timeOut)
        {
            EnsureNotDisposed();
            return _lockStrategy.GetReadLock(timeOut);
        }

        public ILock GetReadLock(int millisecondTimeout)
        {
            return GetReadLock(TimeSpan.FromMilliseconds(millisecondTimeout));
        }

        public ILock GetWriteLock()
        {
            return GetWriteLock(TimeSpan.FromMilliseconds(-1));
        }

        public ILock GetWriteLock(TimeSpan timeOut)
        {
            EnsureNotDisposed();
            return _lockStrategy.GetWriteLock(timeOut);
        }

        public ILock GetWriteLock(int millisecondTimeout)
        {
            return GetWriteLock(TimeSpan.FromMilliseconds(millisecondTimeout));
        }

        private void EnsureReadAccess()
        {
            if (!(_lockStrategy.ThreadCanRead))
            {
                throw new Exception();
            }
        }

        private void EnsureWriteAccess()
        {
            if (!_lockStrategy.ThreadCanWrite)
            {
                throw new Exception();
            }
        }

        public IEnumerator GetEnumerator1()
        {
            return GetEnumerator();
        }
    }
}
