using Moq;
using Stock.Domain;
using Stock.Interfaces;
using Stock.Model.Entity;
using System;
using System.Threading.Tasks;

namespace Stock.Test
{
    public class EstoqueTests
    {
        private Mock<IMovimentacaoRepository> movimentacao = new Mock<IMovimentacaoRepository>();
        private Mock<IProdutoRepository> produto = new Mock<IProdutoRepository>();
        private MovimentacaoDomain service;

        public EstoqueTests()
        {
            movimentacao.Reset();
            produto.Reset();
            service = new(movimentacao.Object, produto.Object);
        }

        [Fact]
        public async Task GetEstoque_When_Valid_Request_Should_Succeed()
        {
            // Arrange
            produto.Setup(p => p.GetByCodigo(It.IsAny<string>())).ReturnsAsync(new Produto());
            // Act
            var result = await service.GetEstoque(new DateTime(), "123");
            //Assert
            Assert.NotNull(result);
            produto.Verify(m => m.GetByCodigo(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task GetEstoque_When_Invalid_CodigoProduto_Should_Fail()
        {
            // Arrange
            produto.Setup(p => p.GetByCodigo(It.IsAny<string>())).ReturnsAsync((Produto)null);
            // Act
            async Task act() => await service.GetEstoque(new DateTime(), "123");
            //Assert
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(act);
            Assert.Equal("Código de produto inválido.", ex.Message);
        }
    }
}