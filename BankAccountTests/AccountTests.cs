using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account account;
        [TestInitialize]
        public void Initialize()
        {
            account = new Account();
        }
        [TestMethod]
        //[TestCategory("Deposit")]
        [DataRow(10_000)]
        [DataRow(12_045.93)]
        [DataRow(10_000.01)]
        public void Deposit_TooLarge_ThrowsArgumentException(double tooLargeDeposit)
        {
            Assert.ThrowsException<ArgumentException>(() => account.Deposit(tooLargeDeposit));
        }
        [TestMethod()]
        [DataRow(100)]
        [DataRow(9999.99)]
        [DataRow(0.01)]
        public void Deposit_PositiveAmount_AddsToBalance(double initialDeposit)
        {
            /// AAA Arrange Act Assert

            /// Arrange - Creating variables/object
            
            const double startBalance = 0;
            
            /// Act - Execute method under test
            account.Deposit(initialDeposit);

            /// Assert - Check a condition
            Assert.AreEqual(startBalance + initialDeposit, account.Balance);
        }

        [TestMethod]
        public void Deposit_PositiveAmount_ReturnsUpdatedBalance()
        {
            // Arrange
            
            double initialBalance = 0;
            double depositAmount = 10.55;

            // Act
            double newBalance = account.Deposit(depositAmount);

            // Assert
            double expectedBalance = initialBalance + depositAmount;
            Assert.AreEqual(expectedBalance, newBalance);
        }

        [TestMethod]
        public void Deposit_MultipleAmounts_ReturnsAccumulatedBalance()
        {
            // Arrange
            
            double deposit1 = 10;
            double deposit2 = 25;
            double expectedBalance = deposit1 + deposit2;

            // Act

            double intermediateBalance = account.Deposit(deposit1);
            double finalBalance = account.Deposit(deposit2);

            // Assert
            Assert.AreEqual(deposit1, intermediateBalance);
            Assert.AreEqual(expectedBalance, finalBalance);
        }

        [TestMethod]
        public void Deposit_NegativeAmounts_ThrowsArgumentException()
        {
            // Arrange
            
            double negativeDeposit = -1;

           // Assert => Act
            Assert.ThrowsException<ArgumentException>
                (
                   () => account.Deposit(negativeDeposit)
                );      
        }  
    }
}