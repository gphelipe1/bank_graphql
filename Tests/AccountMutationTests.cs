using Bank.Model;
using Bank.Services;
using Moq;
using Xunit;

namespace Bank.Tests
{
     public class AccountMutationTests
    {
        private AccountMutation _accountMutation;
        private Mock<IAccountService> _accountServiceMock;

        public AccountMutationTests()
        {
            _accountServiceMock = new Mock<IAccountService>();
            _accountMutation = new AccountMutation();
        }

        [Fact]
        public async Task Depositar_ValidValues_ShouldReturnDepositedAccount()
        {
            // Arrange
            var conta = 54321;
            var valor = 100;
            var expectedAccount = new Account { Conta = conta, Saldo = valor };
            _accountServiceMock.Setup(s => s.Deposit(conta, valor)).ReturnsAsync(expectedAccount);

            // Act
            var result = await _accountMutation.Depositar(conta, valor, _accountServiceMock.Object);

            // Assert
            Assert.Equal(conta, result.Conta);
            Assert.Equal(valor, result.Saldo);
        }

        [Fact]
        public async Task Sacar_ValidValues_ShouldReturnWithdrawnAccount()
        {
            // Arrange
            var conta = 54321;
            var valor = 50;
            var expectedAccount = new Account { Conta = conta, Saldo = valor };
            _accountServiceMock.Setup(s => s.Withdraw(conta, valor)).ReturnsAsync(expectedAccount);

            // Act
            var result = await _accountMutation.Sacar(conta, valor, _accountServiceMock.Object);

            // Assert
            Assert.Equal(conta, result.Conta);
            Assert.Equal(valor, result.Saldo);
        }

        [Fact]
        public async Task Criar_ValidValue_ShouldReturnCreatedAccount()
        {
            // Arrange
            var conta = 54321;
            var expectedAccount = new Account { Conta = conta };
            _accountServiceMock.Setup(s => s.Create(conta)).ReturnsAsync(expectedAccount);

            // Act
            var result = await _accountMutation.Criar(conta, _accountServiceMock.Object);

            // Assert
            Assert.Equal(conta, result.Conta);
        }

        [Fact]
        public async Task Deletar_ValidValue_ShouldReturnDeletedAccount()
        {
            // Arrange
            var conta = 54321;
            var expectedAccount = new Account { Conta = conta };
            _accountServiceMock.Setup(s => s.Delete(conta)).ReturnsAsync(expectedAccount);

            // Act
            var result = await _accountMutation.Deletar(conta, _accountServiceMock.Object);

            // Assert
            Assert.Equal(conta, result.Conta);
        }
    }
}