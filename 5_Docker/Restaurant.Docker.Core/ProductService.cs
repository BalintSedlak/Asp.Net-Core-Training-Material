using Restaurant.Docker.Core.Exceptions;
using Restaurant.Docker.Infrasturcture.Entities;
using Restaurant.Docker.Infrasturcture.Repository;

namespace Restaurant.Docker.Core;
public class ProductService
{
    private readonly IAsyncRepository<ProductEntity> _productRepository;

    public ProductService(IAsyncRepository<ProductEntity> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductEntity> IncreasePriceForProduct(int id, decimal priceIncreaseInPercent, CancellationToken cancellationToken)
    {
        if (priceIncreaseInPercent == 0)
        {
            string logMessage = string.Format("Error in {0}.{1}: The value of {2} is 0.", nameof(ProductService), nameof(IncreasePriceForProduct), nameof(priceIncreaseInPercent));
            string userFriendlyMessage = "The given value of the increment is not allowed.";

            throw new ServiceException(System.Net.HttpStatusCode.BadRequest, logMessage, userFriendlyMessage);
        }

        if (cancellationToken.IsCancellationRequested)
        {
            // Perform cleanup if necessary.
            // Terminate the operation.
        }

        ProductEntity product = await _productRepository.GetByIdAsync(id, cancellationToken);

        product.UnitPrice += product.UnitPrice * priceIncreaseInPercent;

        await _productRepository.UpdateAsync(product, cancellationToken); //maybe its not necessary

        return product;
    }
}
