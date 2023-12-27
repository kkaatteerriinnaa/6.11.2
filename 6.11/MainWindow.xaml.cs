using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _6._11
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new ViewModel();

            AlphaSlider.ValueChanged += OnSliderValueChanged;
            RedSlider.ValueChanged += OnSliderValueChanged;
            GreenSlider.ValueChanged += OnSliderValueChanged;
            BlueSlider.ValueChanged += OnSliderValueChanged;

            Button button = (Button)this.FindName("Add");
            if (button != null)
            {
                button.Click += OnAddButtonClick;
            }
        }

        private void OnSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (AlphaSlider != null && RedSlider != null && GreenSlider != null && BlueSlider != null)
            {
                Color color = Color.FromArgb((byte)AlphaSlider.Value, (byte)RedSlider.Value, (byte)GreenSlider.Value, (byte)BlueSlider.Value);
                this.Background = new SolidColorBrush(color);
            }
        }


        private void OnAddButtonClick(object sender, RoutedEventArgs e)
        {
            Color color = ((SolidColorBrush)this.Background).Color;
            string colorString = $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
            ListBox listBox = (ListBox)this.FindName("ColorListBox");
            listBox.Items.Add(colorString);
        }
    }
}
