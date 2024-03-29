﻿using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using QMS.Module.DisplayTicketSection;
using QMS.Shared;

namespace QM.Modules.DisplayTicketSection
{
    public class DisplayTicketSectionModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            // use the containerProvider to retrieve the instance of the Prism RegionManager
            // and register the view in this module with a specific region in the app
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.DisplayTicketCurrentTicketSectionRegion, typeof(QMS.Module.DisplayTicketSection.Views.DisplayTicketSectionView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // register with the container that SomeService implements ISomeService
            // ISomeService is defined in the Infrastructure module, see app architecture diagram

            //containerRegistry.Register<MyApplication.Infrastructure.ISomeService, SomeService>();
        }

    }
}