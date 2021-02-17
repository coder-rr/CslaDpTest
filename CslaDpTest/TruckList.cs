using System;
using Csla;

namespace CslaDpTest
{
    [Serializable]
    public class TruckInfo : ReadOnlyBase<TruckInfo>
    {
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));

        public string Name
        {
            get => GetProperty(NameProperty);
            set => LoadProperty(NameProperty, value);
        }
    }

    [Serializable]
    public class TruckList : ReadOnlyListBase<TruckList, TruckInfo>
    {
        private interface ICriteriaBase
        {
            string Name { get; }
        }

        [Serializable]
        private class Criteria : ICriteriaBase
        {
            public string Name { get; set; }
        }

        public static TruckList Get(string name) => DataPortal.Fetch<TruckList>(new Criteria { Name = name });

        private void DataPortal_Fetch(ICriteriaBase criteria)
        {

        }
    }
}
