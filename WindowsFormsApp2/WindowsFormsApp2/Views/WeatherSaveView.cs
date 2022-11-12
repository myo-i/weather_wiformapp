using DDD.Domain.Entities;
using DDD.Domain.ValueObjects;
using System;
using System.Windows.Forms;
using WindowsFormsApp2.ViewModels;

namespace WindowsFormsApp2.Views
{
    public partial class WeatherSaveView : Form
    {
        private WeatherSaveViewModel _viewModel
            = new WeatherSaveViewModel();

        public WeatherSaveView()
        {
            InitializeComponent();

            // 変な値を入力できないように設定する
            this.AreaIdcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.AreaIdcomboBox.DataBindings.Add(
                "SelectedValue", _viewModel, nameof(_viewModel.SelectedAreaId));
            this.AreaIdcomboBox.DataBindings.Add(
                "DataSource", _viewModel, nameof(_viewModel.Areas));
            // 内部的な値
            this.AreaIdcomboBox.ValueMember = nameof(AreaEntity.AreaId);
            // 外部に見える値
            this.AreaIdcomboBox.DisplayMember = nameof(AreaEntity.AreaName);

            DateTimeTextBox.DataBindings.Add(
                "Value", _viewModel, nameof(_viewModel.DateDataValue));

            this.ConditionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ConditionComboBox.DataBindings.Add(
                "SelectedValue", _viewModel, nameof(_viewModel.SelectedCondition));
            this.ConditionComboBox.DataBindings.Add(
                "DataSource", _viewModel, nameof(_viewModel.Conditions));
            // 内部的な値
            this.ConditionComboBox.ValueMember = nameof(Condition.Value);
            // 外部に見える値
            this.ConditionComboBox.DisplayMember = nameof(Condition.DisplayValue);

            TemperatureTextBox.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureText));
            UnitLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureUnitName));

            SaveButton.Click += (_, __) =>
            {
                try
                {
                    _viewModel.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
        }

    }
}
