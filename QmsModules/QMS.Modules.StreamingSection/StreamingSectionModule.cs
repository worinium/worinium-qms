using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using QMS.Shared;

namespace QMS.Modules.StreamingSection
{
    public class StreamingSectionModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            // use the containerProvider to retrieve the instance of the Prism RegionManager
            // and register the view in this module with a specific region in the app
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.DisplayStreamingSectionRegion, typeof(Module.StreamingSection.Views.DisplayStreamingSectionView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // register with the container that SomeService implements ISomeService
            // ISomeService is defined in the Infrastructure module, see app architecture diagram

            // containerRegistry.Register<MyApplication.Infrastructure.ISomeService, SomeService>();
        }
    }
}