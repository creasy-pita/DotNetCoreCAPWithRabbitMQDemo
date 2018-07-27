using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPublisher
{
    public class MYDbContext:DbContext
    {
        public MYDbContext(DbContextOptions<MYDbContext> options) : base(options)
        {
        }
    }
}
