using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a single checking account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Deposits amount in bank account and returns balance
        /// </summary>
        /// <param name="amount">The amount to be deposited</param>
        /// <returns>Balance</returns>
        public double Deposit(double amount)
        {
            if (amount >= 10000)
            {
                throw new ArgumentException($"{nameof(amount)} must be less than 10000");
            }
            if (amount <= 0)
            {
                throw new ArgumentException($"{nameof(amount)}  must be a positive value");
            }
            Balance += amount;
            return Balance;
        }

        /// <summary>
        /// Get the current balance
        /// </summary>
        public double Balance { get; private set; }

        public void Withdraw(double amount)
        {
               
        }
    }
}
