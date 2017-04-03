using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoService.Models;

namespace TodoService.Helpers
{
    public class TodoContext:DbContext
    {
        public DbSet<Todo> Todos { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=todo.db");
        }
    }
}
