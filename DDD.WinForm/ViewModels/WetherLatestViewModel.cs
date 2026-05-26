using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using DDD.Infrastructure.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDD.WinForm.ViewModels
{
    public class WetherLatestViewModel : ViewModelBase
    {
        private IWeatherRepository _weather;

        public WetherLatestViewModel()
            : this(new WetherSQLite())
        {
        }

        public WetherLatestViewModel(IWeatherRepository weather)
        {
            _weather = weather;
        }

        private string _areaIdText = string.Empty;
        public string AreaIdText
        {
            get => _areaIdText;
            set
            {
                SetProperty(ref _areaIdText, value);
            }
        }
        private string _dataDateText = string.Empty;
        public string DataDateText
        {
            get => _dataDateText;
            set
            {
                SetProperty(ref _dataDateText, value);
            }
        }
        private string _conditionText = string.Empty;
        public string ConditionText
        {
            get => _conditionText;
            set
            {
                SetProperty(ref _conditionText, value);
            }
        }
        private string _temperatureText = string.Empty;
        public string TemperatureText
        {
            get => _temperatureText;
            set
            {
                SetProperty(ref _temperatureText, value);
            }
        }

        public BindingList<AreaEntity> Areas { get; set; } = new BindingList<AreaEntity>();

        public void Search()
        {
            var entity = _weather.GetLatest(Convert.ToInt32(AreaIdText));

            if (entity != null)
            {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }
        }
    }
}
