using Restaurant.Infrasturcture.Entities;
using Restaurant.Infrasturcture.Repository;

namespace Restaurant.Core;
public class ProductService
{
    private readonly IAsyncRepository<ProductEntity> _productRepository;

    public ProductService(IAsyncRepository<ProductEntity> productRepository)
	{
        _productRepository = productRepository;
    }

    public async Task<ProductEntity> IncreasePriceForProduct(int id, decimal priceIncreaseInPercent, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            // Perform cleanup if necessary.
            // Terminate the operation.
        }

        ProductEntity product = await _productRepository.GetByIdAsync(id, cancellationToken);

        product.UnitPrice += product.UnitPrice * priceIncreaseInPercent;

        await _productRepository.UpdateAsync(product, cancellationToken); //I think its not necessary

        return product;
    }
}
