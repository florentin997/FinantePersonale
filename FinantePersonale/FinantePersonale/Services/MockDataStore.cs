using FinantePersonale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinantePersonale.Services
{
    public class MockDataStore : IDataStore<ValueModelCh>
    {
        readonly List<ValueModelCh> items;

        public MockDataStore()
        {
            items = new List<ValueModelCh>()
            {
                //de adaugat datele din DB aici 
            };
        }

        public async Task<bool> AddItemAsync(ValueModelCh item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ValueModelCh item)
        {
            var oldItem = items.Where((ValueModelCh arg) => arg.IdCh == item.IdCh).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((ValueModelCh arg) => arg.IdCh == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ValueModelCh> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.IdCh == id));
        }

        public async Task<IEnumerable<ValueModelCh>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}