using SQLite;

namespace DataGridMAUI
{

    public class SQLiteDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public SQLiteDatabase()
        {
            _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            _database.CreateTableAsync<DealerInfo>();
        }

        public async Task<List<DealerInfo>> GetDealerInfosAsync()
        {
            return await _database.Table<DealerInfo>().ToListAsync();
        }

        public async Task<DealerInfo> GetDealerInfoAsync(DealerInfo item) 
        {
            return await _database.Table<DealerInfo>().Where(i => i.ID == item.ID).FirstOrDefaultAsync();
        }

        public async Task<int> AddDealerInfoAsync(DealerInfo item)
        {
            return await _database.InsertAsync(item);
        }

        public Task<int> DeleteDealerInfoAsync(DealerInfo item)
        {
            return _database.DeleteAsync(item);
        }

        public Task<int> UpdateDealerInfoAsync(DealerInfo item)
        {
            if (item.ID != 0)
                return _database.UpdateAsync(item);
            else
                return _database.InsertAsync(item);
        }
    }
}
