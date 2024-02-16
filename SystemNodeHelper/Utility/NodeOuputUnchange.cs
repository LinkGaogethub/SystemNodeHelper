using NodeNetwork;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemNodeHelper.Utility
{
    public class NodeOuputUnchange : NodeOutputViewModel
    {
   
        static NodeOuputUnchange()
        {
            NNViewRegistrar.AddRegistration(() => new NodeOutputView(), typeof(IViewFor<NodeOuputUnchange>));
        }

        protected override void CreatePendingConnection()
        {
            return;
        }

    }
}
