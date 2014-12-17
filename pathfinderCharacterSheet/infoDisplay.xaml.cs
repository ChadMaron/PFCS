using pathfinderCharacterSheet.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace pathfinderCharacterSheet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class infoDisplay : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private List<Character> character;
        private String fileName;
        private Boolean fileExists;
        
        public infoDisplay()
        {
            fileExists = false;
            this.InitializeComponent();
            
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            fileName = "data.xml";
            character = new List<Character>();
            
            //SetUpSheet(character[0]);
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            
            //Try to find a character, if it doesn't find one, set the fileExists to False then create a new one.
            try
            {
                await ReadData();
                fileExists = true;
            }
            catch(Exception ex)
            {

                fileExists = false;
                
            }
            if (fileExists == false)
            {
                CreateData();
                await WriteData();
                await ReadData();
            }
            //character[0].StatsCurrentHp = 25;
            SetUpSheet(character[0]);
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        public void appBarBtn_Click(object sender, RoutedEventArgs e) 
        {
            AppBarButton switcher = (AppBarButton)sender;
            
            switch(switcher.Name) {
                case "appBarAboutBtn":
                    Frame.Navigate(typeof(aboutPage));
                    break;
                case "appBarInfoBtn":
                    Frame.Navigate(typeof(infoDisplay));
                    break;
                case "appBarStatsBtn":
                    Frame.Navigate(typeof(statsDisplay));
                    break;
                case "appBarGearBtn":
                    Frame.Navigate(typeof(gearDisplay));
                    break;
                case "appBarWeaponsBtn":
                    Frame.Navigate(typeof(weaponsDisplay));
                    break;
                default:
                    Frame.Navigate(typeof(aboutPage));
                    break;
            }
        }

        private void btnInfoEdit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(infoEdit), character[0]);
        }

        private void CreateData()
        {
            character.Add(new Character());
        }

        private void SetUpSheet(Character character)
        {
            BasicName.Text = character.BasicName;
            BasicClass.Text = character.BasicClass;
            BasicRace.Text = character.BasicRace;
            BasicAlignment.Text = character.BasicAlignment;
            BasicAge.Text = character.BasicAge;
            BasicGender.Text = character.BasicGender;
            BasicSize.Text = character.BasicSize;
            BasicWeight.Text = character.BasicWeight;
            BasicDeity.Text = character.BasicDeity;
            BasicHair.Text = character.BasicHair;
            BasicHomeland.Text = character.BasicHomeland;
            BasicEyes.Text = character.BasicEyes;
        }


        private async Task ReadData()
        {
            string content = String.Empty;
            List<Character> readCharacter;

            var deserializer = new DataContractSerializer(typeof(List<Character>));

            var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(fileName);

            readCharacter = (List<Character>)deserializer.ReadObject(stream);


            /* Run into a stop, what if I only want to select the first*/
            foreach (var read in readCharacter)
            {
                character.Add(new Character()
             {
                 BasicName = read.BasicName,
                 BasicClass = read.BasicClass,
                 BasicRace = read.BasicRace,
                 BasicAlignment = read.BasicAlignment,
                 BasicAge = read.BasicAge,
                 BasicGender = read.BasicGender,
                 BasicSize = read.BasicSize,
                 BasicWeight = read.BasicWeight,
                 BasicDeity = read.BasicDeity,
                 BasicHair = read.BasicHair,
                 BasicHomeland = read.BasicHomeland,
                 BasicEyes = read.BasicEyes,
                 StatsStr = read.StatsStr,
                 StatsDex = read.StatsDex,
                 StatsCon = read.StatsCon,
                 StatsInt = read.StatsInt,
                 StatsWis = read.StatsWis,
                 StatsCha = read.StatsCha,
                 StatsMaxHp = read.StatsMaxHp,
                 StatsInitiative = read.StatsInitiative,
                 StatsBaseAttackBonus = read.StatsBaseAttackBonus,
                 StatsFortitudeBase = read.StatsFortitudeBase,
                 StatsFortitudeMagic = read.StatsFortitudeMagic,
                 StatsFortitudeMisc = read.StatsFortitudeMisc,
                 StatsReflexBase = read.StatsReflexBase,
                 StatsReflexMagic = read.StatsReflexMagic,
                 StatsReflexMisc = read.StatsReflexMisc,
                 StatsWillpowerBase  = read.StatsWillpowerBase,
                 StatsWillpowerMagic = read.StatsWillpowerMagic,
                 StatsWillpowerMisc  = read.StatsWillpowerMisc,
                 StatsACArmor = read.StatsACArmor,
                 StatsACShield = read.StatsACShield,
                 StatsACSize = read.StatsACSize,
                 StatsACNaturalArmor = read.StatsACNaturalArmor,
                 StatsACDeflection = read.StatsACDeflection,
                 StatsACMisc = read.StatsACMisc,
                 StatsStrTemp = read.StatsStrTemp,
                 StatsDexTemp = read.StatsDexTemp,
                 StatsConTemp = read.StatsConTemp,
                 StatsIntTemp = read.StatsIntTemp,
                 StatsWisTemp = read.StatsWisTemp,
                 StatsChaTemp = read.StatsChaTemp,
                 StatsFortitudeTemp = read.StatsFortitudeTemp,
                 StatsReflexTemp = read.StatsReflexTemp,
                 StatsWillpowerTemp = read.StatsWillpowerTemp

             });
                    
            }
               
        }

        private async Task WriteData()
        {
            var serializer = new DataContractSerializer(typeof(List<Character>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(fileName, CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, character);
            }
        }        
    }
}
