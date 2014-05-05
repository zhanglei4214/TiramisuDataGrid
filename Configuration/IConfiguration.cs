using System;
using System.ComponentModel;
using System.Windows.Controls;
using TiramisuDataGrid.EventArgs;

namespace TiramisuDataGrid.Configuration
{
    public interface IConfiguration : INotifyPropertyChanged
    {
        DockPanel Owner { get; set; }

        void Attach();

        void Detach();

        void ResolveDependency(object dependency);
    }
}
