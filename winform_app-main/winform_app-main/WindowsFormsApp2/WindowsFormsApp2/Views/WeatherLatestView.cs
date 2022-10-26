using System;
using System.Windows.Forms;
using WindowsFormsApp2.ViewModels;

namespace WindowsFormsApp2
{
    public partial class WeatherLatestView : Form
    {
        private WeatherLatestViewModel _viewModel
            = new WeatherLatestViewModel();
        public WeatherLatestView()
        {
            InitializeComponent();

            // AreaIdTextBoxのTextプロパティに_viewModelのAreaIdTextがバインディングされる
            // nameofを使わない場合は、this.AreaIdTextBox.DataBindings.Add("Text", _viewModel, "AreaIdText");となる
            this.AreaIdTextBox.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.AreaIdText));
            this.DateDataLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.DateDataText));
            this.ConditionLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.ConditionText));
            this.TemperatureLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureText));
        }


        private void LatestButton_Click(object sender, EventArgs e)
        {
            _viewModel.Search();

        }

    }
}
