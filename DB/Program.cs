using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;

namespace UniConv
{
    public enum XmlMapping { Attribute, Element };
    public enum FieldsRule {
        All              // Все открытые свойства класса
        , BySql          // Только совпадающие по имени с полями таблицы на SQL 
        , ByAnnotation   // Все открытые свойства класса у которых нет атрибута [NotMapped]
    };
    class Program
    {
        static void Main(string[] args)
        {
            var etx = new EntityToXml<ST>("Test001", @"Server=KONAN-PC; Database=I-LDS_REPORTS; Integrated Security=true;");
            var list = PrepareData();
            var xml = etx.GetXml(list, XmlMapping.Attribute, FieldsRule.ByAnnotation, true);
            Console.WriteLine(xml.ToString());
            Console.ReadLine();
            /*var list2 = PrepareData2();
            var xml2 = etx.GetXml(list2, XmlMapping.Attribute, FieldsRule.ByAnnotation, false);
            xml2.Save(@"d:\xml01.txt");
            var list3 = PrepareData2();
            var xml3 = etx.GetXml(list3, XmlMapping.Element, FieldsRule.ByAnnotation, false);
            xml3.Save(@"d:\xml02.txt");*/
        }

        private static List<ST> PrepareData()
        {
            return new List<ST>()
            {
                new ST()
                {
                     STUid = Guid.NewGuid(),
                     Code = "100501",
                     //Name = "Иванов Иван Иванович".PadRight(300,'-'),
                     Name = "Иванов Иван Иванович",
                     ProductUid = Guid.NewGuid(),
                     SampleLogId = null,
                     Date01 = DateTime.Now,
                     Date02 = new TimeSpan(1,0,0),
                     Date03 = DateTime.Now,
                },
                new ST()
                {
                     STUid = Guid.NewGuid(),
                     Code = "100502",
                     Name = "Петров Петр Петрович",
                     ProductUid = Guid.NewGuid(),
                     SampleLogId = null,
                }
            };
        }
        private static List<ST> PrepareData2()
        {
            var result = new List<ST>();
            for (int i = 0; i < 30000; i++)
            {
                result.Add(
                    new ST()
                    {
                        STUid = Guid.NewGuid(),
                        Code = "100501_"+i,
                        Name = "Иванов Иван Иванович",
                        ProductUid = Guid.NewGuid(),
                        SampleLogId = null,
                        Date01 = DateTime.Now,
                        Date02 = new TimeSpan(1, 0, 0),
                        Date03 = DateTime.Now,
                    }
                );
            }
            return result;
        }

    }

    public class EntityToXml<T>
    {
        private readonly string _connectionString;
        private DataTable _tableSchema;
        private readonly string _tableName;
        private List<string> _neededFields;
        public EntityToXml(string tableName, string connectionString)
        {
            _tableName = tableName ?? throw new Exception("tableName не может быть пустым!");
            _connectionString = connectionString ?? throw new Exception("connectionString не может быть пустым!");
        }
        /// <summary>
        /// Сформирует XML из списка экземпляров класса T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Список записей</param>
        /// <param name="mapping">Вид XML</param>
        /// <param name="rule">Вид формирования полей</param>
        /// <param name="validate">Валидировать данные</param>
        /// <returns></returns>
        public XDocument GetXml(List<T> list, XmlMapping mapping, FieldsRule rule, bool validate)
        {
            var validatedList = new List<T>();
            _neededFields = GetFieldNames(typeof(T), rule);
            if (validate)
            {
                foreach (var item in list)
                    if (ItemIsValid(item, rule))
                        validatedList.Add(item);
            }
            else
            {
                validatedList = list;
            }

            // Список полей которые попадут в XML
            var properties = TypeDescriptor
                .GetProperties(typeof(T)).Cast<PropertyDescriptor>()
                .Where(w => _neededFields.Contains(w.Name))
                .ToList();

            XElement content;
            if (mapping == XmlMapping.Element)
                content = new XElement("ROOT",
                    validatedList.Select(row => new XElement("ITEM",
                        properties.Where(w => GetValue(w, row) != null).Select(prop => new XElement(prop.Name, GetValue(prop, row) ?? DBNull.Value)))));
            else
                content = new XElement("ROOT",
                    validatedList.Select(row => new XElement("ITEM",
                        properties.Where(w => GetValue(w, row) != null).Select(prop => new XAttribute(prop.Name, GetValue(prop,row) ?? DBNull.Value)))));

            return new XDocument(content);
        }
        private object GetValue(PropertyDescriptor prop, T row)
        {
            if (prop.PropertyType == typeof(TimeSpan))
                return ((TimeSpan)prop.GetValue(row)).ToString();
            if (prop.PropertyType == typeof(DateTime))
            {
                var attr = prop.Attributes.Cast<Attribute>().FirstOrDefault(c => c.GetType() == typeof(DataTypeAttribute));
                if (((DataTypeAttribute)attr).DataType == DataType.Date)
                    return ((DateTime)prop.GetValue(row)).ToString("yyyy-MM-dd");
                else
                    return ((DateTime)prop.GetValue(row)).ToString("yyyy-MM-dd HH:mm:ss");
            } 
            return string.Format(CultureInfo.InvariantCulture, "{0}", prop.GetValue(row));
        }
        private List<string> GetFieldNames(Type obj, FieldsRule rule)
        {
            PropertyInfo[] propz = obj.GetProperties();
            var result = new List<string>();
            switch (rule)
            {
                case FieldsRule.All:
                    return propz.Select(s => s.Name).ToList();
                case FieldsRule.BySql:
                    _tableSchema = GetSqlTableSchema();
                    return _tableSchema.Columns.Cast<DataColumn>().Select(s => s.ColumnName).ToList();
                case FieldsRule.ByAnnotation:
                    return propz.Where(w => !w.GetCustomAttributes(true).Any(c => c.GetType() == typeof(NotMappedAttribute))).Select(s => s.Name).ToList();
            }
            return result;
        }
        private DataTable GetSqlTableSchema()
        {
            var result = new DataTable();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = String.Format("SELECT TOP 1 * FROM {0}", _tableName);
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.SchemaOnly);
                    result.Load(reader);
                }
                return result;
            }
        }
        private static List<ValidationResult> Validate(T entity)
        {
            var results = new List<ValidationResult>();
            var vc = new ValidationContext(entity, null, null);
            Validator.TryValidateObject(entity, vc, results, true);
            return results;
        }
        private bool ItemIsValid(T item, FieldsRule rule)
        {
            if (rule == FieldsRule.ByAnnotation)
            {
                var results = Validate(item);
                if (results.Count > 0)
                {
                    Console.WriteLine("Ошибка:" + results[0].MemberNames.ToList()[0] + " " + results[0].ErrorMessage);
                    return false;
                }
                else
                    return true;
            }
            if (rule == FieldsRule.BySql)
            {
                var table = _tableSchema.Clone();

                // Список полей которые попадут в XML
                var properties = TypeDescriptor.GetProperties(typeof(T));

                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    if (prop.GetValue(item) != null)
                    {
                        if (_tableSchema.Columns.Cast<DataColumn>().Any(c => c.ColumnName == prop.Name))
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    }
                }
                try
                {
                    table.Rows.Add(row);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка:" + ex.Message);
                    return false;
                }

            }
            return true;
        }
    }

    public class ST
    {
        public Guid STUid { get; set; }
        [Required]
        [StringLength(100)]
        public string Code { get; set; }
        [Required]
        [StringLength(255)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        public Guid ProductUid { get; set; }
        public int? SampleLogId { get; set; }
        private int Error01 { get; set; }
        [NotMapped]
        public int Error02 { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date01 { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan Date02 { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date03 { get; set; }
    }
}
