using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ICashMachineValuesRepository
    {
        void AddValues(int[] valueOptions);
        List<int> GetValues();
    }
}
