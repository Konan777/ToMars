using Indusoft.LDS.Controls.Properties;

namespace Indusoft.LDS.Controls.SampleSearchDialog
{
    partial class SampleSearchDialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._gcSearchParams = new DevExpress.XtraEditors.GroupControl();
            this._pceST = new DevExpress.XtraEditors.PopupContainerEdit();
            this._pccST = new DevExpress.XtraEditors.PopupContainerControl();
            this._gcST = new DevExpress.XtraGrid.GridControl();
            this._gvST = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._intervalControl = new Indusoft.LDS.Controls.TimeIntervalControl2();
            this._lblST = new DevExpress.XtraEditors.LabelControl();
            this._gcSearchResults = new DevExpress.XtraEditors.GroupControl();
            this._scc = new DevExpress.XtraEditors.SplitContainerControl();
            this._tl = new DevExpress.XtraTreeList.TreeList();
            this._tlcId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this._tlcCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this._tlcProduct = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this._tcCP = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this._tlcCDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this._gcSampleTestView = new DevExpress.XtraGrid.GridControl();
            this._gvSampleTestView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._gcolTechOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this._gcolTestOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this._gcolTestResultAnalogOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this._gcolTechName = new DevExpress.XtraGrid.Columns.GridColumn();
            this._gcolSampleTechId = new DevExpress.XtraGrid.Columns.GridColumn();
            this._gcolParentTestName = new DevExpress.XtraGrid.Columns.GridColumn();
            this._gcolTestResultId = new DevExpress.XtraGrid.Columns.GridColumn();
            this._gcolTestName = new DevExpress.XtraGrid.Columns.GridColumn();
            this._gcolMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this._gcolReportValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this._gcolEngUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this._llFind = new System.Windows.Forms.LinkLabel();
            this._llClear = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gcSearchParams)).BeginInit();
            this._gcSearchParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pceST.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pccST)).BeginInit();
            this._pccST.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gcST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gvST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gcSearchResults)).BeginInit();
            this._gcSearchResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._scc)).BeginInit();
            this._scc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._tl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gcSampleTestView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gvSampleTestView)).BeginInit();
            this.SuspendLayout();
            // 
            // _bCancel
            // 
            this._bCancel.Location = new System.Drawing.Point(921, 695);
            this._bCancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            // 
            // _bOk
            // 
            this._bOk.Location = new System.Drawing.Point(840, 695);
            // 
            // _btnCustLayout
            // 
            this._btnCustLayout.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this._btnCustLayout.Location = new System.Drawing.Point(12, 695);
            // 
            // _gcSearchParams
            // 
            this._gcSearchParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gcSearchParams.Controls.Add(this._pceST);
            this._gcSearchParams.Controls.Add(this._intervalControl);
            this._gcSearchParams.Controls.Add(this._lblST);
            this._gcSearchParams.Location = new System.Drawing.Point(12, 12);
            this._gcSearchParams.Name = "_gcSearchParams";
            this._gcSearchParams.Size = new System.Drawing.Size(915, 200);
            this._gcSearchParams.TabIndex = 4;
            this._gcSearchParams.Text = "Свойства";
            // 
            // _pceST
            // 
            this._pceST.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pceST.Location = new System.Drawing.Point(107, 24);
            this._pceST.Name = "_pceST";
            this._pceST.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this._pceST.Properties.PopupControl = this._pccST;
            this._pceST.Size = new System.Drawing.Size(796, 22);
            this._pceST.TabIndex = 12;
            // 
            // _pccST
            // 
            this._pccST.Controls.Add(this._gcST);
            this._pccST.Location = new System.Drawing.Point(444, 91);
            this._pccST.Name = "_pccST";
            this._pccST.Size = new System.Drawing.Size(365, 232);
            this._pccST.TabIndex = 10;
            // 
            // _gcST
            // 
            this._gcST.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gcST.Location = new System.Drawing.Point(0, 0);
            this._gcST.MainView = this._gvST;
            this._gcST.Name = "_gcST";
            this._gcST.Size = new System.Drawing.Size(365, 232);
            this._gcST.TabIndex = 1;
            this._gcST.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._gvST});
            // 
            // _gvST
            // 
            this._gvST.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this._gvST.GridControl = this._gcST;
            this._gvST.Name = "_gvST";
            this._gvST.OptionsBehavior.Editable = false;
            this._gvST.OptionsCustomization.AllowColumnMoving = false;
            this._gvST.OptionsCustomization.AllowGroup = false;
            this._gvST.OptionsDetail.EnableMasterViewMode = false;
            this._gvST.OptionsMenu.EnableColumnMenu = false;
            this._gvST.OptionsMenu.EnableFooterMenu = false;
            this._gvST.OptionsMenu.EnableGroupPanelMenu = false;
            this._gvST.OptionsSelection.EnableAppearanceFocusedCell = false;
            this._gvST.OptionsView.RowAutoHeight = true;
            this._gvST.OptionsView.ShowAutoFilterRow = true;
            this._gvST.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this._gvST.OptionsView.ShowGroupPanel = false;
            this._gvST.OptionsView.ShowIndicator = false;
            // 
            // _intervalControl
            // 
            this._intervalControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._intervalControl.Location = new System.Drawing.Point(13, 51);
            this._intervalControl.Name = "_intervalControl";
            this._intervalControl.Size = new System.Drawing.Size(896, 144);
            this._intervalControl.TabIndex = 2;
            // 
            // _lblST
            // 
            this._lblST.Location = new System.Drawing.Point(13, 27);
            this._lblST.Name = "_lblST";
            this._lblST.Size = new System.Drawing.Size(88, 13);
            this._lblST.TabIndex = 0;
            this._lblST.Text = "Шаблон образца:";
            // 
            // _gcSearchResults
            // 
            this._gcSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gcSearchResults.Controls.Add(this._scc);
            this._gcSearchResults.Location = new System.Drawing.Point(12, 218);
            this._gcSearchResults.Name = "_gcSearchResults";
            this._gcSearchResults.Size = new System.Drawing.Size(984, 471);
            this._gcSearchResults.TabIndex = 4;
            this._gcSearchResults.Text = "Результаты поиска";
            // 
            // _scc
            // 
            this._scc.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scc.Horizontal = false;
            this._scc.Location = new System.Drawing.Point(3, 18);
            this._scc.Name = "_scc";
            this._scc.Panel1.Controls.Add(this._tl);
            this._scc.Panel1.Text = "Panel1";
            this._scc.Panel2.Controls.Add(this._gcSampleTestView);
            this._scc.Panel2.Text = "Panel2";
            this._scc.Size = new System.Drawing.Size(978, 450);
            this._scc.SplitterPosition = 85;
            this._scc.TabIndex = 0;
            this._scc.Text = "splitContainerControl1";
            // 
            // _tl
            // 
            this._tl.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this._tlcId,
            this._tlcCode,
            this._tlcProduct,
            this._tcCP,
            this._tlcCDate});
            this._tl.DataSource = null;
            this._tl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tl.Location = new System.Drawing.Point(0, 0);
            this._tl.Name = "_tl";
            this._tl.OptionsBehavior.Editable = false;
            this._tl.OptionsMenu.EnableColumnMenu = false;
            this._tl.OptionsMenu.EnableFooterMenu = false;
            this._tl.OptionsSelection.EnableAppearanceFocusedCell = false;
            this._tl.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            this._tl.OptionsView.ShowIndicator = false;
            this._tl.OptionsView.ShowRoot = false;
            this._tl.Size = new System.Drawing.Size(978, 85);
            this._tl.TabIndex = 0;
            // 
            // _tlcId
            // 
            this._tlcId.FieldName = "Id";
            this._tlcId.Name = "_tlcId";
            // 
            // _tlcCode
            // 
            this._tlcCode.Caption = global::Indusoft.LDS.Controls.Properties.Resources.Code;
            this._tlcCode.FieldName = global::Indusoft.LDS.Controls.Properties.Resources.Code;
            this._tlcCode.Name = "_tlcCode";
            this._tlcCode.OptionsColumn.AllowEdit = false;
            this._tlcCode.OptionsColumn.AllowMove = false;
            this._tlcCode.OptionsColumn.AllowMoveToCustomizationForm = false;
            this._tlcCode.OptionsColumn.ShowInCustomizationForm = false;
            this._tlcCode.Visible = true;
            this._tlcCode.VisibleIndex = 0;
            this._tlcCode.Width = 114;
            // 
            // _tlcProduct
            // 
            this._tlcProduct.Caption = global::Indusoft.LDS.Controls.Properties.Resources.Product;
            this._tlcProduct.FieldName = "Product";
            this._tlcProduct.Name = "_tlcProduct";
            this._tlcProduct.OptionsColumn.AllowEdit = false;
            this._tlcProduct.OptionsColumn.AllowMove = false;
            this._tlcProduct.OptionsColumn.AllowMoveToCustomizationForm = false;
            this._tlcProduct.OptionsColumn.ShowInCustomizationForm = false;
            this._tlcProduct.Visible = true;
            this._tlcProduct.VisibleIndex = 1;
            // 
            // _tcCP
            // 
            this._tcCP.Caption = global::Indusoft.LDS.Controls.Properties.Resources.ControlPoint;
            this._tcCP.FieldName = "CP";
            this._tcCP.Name = "_tcCP";
            this._tcCP.OptionsColumn.AllowEdit = false;
            this._tcCP.OptionsColumn.AllowMove = false;
            this._tcCP.OptionsColumn.AllowMoveToCustomizationForm = false;
            this._tcCP.OptionsColumn.ShowInCustomizationForm = false;
            this._tcCP.Visible = true;
            this._tcCP.VisibleIndex = 2;
            // 
            // _tlcCDate
            // 
            this._tlcCDate.Caption = global::Indusoft.LDS.Controls.Properties.Resources.TakingTime;
            this._tlcCDate.FieldName = "CreationDate";
            this._tlcCDate.Name = "_tlcCDate";
            this._tlcCDate.OptionsColumn.AllowEdit = false;
            this._tlcCDate.OptionsColumn.AllowMove = false;
            this._tlcCDate.OptionsColumn.AllowMoveToCustomizationForm = false;
            this._tlcCDate.OptionsColumn.ShowInCustomizationForm = false;
            this._tlcCDate.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this._tlcCDate.Visible = true;
            this._tlcCDate.VisibleIndex = 3;
            // 
            // _gcSampleTestView
            // 
            this._gcSampleTestView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gcSampleTestView.Location = new System.Drawing.Point(0, 0);
            this._gcSampleTestView.MainView = this._gvSampleTestView;
            this._gcSampleTestView.Name = "_gcSampleTestView";
            this._gcSampleTestView.Size = new System.Drawing.Size(978, 361);
            this._gcSampleTestView.TabIndex = 1;
            this._gcSampleTestView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._gvSampleTestView});
            // 
            // _gvSampleTestView
            // 
            this._gvSampleTestView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this._gcolTechOrder,
            this._gcolTestOrder,
            this._gcolTestResultAnalogOrder,
            this._gcolTechName,
            this._gcolSampleTechId,
            this._gcolParentTestName,
            this._gcolTestResultId,
            this._gcolTestName,
            this._gcolMeasure,
            this._gcolReportValue,
            this._gcolEngUnit});
            this._gvSampleTestView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this._gvSampleTestView.GridControl = this._gcSampleTestView;
            this._gvSampleTestView.Name = "_gvSampleTestView";
            this._gvSampleTestView.OptionsBehavior.Editable = false;
            this._gvSampleTestView.OptionsCustomization.AllowGroup = false;
            this._gvSampleTestView.OptionsCustomization.AllowSort = false;
            this._gvSampleTestView.OptionsMenu.EnableColumnMenu = false;
            this._gvSampleTestView.OptionsMenu.EnableFooterMenu = false;
            this._gvSampleTestView.OptionsMenu.EnableGroupPanelMenu = false;
            this._gvSampleTestView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this._gvSampleTestView.OptionsView.AllowCellMerge = true;
            this._gvSampleTestView.OptionsView.ShowGroupPanel = false;
            this._gvSampleTestView.OptionsView.ShowIndicator = false;
            this._gvSampleTestView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this._gcolTechOrder, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this._gcolTestOrder, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this._gcolTestResultAnalogOrder, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // _gcolTechOrder
            // 
            this._gcolTechOrder.FieldName = "TechOrder";
            this._gcolTechOrder.Name = "_gcolTechOrder";
            this._gcolTechOrder.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            // 
            // _gcolTestOrder
            // 
            this._gcolTestOrder.FieldName = "TestOrder";
            this._gcolTestOrder.Name = "_gcolTestOrder";
            // 
            // _gcolTestResultAnalogOrder
            // 
            this._gcolTestResultAnalogOrder.FieldName = "TestResultAnalogOrder";
            this._gcolTestResultAnalogOrder.Name = "_gcolTestResultAnalogOrder";
            // 
            // _gcolTechName
            // 
            this._gcolTechName.Caption = global::Indusoft.LDS.Controls.Properties.Resources.MVI;
            this._gcolTechName.FieldName = "TechName";
            this._gcolTechName.Name = "_gcolTechName";
            this._gcolTechName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this._gcolTechName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this._gcolTechName.OptionsColumn.AllowMove = false;
            this._gcolTechName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this._gcolTechName.OptionsColumn.ReadOnly = true;
            this._gcolTechName.OptionsFilter.AllowFilter = false;
            this._gcolTechName.Visible = true;
            this._gcolTechName.VisibleIndex = 0;
            // 
            // _gcolSampleTechId
            // 
            this._gcolSampleTechId.Caption = "SampleTechId";
            this._gcolSampleTechId.FieldName = "SampleTechId";
            this._gcolSampleTechId.Name = "_gcolSampleTechId";
            // 
            // _gcolParentTestName
            // 
            this._gcolParentTestName.Caption = global::Indusoft.LDS.Controls.Properties.Resources.Group;
            this._gcolParentTestName.FieldName = "ParentTestName";
            this._gcolParentTestName.Name = "_gcolParentTestName";
            this._gcolParentTestName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this._gcolParentTestName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this._gcolParentTestName.OptionsColumn.AllowMove = false;
            this._gcolParentTestName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this._gcolParentTestName.OptionsColumn.ReadOnly = true;
            this._gcolParentTestName.OptionsFilter.AllowFilter = false;
            this._gcolParentTestName.Visible = true;
            this._gcolParentTestName.VisibleIndex = 1;
            // 
            // _gcolTestResultId
            // 
            this._gcolTestResultId.Caption = "TestResultId";
            this._gcolTestResultId.FieldName = "TestResultId";
            this._gcolTestResultId.Name = "_gcolTestResultId";
            // 
            // _gcolTestName
            // 
            this._gcolTestName.Caption = global::Indusoft.LDS.Controls.Properties.Resources.Identificator;
            this._gcolTestName.FieldName = "TestName";
            this._gcolTestName.Name = "_gcolTestName";
            this._gcolTestName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this._gcolTestName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this._gcolTestName.OptionsColumn.AllowMove = false;
            this._gcolTestName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this._gcolTestName.OptionsColumn.ReadOnly = true;
            this._gcolTestName.OptionsFilter.AllowFilter = false;
            this._gcolTestName.Visible = true;
            this._gcolTestName.VisibleIndex = 2;
            // 
            // _gcolMeasure
            // 
            this._gcolMeasure.Caption = global::Indusoft.LDS.Controls.Properties.Resources.MeasuredValue;
            this._gcolMeasure.FieldName = "Measure";
            this._gcolMeasure.Name = "_gcolMeasure";
            this._gcolMeasure.OptionsColumn.AllowEdit = false;
            this._gcolMeasure.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this._gcolMeasure.OptionsColumn.AllowMove = false;
            this._gcolMeasure.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this._gcolMeasure.OptionsColumn.ReadOnly = true;
            this._gcolMeasure.OptionsFilter.AllowFilter = false;
            this._gcolMeasure.Visible = true;
            this._gcolMeasure.VisibleIndex = 3;
            // 
            // _gcolReportValue
            // 
            this._gcolReportValue.Caption = global::Indusoft.LDS.Controls.Properties.Resources.LastValue;
            this._gcolReportValue.FieldName = "ResultReportValue";
            this._gcolReportValue.Name = "_gcolReportValue";
            this._gcolReportValue.OptionsColumn.AllowEdit = false;
            this._gcolReportValue.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this._gcolReportValue.OptionsColumn.AllowMove = false;
            this._gcolReportValue.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this._gcolReportValue.OptionsColumn.ReadOnly = true;
            this._gcolReportValue.OptionsFilter.AllowFilter = false;
            this._gcolReportValue.Visible = true;
            this._gcolReportValue.VisibleIndex = 4;
            // 
            // _gcolEngUnit
            // 
            this._gcolEngUnit.Caption = global::Indusoft.LDS.Controls.Properties.Resources.MeasureUn;
            this._gcolEngUnit.FieldName = "EngUnit";
            this._gcolEngUnit.Name = "_gcolEngUnit";
            this._gcolEngUnit.OptionsColumn.AllowEdit = false;
            this._gcolEngUnit.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this._gcolEngUnit.OptionsColumn.AllowMove = false;
            this._gcolEngUnit.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this._gcolEngUnit.OptionsColumn.ReadOnly = true;
            this._gcolEngUnit.OptionsFilter.AllowFilter = false;
            this._gcolEngUnit.Visible = true;
            this._gcolEngUnit.VisibleIndex = 5;
            // 
            // _llFind
            // 
            this._llFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._llFind.AutoSize = true;
            this._llFind.Location = new System.Drawing.Point(933, 39);
            this._llFind.Name = "_llFind";
            this._llFind.Size = new System.Drawing.Size(38, 13);
            this._llFind.TabIndex = 5;
            this._llFind.TabStop = true;
            this._llFind.Text = "Найти";
            // 
            // _llClear
            // 
            this._llClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._llClear.AutoSize = true;
            this._llClear.Location = new System.Drawing.Point(933, 61);
            this._llClear.Name = "_llClear";
            this._llClear.Size = new System.Drawing.Size(56, 13);
            this._llClear.TabIndex = 5;
            this._llClear.TabStop = true;
            this._llClear.Text = "Очистить";
            // 
            // SampleSearchDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this._pccST);
            this.Controls.Add(this._gcSearchParams);
            this.Controls.Add(this._gcSearchResults);
            this.Controls.Add(this._llClear);
            this.Controls.Add(this._llFind);
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "SampleSearchDialogForm";
            this.Text = "SampleSearchDialog";
            this.Controls.SetChildIndex(this._llFind, 0);
            this.Controls.SetChildIndex(this._llClear, 0);
            this.Controls.SetChildIndex(this._gcSearchResults, 0);
            this.Controls.SetChildIndex(this._gcSearchParams, 0);
            this.Controls.SetChildIndex(this._pccST, 0);
            this.Controls.SetChildIndex(this._bOk, 0);
            this.Controls.SetChildIndex(this._bCancel, 0);
            this.Controls.SetChildIndex(this._btnCustLayout, 0);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gcSearchParams)).EndInit();
            this._gcSearchParams.ResumeLayout(false);
            this._gcSearchParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pceST.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pccST)).EndInit();
            this._pccST.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gcST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gvST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gcSearchResults)).EndInit();
            this._gcSearchResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._scc)).EndInit();
            this._scc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._tl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gcSampleTestView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gvSampleTestView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl _gcSearchParams;
        private DevExpress.XtraEditors.GroupControl _gcSearchResults;
        private DevExpress.XtraEditors.SplitContainerControl _scc;
        private DevExpress.XtraTreeList.TreeList _tl;
        private DevExpress.XtraEditors.LabelControl _lblST;
        private System.Windows.Forms.LinkLabel _llFind;
        private System.Windows.Forms.LinkLabel _llClear;
        private Indusoft.LDS.Controls.TimeIntervalControl2 _intervalControl;
        private DevExpress.XtraTreeList.Columns.TreeListColumn _tlcId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn _tlcProduct;
        private DevExpress.XtraTreeList.Columns.TreeListColumn _tlcCDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn _tcCP;
        private DevExpress.XtraGrid.GridControl _gcSampleTestView;
        private DevExpress.XtraGrid.Views.Grid.GridView _gvSampleTestView;
        private DevExpress.XtraGrid.Columns.GridColumn _gcolTechOrder;
        private DevExpress.XtraGrid.Columns.GridColumn _gcolTestOrder;
        private DevExpress.XtraGrid.Columns.GridColumn _gcolTestResultAnalogOrder;
        private DevExpress.XtraGrid.Columns.GridColumn _gcolTechName;
        private DevExpress.XtraGrid.Columns.GridColumn _gcolSampleTechId;
        private DevExpress.XtraGrid.Columns.GridColumn _gcolParentTestName;
        private DevExpress.XtraGrid.Columns.GridColumn _gcolTestResultId;
        private DevExpress.XtraGrid.Columns.GridColumn _gcolTestName;
        private DevExpress.XtraGrid.Columns.GridColumn _gcolMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn _gcolReportValue;
        private DevExpress.XtraGrid.Columns.GridColumn _gcolEngUnit;
        private DevExpress.XtraEditors.PopupContainerEdit _pceST;
        private DevExpress.XtraEditors.PopupContainerControl _pccST;
        private DevExpress.XtraGrid.GridControl _gcST;
        private DevExpress.XtraGrid.Views.Grid.GridView _gvST;
        private DevExpress.XtraTreeList.Columns.TreeListColumn _tlcCode;
    }
}