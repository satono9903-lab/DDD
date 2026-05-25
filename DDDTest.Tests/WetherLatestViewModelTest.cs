using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.WinForm;
using DDD.WinForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data;

namespace DDDTest.Tests
{
    [TestClass]
    public class WetherLatestViewModelTest
    {
        [TestMethod]
        public void シナリオ()
        {
            var weatherMock = new Mock<IWeatherRepository>();
            weatherMock.Setup(x => x.GetLatest(1))
                .Returns(new WeatherEntity(
                1
                , Convert.ToDateTime("2018/01/01 0:00:00")
                , 2
                , 12.3f));

            weatherMock.Setup(x => x.GetLatest(2))
                .Returns(new WeatherEntity(
                2
                , Convert.ToDateTime("2018/01/01 0:00:00")
                , 1
                , 12.123f));

            var viewModel = new WetherLatestViewModel(weatherMock.Object);
            Assert.AreEqual("", viewModel.AreaIdText);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);
            Assert.AreEqual(2, viewModel.Areas.Count);

            viewModel.AreaIdText = "1";
            viewModel.Search();
            Assert.AreEqual("1", viewModel.AreaIdText);
            Assert.AreEqual("2018/01/01 0:00:00", viewModel.DataDateText);
            Assert.AreEqual("曇り", viewModel.ConditionText);
            Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);

            viewModel.AreaIdText = "2";
            viewModel.Search();
            Assert.AreEqual("2", viewModel.AreaIdText);
            Assert.AreEqual("2018/01/01 0:00:00", viewModel.DataDateText);
            Assert.AreEqual("晴れ", viewModel.ConditionText);
            Assert.AreEqual("12.12 ℃", viewModel.TemperatureText);
        }
    }
}
