using eShop.CoreBusiness.Models;

namespace eShop.UseCases.ViewProductScreen.Interfaces
{
    public interface IViewProductUseCase
    {
        Product Execute(int id);
    }
}
