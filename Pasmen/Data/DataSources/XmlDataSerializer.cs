using System;
using System.Collections.Generic;

namespace Pasman.Data.DataSources
{
    public class XmlDataSerializer : IDataSerializer
    {
        Dictionary<string, string> IDataSerializer.DeserializeData(string stringData)
        {
            throw new NotImplementedException();
        }

        string IDataSerializer.SerializeData(IDictionary<string, string> dictionary)
        {
            throw new NotImplementedException();
        }
    }
}