using System;
using System.Collections.Generic;
using HLib.Settings.Property;
using TB.Core.Classes.Properties.Languages;
using TB.Core.Enumerations;
using TB.Core.Interfaces.Properties;

namespace TB.Core.Classes.Properties
{
    public sealed class PDictionary : Property<PDictionary>
    {
        #region Objects

        private ELanguageID languageID;

        #endregion Objects

        #region

        private PDictionary()
        {
            this.Serializeable = false;
            this.Deserializeable = false;

            this.languageID = ELanguageID.UNKNOWN;

            this.InitLanguages();
            this.InitDictionaries();
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// The id of the language of ther server
        /// </summary>
        /// <remarks>
        /// Changing the id of the language will lead to reinitialising the whoe dictionary
        /// So it is nesseccery to set the language id befor resolving buildings for example.
        /// </remarks>
        public ELanguageID LanguageID
        {
            get { return this.languageID; }
            set
            {
                this.languageID = value;
                this.Dictionary = this.Dictionaries[this.languageID];
                this.InitBuildings();
            }
        }

        public IDictionary<String, EBuildingType> Buildings { get; private set; }

        /// <summary>
        /// This dictionary serves the ids combined with the servers state domain.
        /// </summary>
        /// <example>
        /// "de" -> GERMEN
        /// "uk" -> ENGLISH
        /// </example>
        public IDictionary<String, ELanguageID> Languages { get; private set; }

        private IDictionary<ELanguageID, IPDictionary> Dictionaries { get; set; }
        private IPDictionary Dictionary { get; set; }

        #endregion Properties

        #region Methods

        private void InitBuildings()
        {
            this.Buildings = new Dictionary<String, EBuildingType>();

            this.Buildings.Add(this.Dictionary.Unused, EBuildingType.UNUSED);
            this.Buildings.Add(this.Dictionary.Ironmine, EBuildingType.IRONMINE);
            this.Buildings.Add(this.Dictionary.Claypit, EBuildingType.CLAYPIT);
            this.Buildings.Add(this.Dictionary.Cornfarm, EBuildingType.CORNFARM);
            this.Buildings.Add(this.Dictionary.Lumberjack, EBuildingType.LUMBERJACK);
            this.Buildings.Add(this.Dictionary.Warehouse, EBuildingType.WAREHOUSE);
            this.Buildings.Add(this.Dictionary.Granary, EBuildingType.GRANARY);
            this.Buildings.Add(this.Dictionary.Cornmil, EBuildingType.CORNMIL);
            this.Buildings.Add(this.Dictionary.HeroYard, EBuildingType.HEROYARD);
            this.Buildings.Add(this.Dictionary.Palace, EBuildingType.PALACE);
            this.Buildings.Add(this.Dictionary.Barrack, EBuildingType.BARRACK);
            this.Buildings.Add(this.Dictionary.Embassy, EBuildingType.EMBASSY);
            this.Buildings.Add(this.Dictionary.Claystill, EBuildingType.CLAYSTILL);
            this.Buildings.Add(this.Dictionary.Market, EBuildingType.MARKET);
            this.Buildings.Add(this.Dictionary.MainBuilding, EBuildingType.MAINBUILDING);
            this.Buildings.Add(this.Dictionary.IronFoundry, EBuildingType.IRONFOUNDRY);
            this.Buildings.Add(this.Dictionary.Stash, EBuildingType.STASH);
            this.Buildings.Add(this.Dictionary.Lumbermil, EBuildingType.LUMBERMIL);
            this.Buildings.Add(this.Dictionary.AssemblyPlace, EBuildingType.ASSEMBLYPLACE);
            this.Buildings.Add(this.Dictionary.Academy, EBuildingType.ACADAMY);
            this.Buildings.Add(this.Dictionary.Blacksmith, EBuildingType.BLACKSMITH);
            this.Buildings.Add(this.Dictionary.Workshop, EBuildingType.WORKSHOP);
            this.Buildings.Add(this.Dictionary.Wall, EBuildingType.WALL);
            this.Buildings.Add(this.Dictionary.Bakery, EBuildingType.BAKERY);
            this.Buildings.Add(this.Dictionary.Barn, EBuildingType.BARN);
            this.Buildings.Add(this.Dictionary.Chiseler, EBuildingType.CHISELER);
        }

        private void InitLanguages()
        {
            this.Languages = new Dictionary<String, ELanguageID>();

            this.Languages.Add("de", ELanguageID.GERMAN);
        }

        private void InitDictionaries()
        {
            this.Dictionaries = new Dictionary<ELanguageID, IPDictionary>();

            this.Dictionaries.Add(ELanguageID.GERMAN, PDictionaryDE.GetInstance());
        }

        #endregion Methods
    }
}