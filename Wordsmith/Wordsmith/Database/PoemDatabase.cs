using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordsmith.Models;
using SQLite;

namespace Wordsmith.Database
{
    public class PoemDatabase
    {
        SQLiteAsyncConnection? Database;

        public PoemDatabase()
        { 
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<PoemModel>();

            if (result == CreateTableResult.Created)
            {
                // Insert stock poems
                foreach (PoemModel poem in Constants.StockPoems)
                {
                    await InsertNewPoem(poem);
                }
            }
        }

        public async Task<List<PoemModel>> GetPoemsAsync()
        {
            await Init();
            if (Database is not null)
            {
                return await Database.Table<PoemModel>().ToListAsync();
            }
            return new List<PoemModel>();
        }

        public async Task<PoemModel> GetPoemByID(int ID)
        {
            await Init();
            if (Database is not null)
            {
                return  await Database.Table<PoemModel>().Where(p => p.ID == ID).FirstAsync();
            }
            return new PoemModel();
        }

        public async Task<int> InsertNewPoem(PoemModel poem)
        {
            await Init();
            if (Database is not null)
            {
                return await Database.InsertAsync(poem);
            }
            return 0;
        }

        public async Task<int> DeletePoem(PoemModel poem)
        {
            await Init();
            if (Database is not null)
            {
                return await Database.DeleteAsync(poem);
            }
            return 0;
        }

        public async Task<int> UpdatePoem(PoemModel poem)
        {
            await Init();
            if (Database is not null)
            {
                return await Database.UpdateAsync(poem);
            }
            return 0;
        }

        public async Task<bool> Exists(int id)
        {
            await Init();
            if (Database is not null)
            {
                return await Database.Table<PoemModel>().Where(p => p.ID == id).FirstOrDefaultAsync() != null;
            }
            return false;
        }
    }
}
