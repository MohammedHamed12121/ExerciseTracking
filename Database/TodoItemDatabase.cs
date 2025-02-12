using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace ExerciceTracking.Database
{

    public class TodoItem
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
    }

    public class TodoItemDatabase
    {
        SQLiteAsyncConnection Database;

        public TodoItemDatabase()
        {
        }

        async Task Init()
        {
            if(Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<TodoItem>();
        }


        public async Task<List<TodoItem>> GetItems()
        {
            await Init();

            // @nullchecking: Make a DatabaseResponse object to return the data , flag for success or not as well as the a message if failed
            return await Database.Table<TodoItem>().ToListAsync();
        }

        public async Task<int> SaveItemAsync(TodoItem item)
        {
            await Init();
            if(item.Id != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }
    }
}