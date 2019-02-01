using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterDetailsCRUDi.Models;
using MasterDetailsCRUDi.ViewModels;
using Character = MasterDetailsCRUDi.Models.Character;

namespace MasterDetailsCRUDi.Services
{
    public sealed class SQLDataStore : IDataStore
    {

        public void InitializeDatabaseNewTables() {

        }

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static SQLDataStore _instance;

        public static SQLDataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SQLDataStore();
                }
                return _instance;
            }
        }


        private SQLDataStore()
        {
            CreateTables();
        }        
         // Create the Database Tables        
        private void CreateTables()
        { 
            App.Database.CreateTableAsync<Item>().Wait();   
            App.Database.CreateTableAsync<Character>().Wait();
            App.Database.CreateTableAsync<Monster>().Wait();
            App.Database.CreateTableAsync<Score>().Wait();
        }

        private void DeleteTables() {
            App.Database.DropTableAsync<Item>().Wait();
            App.Database.DropTableAsync<Character>().Wait();
            App.Database.DropTableAsync<Monster>().Wait();
            App.Database.DropTableAsync<Score>().Wait();
        }
        public void InitalizeDataBaseNewTables() {
            DeleteTables();
            CreateTables();
            InitilizeSeedData();
            NotifyViewModelsOfDataChange();
        }
        private void NotifyViewModelsOfDataChange() {
            ItemsViewModel.Instance.SetNeedsRefresh(true);
            MonstersViewModel.Instance.SetNeedsRefresh(true);
            CharactersViewModel.Instance.SetNeedsRefresh(true);
            ScoresViewModel.Instance.SetNeedsRefresh(true);
        }

        private async void InitilizeSeedData()
        {
            await AddAsync_Item(new Item { Id = Guid.NewGuid().ToString(), Name = "First item", Description = "This is an item description." });
            await AddAsync_Item(new Item { Id = Guid.NewGuid().ToString(), Name = "Second item", Description = "This is an item description." });
            await AddAsync_Item(new Item { Id = Guid.NewGuid().ToString(), Name = "Third item", Description = "This is an item description." });
            await AddAsync_Item(new Item { Id = Guid.NewGuid().ToString(), Name = "Fourth item", Description = "This is an item description." });
            await AddAsync_Item(new Item { Id = Guid.NewGuid().ToString(), Name = "Fifth item", Description = "This is an item description." });
            await AddAsync_Item(new Item { Id = Guid.NewGuid().ToString(), Name = "Sixth item", Description = "This is an item description." });

            await AddAsync_Character(new Character { Id = Guid.NewGuid().ToString(), Name = "First Character", Description = "This is an Character description.", Age = 23 });
            await AddAsync_Character(new Character { Id = Guid.NewGuid().ToString(), Name = "Second Character", Description = "This is an Character description.", Age = 21 });
            await AddAsync_Character(new Character { Id = Guid.NewGuid().ToString(), Name = "Third Character", Description="This is an Character description." , Age = 42});
            await AddAsync_Character(new Character { Id = Guid.NewGuid().ToString(), Name = "Fourth Character", Description="This is an Character description." , Age = 22});
            //await AddAsync_Character(new Character { Id = Guid.NewGuid().ToString(), Name = "Fifth Character", Description="This is an Character description." , Age = 53});
            //await AddAsync_Character(new Character { Id = Guid.NewGuid().ToString(), Name = "Sixth Character", Description="This is an Character description." , Age = 13});

            await AddAsync_Monster(new Monster { Id = Guid.NewGuid().ToString(), Name = "First Monster", Description="This is an Monster description." });
            await AddAsync_Monster(new Monster { Id = Guid.NewGuid().ToString(), Name = "Second Monster", Description="This is an Monster description." });
            await AddAsync_Monster(new Monster { Id = Guid.NewGuid().ToString(), Name = "Third Monster", Description="This is an Monster description." });
            await AddAsync_Monster(new Monster { Id = Guid.NewGuid().ToString(), Name = "Fourth Monster", Description="This is an Monster description." });
            await AddAsync_Monster(new Monster { Id = Guid.NewGuid().ToString(), Name = "Fifth Monster", Description="This is an Monster description." });
            await AddAsync_Monster(new Monster { Id = Guid.NewGuid().ToString(), Name = "Sixth Monster", Description="This is an Monster description." });

            await AddAsync_Score(new Score { Id = Guid.NewGuid().ToString(), Name = "First Score", ScoreTotal = 111});
            await AddAsync_Score(new Score { Id = Guid.NewGuid().ToString(), Name = "Second Score", ScoreTotal = 222});
            await AddAsync_Score(new Score { Id = Guid.NewGuid().ToString(), Name = "Third Score", ScoreTotal = 333});
            await AddAsync_Score(new Score { Id = Guid.NewGuid().ToString(), Name = "Fourth Score", ScoreTotal = 444});
            await AddAsync_Score(new Score { Id = Guid.NewGuid().ToString(), Name = "Fifth Score", ScoreTotal = 555});
            await AddAsync_Score(new Score { Id = Guid.NewGuid().ToString(), Name = "Sixth Score", ScoreTotal = 666});

        }

        // Item
        public async Task<bool> AddAsync_Item(Item data)
        {
            var result = await App.Database.InsertAsync(data);
            if (result == 1) 
            { 
            return true; 
            }

            return false;
        }

        public async Task<bool> UpdateAsync_Item(Item data)
        {
            var result = await App.Database.UpdateAsync(data);
            if (result == 1)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync_Item(Item data)
        {
                var result = await App.Database.DeleteAsync(data);
                 if (result == 1) 
                 { 
                 return true; 
                 }
                return false;
            }

        public async Task<Item> GetAsync_Item(string id)
        {
            var result = await App.Database.GetAsync<Item>(id); 
            return result;
        }

        public async Task<IEnumerable<Item>> GetAllAsync_Item(bool forceRefresh = false)
        {
                var result = await App.Database.Table<Item>().ToListAsync();
                return result;
                }


        // Character
        public async Task<bool> AddAsync_Character(Character data)
        {
            var result = await App.Database.InsertAsync(data);
             if (result == 1) 
             { 
             return true;
             }
            return false;
        }

        public async Task<bool> UpdateAsync_Character(Character data)
        {
                var result = await App.Database.UpdateAsync(data);
                if (result == 1)
                {
                    return true;
                }
                return false;
            }

        public async Task<bool> DeleteAsync_Character(Character data)
        {
                var result = await App.Database.DeleteAsync(data);
                if (result == 1)
                {
                    return true;
                }
                return false;
            }

        public async Task<Character> GetAsync_Character(string id)
        {
            var result = await App.Database.GetAsync<Character>(id); 
            return result;
        }

        public async Task<IEnumerable<Character>> GetAllAsync_Character(bool forceRefresh = false)
        {
                var result = await App.Database.Table<Character>().ToListAsync();
                return result;
            }


        //Monster
        public async Task<bool> AddAsync_Monster(Monster data)
        {
            var result = await App.Database.InsertAsync(data);
             if (result == 1) 
             { 
             return true; 
             }
            return false;
        }

        public async Task<bool> UpdateAsync_Monster(Monster data)
        {
                var result = await App.Database.UpdateAsync(data);
                if (result == 1)
                {
                    return true;
                }
                return false;
            }

        public async Task<bool> DeleteAsync_Monster(Monster data)
        {
                var result = await App.Database.DeleteAsync(data);
                if (result == 1)
                {
                    return true;
                }
                return false;
            }

        public async Task<Monster> GetAsync_Monster(string id)
        {
            var result = await App.Database.GetAsync<Monster>(id); 
            return result;
        }

        public async Task<IEnumerable<Monster>> GetAllAsync_Monster(bool forceRefresh = false)
        {
                var result = await App.Database.Table<Monster>().ToListAsync();
                return result;
            }

        // Score
        public async Task<bool> AddAsync_Score(Score data)
        {
            var result = await App.Database.InsertAsync(data);
             if (result == 1) { return true; }
            return false;
        }

        public async Task<bool> UpdateAsync_Score(Score data)
        {
                var result = await App.Database.UpdateAsync(data);
                if (result == 1)
                {
                    return true;
                }
                return false;
            }

        public async Task<bool> DeleteAsync_Score(Score data)
        {
                var result = await App.Database.DeleteAsync(data);
                if (result == 1)
                {
                    return true;
                }
                return false;
            }

        public async Task<Score> GetAsync_Score(string id)
        {
            var result = await App.Database.GetAsync<Score>(id);
             return result;
        }

        public async Task<IEnumerable<Score>> GetAllAsync_Score(bool forceRefresh = false)
        {
                var result = await App.Database.Table<Score>().ToListAsync();
                return result;
            }

    }
}