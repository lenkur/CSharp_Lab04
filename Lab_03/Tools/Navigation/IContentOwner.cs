using System.Windows.Controls;

namespace KMA.CSharp2020.Lab03.Tools.Navigation
{
    internal interface IContentOwner
    {
        ContentControl ContentControl { get; }
    }
}
