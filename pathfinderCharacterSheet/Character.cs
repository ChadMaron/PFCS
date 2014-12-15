using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pathfinderCharacterSheet
{
    
    
    public class Character
    {
        /* Character Name */
        //public String CharacterName { get; set; } // For possible addition for multiple characters
        /* Basic Info */
        public String BasicName{get; set;} // Character's Name
        public String BasicClass {get; set; } // Character's Class Info
        public String BasicRace { get; set; } // Character's Race
        public String BasicAlignment { get; set; } // Character's Alignment
        public String BasicAge {get; set; }
        public String BasicGender { get; set; }
        public String BasicSize { get; set; }
        public String BasicWeight { get; set; }
        public String BasicDeity { get; set; }
        public String BasicHair { get; set; }
        public String BasicHomeland { get; set; }
        public String BasicEyes { get; set; }
        /* Character Stats*/
            /*Ability Scores*/
        public Int16 StatsStr { get; set; }
        public Int16 StatsDex { get; set; }
        public Int16 StatsCon { get; set; }
        public Int16 StatsInt { get; set; }
        public Int16 StatsWis { get; set; }
        public Int16 StatsCha { get; set; }
        
            /*Other Stats*/
        public Int16 StatsMaxHp { get; set; }
        public Int16 StatsCurrentHp { get; set; }
        public Int16 StatsInitiative { get; set; }
        public Int16 StatsBaseAttackBonus { get; set; }
            /*Saves*/
        public Int16 StatsFortitudeBase { get; set; }
        public Int16 StatsFortitudeMagic { get; set; }
        public Int16 StatsFortitudeMisc { get; set; }
        public Int16 StatsReflexBase { get; set; }
        public Int16 StatsReflexMagic { get; set; }
        public Int16 StatsReflexMisc { get; set; }
        public Int16 StatsWillpowerBase { get; set; }
        public Int16 StatsWillpowerMagic { get; set; }
        public Int16 StatsWillpowerMisc { get; set; }
            /*Armor*/
        public Int16 StatsACArmor { get; set; }
        public Int16 StatsACShield { get; set; }
        public Int16 StatsACSize { get; set; }
        public Int16 StatsACNaturalArmor { get; set; }
        public Int16 StatsACDeflection { get; set; }
        public Int16 StatsACMisc { get; set; }
        
            /*Temporary*/

        public Int16 StatsStrTemp { get; set; }
        public Int16 StatsDexTemp { get; set; }
        public Int16 StatsConTemp { get; set; }
        public Int16 StatsIntTemp { get; set; }
        public Int16 StatsWisTemp { get; set; }
        public Int16 StatsChaTemp { get; set; }
        public Int16 StatsFortitudeTemp { get; set; }
        public Int16 StatsReflexTemp { get; set; }
        public Int16 StatsWillpowerTemp { get; set; }

        public Character()
        {
         /* Basic Info */
         BasicName = "New Character";
         BasicClass = "Fighter 1"; 
         BasicRace = "Human"; 
         BasicAlignment = "Neutral Good"; 
         BasicAge = "25";
         BasicGender = "Male";
         BasicSize = "Medium";
         BasicWeight = "156lbs";
         BasicDeity = "None";
         BasicHair = "Brown";
         BasicHomeland = "Ravenmoor";
         BasicEyes = "Brown";

         /*Ability Scores*/
         StatsStr = 10;
         StatsDex = 10;
         StatsCon = 10;
         StatsInt = 10;
         StatsWis = 10;
         StatsCha = 10;
         
         /*Other Stats*/
         StatsMaxHp = 0;
         StatsCurrentHp = 0;
         StatsInitiative = 0;
         StatsBaseAttackBonus = 0;

         /*Saves*/
         StatsFortitudeBase  = 0;
         StatsFortitudeMagic = 0;
         StatsFortitudeMisc  = 0;
         StatsReflexBase  = 0;
         StatsReflexMagic = 0;
         StatsReflexMisc  = 0;
         StatsWillpowerBase  = 0;
         StatsWillpowerMagic = 0;
         StatsWillpowerMisc  = 0;
        
         /*Armor*/
         StatsACArmor  = 0;
         StatsACShield = 0;
         StatsACSize   = 0;
         StatsACNaturalArmor = 0;
         StatsACDeflection   = 0;
         StatsACMisc = 0;
        
         /*Temporary*/

         StatsStrTemp  = 10;
         StatsDexTemp  = 10;
         StatsConTemp  = 10;
         StatsIntTemp  = 10;
         StatsWisTemp  = 10;
         StatsChaTemp  = 10;
         StatsFortitudeTemp  = 0;
         StatsReflexTemp     = 0;
         StatsWillpowerTemp  = 0;
        }

        Character(String BasicName, String BasicClass, String BasicRace, String BasicAlignment, 
String BasicAge, String BasicGender, String BasicSize, String BasicWeight, 
String BasicDeity, String BasicHair, String BasicHomeland, String BasicEyes, 
Int16 StatsStr, Int16 StatsDex, Int16 StatsCon, Int16 StatsInt, Int16 StatsWis,
Int16 StatsCha, Int16 StatsMaxHp, Int16 StatsCurrentHp, Int16 StatsInitiative, Int16 StatsBaseAttackBonus,
Int16 StatsFortitudeBase, Int16 StatsFortitudeMagic, Int16 StatsFortitudeMisc, Int16 StatsReflexBase, 
Int16 StatsReflexMagic, Int16 StatsReflexMisc, Int16 StatsWillPowerBase, Int16 StatsWillPowerMagic,
Int16 StatsWillPowerMisc, Int16 StatsACArmor, Int16 StatsACShield, Int16 StatsACSize, 
Int16 StatsACNaturalArmor, Int16 StatsACDeflection, Int16 StatsACMisc, Int16 StatsStrTemp,
Int16 StatsDexTemp, Int16 StatsConTemp, Int16 StatsIntTemp, Int16 StatsWisTemp, Int16 StatsChaTemp,
Int16 StatsFortitudeTemp, Int16 StatsReflexTemp, Int16 StatsWillpowerTemp)
        {
            this.BasicName = BasicName;
            this.BasicClass = BasicClass;
            this.BasicRace = BasicRace;
            this.BasicAlignment = BasicAlignment;
            this.BasicAge = BasicAge;
            this.BasicGender = BasicGender;
            this.BasicSize = BasicSize;
            this.BasicWeight = BasicWeight;
            this.BasicDeity = BasicDeity;
            this.BasicHair = BasicHair;
            this.BasicHomeland = BasicHomeland;
            this.BasicEyes = BasicEyes;
            this.StatsStr = StatsStr;
            this.StatsDex = StatsDex;
            this.StatsCon = StatsCon;
            this.StatsInt = StatsInt;
            this.StatsWis = StatsWis;
            this.StatsCha = StatsCha;
            this.StatsMaxHp = StatsMaxHp;
            this.StatsCurrentHp = StatsCurrentHp;
            this.StatsInitiative = StatsInitiative;
            this.StatsBaseAttackBonus = StatsBaseAttackBonus;
            this.StatsFortitudeBase = StatsFortitudeBase;
            this.StatsFortitudeMagic = StatsFortitudeMagic;
            this.StatsFortitudeMisc = StatsFortitudeMisc;
            this.StatsReflexBase = StatsReflexBase;
            this.StatsReflexMagic = StatsReflexMagic;
            this.StatsReflexMisc = StatsReflexMisc;
            this.StatsWillpowerBase = StatsWillPowerBase;
            this.StatsWillpowerMagic = StatsWillPowerMagic;
            this.StatsWillpowerMisc = StatsWillPowerMisc;
            this.StatsACArmor = StatsACArmor;
            this.StatsACShield = StatsACShield;
            this.StatsACSize = StatsACSize;
            this.StatsACNaturalArmor = StatsACNaturalArmor;
            this.StatsACDeflection = StatsACDeflection;
            this.StatsACMisc = StatsACMisc;
            this.StatsStrTemp = StatsStrTemp;
            this.StatsDexTemp = StatsDexTemp;
            this.StatsConTemp = StatsConTemp;
            this.StatsIntTemp = StatsIntTemp;
            this.StatsWisTemp = StatsWisTemp;
            this.StatsChaTemp = StatsChaTemp;
            this.StatsFortitudeTemp = StatsFortitudeTemp;
            this.StatsReflexTemp = StatsReflexTemp;
            this.StatsWillpowerTemp = StatsWillpowerTemp;
        }
    }


}


