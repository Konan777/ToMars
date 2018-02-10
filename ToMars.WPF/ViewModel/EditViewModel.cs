using System;
using System.Reflection;
using System.Windows;
using ToMars.Model.Context;
using ToMars.Model.Entities;
using ToMars.Model;
using AutoMapper;

namespace ToMars.WPF.ViewModel
{
    public interface IEditViewModel
    {
        RelayCommand CmdCancel { get; }
        RelayCommand CmdSave { get; }
        Action CloseAction { get; set; }
        Action ShowAction { get; set; }
    }

    public class EditViewModel : IEditViewModel
    {
        private readonly ITMRepositary _IAnketaKeeper;
        private readonly AnketaViewModel OriginalAnketa;
        public AnketaViewModel EditableAnketa { get; set; }

        public EditViewModel(AnketaViewModel _anketa, ITMRepositary _ianketaKeeper)
        {
            _IAnketaKeeper = _ianketaKeeper;
            OriginalAnketa = new AnketaViewModel(_anketa.TheAnketa);
            //Copy(_anketa, OriginalAnketa);
            EditableAnketa = _anketa;
            CmdSave = new RelayCommand(Save);
            CmdCancel = new RelayCommand(Cancel);
        }

        public RelayCommand CmdSave { get; }
        public RelayCommand CmdCancel { get; }
        public Action CloseAction { get; set; }
        public Action ShowAction { get; set; }

        private void Save(object obj)
        {
            if (EditableAnketa.HasErrors)
            {
                MessageBox.Show("Data has errors!");
                return;
            }
            try
            {
                if (EditableAnketa.ID > 0)
                    _IAnketaKeeper.Update(EditableAnketa.TheAnketa);
                else
                {
                    var ank = EditableAnketa.TheAnketa; // readonly property..
                    _IAnketaKeeper.Add(ank);
                    EditableAnketa.ID = ank.ID; // new record. update id
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            CloseAction();
        }
        private void Cancel(object obj)
        {
            RollBack();
            CloseAction();
        }
        private void RollBack()
        {
            // For each updated property raised NotifyPropertyChanged
            EditableAnketa.ID = OriginalAnketa.ID;
            EditableAnketa.FIO = OriginalAnketa.FIO;
            EditableAnketa.Birthday = OriginalAnketa.Birthday;
            EditableAnketa.Email = OriginalAnketa.Email;
            EditableAnketa.Phone = OriginalAnketa.Phone;
        }

    }
}
