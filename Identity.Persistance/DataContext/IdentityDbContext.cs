﻿using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Persistance.DataContext;

public class IdentityDbContext : DbContext
{
    public  DbSet<User> Users => Set<User>();
    
    public  DbSet<Role> Roles => Set<Role>();
    
    public DbSet<AccessToken> AccessTokens => Set<AccessToken>();

    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
    }
}