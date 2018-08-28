using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indusoft.LDS.Client.AE.Controls
{
    public class AEController
    {
        private readonly IAEView _view;
        public AEController(IAEView view)
        {
            InitEvents();
        }
        private void InitEvents()
        {
            _view.SelectorChanged += (s, e) => SelectorChanged();
            _view.CheckBox1Checked = true;
            // TODO
            _view.DataSource1 = new int[3];
            _view.DataSource2 = new int[3];
            _view.DataSource3 = new int[3];
        }

        private void SelectorChanged()
        {
            if (_view.CheckBox1Checked)
            {
                _view.EnableCombo1 = true;
                _view.EnableCombo2 = true;
                _view.EnableCombo3 = false;
                _view.CheckBox2Checked = true;
            } else {
                _view.EnableCombo1 = false;
                _view.EnableCombo2 = false;
                _view.EnableCombo3 = true;
                _view.CheckBox2Checked = true;
            }
        }

    }
}
