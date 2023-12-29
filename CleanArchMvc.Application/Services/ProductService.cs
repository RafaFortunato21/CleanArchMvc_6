using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services;

public class ProductService : IProductService
{

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductService(IMediator mediator,
                          IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        try
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);


            //var productsEntity = await _productRepository.GetProductsAsync();
            //return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar as categorias:" + ex.Message);
        }
    }


    public async Task<ProductDTO> GetById(int? id)
    {
        var productByIdQuery = new GetProductByIdQuery(id.Value);


        if (productByIdQuery == null)
            throw new Exception($"Entity could not be loaded.");

        var result = await _mediator.Send(productByIdQuery);

        return _mapper.Map<ProductDTO>(result);

    }

    //public async Task<ProductDTO> GetProductCategory(int? id)
    //{
    //    var productByIdQuery = new GetProductByIdQuery(id.Value);


    //    if (productByIdQuery == null)
    //        throw new Exception($"Entity could not be loaded.");

    //    var result = await _mediator.Send(productByIdQuery);

    //    return _mapper.Map<ProductDTO>(result);
    //}

    public async Task Add(ProductDTO productDTO)
    {
        var productCreate = _mapper.Map<ProductCreateCommand>(productDTO);
        await _mediator.Send(productCreate);
    }
    public async Task Update(ProductDTO productDTO)
    {
        var productRemoveCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
        await _mediator.Send(productRemoveCommand);
    }


    public async Task Remove(int? id)
    {
        var productRemoveCommand = new ProductRemoveCommand(id.Value);

        if (productRemoveCommand == null)
            throw new Exception($"Entity could not be loaded.");

        await _mediator.Send(productRemoveCommand);

    }



}
