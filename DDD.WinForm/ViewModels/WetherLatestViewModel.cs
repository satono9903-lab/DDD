using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using DDD.WinForm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WinForm.ViewModels
{
    public class WetherLatestViewModel
    {
        private IWeatherRepository _weather;

        public WetherLatestViewModel(IWeatherRepository weather)
        {
            _weather = weather;
        }

        public string AreaIdText { get; set; } = string.Empty;
        public string DataDateText { get; set; } = string.Empty;
        public string ConditionText { get; set; } = string.Empty;
        public string TemperatureText { get; set; } = string.Empty;

        public void Search()
        {
            var entity = _weather.GetLatest(Convert.ToInt32(AreaIdText));

            if (entity != null)
            {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.ToString();
                TemperatureText =
                    CommonFunc.RoundString(entity.Temperature,
                        Temperature.DecimalPoint) + " "
                        + Temperature.UnitName;
            }
        }
    }
}
