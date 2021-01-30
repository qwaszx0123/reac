using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence
{
    public class DataContext : DbContext
     {
//          00:05:30.210 ~ 00:05:40.230  takes some parameters or a parameter and we need to pass it some DB context options and call it options
//  00:05:40.890 ~ 00:05:45.130  and we also need to use the options from the base class.
//  00:05:45.210 ~ 00:05:50.960  So in order to do this we'll specify base and options as well.
    public DataContext(DbContextOptions options) : base(options)
    {

    }
    //          00:06:02.910 ~ 00:06:12.540  the constructor what we need to pass this is DB set properties or properties of type DV sets and then
    //  00:06:12.540 ~ 00:06:16.430  we specify the entity that we want to use.
    //  00:06:16.440 ~ 00:06:19.370  Now in this case we've only got one entity it's called value.


    //value is entity         values is table name
    public DbSet<Value> Values { get; set; }
    //  00:06:32.220 ~ 00:06:39.210  Now this values property is what's going to be used for the table name inside sequel lights and we'll
    //  00:06:39.210 ~ 00:06:44.550  see that when we actually go ahead and create our database so we have this in place what we need to
    
   protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Value>()
                .HasData(
                    new Value {Id = 1, Name = "Value 101"},
                    new Value {Id = 2, Name = "Value 102"},
                    new Value {Id = 3, Name = "Value 103"}
                );

                // 00:02:45.340 ~ 00:02:51.010  Now what we should be able to see is that when we create another migration this is going to create a
//  00:02:51.010 ~ 00:02:57.480  migration that then attempts to insert these values into our values table.
        }
    
    
    }
    
}
