using DDD.Domain.Entities;
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

            // 変な値を入力できないように設定する
            this.AreasComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            this.AreasComboBox.DataBindings.Add(
                "SelectedValue", _viewModel, nameof(_viewModel.SelectedAreaId));
            this.AreasComboBox.DataBindings.Add(
                "DataSource", _viewModel, nameof(_viewModel.Areas));
            // 内部的な値
            this.AreasComboBox.ValueMember = nameof(AreaEntity.AreaId);
            // 外部に見える値
            this.AreasComboBox.DisplayMember = nameof(AreaEntity.AreaName);

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
