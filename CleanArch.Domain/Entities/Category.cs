using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities;

public sealed class Category : Entity
{
    public string Name { get; private set; }

    public Category(string name)
    {
        ValidadeDomain(name);
    }
    public Category(int id, string name)
    {
        DomainExceptionValidation.when(id < 0, "Invalid Id Value");
        Id = id;
        ValidadeDomain(name);
    }

    public void Update(string name)
    {
        ValidadeDomain(name);
    }


    public ICollection<Product> Products { get; set; }

    private void ValidadeDomain(string name)
    {
        DomainExceptionValidation.when(string.IsNullOrEmpty(name), 
            "Invalid name. Name is Required.");
        
        DomainExceptionValidation.when(name.Length < 3, 
            "Invalid name. too short, minimum 3 characteres.");

        Name = name;
    }
}
