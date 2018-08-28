using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indusoft.LDS.Client.AE.Controls
{
    public interface IAEView
    {
        bool CheckBox1Checked { get; set; }
        bool CheckBox2Checked { get; set; }
        bool EnableCombo1 { get; set; }
        bool EnableCombo2 { get; set; }
        bool EnableCombo3 { get; set; }
        int AESelectedValue { get; set; }
        int DimsSelectedValue { get; set; }
        int[] DataSource1 { get; set; }
        int[] DataSource2 { get; set; }
        int[] DataSource3 { get; set; }
        bool AllValues { get; set; }
        event EventHandler SelectorChanged;
    }
}
