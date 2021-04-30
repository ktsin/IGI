using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

namespace WpfApp
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel() {
            this._model = ServicesHolder.Provider.GetRequiredService<MainWindowModel>();
            _model.PropertyChanged += _model_PropertyChanged;
        }

        private void _model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e?.PropertyName);
        }

        public MainWindowViewModel(MainWindowModel model)
        {
            this._model = model;
        }

        private Commands.ChangeDataSourceCommand _changeDB = null;

        public Commands.ChangeDataSourceCommand ChangeDB { 
            get => _changeDB ?? new Commands.ChangeDataSourceCommand();
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public List<string> TableNames { get => _model.TableNames; }

        public string SelectedTable { get => _model.SelectedTable;
            set => _model.SelectedTable = value; }

        public ObservableCollection<object> CurrentTable { get { return _model?.CurrentTable; }
                                                        set => PropertyChanged?.Invoke("CurrentTable", new PropertyChangedEventArgs("CurrentTable")); }

        public void DataViewTable_RowEditEnding(object sender, System.Windows.Controls.DataGridRowEditEndingEventArgs e)
        {

        }

        public bool SaveData(ObservableCollection<object> datas)
        {

            return true;
        }

        private readonly MainWindowModel _model = null;

    }
}
