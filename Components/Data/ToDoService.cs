using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorWhyUseDbContextFactory.Components.Data
{
    public class ToDoService
    {
        
        // =================================================================
        // Uses DbContextFactory instead of simple DbContext
        //  - make sure Program.cs uses builder.Services.AddDbContextFactory
        // =================================================================
        private readonly IDbContextFactory<AppDbContext> ContextFactory;
        // ================================
        // Design: Inject IDbContextFactory
        // ================================
        public ToDoService(IDbContextFactory<AppDbContext> iDbContextFactory)
        {
            ContextFactory = iDbContextFactory;
        }
        /// <summary>
        /// Get a list of all ToDo items with priority <= priorityFilter  (1=highest priority 3=lowest priority)
        /// </summary>
        public async Task<List<ToDoItem>> GetAllToDoItemsAsync(int priorityFilter)
        {
            using (var ctx = ContextFactory.CreateDbContext())
            {
                return await ctx.ToDoItems.OrderBy(k => k.Priority).Where(k => k.Priority <= priorityFilter).ToListAsync();
            }
        }
        
        /*
        
        // =================================================================
        // Uses DbContext (not a factory)
        //  - make sure Program.cs uses builder.Services.AddDbContext (not AddDbContextFactory)
        // =================================================================
        private readonly AppDbContext dbContext;
        // ================================
        // Design: Inject 
        // ================================
        public ToDoService(AppDbContext iDbContext)
        {
            dbContext = iDbContext;
        }
        /// <summary>
        /// Get a list of all ToDo items with priority <= priorityFilter  (1=highest priority 3=lowest priority)
        /// </summary>
        public async Task<List<ToDoItem>> GetAllToDoItemsAsync(int priorityFilter)
        {
            return await dbContext.ToDoItems.OrderBy(k => k.Priority).Where(k => k.Priority <= priorityFilter).ToListAsync();
        }
        */
    }
}
