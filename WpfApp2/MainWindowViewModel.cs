using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel() { }
        public MainWindowViewModel(MainWindowModel model)
        {
            this._model = model;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        [Bindable(BindableSupport.Yes)]
        [ListBindable(true)]
        public List<string> TableNames { get => _model.TableNames; }

        private readonly MainWindowModel _model = null;

    }
}
