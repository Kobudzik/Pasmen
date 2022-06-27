using System.Collections.Generic;

namespace Pasmen.Data.DataSources
{
    public interface IDataSerializer
    {
        string SerializeData(IDictionary<string, string> dictionary);
        Dictionary<string, string> DeserializeData(string stringData);
    }
}