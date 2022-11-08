using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WindowsFormsApp2.ViewModels;

namespace DDDTest.Tests
{
    [TestClass]
    public class WatherSaveViewModelTest
    {
        [TestMethod]
        public void WeatherRegist()
        {
            var viewModel = new WeatherSaveViewModel();
            viewModel.SelectedAreaId.IsNull();
            viewModel.DateDataValue.Is(
                Convert.ToDateTime("2022/01/01 12:34:56"));
            viewModel.SelectedCondition.Is(1);
            viewModel.TemperatureText.Is("");

        }
    }
}
