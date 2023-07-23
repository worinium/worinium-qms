using Prism.Ioc;
using QM.Modules.DisplayTicketSection;
using QMS.Module.DisplayQueueDetailsSection;
using QMS.Module.DisplayQueueDetailsSection.ViewModels;
using QMS.Modules.DisplayRibbonSection;
using QMS.Modules.DisplayServicesSection;
using QMS.Modules.StreamingSection;
using System.Windows;

namespace Worinium.QMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<WaitingRoomScreen>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<DisplayTicketSectionModule>();
            containerRegistry.Register<DisplayQueueDetailsSectionModule>();
            containerRegistry.Register<DisplayHeaderSectionModule>();
            containerRegistry.Register<DisplayServicesSectionModule>();
            containerRegistry.Register<StreamingSectionModule>();
        }
    }
}
