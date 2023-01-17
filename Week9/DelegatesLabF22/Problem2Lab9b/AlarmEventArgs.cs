using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2Lab9b
{
    public class AlarmEventArgs :EventArgs
    {
		private int nrings;
		public AlarmEventArgs(int rings )
		{
			NRings = rings;	
		}
		public int NRings
		{
			get { return nrings; }
			set { nrings = value >= 0 ? value: 0 ; }
		}

	}
}
