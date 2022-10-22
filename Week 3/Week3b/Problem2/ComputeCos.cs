using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class ComputeCos
    {
        #region Properties
        private double accuracy;
        public double Accuracy
        {
            get => accuracy;
            set
            {
                accuracy = (value > 0 && value < 1) ? value : 0.001;
            }
        }
        #endregion

        #region Constructors    
        public ComputeCos()
        {
            accuracy = 0.001;
        }
        public ComputeCos(double accuracy)
        {
            Accuracy = accuracy;
        } 
        #endregion

        /// <summary>
        /// Approximate cosine computation
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double Cosine(double x)
        {
            double result;
            double term;
            int termCounter;

            // initialization
            term = 1;
            result = 1;
            termCounter = 1;

            // processing
            do
            {
                term = -term * x * x / ((2 * termCounter) * (2 * termCounter - 1));
                result += term;
                termCounter++;

            } while (Math.Abs(term) > accuracy);
           
            return result; 

        }
    }
}
