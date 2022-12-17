namespace Business.Abstracts
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
    }
}
