using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Core.Repository
{
    public class CashMachineValuesRepository : ICashMachineValuesRepository
    {
        private List<int> _machineValues;

        public void AddValues(int[] valueOptions)
        {
            _machineValues = valueOptions.ToList();
        }

        public List<int> GetValues()
        {
            return _machineValues;
        }
    }
}
