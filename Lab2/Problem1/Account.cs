using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Problem1
{
    /// <summary>
    /// Class Account represents account objects
    /// </summary>
    public class Account
    {
        #region Data Members

        private decimal anualnterestRate;
        private decimal balance;
        private System.DateTime? dateCreated;
        private readonly string ID;
        private const decimal MONTHLY_RATE = 0.01M;

        #endregion

        #region Properties

        public decimal AnualInterestRate
        {
            get => anualnterestRate;
            set { anualnterestRate = value >= 0m ? value : 0; }
        }

        public decimal Balance
        {
            get => this.balance;
            set
            {
                balance = value >= 0m ? value : 0;
            }
        }

        public string? AccountOwner { get; set; }

        public DateTime? DateCreated
        {
            get => dateCreated;
            set
            {
                dateCreated = value != null ? value : DateTime.Now;
            }
        }

        #endregion

        #region Constructors
        public Account()
        {
            this.AnualInterestRate = 0;
            this.Balance = 0;
            this.DateCreated = DateTime.Now;
            this.ID = "12345";
        }

        public Account(decimal anualInterestRate, decimal balance, DateTime? dateCreated, string iD, string? accountOwner)
        {
            this.Balance = balance;
            this.DateCreated = dateCreated;
            this.ID = iD;
            this.AnualInterestRate = anualInterestRate;
            this.AccountOwner = accountOwner;
        }
        /// <summary>
        /// Copy-constructor
        /// </summary>

        public Account(Account account)
        {
            this.AnualInterestRate = account.AnualInterestRate;
            this.Balance = account.balance;
            this.DateCreated = account.dateCreated;
            ID = account.ID;
            this.AccountOwner = account.AccountOwner;
        } 
        #endregion

        #region Utility
        /// <summary>
        /// Adds amountToDeposit top balance
        /// </summary>
        /// <param name="amountToDeposit">Amount to Deposit</param>
        public void Deposit(decimal amountToDeposit)
        {
            if (amountToDeposit >= 0)
            {
                this.Balance += amountToDeposit;
            }
        }

        /// <summary>
        /// Method to withdraw amount of cash
        /// </summary>
        /// <param name="amountToWithdraw"></param>
        /// <returns>Current Balance</returns>
        public decimal Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw >= 0 && amountToWithdraw <= balance)
            {
                this.Balance -= amountToWithdraw;
            }

            return this.Balance;
        } 
        #endregion
    }
}