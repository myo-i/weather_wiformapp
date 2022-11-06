using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WindowsFormsApp2.ViewModels;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherListViewModelTest
    {
        [TestMethod]
        public void WeatherListScreen()
        {
            var weatherMock = new Mock<IWeatherRepository>();

            var entities = new List<WeatherEntity>();

            entities.Add(new WeatherEntity(
                1,
                "東京",
                Convert.ToDateTime("2018/01/01 12:34:56"),
                2,
                12.3f));

            entities.Add(new WeatherEntity(
                2,
                "神戸",
                Convert.ToDateTime("2018/01/01 12:34:56"),
                2,
                25.21234f));

            weatherMock.Setup(x => x.GetData()).Returns(entities);

            var viewModel = new WeatherListViewModel(weatherMock.Object);
            viewModel.Weathers.Count.Is(2);
            viewModel.Weathers[0].AreaId.Is("1");
            viewModel.Weathers[0].AreaName.Is("東京");
            viewModel.Weathers[0].DateData.Is("2018/01/01 12:34:56");
            viewModel.Weathers[0].Condition.Is("曇り");
            viewModel.Weathers[0].Temperature.Is("12.30 ℃");
        }
    }
}
