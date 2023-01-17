using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5
{
    public interface IEnumerator
    {
        bool MoveNext();
        object Current { get; }
        void Reset();

        public class CountDown : IEnumerator
        {
            public object Current => position;

            private int position = 17;

            bool IEnumerator.MoveNext()
            {
                //this.Current = 2;
                position--;
                return position >= 0;
            }

            void IEnumerator.Reset()
            {
                this.position = 17;
            }
        }
    }
}
