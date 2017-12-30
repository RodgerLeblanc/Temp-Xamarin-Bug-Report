using Nevitium.Domain.Entities.Inventory;
using Nevitium.Persistence.Database;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Nevitium.Application.Facades
{
   
    public class InventoryFacade
    { 
        private readonly DatabaseContext _databaseContext;
        public InventoryFacade(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext; 

        }

        public async Task<ObservableCollection<Inventory>> GetAllItemsAsync()
        {
            var items = await Task.Run(() =>
            {
                var result = _databaseContext.Inventory.ToList().OrderBy(x => x.ShortDescription);
                return new ObservableCollection<Inventory>(result);

            });  //profile .ConfigureAwait(false)


            return items;
        }

        public async Task<Inventory> GetByIdAsync(int id)
        {
            var item = await Task.Run(() =>
            {
                var result = _databaseContext.Inventory.FirstOrDefault(x => x.Id == id);

                return result;

            });


            return item;
        }

        public async Task<int> SaveAsync(Inventory inventory)
        {

            if (inventory.InventoryMeta == null)
            {
                inventory.InventoryMeta = new InventoryMeta();
            }

            inventory.InventoryMeta.Modified = DateTime.UtcNow;
            if (inventory.InventoryMeta.Created == null)
            {
                inventory.InventoryMeta.Created = DateTime.UtcNow;
            }

            _databaseContext.Add(inventory);

            var id = await _databaseContext.SaveChangesAsync();

            return id;

        }

        public async Task<ObservableCollection<InventoryImage>> GetInventoryImages(int InventoryId)
        {

            var images = await Task.Run(() =>
            {
                var result = _databaseContext.InventoryImage.Where(i => i.InventoryId == InventoryId).OrderBy(o => o.ZOrder);
                return new ObservableCollection<InventoryImage>(result);
            });


            return images;

        }

        public void Dispose()
        {
            _databaseContext.Dispose();
        }

    }
}
