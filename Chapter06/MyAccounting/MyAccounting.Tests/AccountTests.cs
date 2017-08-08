using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAccounting.Model;

namespace MyAccounting.Tests
{
    [TestClass]
    public class AccountTests
    {
        // Listing 6-9 on page 198 is useless to me here and now. Pretend DI populate the property
        public IAccountFactory AccountFactory { get; private set; }

        public AccountTests( /* dependency injected here */)
        {
            AccountFactory = new AccountFactory(); // Not here. Who cares. This is just a test.
        }

        [TestMethod]
        public void AccountShouldHaveInitialBalanceZero()
        {
            // Arrange 
            var sut = AccountFactory.CreateAccount(AccountType.Silver);

            // Act

            // Assert
            Assert.AreEqual(0, sut.Balance);
        }

        [TestMethod]
        public void AccountTransaction100ShouldIncreaseBalance()
        {
            // Arrange 
            var sut = AccountFactory.CreateAccount(AccountType.Silver);

            // Act
            sut.AddTransaction(100m);

            // Assert
            Assert.AreEqual(100m, sut.Balance);
        }

        [TestMethod]
        public void SilverAccountTransactionShouldGenerateRewardPoints()
        {
            // Arrange 
            var sut = AccountFactory.CreateAccount(AccountType.Silver);

            // Act
            sut.AddTransaction(100m);

            Assert.AreEqual(10, sut.RewardPoints);
        }

        [TestMethod]
        public void GoldAccountTransactionShouldGenerateRewardPoints()
        {
            // Arrange 
            var sut = AccountFactory.CreateAccount(AccountType.Gold);

            // Act
            sut.AddTransaction(100m);

            Assert.AreEqual(20, sut.RewardPoints);
        }

        [TestMethod]
        public void PlatiniumAccountTransactionShouldGenerateRewardPoints()
        {
            // Arrange 
            var sut = AccountFactory.CreateAccount(AccountType.Platinum);

            // Act
            sut.AddTransaction(100m);

            Assert.AreEqual(50, sut.RewardPoints);
        }

        [TestMethod]
        public void PlatiniumAccountTransactionsShouldGenerateRewardPoints()
        {
            // Arrange 
            var sut = AccountFactory.CreateAccount(AccountType.Platinum);

            // Act
            sut.AddTransaction(10000m);
            sut.AddTransaction(1000m);

            Assert.AreEqual(5510, sut.RewardPoints);
        }

    }
}
