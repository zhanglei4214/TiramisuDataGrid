using System;
using System.ComponentModel;
using System.Windows.Controls;
using TiramisuDataGrid.EventArgs;

namespace TiramisuDataGrid.Configuration
{
    public interface IConfiguration : INotifyPropertyChanged
    {
        event EventHandler<ConfigurationChangedEventArgs> Changed;

        string Name { get; }

        DockPanel Owner { get; set; }

        void Attach();

        void Detach();

        void SolveDependency(IConfiguration dependency);
    }
}
