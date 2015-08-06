namespace WestWorld2 {
    using System.Collections.Generic;
    using System.Linq;

    internal class PriorityQueue<T> where T:class {
        private int _totalSize;
        private readonly SortedDictionary<double, Queue<T>> _queue = new SortedDictionary<double, Queue<T>>();

        public bool IsEmpty { get { return _totalSize == 0; } }

        public T Dequeue() {
            if (IsEmpty) {
                return null;
            }
            foreach (var queue in _queue.Values.Where(queue => queue.Count > 0)) {
                _totalSize--;
                return queue.Dequeue();
            }
            return null;
        }

        public T Peek() {
            return IsEmpty ? null : (_queue.Values.Where(queue => queue.Count > 0).Select(queue => queue.Peek())).FirstOrDefault();
        }
        public void Enqueue(double priority, T @object){
            if (!_queue.ContainsKey(priority)) {
                _queue.Add(priority, new Queue<T>());
            }
            _queue[priority].Enqueue(@object);
            _totalSize++;
        }
    }
}