﻿namespace CustomerService;

public interface IUnitOfWork
{
    //Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
}