using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            var viewModelMock = new Mock<WeatherSaveViewModel>();
            viewModelMock.Setup(x => x.GetDateTime()).Returns(
                Convert.ToDateTime("2022/01/01 12:34:56"));
            var viewModel = viewModelMock.Object;
            viewModel.SelectedAreaId.IsNull();
            viewModel.DateDataValue.Is(
                Convert.ToDateTime("2022/01/01 12:34:56"));
            viewModel.SelectedCondition.Is(1);
            viewModel.TemperatureText.Is("");

        }
    }
}
