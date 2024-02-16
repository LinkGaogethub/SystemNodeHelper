using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace SystemNodeHelper.ViewModel
{
    public class SaveNetworkViewModel : ReactiveObject
    {

        public ReactiveCommand<Unit, Unit> Ok { get; }
      
        public string Text { get; set; }
        public bool IsOk { get; set; }

        public SaveNetworkViewModel() {

            Ok = ReactiveCommand.Create(OkCommand);
        }

        private void OkCommand()
        {
            if(Text.Length >0) IsOk = true;    
        }
    }
}
