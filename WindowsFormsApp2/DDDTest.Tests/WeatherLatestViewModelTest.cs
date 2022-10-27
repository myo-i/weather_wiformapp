using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp2.ViewModels;
using System;
using DDD.Domain.Repositories;
using System.Data;
using System.Diagnostics;
using DDD.Domain.Entities;
using Moq;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherLatestViewModelTest
    {
        [TestMethod]
        public void シナリオ()
        {
            var weatherMock = new Mock<IWeatherRepository>();
            weatherMock.Setup(x => x.GetLatest(1)).Returns(new WeatherEntity(
                1,
                Convert.ToDateTime("2018/01/01 12:34:56"),
                2,
                12.3f));

            weatherMock.Setup(x => x.GetLatest(2)).Returns(new WeatherEntity(
                2,
                Convert.ToDateTime("2018/01/01 12:34:56"),
                2,
                25.21234f));



            var viewModel = new WeatherLatestViewModel(weatherMock.Object);
            Assert.AreEqual("", viewModel.AreaIdText);
            Assert.AreEqual("", viewModel.DateDataText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);


            viewModel.AreaIdText = "1";
            viewModel.Search();
            Assert.AreEqual("1", viewModel.AreaIdText);
            Assert.AreEqual("2018/01/01 12:34:56", viewModel.DateDataText);
            Assert.AreEqual("曇り", viewModel.ConditionText);
            Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);

            viewModel.AreaIdText = "2";
            viewModel.Search();
            Assert.AreEqual("2", viewModel.AreaIdText);
            Assert.AreEqual("2018/01/01 12:34:56", viewModel.DateDataText);
            Assert.AreEqual("曇り", viewModel.ConditionText);
            Assert.AreEqual("25.21 ℃", viewModel.TemperatureText);

        }
    }

}
