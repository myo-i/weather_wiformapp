using System.Windows.Forms;
using WindowsFormsApp2.ViewModels;

namespace WindowsFormsApp2.Views
{
    public partial class WeatherListView : Form
    {
        private WeatherListViewModel _viewModel 
            = new WeatherListViewModel();
        public WeatherListView()
        {
            InitializeComponent();

            // WeatherDataGridはWindowsformで生成した画面の(Name)にあたるところ
            WeatherDataGrid.DataBindings.Add(
                "DataSource", _viewModel, nameof(_viewModel.Weathers));
        }
    }
}
