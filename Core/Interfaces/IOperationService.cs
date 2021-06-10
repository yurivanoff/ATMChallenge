using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IOperationService
    {
        Dictionary<int, int> Withdraw(int amount);
    }
}
