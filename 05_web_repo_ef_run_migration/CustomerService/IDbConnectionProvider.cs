using System.Data.Common;

namespace Customers;
public interface IDbConnectionProvider
{
    DbConnection GetConnection();
}