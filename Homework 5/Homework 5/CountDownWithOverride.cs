using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5
{
    public class CountDownWithOverride : IEnumerator.CountDown
    {
        public new object Current => position;

        private int position = -1;

        //public override bool MoveNext()
        //{
        //    //this.Current = 2;
        //    position++;
        //    return position <= 16;
        //}

        //public override void Reset()
        //{
        //    this.position = -1;
        //}
    }
}
