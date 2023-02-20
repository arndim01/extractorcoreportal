using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ONEConverter.Interfaces
{
    public interface IOneBuild<T>
    {
        IItem<T> Details { get; }
        Task CompileDataTable(string xmlJSON,string ContractId, string AmdId);
    }
}
