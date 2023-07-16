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
            var account = 54321;
            var value = 100;
            var depositValue = 50;
            var expectedValue = 150;

            var contaMock = new Account { Conta = account, Saldo = value };
            _accountServiceMock.Setup(s => s.Deposit(account, depositValue)).ReturnsAsync(() =>
            {
                contaMock.Saldo += depositValue;
                return contaMock;
            });

            // Act
            var result = await _accountMutation.Depositar(account, depositValue, _accountServiceMock.Object);

            // Assert
            Assert.Equal(account, result.Conta);
            Assert.Equal(expectedValue, result.Saldo);
        }

        [Fact]
        public async Task Sacar_ValidValues_ShouldReturnWithdrawnAccount()
        {
            // Arrange
            var conta = 54321;
            var saldoInicial = 300;
            var valorSaque = 60;
            var saldoEsperado = saldoInicial - valorSaque;
            var contaMock = new Account { Conta = conta, Saldo = saldoInicial };
           _accountServiceMock.Setup(s => s.Withdraw(conta, valorSaque)).ReturnsAsync(() =>
            {
                contaMock.Saldo -= valorSaque;
                return contaMock;
            });

            // Act
            var result = await _accountMutation.Sacar(conta, valorSaque, _accountServiceMock.Object);

            // Assert
            Assert.Equal(conta, result.Conta);
            Assert.Equal(saldoEsperado, result.Saldo);
        }

        [Fact]
        public async Task Criar_ValidValue_ShouldReturnCreatedAccount()
        {
            // Arrange
            var conta = 54321;
            var expectedAccount = new Account { Conta = conta, Saldo = 0 };
            _accountServiceMock.Setup(s => s.Create(conta)).ReturnsAsync(expectedAccount);

            // Act
            var result = await _accountMutation.Criar(conta, _accountServiceMock.Object);

            // Assert
            Assert.Equal(conta, result.Conta);
            Assert.Equal(0, result.Saldo);
        }

        [Fact]
        public async Task Deletar_ValidValue_ShouldReturnDeletedAccount()
        {
            // Arrange
            var conta = 54321;
            var expectedAccount = new Account { Conta = conta, Saldo = 0 };
            _accountServiceMock.Setup(s => s.Delete(conta)).ReturnsAsync(expectedAccount);

            // Act
            var result = await _accountMutation.Deletar(conta, _accountServiceMock.Object);

            // Assert
            Assert.Equal(conta, result.Conta);
        }
    }
}