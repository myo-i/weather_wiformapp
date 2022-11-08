using System;

namespace WindowsFormsApp2.ViewModels
{
    public class WeatherSaveViewModel : ViewModelBase
    {
        public WeatherSaveViewModel()
        {
            DateDataValue = DateTime.Now;
        }
        // AreaIdとConditionはコンボボックスのValueを
        // バインディングするのでobject型
        public object SelectedAreaId { get; set; }
        public DateTime DateDataValue { get; set; }
        public object SelectedCondition { get; set; }
        public string TemperatureText { get; set; }
    }
}
