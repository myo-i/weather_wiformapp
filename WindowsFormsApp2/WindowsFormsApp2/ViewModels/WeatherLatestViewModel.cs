using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using System;
using System.ComponentModel;

namespace WindowsFormsApp2.ViewModels
{
public class WeatherLatestViewModel : ViewModelBase
{
    private IWeatherRepository _weather;

    public WeatherLatestViewModel()
        :this(new WeatherSQLite())
    {
    }

    public WeatherLatestViewModel(IWeatherRepository weather)
    {
        _weather = weather;
    }

        private string _areaIdText = string.Empty;
        public string AreaIdText
        {
            get { return _areaIdText; }
            set
            {
                SetProperty(ref _areaIdText, value);
            }
        }
        private string _dateDataText = string.Empty;
        public string DateDataText
        {
            get { return _dateDataText; }
            set
            {
                SetProperty(ref _dateDataText, value);
            }
        }
        private string _conditionText = string.Empty;
        public string ConditionText
        {
            get { return _conditionText; }
            set
            {
                SetProperty(ref _conditionText, value);
            }
        }
        private string _temperatureText = string.Empty;
        public string TemperatureText
        {
            get { return _temperatureText; }
            set
            {
                SetProperty(ref _temperatureText, value);
            }
        }

    public void Search()
    {
        var entity = _weather.GetLatest(Convert.ToInt32(AreaIdText));
        if (entity != null)
        {
            DateDataText = entity.DateData.ToString();
            ConditionText = entity.Condition.DisplayValue;
            TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
        }

    }

    
}
