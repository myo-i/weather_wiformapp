using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Helpers;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using DDD.Infrastructure.SQLite;
using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;

namespace WindowsFormsApp2.ViewModels
{
    public class WeatherSaveViewModel : ViewModelBase
    {
        private IWeatherRepository _weather;
        private IAreasRepository _areas;

        public WeatherSaveViewModel()
            :this(new WeatherSQLite(), new AreasSQLite())
        {
        }

        public WeatherSaveViewModel(
            IWeatherRepository weather,
            IAreasRepository areas)
        {
            _weather = weather;
            _areas = areas;

            DateDataValue = GetDateTime();
            SelectedCondition = Condition.Sunny.Value;
            TemperatureText = String.Empty;

            foreach (var area in _areas.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }
        }
        // AreaIdとConditionはコンボボックスのValueを
        // バインディングするのでobject型
        public object SelectedAreaId { get; set; }
        public DateTime DateDataValue { get; set; }
        public object SelectedCondition { get; set; }
        public string TemperatureText { get; set; }
        public BindingList<AreaEntity> Areas { get; set; }
                = new BindingList<AreaEntity>();
        // あくまでConditionが欲しいのはデータの中身ではなく、
        // 入力した際の区分を返す
        public BindingList<Condition> Conditions { get; set; }
        = new BindingList<Condition>(Condition.ToList());
        public string TemperatureUnitName => Temperature.UnitName;

        public void Save()
        {
            Guard.IsNull(SelectedAreaId, "エリアを選択してください");
            var temperature =
                Guard.IsFloat(TemperatureText, "温度を入力してください");

            var entity = new WeatherEntity(
                Convert.ToInt32(SelectedAreaId),
                DateDataValue,
                Convert.ToInt32(SelectedCondition),
                temperature);

            _weather.Save(entity);
        }
    }
}
