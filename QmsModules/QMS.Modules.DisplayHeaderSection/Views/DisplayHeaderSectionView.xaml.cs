using QMS.Shared;
using System;
using System.Windows.Media;
using System.Speech.Synthesis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QMS.Modules.DisplayHeaderSection.Properties;
using QMS.Module.DisplayHeaderSection.Core;

namespace QMS.Module.DisplayHeaderSection.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class DisplayHeaderSectionView : UserControl
    {
        public DisplayHeaderSectionView()
        {
            InitializeComponent();
        }
        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do You want to close Application?", "Question ??", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
                Environment.Exit(0);
            else
                return;
        }
        private void btnTestPrintCick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Helpers.printerExists(Settings.Default.printer_name))
                {
                    ManageTicket ticket = new ManageTicket(1, DateTime.Now, Settings.Default.region_code, "Printer Testing", Settings.Default.printer_name);
                    ticket.Tickprint();
                }
                else
                    MessageBox.Show(Settings.Default.printer_name + " printer is not connected, Please contact your administrator!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("HeaderSection.btnTestPrintCick: {0}", ex.Message);
            }
        }

        private void btnTestSoundCick(object sender, RoutedEventArgs e)
        {
            try
            {
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult);
                bool voiceStatus = TextToSpeechManager.voiceExists(Settings.Default.voices);
                if (voiceStatus)
                    synthesizer.SelectVoice(Settings.Default.voices);
                else
                {
                    MessageBox.Show("A New Default Voice is Selected Because Configured Voice Not Found");
                    var data = TextToSpeechManager.getDefaultInstalledVoice();
                    synthesizer.SelectVoice(data[0]);
                }
                synthesizer.SetOutputToDefaultAudioDevice();
                synthesizer.Volume = int.Parse(Settings.Default.voice_volume);
                synthesizer.Rate = int.Parse(Settings.Default.voice_rate);
                synthesizer.SpeakAsync(Settings.Default.test_voice);
            }
            catch (Exception ex)
            {
                MessageBox.Show("HeaderSection.btnTestSoundCick: {0}", ex.Message);
            }
        }
        private void CustomerScreenMenu_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string _btnColor = Helpers.getQmsSetting(Helpers.Constants.buttonColor);
                CustomerScreenMenu.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Helpers.getQmsSetting(Helpers.Constants.HeaderColor)));
                btnPrinter.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_btnColor));
                version.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_btnColor));
                btnVoice.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_btnColor));
                if (!Settings.Default.testmode)
                {
                    btnPrinter.Visibility = Visibility.Hidden;
                    btnVoice.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HeaderSection.CustomerScreenMenu_Loaded: {0}", ex.Message);
            }
        }
    }
}
