namespace Pasman.Data.DataSources
{
    public interface IDataSource
    {
        void SaveData();
        string ReadData();
    }
}