using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slides
{
    class FeatureEnvy
    {
        private DateTime DATE;

        public double GetCapital(Loan loan)
        {
            if (loan.Expiry.Equals(DATE)) 
                return loan.Commitment() * loan.Duration() * loan.RiskFactor();

            return loan.RiskAmount() * loan.Duration() * loan.RiskFactor() +
                   loan.UnusedRiskAmount() * loan.Duration() * loan.UnusedRiskFactor();
        }
    }

    internal class Loan
    {
        public Object Expiry
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double Commitment()
        {
            throw new NotImplementedException();
        }

        public int Duration()
        {
            throw new NotImplementedException();
        }

        public double RiskFactor()
        {
            throw new NotImplementedException();
        }

        public double RiskAmount()
        {
            throw new NotImplementedException();
        }

        public double UnusedRiskAmount()
        {
            throw new NotImplementedException();
        }

        public double UnusedRiskFactor()
        {
            throw new NotImplementedException();
        }
    }
}
