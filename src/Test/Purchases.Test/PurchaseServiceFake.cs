using Purchases.API.Models;
using Purchases.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Purchases.Test
{
    public class PurchaseServiceFake : IPurchaseService
    {

        private readonly List<PurchaseItem> _purchase;

        public PurchaseServiceFake()
        {
            _purchase = new List<PurchaseItem>()

            {
                new PurchaseItem() {Id= 1, Name = "Teclado Logitech", Manufacturer = "Logtech", Price = 120M},
                new PurchaseItem() {Id= 2, Name = "Teclado Multilazer", Manufacturer = "Multilazer", Price = 80M},
                new PurchaseItem() {Id= 3, Name = "Monitor LG 23", Manufacturer = "LG", Price = 120M},
                new PurchaseItem() {Id= 4, Name = "HD SSD Asus ", Manufacturer = "Assus", Price = 120M}
            };
        }

        public IEnumerable<PurchaseItem> GetAllItems()
        {
            return _purchase;
        }

        public PurchaseItem Add(PurchaseItem newItem)
        {
            newItem.Id = GetId();
            _purchase.Add(newItem);
            return newItem;
        }

        public PurchaseItem GetById(int id)
        {
            return _purchase.Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public void Remove(int id)
        {
            var item = _purchase.First(a => a.Id == id);
            _purchase.Remove(item);
        }

        static int GetId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }
    }
}
