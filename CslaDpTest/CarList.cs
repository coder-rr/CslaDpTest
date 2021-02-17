using System;
using System.Collections.Generic;
using System.Linq;
using Csla;

namespace CslaDpTest
{
    [Serializable]
    public class CarInfo : ReadOnlyBase<CarInfo>
    {
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));
        public string Name
        {
            get => GetProperty(NameProperty);
            set => LoadProperty(NameProperty, value);
        }

        public static CarInfo Get(string name) => DataPortal.FetchChild<CarInfo>(name);

        private void Child_Fetch(string name)
        {
            Name = name;
        }
    }

    [Serializable]
    public class CarList : ReadOnlyListBase<CarList, CarInfo>
    {
        public static CarList Get(IEnumerable<string> names) => DataPortal.Fetch<CarList>(names);

        private void DataPortal_Fetch(IEnumerable<string> criteria)
        {
            IsReadOnly = false;
            Add(CarInfo.Get(criteria.First()));
            IsReadOnly = true;
        }
    }
}