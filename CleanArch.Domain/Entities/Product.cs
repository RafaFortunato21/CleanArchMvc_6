using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image{ get; private set; }

    public Product(string name, string description, decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
    }

    public Product(int id, string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.when(id < 0, "Invalid Id value");
        Id = id;
        ValidateDomain(name, description, price, stock, image);
    }

    public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        CategoryId = categoryId;
    }

    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.when(string.IsNullOrEmpty(name),
            "Invalid name. Name is Required.");

        DomainExceptionValidation.when(name.Length < 3,
            "Invalid name. too short, minimum 3 characteres.");

        DomainExceptionValidation.when(string.IsNullOrEmpty(description),
            "Invalid name. description is Required.");

        DomainExceptionValidation.when(description.Length < 5,
            "Invalid description. too short, minimum 5 characteres.");

        DomainExceptionValidation.when(price < 0,"Invalid price value");
        
        DomainExceptionValidation.when(stock < 0,"Invalid stock value");

        DomainExceptionValidation.when(image?.Length > 250,
            "Invalid iamge name. too long, max 250 characteres.");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;



        Name = name;
    }

    public int? CategoryId { get; set; }
    public Category Category { get; set; }
}
