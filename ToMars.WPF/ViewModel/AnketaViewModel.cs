using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ToMars.Model.Entities;
using ToMars.Model.Models;
using System.ComponentModel.DataAnnotations;
using AutoMapper;


namespace ToMars.WPF.ViewModel
{
    // Needed for :
    // 1) updating current SelectedRow in DataGrid because each property support notification
    // 2) highlight incorrect fields and show message in tooltip
    public class AnketaViewModel: ViewModelBase, INotifyDataErrorInfo
    {
        private AnketaModel _AnketaModel;   // Validable model (validation by DataAnnotations)

        public AnketaViewModel() {}         // Empty constructor for unit testing purpose

        public AnketaViewModel(Anketa _anketa)
        {
            _AnketaModel = Mapper.Map<AnketaModel>(_anketa);
        }

        // Readonly property. Bridge between Anketa and AnketaModel
        public Anketa TheAnketa { 
            get {
                return Mapper.Map<Anketa>(_AnketaModel);
            }
        }

        public int ID
        {
            get { return _AnketaModel.ID; }
            set
            {
                _AnketaModel.ID = value;
                NotifyPropertyChanged();
            }
        }
        public int FileId
        {
            get { return _AnketaModel.FileId; }
            set
            {
                _AnketaModel.FileId = value;
                NotifyPropertyChanged();
            }
        }

        public string FIO
        {
            get { return _AnketaModel.FIO; }
            set
            {
                _AnketaModel.FIO = value;
                Validate();
                NotifyPropertyChanged();
            }
        }
        public DateTime Birthday
        {
            get
            {
                return _AnketaModel.Birthday;
            }
            set
            {
                _AnketaModel.Birthday = value;
                Validate();
                NotifyPropertyChanged();
            }
        }
        public string Email
        {
            get { return _AnketaModel.Email; }
            set
            {
                _AnketaModel.Email = value;
                Validate();
                NotifyPropertyChanged();
            }
        }
        public string Phone
        {
            get { return _AnketaModel.Phone; }
            set
            {
                _AnketaModel.Phone = value;
                Validate();
                NotifyPropertyChanged();
            }
        }

        #region Validation helpers
        public void AddError(string property, List<string> errors)
        {
            _errors.Add(property, errors);
            OnErrorsChanged(property);
        }

        public void ClearErrors()
        {
            foreach (var err in _errors.ToList())
            {
                string key = err.Key;
                _errors.Remove(key);
                OnErrorsChanged(key);
            }
        }

        private void Validate()
        {
            ClearErrors();
            var validationResults = new List<ValidationResult>();
            var vc = new System.ComponentModel.DataAnnotations.ValidationContext(_AnketaModel, null, null);
            var isValid = Validator.TryValidateObject(_AnketaModel, vc, validationResults, true);
            if (!isValid) {
                foreach (var err in validationResults) {
                    AddError(err.MemberNames.ToList()[0], new List<string>() { err.ErrorMessage });
                }
            }
        }
        #endregion

        #region INotifyDataErrorInfo
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            List<string> errorsForName;
            _errors.TryGetValue(propertyName, out errorsForName);
            return errorsForName;
        }
        public bool HasErrors
        {
            get { return _errors.Any(kv => kv.Value != null && kv.Value.Count > 0); }
        }
        #endregion

    }
}
