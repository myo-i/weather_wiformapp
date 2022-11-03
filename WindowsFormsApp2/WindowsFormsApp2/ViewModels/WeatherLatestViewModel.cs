using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using System;
using System.ComponentModel;

namespace WindowsFormsApp2.ViewModels
{
    public class WeatherLatestViewModel : ViewModelBase
    {
        private IWeatherRepository _weather;
        IAreasRepository _areas;

        public WeatherLatestViewModel()
            : this(new WeatherSQLite(), new AreasSQLite())
        {
        }

        public WeatherLatestViewModel(
            IWeatherRepository weather, 
            IAreasRepository areas)
        {
            _weather = weather;
            _areas = areas;

            foreach (var area in _areas.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }
        }

        private object _selectedareaId;
        public object SelectedAreaId
        {
            get { return _selectedareaId; }
            set
            {
                SetProperty(ref _selectedareaId, value);
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

        public BindingList<AreaEntity> Areas { get; set; }
        = new BindingList<AreaEntity>();

        public void Search()
        {
            var entity = _weather.GetLatest(Convert.ToInt32(_selectedareaId));
            if (entity != null)
            {
                DateDataText = entity.DateData.ToString();
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }
            else
            {
                DateDataText = string.Empty;
                ConditionText = string.Empty;
                TemperatureText = string.Empty;

            }

        }


    }
}