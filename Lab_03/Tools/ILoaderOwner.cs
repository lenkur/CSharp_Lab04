using System.ComponentModel;
using System.Windows;

namespace KMA.CSharp2020.Lab03.Tools
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}