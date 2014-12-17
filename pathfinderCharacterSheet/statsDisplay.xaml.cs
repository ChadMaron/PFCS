
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
    public sealed partial class statsDisplay : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private List<Character> character;
        private String fileName;
        

        public statsDisplay()
        {
            this.InitializeComponent();
            character = new List<Character>();
            fileName = "data.xml";
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            
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
            if (e.PageState != null && e.PageState.ContainsKey("StrTemp")) 
            {
                StatsStrTemp.Text = e.PageState["StrTemp"].ToString();
            } 
            else 
            {
                StatsStrTemp.Text = StatsStr.Text;
            }

            if (e.PageState != null && e.PageState.ContainsKey("DexTemp")) 
            {
                StatsDexTemp.Text = e.PageState["DexTemp"].ToString();
            } 
            else 
            {

            }

            if (e.PageState != null && e.PageState.ContainsKey("ConTemp")) 
            {
                StatsConTemp.Text = e.PageState["ConTemp"].ToString();
            } 
            else 
            {
                StatsConTemp.Text = StatsConTemp.Text;
            }

            if (e.PageState != null && e.PageState.ContainsKey("IntTemp")) 
            {
                StatsIntTemp.Text = e.PageState["IntTemp"].ToString();
            } 

            else 
            {
                StatsIntTemp.Text = StatsInt.Text;
            }

            if(e.PageState != null && e.PageState.ContainsKey("WisTemp")) 
            {
                StatsWisTemp.Text = e.PageState["WisTemp"].ToString();
            } 
            else 
            {
                StatsWisTemp.Text = StatsWis.Text;
            }

            if (e.PageState != null && e.PageState.ContainsKey("ChaTemp")) 
            {
                StatsChaTemp.Text = e.PageState["ChaTemp"].ToString();
            } 
            else 
            {
                StatsChaTemp.Text = StatsCha.Text;
            }


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
            e.PageState["StrTemp"] = StatsStrTemp.Text;
            e.PageState["DexTemp"] = StatsDexTemp.Text;
            e.PageState["ConTemp"] = StatsConTemp.Text;
            e.PageState["IntTemp"] = StatsIntTemp.Text;
            e.PageState["WisTemp"] = StatsWisTemp.Text;
            e.PageState["ChaTemp"] = StatsChaTemp.Text;
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
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await ReadData();
            SetUpSheet(character[0]);
            setUpTempMods();
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override async void OnNavigatedFrom(NavigationEventArgs e)
        {
            Int16 saver;
            //if (Int16.TryParse(StatsCurrentHp.Text, out saver))
            //{
            //    character[0].StatsCurrentHp = saver;
            //}
            //if (Int16.TryParse(StatsStrTemp.Text, out saver))
            //{
            //    character[0].StatsStrTemp = saver;
            //}
            //if (Int16.TryParse(StatsDexTemp.Text, out saver))
            //{
            //    character[0].StatsDexTemp = saver;
            //}
            //if (Int16.TryParse(StatsConTemp.Text, out saver))
            //{
            //    character[0].StatsConTemp = saver;
            //}
            //if (Int16.TryParse(StatsIntTemp.Text, out saver))
            //{
            //    character[0].StatsIntTemp = saver;
            //}
            //if (Int16.TryParse(StatsWisTemp.Text, out saver))
            //{
            //    character[0].StatsWisTemp = saver;
            //}
            //if (Int16.TryParse(StatsChaTemp.Text, out saver))
            //{
            //    character[0].StatsChaTemp = saver;
            //}
            //await WriteData();
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        public void appBarBtn_Click(object sender, RoutedEventArgs e)
        {
            AppBarButton switcher = (AppBarButton)sender;

            switch (switcher.Name)
            {
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
            Frame.Navigate(typeof(statsEdit));
        }
        //Used for first time users to generate a generic character sheet for the user.

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

        private void SetUpSheet(Character character)
        {

            StatsStr.Text = character.StatsStr.ToString();
            StatsDex.Text = character.StatsDex.ToString();
            StatsCon.Text = character.StatsCon.ToString();
            StatsInt.Text = character.StatsInt.ToString();
            StatsWis.Text = character.StatsWis.ToString();
            StatsCha.Text = character.StatsCha.ToString();
            StatsCon.Text = character.StatsCon.ToString();

            StatsStrTemp.Text = character.StatsStrTemp.ToString();
            StatsDexTemp.Text = character.StatsDexTemp.ToString();
            StatsConTemp.Text = character.StatsConTemp.ToString();
            StatsIntTemp.Text = character.StatsIntTemp.ToString();
            StatsWisTemp.Text = character.StatsWisTemp.ToString();
            StatsChaTemp.Text = character.StatsChaTemp.ToString();

            StatsMaxHp.Text = character.StatsMaxHp.ToString();
            StatsCurrentHp.Text = character.StatsCurrentHp.ToString();

            ModStr.Text = calculateModifierString(StatsStr.Text.ToString());
            ModDex.Text = calculateModifierString(StatsDex.Text.ToString());
            ModCon.Text = calculateModifierString(StatsCon.Text.ToString());
            ModInt.Text = calculateModifierString(StatsInt.Text.ToString());
            ModWis.Text = calculateModifierString(StatsWis.Text.ToString());
            ModCha.Text = calculateModifierString(StatsCha.Text.ToString());
            
            
             

            StatsACDisplay.Text = calculateAC(character) + " (" + calculateFlatFootedAC(character) + " Flat-Footed, " + calculateTouchAC(character) + " Touch)";

            StatsBaseAttackBonus.Text = calculateBaseAttackBonus(character);

            StatsInitiative.Text = calculateInitiative(character);

            StatsFortitudeTotal.Text = calculateFortitudeTotal(character);
            StatsReflexTotal.Text = calculateReflexTotal(character);
            StatsWillpowerTotal.Text = calculateWillpowerTotal(character);

        }

        private double ModToDouble(String mod)
        {
            double number = 0;
            mod.Replace("+", "");
            mod.Replace("-", "");
            mod.Replace("--", "");
            number = double.Parse(mod);
            return number;
        }

        private String calculateModifierString(String baseStat)
        {
            String modifier = String.Empty;
            double number = 0;
            number = double.Parse(baseStat);
            if (number <= 0)
            {
                //number = 10;
                modifier = "0";
            }
            if (number >= 10)
            {
                number = Math.Floor((number - 10) / 2);
                if (number > 0)
                {
                    modifier = "+" + number;
                }
                else if (number < 0)
                {
                    modifier = "-" + number;
                }
                else
                {
                    modifier = "" + number;
                }
            }
            else
            {
                Int16 negStat = Convert.ToInt16(number);
                switch (negStat)
                {
                    case 9:
                        modifier = "-1";
                    break;
                    case 8:
                    modifier = "-1";
                    break;
                    case 7:
                    modifier = "-2";
                    break;
                    case 6:
                    modifier = "-2";
                    break;
                    case 5:
                    modifier = "-3";
                    break;
                    case 4:
                    modifier = "-3";
                    break;
                    case 3:
                    modifier = "-4";
                    break;
                    case 2:
                    modifier = "-4";
                    break;
                    case 1:
                    modifier = "-5";
                    break;
                    case 0:
                    modifier = "-5";
                    break;
                }
            }
            return modifier;
        }

        private double calculateModifierDouble(Int16 StatsDex)
        {
            double number = 0 + StatsDex;
            number = Math.Floor((number - 10) / 2);
            return number;
        }

        private String calculateAC(Character character)
        {
            String ac = String.Empty;
            Int16 StatsACArmor = character.StatsACArmor;
            Int16 StatsACDeflection = character.StatsACDeflection;
            Int16 StatsACMisc = character.StatsACMisc;
            Int16 StatsACNaturalArmor = character.StatsACNaturalArmor;
            Int16 StatsACShield = character.StatsACShield;
            Int16 StatsACSize = character.StatsACSize;
            double Dex = calculateModifierDouble(character.StatsDex);
            double TempDex = ModToDouble(TempModDex.Text.ToString());
            String PlaceHolder = "" + TempDex;
            int StatsDex = int.Parse(PlaceHolder);
            int total = 10 + StatsDex + StatsACArmor + StatsACDeflection + StatsACMisc + StatsACNaturalArmor + StatsACShield + StatsACSize;
            ac = "" + total;
            return ac;
        }

        private String calculateTouchAC(Character character)
        {
            String ac = String.Empty;
            Int16 StatsACDeflection = character.StatsACDeflection;
            Int16 StatsACMisc = character.StatsACMisc;
            Int16 StatsACSize = character.StatsACSize;
            double Dex = calculateModifierDouble(character.StatsDex);
            double TempDex = ModToDouble(TempModDex.Text.ToString());
            String PlaceHolder = "" + TempDex;
            int StatsDex = int.Parse(PlaceHolder);
            int total = 10 + StatsDex + StatsACDeflection + StatsACMisc + StatsACSize;
            ac = "" + total;
            return ac;
        }

        private String calculateFlatFootedAC(Character character)
        {
            String ac = String.Empty;
            Int16 StatsACArmor = character.StatsACArmor;
            Int16 StatsACDeflection = character.StatsACDeflection;
            Int16 StatsACNaturalArmor = character.StatsACNaturalArmor;
            Int16 StatsACShield = character.StatsACShield;
            Int16 StatsACSize = character.StatsACSize;
            int total = 10 + StatsACArmor + StatsACDeflection  + StatsACNaturalArmor + StatsACShield + StatsACSize;
            ac = "" + total;
            return ac;
        }

        private String calculateBaseAttackBonus(Character character)
        {
            String babString = String.Empty;
            Int16 babInt = character.StatsBaseAttackBonus;
            if (babInt >= 6 && babInt < 11)
            {
                babString = "+" + babInt + "/+" + (babInt-5); 
            }
            else if (babInt >= 11 && babInt < 16)
            {
                babString = "+" + babInt + "/+" + (babInt - 5) + "/+" + (babInt - 10); 
            }
            else if (babInt >= 16)
            {
                babString = "+" + babInt + "/+" + (babInt - 5) + "/+" + (babInt - 10) + "/+" + (babInt - 15);
            }
            else
            {
                babString = "+" + babInt;
            }
            return babString;

        }

        private String calculateInitiative(Character character)
        {
            String initString = String.Empty;
            double initDouble = 0;
            Int16 StatsInitiative = character.StatsInitiative;
            double TempDex = ModToDouble(TempModDex.Text.ToString());
            initDouble = StatsInitiative + TempDex;
            if (initDouble > 0)
            {
                initString = "+" + initDouble;
            }else 
            {
                initString = ""+initDouble;
            }

            return initString;
        }

        private String calculateFortitudeTotal(Character character)
        {
            String fortString = String.Empty;
            double fortDouble = 0;
            double TempCon = ModToDouble(TempModCon.Text.ToString());
            fortDouble = TempCon + character.StatsFortitudeBase + character.StatsFortitudeMagic + character.StatsFortitudeMisc;

            if (fortDouble > 0)
            {
                fortString = "+" + fortDouble;
            }
            else
            {
                fortString = "" + fortDouble;
            }
            
            //fortString = "+" + fortDouble;
            return fortString;
        }

        private String calculateReflexTotal(Character character)
        {
            String refString = String.Empty;
            double refDouble = 0;
            double TempDex = ModToDouble(TempModDex.Text.ToString());
            refDouble = TempDex + character.StatsReflexBase + character.StatsReflexMagic + character.StatsReflexMisc;

            if (refDouble > 0)
            {
                refString = "+" + refDouble;
            }
            else
            {
                refString = "" + refDouble;
            }

            //refString = "+" + refDouble;
            return refString;
        }

        private String calculateWillpowerTotal(Character character)
        {
            String wilString = String.Empty;
            double wilDouble = 0;
            double TempWis = ModToDouble(TempModWis.Text.ToString());
            wilDouble = TempWis + character.StatsWillpowerBase + character.StatsWillpowerMagic + character.StatsWillpowerMisc;
            //wilString = "+" + wilDouble;
            if (wilDouble > 0)
            {
                wilString = "+" + wilDouble;
            }
            else
            {
                wilString = "" + wilDouble;
            }
            return wilString;
        }

        private async void StatsTemp_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tempmod = (TextBox)sender;
            int i = 0;
            string s = tempmod.Text;
            bool result = int.TryParse(s, out i);
            Int16 convert = 0;

            if (result == true)
            {
                //tempmod.Text = calculateModifierString(tempmod.Text);

                switch (tempmod.Name)
                {
                    case "StatsStrTemp":

                        TempModStr.Text = calculateModifierString(StatsStrTemp.Text.ToString());
                        //modifier = ModToDouble(TempModStr.Text.ToString());
                        convert = Convert.ToInt16(i);
                        character[0].StatsStrTemp = convert;
                        break;
                    case "StatsDexTemp":
                        TempModDex.Text = calculateModifierString(StatsDexTemp.Text.ToString());
                        //modifier = ModToDouble(TempModDex.Text.ToString());
                        convert = Convert.ToInt16(i);
                        character[0].StatsDexTemp = convert;
                        break;
                    case "StatsConTemp":
                        TempModCon.Text = calculateModifierString(StatsConTemp.Text.ToString());
                        //modifier = ModToDouble(TempModCon.Text.ToString());
                        convert = Convert.ToInt16(i);
                        character[0].StatsConTemp = convert;
                        break;
                    case "StatsIntTemp":
                        TempModInt.Text = calculateModifierString(StatsIntTemp.Text.ToString());
                        //modifier = ModToDouble(TempModInt.Text.ToString());
                        convert = Convert.ToInt16(i);
                        character[0].StatsIntTemp = convert;
                        break;
                    case "StatsWisTemp":
                        TempModWis.Text = calculateModifierString(StatsWisTemp.Text.ToString());
                        //modifier = ModToDouble(TempModWis.Text.ToString());
                        convert = Convert.ToInt16(i);
                        character[0].StatsWisTemp = convert;
                        break;
                    case "StatsChaTemp":
                        TempModCha.Text = calculateModifierString(StatsChaTemp.Text.ToString());
                        //modifier = ModToDouble(TempModCha.Text.ToString());
                        convert = Convert.ToInt16(i);
                        character[0].StatsChaTemp = convert;
                        break;
                }
            }
            else
            {
                switch (tempmod.Name)
                {
                    case "StatsStrTemp":
                        tempmod.Text = Convert.ToString(character[0].StatsStr);
                        break;
                    case "StatsDexTemp":
                        tempmod.Text = Convert.ToString(character[0].StatsDex);
                        break;
                    case "StatsConTemp":
                        tempmod.Text = Convert.ToString(character[0].StatsCon);
                        break;
                    case "StatsIntTemp":
                        tempmod.Text = Convert.ToString(character[0].StatsInt);
                        break;
                    case "StatsWisTemp":
                        tempmod.Text = Convert.ToString(character[0].StatsWis);
                        break;
                    case "StatsChaTemp":
                        tempmod.Text = Convert.ToString(character[0].StatsCha);
                        break;
                }
            }
            await WriteData();
            SetUpSheet(character[0]);
            setUpTempMods();
        }

        private void setUpTempMods()
        {
            TempModStr.Text = calculateModifierString(StatsStrTemp.Text.ToString());
            TempModDex.Text = calculateModifierString(StatsDexTemp.Text.ToString());
            TempModCon.Text = calculateModifierString(StatsConTemp.Text.ToString());
            TempModInt.Text = calculateModifierString(StatsIntTemp.Text.ToString());
            TempModWis.Text = calculateModifierString(StatsWisTemp.Text.ToString());
            TempModCha.Text = calculateModifierString(StatsChaTemp.Text.ToString());

        }

        

        

        
    }
}
