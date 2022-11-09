using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;

namespace WindowsFormsApp2.ViewModels
{
    public class WeatherSaveViewModel : ViewModelBase
    {
        private IAreasRepository _areas;

        public WeatherSaveViewModel(IAreasRepository areas)
        {
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
    }
}
