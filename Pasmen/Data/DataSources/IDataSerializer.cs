using System.Collections.Generic;

namespace Pasman.Data.DataSources
{
    public interface IDataSerializer
    {
        string SerializeData(IDictionary<string, string> dictionary);
        Dictionary<string, string> DeserializeData(string stringData);
    }
}