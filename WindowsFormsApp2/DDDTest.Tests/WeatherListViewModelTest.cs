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
                Convert.ToDateTime("2018/01/01 12:34:56"),
                2,
                12.3f));

            entities.Add(new WeatherEntity(
                2,
                Convert.ToDateTime("2018/01/01 12:34:56"),
                2,
                25.21234f));

            weatherMock.Setup(x => x.GetData()).Returns(entities);

            var viewModel = new WeatherListViewModel(weatherMock.Object);
            viewModel.Weathers.Count.Is(2);
        }
    }
}
