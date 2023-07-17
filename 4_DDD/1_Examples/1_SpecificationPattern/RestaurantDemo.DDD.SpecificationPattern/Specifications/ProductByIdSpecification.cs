using RestaurantDemo.DDD.SpecificationPattern.DB.Entities;

namespace RestaurantDemo.DDD.SpecificationPattern.Specifications;

public class ProductByIdSpecification : Specification<ProductEntity>
{
	public ProductByIdSpecification(int id) : base(product => product.Id == id)
	{
		//AddInclude(product => product.Category);
		//AddInclude(product => product.Supplier);

		//IsSplitQuery = true;
	}
}
