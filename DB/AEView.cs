using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Indusoft.LDS.Client.AE.Controls
{
    public partial class AEView : UserControl, IAEView
    {
        public bool CheckBox1Checked
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }
        public bool CheckBox2Checked
        {
            get { return checkBox2.Checked; }
            set { checkBox2.Checked = value; }
        }
        public bool EnableCombo1
        {
            get { return Combo1.Enabled; }
            set { Combo1.Enabled = value; }
        }
        public bool EnableCombo2
        {
            get { return Combo1.Enabled; }
            set { Combo1.Enabled = value; }
        }
        public bool EnableCombo3
        {
            get { return Combo1.Enabled; }
            set { Combo1.Enabled = value; }
        }
        // TODO
        public int AESelectedValue { get; set; }
        public int DimsSelectedValue { get; set; }
        public int[] DataSource1 { get; set; }
        public int[] DataSource2 { get; set; }
        public int[] DataSource3 { get; set; }
        public bool AllValues
        {
            get { return AllValues.Checked; }
            set { AllValues.Checked = value; }
        }



        public AEView()
        {
            InitializeComponent();
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            checkBox2.CheckedChanged += CheckBox2_CheckedChanged;
        }


        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            SelectorChanged?.Invoke(this, new EventArgs());
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            SelectorChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler SelectorChanged;




    }
}
