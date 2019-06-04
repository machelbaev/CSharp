using System;
using System.Collections.Generic;

namespace Task
{
    public class DataBase
    {
        private readonly IDictionary<Type, object> _tables = new Dictionary<Type, object>();

        public string Name { get; }

        public DataBase(string name)
        {
            Name = name;
        }

        public void CreateTable<T>() where T : IEntity
        {
            Type tableType = typeof(T);

            if (_tables.ContainsKey(tableType))
                throw new DataBaseException($"Table already exists {tableType.Name}!");

            _tables[tableType] = new List<T>();
        }

        public void InsertInto<T>(IEntityFactory<T> values) where T : IEntity
        {
            Type tableType = typeof(T);

            if (!_tables.ContainsKey(tableType))
                throw new DataBaseException($"Unknown table {tableType.Name}!");

            ((List<T>)_tables[tableType]).Add(values.Instance);
        }

        public IEnumerable<T> Table<T>() where T : IEntity
        {
            Type tableType = typeof(T);

            if (!_tables.ContainsKey(tableType))
                throw new DataBaseException($"Unknown table {tableType.Name}!");

            return (IEnumerable<T>)_tables[tableType];
        }
    }
}
