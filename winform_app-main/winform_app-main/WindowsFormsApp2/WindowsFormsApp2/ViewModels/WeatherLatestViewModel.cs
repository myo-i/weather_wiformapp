using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using System;
using System.ComponentModel;

namespace WindowsFormsApp2.ViewModels
{
public class WeatherLatestViewModel : INotifyPropertyChanged
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
                if (_areaIdText == value)
                {
                    return;
                }
                _areaIdText = value;
                OnPropertyChanged(nameof(AreaIdText));
            }
        }
        private string _dateDataText = string.Empty;
        public string DateDataText
        {
            get { return _dateDataText; }
            set
            {
                if (_dateDataText == value)
                {
                    return;
                }
                _dateDataText = value;
                OnPropertyChanged(nameof(DateDataText));
            }
        }
        private string _conditionText = string.Empty;
        public string ConditionText
        {
            get { return _conditionText; }
            set
            {
                if (_conditionText == value)
                {
                    return;
                }
                _conditionText = value;
                OnPropertyChanged(nameof(ConditionText));
            }
        }
        private string _temperatureText = string.Empty;
        public string TemperatureText
        {
            get { return _temperatureText; }
            set
            {
                if (_temperatureText == value)
                {
                    return;
                }
                _temperatureText = value;
                OnPropertyChanged(nameof(TemperatureText));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    public void Search()
    {
        var entity = _weather.GetLatest(Convert.ToInt32(AreaIdText));
        if (entity != null)
        {
            DateDataText = entity.DateData.ToString();
            ConditionText = entity.Condition.DisplayValue;
            TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
        }

        OnPropertyChanged("");

    }

    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, 
            new PropertyChangedEventArgs(propertyName));
    }
}
}
