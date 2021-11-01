using Purchases.API.Models;

namespace Purchases.API.Services
{
    public interface IPurchaseService
    {
        IEnumerable<PurchaseItem> GetAllItems();
        PurchaseItem Add(PurchaseItem newItem);
        PurchaseItem GetById(int id);
        void Remove(int id);
    }
}
