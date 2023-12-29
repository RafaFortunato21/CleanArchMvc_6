using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Test;

public class CategoryUnitClass1
{
    [Fact(DisplayName = "Create Category with Valid State")]
    public void CreateCategory_WithValidparameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "CategoryName");
        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category with Invalid ID")]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-10, "CategoryName");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid Id Value");
    }

    [Fact(DisplayName = "Create Category shortName")]
    public void CreateCategory_ShortName_DomainExceptionShortName()
    {
        Action action = () => new Category(1, "ca");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. too short, minimum 3 characteres.");
    }

    [Fact(DisplayName = "Create Category MissingName")]
    public void CreateCategory_MissingNameValue_DomainExceptionMissingName()
    {
        Action action = () => new Category(1, "");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is Required.");
    }

    [Fact(DisplayName = "Create Category WithNullNameValue")]
    public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, "");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is Required.");
    }





}
