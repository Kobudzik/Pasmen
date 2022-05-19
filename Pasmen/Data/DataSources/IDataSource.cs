namespace Pasman.Data.DataSources
{
    public interface IDataSource
    {
        public void SaveData();
        public string ReadData();
    }
}