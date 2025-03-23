using Moq;
using Stock.Domain;
using Stock.Interfaces;
using Stock.Model.Dto;
using Stock.Model.Entity;
using System;
using System.Threading.Tasks;

namespace Stock.Test
{
    public class MovimentacaoTests
    {
        private Mock<IMovimentacaoRepository> movimentacao = new Mock<IMovimentacaoRepository>();
        private Mock<IProdutoRepository> produto = new Mock<IProdutoRepository>();
        private MovimentacaoDomain service;

        public MovimentacaoTests()
        {
            movimentacao.Reset();
            produto.Reset();
            service = new(movimentacao.Object, produto.Object);
        }

        [Fact]
        public async Task CreateMovimentacao_When_Valid_Request_Should_Succeed()
        {
            // Arrange
            produto.Setup(p => p.GetByCodigo(It.IsAny<string>())).ReturnsAsync(new Produto());
            MovimentacaoCreateRequest request = new() { Quantidade = 1, Tipo = TipoMovimentacao.Entrada, CodigoProduto = "123" };
            // Act
            var result = await service.Create(request);
            //Assert
            Assert.NotNull(result);
            movimentacao.Verify(m => m.Create(It.IsAny<Movimentacao>()), Times.Once);
        }

        [Fact]
        public async Task CreateMovimentacao_When_Invalid_CodigoProduto_Should_Fail()
        {
            // Arrange
            produto.Setup(p => p.GetByCodigo(It.IsAny<string>())).ReturnsAsync((Produto)null);
            MovimentacaoCreateRequest request = new() { Quantidade = 1, Tipo = TipoMovimentacao.Entrada, CodigoProduto = "123" };
            // Act
            async Task act() => await service.Create(request);
            //Assert
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(act);
            Assert.Equal("Código de produto inválido.", ex.Message);
        }

        [Fact]
        public async Task CreateMovimentacao_When_Invalid_Tipo_Should_Fail()
        {
            // Arrange
            produto.Setup(p => p.GetByCodigo(It.IsAny<string>())).ReturnsAsync(new Produto());
            MovimentacaoCreateRequest request = new() { Quantidade = 1, Tipo = (TipoMovimentacao)0, CodigoProduto = "123" };
            // Act
            async Task act() => await service.Create(request);
            //Assert
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(act);
            Assert.Equal("Tipo de movimentação inválido.", ex.Message);
        }

        [Fact]
        public async Task CreateMovimentacao_When_Invalid_Quantidade_Should_Fail()
        {
            // Arrange
            produto.Setup(p => p.GetByCodigo(It.IsAny<string>())).ReturnsAsync(new Produto());
            MovimentacaoCreateRequest request = new() { Quantidade = 0, Tipo = TipoMovimentacao.Entrada, CodigoProduto = "123" };
            // Act
            async Task act() => await service.Create(request);
            //Assert
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(act);
            Assert.Equal("Quantidade deve ser positiva", ex.Message);
        }
    }
}