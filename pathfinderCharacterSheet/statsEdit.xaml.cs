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
    public sealed partial class statsEdit : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private List<Character> character;
        private String fileName;
        

        public statsEdit()
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
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await ReadData();
            SetUpSheet(character[0]);
            RefreshSheet();
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        

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
                    StatsWillpowerBase = read.StatsWillpowerBase,
                    StatsWillpowerMagic = read.StatsWillpowerMagic,
                    StatsWillpowerMisc = read.StatsWillpowerMisc,
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

            StatsMaxHp.Text = character.StatsMaxHp.ToString();
            StatsBaseAttackBonus.Text = character.StatsBaseAttackBonus.ToString();
            StatsInitiative.Text = character.StatsInitiative.ToString();

            StatsFortitudeBase.Text  = character.StatsFortitudeBase.ToString();
            StatsFortitudeMagic.Text = character.StatsFortitudeMagic.ToString();
            StatsFortitudeMisc.Text  = character.StatsFortitudeMisc.ToString();

            StatsReflexBase.Text  = character.StatsReflexBase.ToString();
            StatsReflexMagic.Text = character.StatsReflexMagic.ToString();
            StatsReflexMisc.Text  = character.StatsReflexMisc.ToString();

            StatsWillpowerBase.Text  = character.StatsWillpowerBase.ToString();
            StatsWillpowerMagic.Text = character.StatsWillpowerMagic.ToString();
            StatsWillpowerMisc.Text  = character.StatsWillpowerMisc.ToString();

            StatsACArmor.Text = character.StatsACArmor.ToString();
            StatsACShield.Text = character.StatsACShield.ToString();
            StatsACSize.Text = character.StatsACSize.ToString();
            StatsACNaturalArmor.Text = character.StatsACNaturalArmor.ToString();
            StatsACDeflection.Text = character.StatsACDeflection.ToString();
            StatsACMisc.Text = character.StatsACMisc.ToString();
        }

        private void SaveCharacter()
        {
            Int16 saver = 0;

            if(Int16.TryParse(StatsStr.Text, out saver)){
                character[0].StatsStr = saver;
            }
            if(Int16.TryParse(StatsDex.Text, out saver)){
                character[0].StatsDex = saver;
            }
            if(Int16.TryParse(StatsCon.Text, out saver)){
                character[0].StatsCon = saver;
            }
            if(Int16.TryParse(StatsInt.Text, out saver)){
                character[0].StatsInt = saver;
            }
            if(Int16.TryParse(StatsWis.Text, out saver)){
                character[0].StatsWis = saver;
            }
            if(Int16.TryParse(StatsCha.Text, out saver)){
                character[0].StatsCha = saver;
            }
            
            if(Int16.TryParse(StatsMaxHp.Text, out saver)){
                character[0].StatsMaxHp = saver;
            }
            if(Int16.TryParse(StatsInitiative.Text, out saver)){
                character[0].StatsInitiative = saver;
            }
            if(Int16.TryParse(StatsBaseAttackBonus.Text, out saver)){
                character[0].StatsBaseAttackBonus = saver;
            }
            
            if(Int16.TryParse(StatsFortitudeBase.Text, out saver)){
                character[0].StatsFortitudeBase = saver;
            }
            if(Int16.TryParse(StatsFortitudeMagic.Text, out saver)){
                character[0].StatsFortitudeMagic = saver;
            }
            if(Int16.TryParse(StatsFortitudeMisc.Text, out saver)){
                character[0].StatsFortitudeMisc = saver;
            }

            if(Int16.TryParse(StatsReflexBase.Text, out saver)){
                character[0].StatsReflexBase = saver;
            }
            if(Int16.TryParse(StatsReflexMagic.Text, out saver)){
                character[0].StatsReflexMagic = saver;
            }
            if(Int16.TryParse(StatsReflexMisc.Text, out saver)){
                character[0].StatsReflexMisc = saver;
            }
            
            if(Int16.TryParse(StatsWillpowerBase.Text, out saver)){
                character[0].StatsWillpowerBase = saver;
            }
            if(Int16.TryParse(StatsWillpowerMagic.Text, out saver)){
                character[0].StatsWillpowerMagic = saver;
            }
            if(Int16.TryParse(StatsWillpowerMisc.Text, out saver)){
                character[0].StatsWillpowerMisc = saver;
            }
            
            if(Int16.TryParse(StatsACArmor.Text, out saver)){
                character[0].StatsACArmor = saver;
            }
            if(Int16.TryParse(StatsACShield.Text, out saver)){
                character[0].StatsACShield = saver;
            }
            if(Int16.TryParse(StatsACSize.Text, out saver)){
                character[0].StatsACSize = saver;
            }
            if(Int16.TryParse(StatsACNaturalArmor.Text, out saver)){
                character[0].StatsACNaturalArmor = saver;
            }
            if(Int16.TryParse(StatsACDeflection.Text, out saver)){
                character[0].StatsACDeflection = saver;
            }
              if(Int16.TryParse(StatsACMisc.Text, out saver)){
                character[0].StatsACMisc = saver;
            }
                    
        }

        private async void btnStatsSave_Click(object sender, RoutedEventArgs e)
        {
            SaveCharacter();
            await WriteData();
            Frame.Navigate(typeof(statsDisplay));
        }

        private double ModToDouble(String mod)
        {
            double number = 0;
            mod.Replace("+", "");
            mod.Replace("-", "");
            number = double.Parse(mod);
            return number;
        }

        private void StatsTemp_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tempmod = (TextBox)sender;
            int i = 0;
            string s = tempmod.Text;
            bool result = int.TryParse(s, out i);
            if (result == true)
            {
                //tempmod.Text = calculateModifierString(tempmod.Text);

                switch (tempmod.Name)
                {
                    case "StatsStr":

                        StatsStrMod.Text = calculateModifierString(StatsStr.Text.ToString());
                        break;
                    case "StatsDex":
                        StatsDexMod.Text = calculateModifierString(StatsDex.Text.ToString());
                        break;
                    case "StatsCon":
                        StatsConMod.Text = calculateModifierString(StatsCon.Text.ToString());
                        break;
                    case "StatsInt":
                        StatsIntMod.Text = calculateModifierString(StatsInt.Text.ToString());
                        break;
                    case "StatsWis":
                        StatsWisMod.Text = calculateModifierString(StatsWis.Text.ToString());
                        break;
                    case "StatsCha":
                        StatsChaMod.Text = calculateModifierString(StatsCha.Text.ToString());
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
            RefreshSheet();
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

        private String calculateSaveModifierInt(Int16 mod){
            String modifier = String.Empty;
            if (mod > 0){
                modifier = "+" + mod;
            }
            else
            {
                modifier = ""+mod;
            }
            return modifier;
        }

            private void StatsSave_LostFocus(object sender, RoutedEventArgs e)
            {
                TextBox tempmod = (TextBox)sender;
                int i = 0;
                string s = tempmod.Text;
                bool result = int.TryParse(s, out i);
                if (!result)
                {
                    tempmod.Text = ""+0;
                    i = 0;
                }

                RefreshSheet();
                
            }

            private void RefreshSheet()
            {

                StatsStrMod.Text = calculateModifierString(StatsStr.Text.ToString());
                StatsDexMod.Text = calculateModifierString(StatsDex.Text.ToString());
                StatsConMod.Text = calculateModifierString(StatsCon.Text.ToString());
                StatsIntMod.Text = calculateModifierString(StatsInt.Text.ToString());
                StatsWisMod.Text = calculateModifierString(StatsWis.Text.ToString());
                StatsChaMod.Text = calculateModifierString(StatsCha.Text.ToString());
        


                Int16 ConModifier            = Convert.ToInt16(ModToDouble(StatsConMod.Text.ToString()));
                Int16 DexModifier            = Convert.ToInt16(ModToDouble(StatsDexMod.Text.ToString()));
                Int16 WisModifier            = Convert.ToInt16(ModToDouble(StatsWisMod.Text.ToString()));
                                             
                                             
                /* Initiative */             
                Int16 InitMisc               = Int16.Parse(StatsInitiative.Text);
                Int16 InitTotal              = (Int16)(InitMisc + DexModifier);
                StatsInitiativeModifier.Text = "" + InitTotal;

                /*Saves*/
                Int16 FortBase               = Int16.Parse(StatsFortitudeBase.Text);
                Int16 FortMagic              = Int16.Parse(StatsFortitudeMagic.Text);
                Int16 FortMisc               = Int16.Parse(StatsFortitudeMisc.Text);
                                             
                Int16 FortTotal              = (Int16)(FortBase + FortMagic + FortMisc + ConModifier);
                StatsFortitudeAbility.Text   = StatsConMod.Text;
                StatsFortTotal.Text          = calculateSaveModifierInt(FortTotal);
                                             
                Int16 ReflexBase             = Int16.Parse(StatsReflexBase.Text);
                Int16 ReflexMagic            = Int16.Parse(StatsReflexMagic.Text);
                Int16 ReflexMisc             = Int16.Parse(StatsReflexMisc.Text);
                                             
                Int16 ReflexTotal            = (Int16)(ReflexBase + ReflexMagic + ReflexMisc + DexModifier);
                StatsReflexAbility.Text      = StatsDexMod.Text;
                StatsReflexTotal.Text        = calculateSaveModifierInt(ReflexTotal);
                                             
                Int16 WillBase               = Int16.Parse(StatsWillpowerBase.Text);
                Int16 WillMagic              = Int16.Parse(StatsWillpowerMagic.Text);
                Int16 WillMisc               = Int16.Parse(StatsWillpowerMisc.Text);
                                             
                Int16 WillTotal              = (Int16)(WillBase + WillMagic + WillMisc + WisModifier);
                StatsWillpowerAbility.Text   = StatsWisMod.Text;
                StatsWillTotal.Text          = calculateSaveModifierInt(WillTotal);


                /* AC */
                Int16 ACArmor                = Int16.Parse(StatsACArmor.Text);
                Int16 ACDeflection           = Int16.Parse(StatsACDeflection.Text);
                Int16 ACMisc                 = Int16.Parse(StatsACMisc.Text);
                Int16 ACNatArmor             = Int16.Parse(StatsACNaturalArmor.Text);
                Int16 ACShield               = Int16.Parse(StatsACShield.Text);
                Int16 ACSize                 = Int16.Parse(StatsACSize.Text);
                Int16 ACTotal                = (Int16)(ACArmor + ACDeflection + ACMisc + ACNatArmor + ACShield + ACSize + DexModifier + 10);
                StatsACDex.Text              = StatsDexMod.Text; 
                StatsACTotal.Text            = "" + ACTotal;
                
            }
            
        

        
    }
}
