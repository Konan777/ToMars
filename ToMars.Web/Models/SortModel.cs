using System.Collections.Generic;
using System.Linq;

namespace ToMars.Web.Models
{
    public class SortColumn
    {
        public int nn { get; set; }
        public string column { get; set; }
        public string order { get; set; }
    }

    public class SortModel
    {
        private List<SortColumn> columns = new List<SortColumn>();
        public string GetSort(string col)
        {
            // Used inside AnketaList.cshtml to determine column sort order
            return columns.Where(w => w.column == col).Select(s => s.order).FirstOrDefault();
        }
        private void AddColumn(string col)
        {
            if (!string.IsNullOrEmpty(col)) {
                if (columns.Count(w => w.column == col) == 0) {
                    // Добавим новую кононку
                    var cnt = columns.Count() + 1;
                    columns.Add(new SortColumn() { nn=cnt, column=col, order="asc" });
                } else {
                    // Изменим порядок сортировки 
                    var curcol = columns.FirstOrDefault(w => w.column == col);
                    if (curcol.order == "asc") { 
                        curcol.order = "desc";
                    } else {
                        columns.Remove(curcol);
                        // Колонка выбыла списка. Нужно сделать новую номерацию.
                        int num = 1;
                        foreach (var co in columns.OrderBy(o => o.nn)) {
                            co.nn = num;
                            num++;
                        }
                    }
                }
            }
        }
        public void UpdateModel(string column)
        {
            // add_ for column clicked with shift
            if (column.Contains("add_")) {
                // Multicolumn sort with shift key
                AddColumn(column.Replace("add_", ""));
            } else {
                // Single column sort
                if ((column.Length > 0) && 
                   ((columns.Count > 1) || (columns.Count(w => w.column == column) == 0))
                ) {
                    columns.Clear();
                }
                AddColumn(column);
            }
        }
        public string GetSortOrder()
        {
            string rv = "";
            foreach (var col in columns.OrderBy(o => o.nn)) {
                if (rv.Length == 0)
                    rv += col.column + " " + col.order;
                else
                    rv += ", " + col.column + " " + col.order;
            }
            return rv;
        }
        public void Clear()
        {
            columns.Clear();
        }
    }

}