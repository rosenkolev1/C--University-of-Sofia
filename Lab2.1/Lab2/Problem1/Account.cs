using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    /// <summary>
    /// Account of customer
    /// </summary>
    public class Account
    {
        #region Data members
        // Create region ^K ^S
        // Forfmat code ^K ^D
        // Comment  ^K ^C
        // Uncomment  ^K ^U
        private decimal annualInterestRate;
        private decimal balance;
        private DateTime dateCreated;
        private string id;
        private string accountOwner;

        #endregion

        #region Constructors

        // snippet ctor
        public Account(decimal annualInterestRate,
                        decimal balance,
                        DateTime dateCreated,
                        string id,
                        string accountOwner
            )
        {
            AnnualInterestRate = annualInterestRate;
            Balance = balance;
            DateCreated = dateCreated;
            Id = id;
            AccountOwner = accountOwner;
        }
        public Account()
        {
            AnnualInterestRate = 0m;
            Balance = 0m;
            DateCreated = DateTime.Now;
            Id = "dummy id";
            AccountOwner = "unknown owner";
        }


        #endregion

        #region Properties
        public string AccountOwner
        {
            get { return accountOwner; }
            set { accountOwner = value != null ? value : "unknown owner"; }
        }

        /// <summary>
        /// id of account
        /// </summary>
        public string Id
        {
            get => id;
            private set
            {
                id = value != null ? value : "dummy id";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Balance
        {
            get => balance;
            private set
            {
                balance = value >= 0 ? value : 0m;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateCreated
        {
            get => dateCreated;
            set
            {
                dateCreated = value;
            }
        }

        public decimal AnnualInterestRate
        {
            get => annualInterestRate;
            set
            {
                annualInterestRate = value >= 0 ? value : 0.01m;
            }
        }
        #endregion

        #region Utility methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amountToDeposit"> amountg to deposit</param>
        /// <returns>amountToDeposit nonnegative-> True; successful , amountToDeposit negative->False></returns>
        public bool Deposit(decimal amountToDeposit)
        {
            if (amountToDeposit >= 0)
            {
                balance += amountToDeposit;
                return true;
            }
            else
            {
                return false;
            }
        }

        public decimal Withdraw(decimal ammountToWithdraw)
        {
            if (ammountToWithdraw >= 0)
            {
                if (ammountToWithdraw <= balance)
                {
                    balance -= ammountToWithdraw;
                }
            }
            return balance;
        }


        #endregion

    }
}