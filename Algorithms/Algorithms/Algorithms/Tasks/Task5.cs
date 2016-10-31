using System;

namespace Algorithms
{
    public class Task5
    {
         
    }

    public class Stack
    {
        private int Value { get; set; }

        private Stack NextValue { get; set; }

        public Stack()
        {
        }

        public Stack(int ob)
        {
            this.Value = ob;
        }

        public void Push(int ob)
        {
            var tmp = this.NextValue;
            this.NextValue = new Stack(ob);
            this.NextValue.NextValue = tmp;
        }

        public int Pop()
        {
            if(this.NextValue == null)
                throw new InvalidOperationException();
            var tmp = this.NextValue.Value;
            this.NextValue = this.NextValue.NextValue;
            return tmp;
        }

        public int Peek()
        {
            return this.NextValue.Value;
        }
    }
}