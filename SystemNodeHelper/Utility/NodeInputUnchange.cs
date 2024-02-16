using DynamicData;
using NodeNetwork;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemNodeHelper.Utility
{
    public class NodeInputUnchange: NodeInputViewModel
    {
        static NodeInputUnchange()
        {
            NNViewRegistrar.AddRegistration(() => new NodeInputView(), typeof(IViewFor<NodeInputUnchange>));
        }

        protected override void CreatePendingConnection()
        {
                return;
        }
    }
}
