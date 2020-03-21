using KMA.CSharp2020.Lab03.Tools.DataStorage;

namespace KMA.CSharp2020.Lab03.Tools.Managers
{
    internal static class StationManager
    {
        private static IDataStorage _dataStorage;
        //internal static Person CurrentPerson { get; set; }
        internal static IDataStorage DataStorage { get { return _dataStorage; } }
        internal static void Initialize(IDataStorage dataStorage) { _dataStorage = dataStorage; }
    }
}