using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Forms;
using ToMars.Model;
using ToMars.Model.Entities;
using ToMars.Model.Context;
using ToMars.Model.Settings;
using System.Threading;

namespace ToMars.WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _fileName;
        private int _progressBarValue;
        private int _progressBarMaximum;
        private string _progressBarText;
        private bool _statuBarVisiblity;
        private AnketaFile _selectedFile;
        private AnketaViewModel _selectedRow;
        private bool _comboEnabed;
        private bool _allowAdd;
        private bool _allowDelChg;
        private bool _allowDeploy;
        private bool _allowStop;

        private readonly IGeneralFacade Facade;            

        public MainViewModel(IGeneralFacade _facade)
        {
            Facade = _facade;

            CmdSelectFile = new RelayCommand(SelectFile);
            CmdProcess = new RelayCommand(ProcessSingleThread);
            CmdProcessMultithread = new RelayCommand(ProcessMultithread);
            CmdStop = new RelayCommand(Stop);
            CmdRemove = new RelayCommand(Remove);
            CmdAdd = new RelayCommand(Add);
            CmdChange = new RelayCommand(Change);
            CmdExport = new RelayCommand(Export);
            CmdSet = new RelayCommand(SetChanges);

            Files = new ObservableCollection<AnketaFile>();
            RowSource = new ObservableCollection<AnketaViewModel>();

            FileName = @"C:\Work\ToMars\Анкета_000.csv";
            if (GoodConnection())
                InitFormProps();
        }

        private bool GoodConnection()
        {
            // Sync method called. UI is locked for a while..
            if (!Facade.Settings.SelectedDatabase.ConnectionIsValid()) {
                Facade.Messenger.ShowMessage("Ошибка при попытке подключения к серверу!");
                return false;
            }
            return true;
        }

        // Support methods
        private async void InitFormProps()
        {
            StatuBarVisiblity = false;
            Files.Clear();
            ComboEnabed = false;
            try {
                var files = await Facade.Keeper.GetFilesAsync();
                if (files.Count > 0)
                    foreach (var fil in files)
                        Files.Add(fil);
            } catch (Exception ex) {
                Facade.Messenger.ShowMessage("Ошибка при получении списка файлов:\r\n" + ex.Message);
            }
            SelectedFile = Files.Count == 0 ? null : Files[Files.Count-1];
        }
        private async void ReloadGridData()
        {
            ComboEnabed = false; 
            RowSource.Clear();
            if (SelectedFile != null)
            {
                var anketas = await Facade.Keeper.GetAnketasAsync(_selectedFile.ID);
                foreach (var row in anketas)
                {
                    var ankview = new AnketaViewModel(row);             // Stable dependency
                    RowSource.Add(ankview);
                }
            }
            if (RowSource.Count > 0)
                AllowDeploy = true;
            else
                AllowDeploy = false;
            ComboEnabed = true;
        }

        public string FileName
        {
            get { return _fileName; }
            private set
            {
                _fileName = value;
                NotifyPropertyChanged();
            }
        }
        public int ProgressBarValue
        {
            get
            {
                return _progressBarValue;
            }

            private set
            {
                _progressBarValue = value;
                NotifyPropertyChanged();
            }
        }
        public int ProgressBarMaximum
        {
            get
            {
                return _progressBarMaximum;
            }

            private set
            {
                _progressBarMaximum = value;
                NotifyPropertyChanged();
            }
        }
        public string ProgressBarText
        {
            get
            {
                return _progressBarText;
            }

            private set
            {
                _progressBarText = value;
                NotifyPropertyChanged();
            }
        }
        public bool StatuBarVisiblity
        {
            get
            {
                return _statuBarVisiblity;
            }

            private set
            {
                _statuBarVisiblity = value;
                NotifyPropertyChanged();
            }
        }

        public bool AllowAdd
        {
            get { return _allowAdd; }
            private set
            {
                _allowAdd = value;
                NotifyPropertyChanged();
            }
        }
        public bool AllowDelChg
        {
            get { return _allowDelChg; }
            private set
            {
                _allowDelChg = value;
                NotifyPropertyChanged();
            }
        }
        public bool AllowDeploy
        {
            get { return _allowDeploy; }
            private set
            {
                _allowDeploy = value;
                NotifyPropertyChanged();
            }
        }
        public bool AllowStop
        {
            get { return _allowStop; }
            private set
            {
                _allowStop = value;
                NotifyPropertyChanged();
            }
        }

        public AnketaViewModel SelectedRow
        {
            get
            {
                return _selectedRow;
            }
            set
            {
                _selectedRow = value;
                if (_selectedRow != null)
                    AllowDelChg = true;
                else
                    AllowDelChg = false;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<AnketaFile> Files { get; set; }
        public ObservableCollection<AnketaViewModel> RowSource { get; set; }
        public List<Database> Databases {
            get
            {
                return Facade.Settings.Databases;
            }
        }
        public Database SelectedDB
        {
            get
            {
                return Facade.Settings.SelectedDatabase;
            }
            set
            {
                Facade.Settings.SelectedDatabase = value;
                if (GoodConnection())
                    InitFormProps();
                NotifyPropertyChanged();
            }
        }
        
        public bool ComboEnabed
        {
            // ComboBox filled from DB and can run too long. Lock both for a while..
            get { return _comboEnabed; }
            set
            {
                _comboEnabed = value;
                NotifyPropertyChanged();
            }
        }
        public AnketaFile SelectedFile
        {
            get
            {
                return _selectedFile;
            }
            set
            {
                _selectedFile = value;
                ReloadGridData();
                NotifyPropertyChanged();
                if (_selectedFile != null)
                    AllowAdd = true;
                else
                    AllowAdd = false;
            }
        }

        // Commands
        public RelayCommand CmdSelectFile { get; }
        public RelayCommand CmdProcessMultithread { get; }
        public RelayCommand CmdProcess { get; }
        public RelayCommand CmdStop { get; }
        public RelayCommand CmdRemove { get; }
        public RelayCommand CmdAdd { get; }
        public RelayCommand CmdChange { get; }
        public RelayCommand CmdExport { get; }
        public RelayCommand CmdSet { get; }

        // Commands handlers
        private void SelectFile(object obj)
        {
            var fbd = new OpenFileDialog();
            fbd.Filter = "Анкеты (*.csv)|*.csv";
            var result = fbd.ShowDialog();
            if (string.IsNullOrWhiteSpace(fbd.FileName)) return;
            FileName = fbd.FileName;
        }
        private CancellationTokenSource _Cancel;
        private async void Process(bool multithread)
        {
            if (Facade.Parser.FileAlreadyParsed(FileName))
            {
                Facade.Messenger.ShowMessage("File already parsed!");
                return;
            }
            var progress = new Progress<int>();
            ProgressBarValue = 0;
            StatuBarVisiblity = true;
            AllowStop = true;
            _Cancel = new CancellationTokenSource();
            try
            {
                ProgressBarMaximum = await Facade.Parser.RowsInAnketa(FileName);
                progress.ProgressChanged += (sender, args) =>
                {
                    ProgressBarValue = args;
                    ProgressBarText = string.Format("Parsed {0} from {1} rows", args, ProgressBarMaximum);
                };
                if (!multithread)
                    await Facade.Parser.Parse_SigleAsync(FileName, progress, _Cancel);
                else
                    await Facade.Parser.Parse_MultipleAsync(FileName, progress, _Cancel);
            }
            catch (Exception ex)
            {
                Facade.Messenger.ShowMessage(ex.Message);
            }
            AllowStop = false;
            StatuBarVisiblity = false;
            InitFormProps();
        }
        private void ProcessSingleThread(object obj)
        {
            Process(false);
        }
        private void ProcessMultithread(object obj)
        {
            Process(true);
        }
        private void Stop(object obj)
        {
            _Cancel.Cancel();
        }
        private void Remove(object obj)
        {
            Facade.Keeper.Remove(SelectedRow.TheAnketa);
            RowSource.Remove(SelectedRow);
        }
        private void Add(object obj)
        {
            var ank = new AnketaViewModel(new Anketa()) { FileId = SelectedFile.ID };   // Stable dependency
            var ieditView = Facade.GetEditView(ank);
            ieditView.ShowAction();
            if (!ank.HasErrors)
                RowSource.Add(ank);
        }
        private void Change(object obj)
        {
            var ieditView = Facade.GetEditView(SelectedRow);
            ieditView.ShowAction();
            SelectedRow = SelectedRow;
        }
        private async void Export(object obj)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Text Files(*.csv)|",
                FileName = SelectedFile.FileName
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var anklist = Facade.Keeper.GetAnketas(SelectedFile.ID);
                await Facade.Reader.Export(dialog.FileName, anklist);
            }
        }
        private void SetChanges(object obj)
        {
            if (GoodConnection())
            {
                InitFormProps();
                Facade.Settings.Save();
            }
        }
    }
}