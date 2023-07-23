using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using QMS.Shared.Contracts;
using QMS.Shared.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMS.Module.DisplayQueueDetailsSection.ViewModels
{
    public class DisplayQueueDetailsSectionViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DisplayQueueDetailsSectionViewModel(IRegionManager regionManager, IMessageService messageService) :
            base(regionManager)
        {
            Message = messageService.GetMessage();

            // Message = "DisplayHeaderSection Prism Module";
        }
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}
