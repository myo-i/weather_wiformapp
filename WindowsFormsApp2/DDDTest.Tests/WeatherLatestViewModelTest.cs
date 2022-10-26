using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp2.ViewModels;
using System;
using DDD.Domain.Repositories;
using System.Data;
using System.Diagnostics;
using DDD.Domain.Entities;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherLatestViewModelTest
    {
        [TestMethod]
        public void シナリオ()
        {


            var viewModel = new WeatherLatestViewModel(new WeatherMock());
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

        }
    }

    internal class WeatherMock : IWeatherRepository
    {
        public WeatherEntity GetLatest(int areaId)
        {
            return new WeatherEntity(1,
                Convert.ToDateTime("2018/01/01 12:34:56"),
                2,
                12.3f);


        }
    }
}
