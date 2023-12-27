using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace _6._11
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Color _selectedColor;
        public Color SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                OnPropertyChanged("SelectedColor");
            }
        }

        private ObservableCollection<Color> _colorList;
        public ObservableCollection<Color> ColorList
        {
            get { return _colorList; }
            set
            {
                _colorList = value;
                OnPropertyChanged("ColorList");
            }
        }
        public class RelayCommand : ICommand
        {
            private readonly Action<object> _execute;
            private readonly Predicate<object> _canExecute;

            
            public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute == null || _canExecute(parameter);
            }

            public void Execute(object parameter)
            {
                _execute(parameter);
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
        }

        public ICommand AddColorCommand { get; set; }

        public ViewModel()
        {
            ColorList = new ObservableCollection<Color>();
            AddColorCommand = new RelayCommand(AddColor, CanAddColor);
        }

        private void AddColor(object color)
        {
            ColorList.Add((Color)color);
        }
        private bool CanAddColor(object color)
        {
            return !ColorList.Contains((Color)color);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
