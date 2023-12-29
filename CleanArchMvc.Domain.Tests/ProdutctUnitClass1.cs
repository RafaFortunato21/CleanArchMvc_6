using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Test;

public class ProdutctUnitClass1
{
    [Fact(DisplayName = "Create Product with Valid State")]
    public void CreateProduct_WithValidparameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "ProductName", "Product description", 9.99m, 99, "productImage");
        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(-1, "ProductName", "Product description", 9.99m, 99, "productImage");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }

    [Fact]
    public void CreateProduct_ShorNameValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(1, "pr", "Product description", 9.99m, 99, "productImage");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. too short, minimum 3 characteres.");
    }

    [Fact]
    public void CreateProduct_LongImageName_DomainExceptionLongImagename()
    {
        Action action = () => new Product(1, "product name", "Product description", 9.99m, 99, "productImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImageproductImage");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid iamge name. too long, max 250 characteres.");
    }

    [Fact]
    public void CreateProduct_NullImageName_NullException()
    {
        Action action = () => new Product(1, "product name", "Product description", 9.99m, 99, null);
        action.Should()
            .NotThrow<NullReferenceException>();

    }

    [Fact]
    public void CreateProduct_WithNullImageName_NoDomainException()
    {
        Action action = () => new Product(1, "product name", "Product description", 9.99m, 99, null);
        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_WithEmptyImageName_NoDomainException()
    {
        Action action = () => new Product(1, "product name", "Product description", 9.99m, 99, "");
        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_InvalidPriceVlue_DomainExceptionPriceNegative()
    {
        Action action = () => new Product(1, "product name", "Product description", -9.99m, 99, "asdfasdfasdf");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid price value");
    }



    [Theory]
    [InlineData(-5)]
    public void CreateProduct_InvaldStockValue_DomainExceptionNegativeValue(int value)
    {
        Action action = () => new Product(5, "ProductName", "Product description", 9.99m, value, "productImage");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid stock value");
    }
}
