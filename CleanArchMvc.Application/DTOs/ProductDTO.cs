﻿using CleanArchMvc.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMvc.Application.DTOs;

public class ProductDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage ="The name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The Description is required")]
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Description")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "The Price is required")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Price")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The Stock is required")]
    [Range(1,9999)]
    [DisplayName("Stock")]
    public int Stock { get; set; }

    [MaxLength(250)]
    [DisplayName("Image")]
    public string? Image { get; set; }

    [DisplayName("Categories")]
    public int? CategoryId { get; set; }
    public CategoryDTO? Category { get; set; }


}
