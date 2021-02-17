using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace CslaDpTest
{
    [Serializable]
    public class VehicleCommand : CommandBase<VehicleCommand>
    {
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
        public string Name
        {
            get => ReadProperty(NameProperty);
            private set => LoadProperty(NameProperty, value);
        }

        public VehicleCommand() { }
        private VehicleCommand(string name) => Name = name;

        public static Task<VehicleCommand> GetCommand(string x) => DataPortal.ExecuteAsync(new VehicleCommand(x));

        protected new async Task DataPortal_Execute()
        {
            await Task.Delay(10);
        }

    }
}
