using DDD.WinForm.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDD.WinForm
{
    public partial class WetherLatestView : Form
    {
        private WetherLatestViewModel _viewModel = new WetherLatestViewModel();

        public WetherLatestView()
        {
            InitializeComponent();

            AreaIdTextBox.DataBindings.Add("Text", _viewModel, nameof(_viewModel.AreaIdText));
            DataDateLabel.DataBindings.Add("Text", _viewModel, nameof(_viewModel.DataDateText));
            ConditionLabel.DataBindings.Add("Text", _viewModel, nameof(_viewModel.ConditionText));
            TemperatureLabel.DataBindings.Add("Text", _viewModel, nameof(_viewModel.TemperatureText));
        }

        private void LatestButton_Click(object sender, EventArgs e)
        {
            _viewModel.Search();

        }

       
    }
}
