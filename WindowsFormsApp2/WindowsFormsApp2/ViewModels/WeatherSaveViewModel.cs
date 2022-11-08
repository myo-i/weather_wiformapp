using DDD.Domain.ValueObjects;
using System;

namespace WindowsFormsApp2.ViewModels
{
    public class WeatherSaveViewModel : ViewModelBase
    {
        public WeatherSaveViewModel()
        {
            DateDataValue = GetDateTime();
            SelectedCondition = Condition.Sunny.Value;
            TemperatureText = String.Empty;
        }
        // AreaIdとConditionはコンボボックスのValueを
        // バインディングするのでobject型
        public object SelectedAreaId { get; set; }
        public DateTime DateDataValue { get; set; }
        public object SelectedCondition { get; set; }
        public string TemperatureText { get; set; }

    }
}
