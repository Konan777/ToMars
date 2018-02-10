using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ToMars.Model.Models;
using ToMars.Model.Entities;

namespace ToMars.Model.Parser
{
    // Generic string to type converter interface
    public interface IConverter
    {
        T ConvertIt<T>(string line);
    }
    public class ToAnketa : IConverter
    {
        private readonly char Splitby;
        public ToAnketa(char splitby)
        {
            Splitby = splitby;
        }
        private List<ValidationResult> Validate(AnketaModel ankm)
        {
            var results = new List<ValidationResult>();
            var vc = new ValidationContext(ankm, null, null);
            Validator.TryValidateObject(ankm, vc, results, true);
            return results;
        }
        public T ConvertIt<T>(string line)
        {
            if (typeof(T).Name!="Anketa")
                throw new Exception("Wrong type!");

            var splited = line.Split(Splitby);
            if (splited.Length != 4)
                throw new Exception("Not all fields filled!");
            // Валидируем AnketaModel
            var ankm = new AnketaModel() {
                FIO = splited[0],
                Birthday = DateTime.Parse(splited[1]),
                Email = splited[2],
                Phone = splited[3]
            };
            var results = Validate(ankm);
            if (results.Count > 0)
                throw new Exception(results[0].MemberNames.ToList()[0]+" "+results[0].ErrorMessage);
            // Возварщаем Anketa
            var ank = new Anketa() {
                FIO = ankm.FIO,
                Birthday = ankm.Birthday,
                Email = ankm.Email,
                Phone = ankm.Phone
            };
            return (T)Convert.ChangeType(ank, typeof(T));
        }
    }
}
