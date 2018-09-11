C:\!Indus\Branches\Malahit_BMU\Source\Indusoft.LDS.Client.AnalysisInputControl\Controls\Model\SampleInfo.cs
        private bool ShowInternalControlSampleDialog(Guid taskUid)
        {
            var taskContentSecurity = DataManager.Instance.IntControlService.GetTaskContentSecurity(_taskContents.Single().TaskContentUid);

            using (var propDlg = new CheckProcSamplePropertyDialog())
            {
                _checkProc = DataManager.Instance.IntControlService.GetCheckProcByTaskUid(taskUid);
                if (_checkProc == null)
                {
                    _checkProc = CheckProc.CreateInstance();
                    _checkProc.Insert();
                    _checkProc.CheckProcUid = DataManager.Instance.GuidGenerator.NewSequentialId();
                    _checkProc.CheckProcInfoUid = CheckProcInfo.CheckProcInfoUid;
                    _checkProc.StatusId = DataManager.Instance.GetStatusByCode("CheckProcWorking").StatusId;
                    _checkProc.CreationDate = _creationDate;
                    _checkProc.ProcInfo = CheckProcInfo;
                }

                var prop = CheckProcTask.Props.Find(a =>
                    a.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.ChkSUid ||
                    a.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.AEBatchUid);
                if (prop != null && _checkProc.CheckProcChkS == null)
                {
                    var cs = CheckProcChkS.CreateInstance();
                    cs.Insert();
                    cs.CheckProcUid = _checkProc.CheckProcUid;
                    // Заполняем ссылку на ОК или Партию ОУ
                    if (prop.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.ChkSUid)
                        cs.ChkSUid = !prop.Value.IsNullOrEmpty() ? new Guid(prop.Value) : (Guid?)null;
                    else
                        cs.AEBatchUid = !prop.Value.IsNullOrEmpty() ? new Guid(prop.Value) : (Guid?)null;

                    _checkProc.CheckProcChkS = cs;
                }

                // Свойство с количеством объекта учета для списания
                prop = CheckProcTask.Props.Find(a =>
                    a.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.AEBatchQuantitySpendingUid);
                if (prop != null)
                {
                    var cs = _checkProc.CheckProcChkS;
                    if (cs == null)
                    {
                        cs = CheckProcChkS.CreateInstance();
                        cs.Insert();
                        cs.CheckProcUid = _checkProc.CheckProcUid;
                    }
                    cs.AEBatchQuantitySpending = (!prop.Value.IsNullOrEmpty()) ? DoubleUtils.DoubleFromString(prop.Value) : 0; // иначе ставим 0, чтобы не прошла валидация

                    // Заполняем ссылку на ед.изм.
                    var engUnitProp = CheckProcTask.Props.Find(a =>
                        a.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.AEBatchSpendingEngUnitUid);
                    if (engUnitProp != null)
                    {
                        int res;
                        if (int.TryParse(engUnitProp.Value, out res))
                            cs.AEBatchSpendingEngUnitUid = res;
                    }
                }

                // Свойство с характеристиками партии ОУ
                prop = CheckProcTask.Props.Find(a =>
                    a.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.AEBatchTestUid);
                if (prop != null && !prop.Value.IsNullOrEmpty())
                {
                    var cs = _checkProc.CheckProcChkS;
                    if (cs == null)
                    {
                        cs = CheckProcChkS.CreateInstance();
                        cs.Insert();
                        cs.CheckProcUid = _checkProc.CheckProcUid;
                    }
                    cs.AEBatchTestUid = new Guid(prop.Value);
                }

                // Свойства с характеристикими раствора
                prop = CheckProcTask.Props.Find(a =>
                    a.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.AEBatchTestValueUid);
                if (prop != null)
                {
                    var cs = _checkProc.CheckProcChkS;
                    if (cs == null)
                    {
                        cs = CheckProcChkS.CreateInstance();
                        cs.Insert();
                        cs.CheckProcUid = _checkProc.CheckProcUid;
                    }
                    // Значение характеристики
                    if (!prop.Value.IsNullOrEmpty())
                        cs.AEBatchTestValue = DoubleUtils.DoubleFromString(prop.Value);

                    // Абсолютная погрешность
                    var nextProp = CheckProcTask.Props.Find(a =>
                        a.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.AEBatchTestAbsErrUid);

                    if (nextProp != null && !nextProp.Value.IsNullOrEmpty())
                        cs.AEBatchTestAbsErr = DoubleUtils.DoubleFromString(nextProp.Value);

                    // Относительная погрешность
                    nextProp = CheckProcTask.Props.Find(a =>
                        a.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.AEBatchTestRelErrUid);
                    if (nextProp != null && !nextProp.Value.IsNullOrEmpty())
                        cs.AEBatchTestRelErr = DoubleUtils.DoubleFromString(nextProp.Value);
                }

                if (CheckProcTask.Props.Any(a => a.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.CheckProcTechTestUid) && _checkProc.CheckProcTechTest == null)
                {
                    var cs = CheckProcTechTest.CreateInstance();
                    cs.Insert();
                    cs.CheckProcUid = _checkProc.CheckProcUid;
                    cs.TechTestUid = new Guid(CheckProcTask.Props.Find(a => a.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.CheckProcTechTestUid).Value);
                    _checkProc.CheckProcTechTest = cs;
                }

                prop = CheckProcTask.Props.Find(a => a.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.Addition);
                if (prop != null && !string.IsNullOrEmpty(prop.Value) && _checkProc.CheckProcAddition == null)
                {
                    var cs = CheckProcAddition.CreateInstance();
                    cs.Insert();
                    cs.CheckProcUid = _checkProc.CheckProcUid;
                    cs.Addition = DoubleUtils.DoubleFromString(prop.Value);
                    _checkProc.CheckProcAddition = cs;
                }

                prop = CheckProcTask.Props.Find(a => a.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.Dilution);
                if (prop != null && !string.IsNullOrEmpty(prop.Value) && _checkProc.CheckProcDilution == null)
                {
                    var cs = CheckProcDilution.CreateInstance();
                    cs.Insert();
                    cs.CheckProcUid = _checkProc.CheckProcUid;
                    cs.Dilution = DoubleUtils.DoubleFromString(prop.Value);
                    _checkProc.CheckProcDilution = cs;
                }

                prop = CheckProcTask.Props.Find(a => a.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.DilutionAEBatchUid);
                if (prop != null && !prop.Value.IsNullOrEmpty())
                {
                    var cs = _checkProc.CheckProcDilution;
                    if (cs == null)
                    {
                        cs = CheckProcDilution.CreateInstance();
                        cs.Insert();
                        cs.CheckProcUid = _checkProc.CheckProcUid;
                        _checkProc.CheckProcDilution = cs;
                    }

                    cs.AEBatchUid = !prop.Value.IsNullOrEmpty() ? new Guid(prop.Value) : (Guid?)null;

                    prop = CheckProcTask.Props.Find(a => a.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.DilutionAEBatchQuantitySpendingUid);
                    if (prop != null && !prop.Value.IsNullOrEmpty())
                    {
                        cs.AEBatchQuantitySpending = DoubleUtils.DoubleFromString(prop.Value);
                    }

                    prop = CheckProcTask.Props.Find(a => a.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.DilutionAEBatchSpendingEngUnitUid);
                    if (prop != null && !prop.Value.IsNullOrEmpty())
                    {
                        int res;
                        if (int.TryParse(prop.Value, out res))
                            cs.AEBatchSpendingEngUnitUid = res;
                    }
                }

                prop = CheckProcTask.Props.Find(a => a.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.ControlMode);
                if (prop != null && !string.IsNullOrEmpty(prop.Value) && prop.Value == "1")
                {
                    _checkProc.Flags |= (int)CheckProcFlags.HardControl;
                }

                var cpSamples = DataManager.Instance.IntControlService.GetCheckProcSamples(_checkProc.CheckProcUid).OrderByDescending(a => a.RegistrationDate).ThenBy(a => a.RepControlStatusId);
                _cpSample = cpSamples.SingleOrDefault(a => a.TaskUid == taskUid);

                var scheme = DataManager.Instance.IntControlManager.GetCheckProcScheme(CheckProcInfo.CheckProcSchemeUid);
                if (scheme.FixedSamplesOrder)
                {
                    Status authorizedStatus = DataManager.Instance.GetStatusByCode(RS.Statuses.SampleAutorized);
                    Status repControlSuccessStatus = DataManager.Instance.GetStatusByCode("RepeatabilityControl.Success");
                    foreach (var schemeSample in scheme.Samples)
                    {
                        if (_cpSample != null && schemeSample.Tag == _cpSample.CheckProcSchemeSampleId)
                            break;

                        var cpSample = cpSamples.FirstOrDefault(a => a.CheckProcSchemeSampleId == schemeSample.Tag && a.TaskUid != taskUid);
                        if (cpSample == null)
                            break;

                        if (cpSample.SampleStatusId != authorizedStatus.StatusId)
                        {
                            MsgBox.ShowError(string.Format(Resources.FirstYouHaveToAutorizate, schemeSample.Name));
                            return false;
                        }

                        if (cpSample.RepControlStatusId.HasValue && cpSample.RepControlStatusId.Value != repControlSuccessStatus.StatusId)
                        {
                            MsgBox.ShowError(string.Format(Resources.PreviousTestIsNotSuitableForCalculations));
                            return false;
                        }
                    }
                }

                if (_cpSample == null)
                {
                    _cpSample = CheckProcSample.CreateInstance();
                    _cpSample.Insert();
                    _cpSample.CheckProcSampleUid = DataManager.Instance.GuidGenerator.NewSequentialId();
                    _cpSample.CheckProcUid = _checkProc.CheckProcUid;
                    _cpSample.TaskUid = taskUid;
                    _cpSample.CheckProcSchemeSampleId = -1;
                }
                _cpSample.SampleUid = SampleId;

                var mode = ChkSMode.ChkS;
                var task = DataManager.Instance.TaskService?.GetTask(taskUid);
                if (task != null)
                {
                    var ext = DataManager.Instance.TaskEM?.GetTaskExtension(task.ExtensionUid);
                    var settings = (ext as ISettingsSupport)?.Settings;
                    if (settings != null && settings is ChkSModeSettings)
                    {
                        mode = (settings as ChkSModeSettings).Mode;
                    }
                }

                // Извлечение настроек внутрилабораторного контроля
                var ic = DataManager.Instance.GetTaskExtensionInfo(Services.Contracts.IC.RS.Guids.InternalControlTaskExtensionUid);
                var icSettings = (ic as ISettingsSupport)?.Settings;
                var chksModeSettingEx = (icSettings as IInternalControlTaskExtensionSettings)?.ChkSModeSettingsEx ?? new ChkSModeSettingsEx();

                propDlg.Init(taskContentSecurity, CheckProcTask, _checkProc, _cpSample, mode, chksModeSettingEx);

                if (propDlg.ShowDialog() != DialogResult.OK)
                    return false;
if (propDlg.SampleUid != null)
{

    DataManager.Instance.TaskService.SetTaskResultKey(task.TaskUid, propDlg.SampleUid);
    task.ResultKey = propDlg.SampleUid;

    var checkProcInfo = DataManager.Instance.GetCheckProcInfoByUid(CheckProcTask.CheckProcInfoUid);
    var CheckProcWorkingStatus = DataManager.Instance.RepositoryDataService.GetStatus(null, "CheckProcWorking");

    _cpSample.SampleUid = propDlg.SampleUid;

    DataManager.Instance.IntControlService.CheckProcInsert(ref _checkProc); 
    DataManager.Instance.IntControlService.CheckProcSampleInsert(ref _cpSample);

    LabAnalysisTaskManager.Instance.RefreshTask(taskUid, false);

    return false;
}

                if (propDlg.ChangeSecurityOnly)
                {
                    DataManager.Instance.IntControlService.ChangeTaskContentSecurity(taskContentSecurity.TaskContentUid, propDlg.SelectedUserId, propDlg.SelectedRoleUid);

                    LabAnalysisTaskManager.Instance.RefreshTask(taskUid, false);
                    return false;
                }
            }
            return true;
        }





C:\!Indus\Branches\Malahit_BMU\Source\Indusoft.LDS.Client.AnalysisInputControl\Dialogs\CheckProcSamplePropertyDialog.cs
        public void Init(TaskContentSecurity contentSecurity, CheckProcTask task, CheckProc checkProc, CheckProcSample cpSample, ChkSMode mode, IChkSModeSettingsEx icSettings)
        {
            _mode = mode;
            _checkProcTask = task;
            _checkProc = checkProc;
            _cpSample = cpSample;
            _icSettings = icSettings;

            var roleId = contentSecurity == null ? task.RoleId : contentSecurity.RoleId;
            var userId = contentSecurity == null ? task.UserId : contentSecurity.UserId;

            _gleRole.Properties.DataSource = DataManager.Instance.GetRoles();
            _gleUser.Properties.DataSource = DataManager.Instance.RepositoryDataService.GetUsersForSubdivision(_checkProc.ProcInfo.SubdivisionId).Where(a => a.Enable).ToList();

            if (roleId.HasValue)
            {
                _rbRole.Checked = true;
                _rbUser.Checked = false;
                _gleRole.EditValue = roleId.Value;
            }

            if (userId.HasValue)
            {
                _rbRole.Checked = false;
                _rbUser.Checked = true;
                _gleUser.EditValue = userId.Value;
            }

            _forbidPropChange = _checkProcTask.ForbidPropChange;
            // Если был назначен другой исполнитель, разрешить изменение параметров КП
            if (contentSecurity != null && (contentSecurity.RoleId != task.RoleId || contentSecurity.UserId != task.UserId))
            {
                _forbidPropChange = false;
            }

            UpdateControlsState();

            _scheme = DataManager.Instance.IntControlManager.GetCheckProcScheme(checkProc.ProcInfo.CheckProcSchemeUid);
            if(_scheme == null)
                throw new Exception("CheckProcScheme not found");

            if (_cpSample.IsInserted)
            {
                var samples = DataManager.Instance.IntControlService.GetCheckProcSamples(_checkProc.CheckProcUid);

                foreach (var sample in _scheme.Samples)
                {
                    if (samples.Any(a => a.CheckProcSchemeSampleId == sample.Tag)) continue;

                    _cbSampleTag.Properties.Items.Add(new SchemeSampleInfo(sample));
                }

                _cbSampleTag.Properties.ReadOnly = _scheme.FixedSamplesOrder;
            }
            else
            {
                var schemeSample = _scheme.Samples.Single(a => a.Tag == _cpSample.CheckProcSchemeSampleId);
                _cbSampleTag.Properties.Items.Add(new SchemeSampleInfo(schemeSample));
                _cbSampleTag.Properties.ReadOnly = true;
            }

            _cbSampleTag.SelectedIndex = 0;
// Только если выбран контрольный образец
if (((SchemeSampleInfo)_cbSampleTag.Properties.Items[_cbSampleTag.SelectedIndex]).Sample.Tag == 0) 
{
    if (task.Props.Any(a => a.PropUid == IC.Common.RS.CheckProcSeriesTaskProps.WorkSample && a.Value == "1"))
    {
        var checkProcInfo = DataManager.Instance.GetCheckProcInfoByUid(task.CheckProcInfoUid);
        if (_cWorkProbe.ProcSchemeIsCorrect(checkProcInfo.CheckProcSchemeUid))
        {
            var techTest = DataManager.Instance.RepositoryDataService.GetTechTestsByTechTest(new[] { checkProcInfo.TechTestUid }).FirstOrDefault();

            ProbeSelect = true;
            _cWorkProbe.TechUid = techTest?.TechUid;
            _cWorkProbe.TechTestUid = techTest?.TechTestUid;
            _cWorkProbe.Init(DataManager.Instance.ServiceProvider, null, true);
            _cWorkProbe.PropertyChanged += _cWorkProbe_PropertyChanged;
            _bOk.Enabled = false;
        }
    }
}
        }






















C:\!Indus\Branches\Malahit_BMU\Source\Indusoft.LDS.Client.IC\Commands\OperativeControlOnDemandCommand.cs
        void ISampleCommand.Execute(SampleCommandAfterExecute afterExecute)
        {
            using (var dlg = new OperativeControlOnDemandDialog())
            {
                CheckProcInfo checkProcInfo;
                CheckProcTask checkProcTask;

                if (!dlg.CreateOperativeControl(out checkProcInfo, out checkProcTask)) return;

                var creationDate = dlg.RunningDate;

                SA.Instance.IntCDataService.CheckProcInfoInsert(ref checkProcInfo);
                SA.Instance.SaveCheckProcTask(ref checkProcTask);
                int prepared = 0;
                foreach (var taskItem in checkProcTask.Items)
                {
                    Task task = null;
                    if (dlg.SelectedSample != null)
                    {
                        if (prepared<checkProcTask.Items.Count-1) 
                        {
                            task = SA.Instance.CreateTask(checkProcInfo, taskItem.CheckProcTaskItemUid, creationDate);

                            int checkProcSchemeSampleId = 0;
                            // С двумя контрольными измерениями каждого образца в условиях полной воспроизводимости
                            if (dlg.CheckProcSchemeUid == Common.RS.CheckProcSchemes.CheckProcSchemeFullReproducibilityUid)
                                checkProcSchemeSampleId = 7;
                            // С двумя контрольными измерениями каждого образца в условиях частичной воспроизводимости
                            if (dlg.CheckProcSchemeUid == Common.RS.CheckProcSchemes.CheckProcSchemePartReproducibilityUid)
                                checkProcSchemeSampleId = 7;
                            // С двумя контрольными измерениями каждого образца в условиях чистой воспроизводимости
                            if (dlg.CheckProcSchemeUid == Common.RS.CheckProcSchemes.CheckProcSchemePureReproducibilityUid)
                                checkProcSchemeSampleId = 7;
                            // С применением контрольной методики
                            if (dlg.CheckProcSchemeUid == Common.RS.CheckProcSchemes.CheckProcSchemeCheckTechUid)
                                checkProcSchemeSampleId = 5;
                            // С применением метода варьирования навески
                            if (dlg.CheckProcSchemeUid == Common.RS.CheckProcSchemes.CheckProcSchemeVaryingMassUid)
                                checkProcSchemeSampleId = 6;
                            // С применением метода добавки
                            if (dlg.CheckProcSchemeUid == Common.RS.CheckProcSchemes.CheckProcSchemeAdditionUid)
                                checkProcSchemeSampleId = 4;
                            // С применением метода добавки совместно с методом разбавления
                            if (dlg.CheckProcSchemeUid == Common.RS.CheckProcSchemes.CheckProcSchemeDilutionAdditionUid)
                                checkProcSchemeSampleId = 2; // May be 3?
                            // С применением метода разбавления
                            if (dlg.CheckProcSchemeUid == Common.RS.CheckProcSchemes.CheckProcSchemeDilutionUid)
                                checkProcSchemeSampleId = 2; 

                            var _checkProc = CheckProc.CreateInstance();
                            _checkProc.Insert();
                            _checkProc.CheckProcUid = Guid.NewGuid();
                            _checkProc.CheckProcInfoUid = checkProcInfo.CheckProcInfoUid;
                            _checkProc.StatusId = SA.Instance.CheckProcWorkingStatus.StatusId;
                            _checkProc.CreationDate = creationDate;
                            SA.Instance.CreateCheckProc(ref _checkProc);

                            var _fkSample = CheckProcSample.CreateInstance();
                            _fkSample.Insert();
                            _fkSample.CheckProcSampleUid = Guid.NewGuid();
                            _fkSample.CheckProcUid = _checkProc.CheckProcUid;
                            _fkSample.SampleUid = dlg.SelectedSample.SampleId;
                            _fkSample.CheckProcSchemeSampleId = 0;
                            SA.Instance.IntCDataService.CheckProcSampleInsert(ref _fkSample);
                            
                            var _cpSample = CheckProcSample.CreateInstance();
                            _cpSample.Insert();
                            _cpSample.CheckProcSampleUid = Guid.NewGuid();
                            _cpSample.CheckProcUid = _checkProc.CheckProcUid;
                            _cpSample.TaskUid = task.TaskUid;
                            _cpSample.CheckProcSchemeSampleId = checkProcSchemeSampleId;

                            SA.Instance.IntCDataService.CheckProcSampleInsert(ref _cpSample);


                            prepared++;
                        }
                    }
                    else
                    {
                        task = SA.Instance.CreateTask(checkProcInfo, taskItem.CheckProcTaskItemUid, creationDate);
                    }

                    if (task != null)
                    {
                        afterExecute(task.TaskUid, task.ExtensionUid);
                    }
                }
            }
        }


