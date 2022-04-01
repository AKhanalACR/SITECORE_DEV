using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages
{
	public partial class PledgeFormItem
	{
		private static readonly IList<string> _referringPractProfessionsAndRoles = new List<string>();
		private static readonly IList<string> _professionsAndRoles = new List<string>();
		private static readonly IDictionary<KeyValuePair<string, string>, string> _pledgeStates = new Dictionary<KeyValuePair<string, string>, string>();
		private static readonly IDictionary<KeyValuePair<string, string>, string> _pledgeProvinces = new Dictionary<KeyValuePair<string, string>, string>();
		private static readonly IDictionary<KeyValuePair<string, string>, string> _pledgeInternational = new Dictionary<KeyValuePair<string, string>, string>();
		private static readonly IList<string> _pledgeCountries = new List<string>();
		private static readonly IList<string> _primaryPracticeTypes = new List<string>();
		private static readonly IList<string> _imageWiselyCampaign = new List<string>();

		public IEnumerable<string> ReferringPractitionerProfessionsAndRoles
		{
			get
			{
				if (_referringPractProfessionsAndRoles.Count == 0)
				{
					_referringPractProfessionsAndRoles.Add("Non-Radiologist Physician");
					_referringPractProfessionsAndRoles.Add("Hospital/Department Administrator");
					_referringPractProfessionsAndRoles.Add("Nurse");
					_referringPractProfessionsAndRoles.Add("Physician Assistant");
					_referringPractProfessionsAndRoles.Add("Other");
				}
				return _referringPractProfessionsAndRoles;
			}
		}

		public IEnumerable<string> ProfessionsAndRoles
		{
			get
			{
				if (_professionsAndRoles.Count == 0)
				{
					_professionsAndRoles.Add("Radiologist");
					_professionsAndRoles.Add("Non-Radiologist Physician");
					_professionsAndRoles.Add("Medical Physicist");
					_professionsAndRoles.Add("Radiation Oncologist");
					_professionsAndRoles.Add("Imaging Technologist");
					_professionsAndRoles.Add("Registered Radiologist Assistant");
					_professionsAndRoles.Add("Hospital/Department Administrator");
					_professionsAndRoles.Add("Nurse");
					_professionsAndRoles.Add("Physician Assistant");
                    //added on 3/7/2017
                    _professionsAndRoles.Add("Radiation Therapist");
                    _professionsAndRoles.Add("Student");
                    //-----
                    _professionsAndRoles.Add("Other");
				}
				return _professionsAndRoles;
			}
		}

		public IDictionary<KeyValuePair<string, string>, string> PledgeStates
		{
			get
			{
				if (_pledgeStates.Count == 0)
				{
					// U.S. States and Territories
					_pledgeStates.Add(new KeyValuePair<string, string>("AL", "Alabama"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("AK", "Alaska"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("AS", "American Samoa"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("AZ", "Arizona"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("AR", "Arkansas"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("CA", "California"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("CO", "Colorado"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("CT", "Connecticut"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("DE", "Delaware"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("DC", "District of Columbia"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("FM", "Fed. States of Micronesia"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("FL", "Florida"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("GA", "Georgia"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("GU", "Guam"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("HI", "Hawaii"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("ID", "Idaho"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("IL", "Illinois"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("IN", "Indiana"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("IA", "Iowa"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("KS", "Kansas"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("KY", "Kentucky"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("LA", "Louisiana"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("ME", "Maine"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("MH", "Marshall Islands"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("MD", "Maryland"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("MA", "Massachusetts"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("MI", "Michigan"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("MN", "Minnesota"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("MS", "Mississippi"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("MO", "Missouri"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("MT", "Montana"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("NE", "Nebraska"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("NV", "Nevada"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("NH", "New Hampshire"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("NJ", "New Jersey"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("NM", "New Mexico"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("NY", "New York"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("NC", "North Carolina"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("ND", "North Dakota"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("MP", "Northern Mariana Is."), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("OH", "Ohio"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("OK", "Oklahoma"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("OR", "Oregon"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("PW", "Palau"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("PA", "Pennsylvania"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("PR", "Puerto Rico"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("RI", "Rhode Island"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("SC", "South Carolina"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("SD", "South Dakota"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("TN", "Tennessee"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("TX", "Texas"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("UT", "Utah"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("VT", "Vermont"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("VI", "Virgin Islands"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("VA", "Virginia"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("WA", "Washington"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("WV", "West Virginia"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("WI", "Wisconsin"), "state");
					_pledgeStates.Add(new KeyValuePair<string, string>("WY", "Wyoming"), "state");
				}
				return _pledgeStates;
			}
		}

		public IDictionary<KeyValuePair<string, string>, string> PledgeProvinces
		{
			get
			{
				if (_pledgeProvinces.Count == 0)
				{
					// Canadian Provinces
					_pledgeProvinces.Add(new KeyValuePair<string, string>("AB", "Alberta"), "province");
					_pledgeProvinces.Add(new KeyValuePair<string, string>("BC", "British Columbia"), "province");
					_pledgeProvinces.Add(new KeyValuePair<string, string>("MB", "Manitoba"), "province");
					_pledgeProvinces.Add(new KeyValuePair<string, string>("NB", "New Brunswick"), "province");
					_pledgeProvinces.Add(new KeyValuePair<string, string>("NF", "Newfoundland"), "province");
					_pledgeProvinces.Add(new KeyValuePair<string, string>("NT", "Northwest Territories"), "province");
					_pledgeProvinces.Add(new KeyValuePair<string, string>("NS", "Nova Scotia"), "province");
					_pledgeProvinces.Add(new KeyValuePair<string, string>("ON", "Ontario"), "province");
					_pledgeProvinces.Add(new KeyValuePair<string, string>("PE", "Prince Edward Island"), "province");
					_pledgeProvinces.Add(new KeyValuePair<string, string>("QC", "Quebec"), "province");
					_pledgeProvinces.Add(new KeyValuePair<string, string>("SK", "Saskatchewan"), "province");
					_pledgeProvinces.Add(new KeyValuePair<string, string>("YT", "Yukon"), "province");
				}
				return _pledgeProvinces;
			}
		}

		public IDictionary<KeyValuePair<string, string>, string> PledgeInternational
		{
			get
			{
				if (_pledgeInternational.Count == 0)
				{
					// Empty Option for International
					_pledgeInternational.Add(new KeyValuePair<string, string>("", ""), "international"); //International
				}
				return _pledgeInternational;
			}
		}

		public IEnumerable<string> PledgeCountries
		{
			get
			{
				if (_pledgeCountries.Count == 0)
				{
					_pledgeCountries.Add("Afghanistan");
					_pledgeCountries.Add("Albania");
					_pledgeCountries.Add("Algeria");
					_pledgeCountries.Add("American Samoa");
					_pledgeCountries.Add("Andorra");
					_pledgeCountries.Add("Angola");
					_pledgeCountries.Add("Anguilla");
					_pledgeCountries.Add("Antarctica");
					_pledgeCountries.Add("Antigua and Barbuda");
					_pledgeCountries.Add("Argentina");
					_pledgeCountries.Add("Armenia ");
					_pledgeCountries.Add("Aruba");
					_pledgeCountries.Add("Australia");
					_pledgeCountries.Add("Austria");
					_pledgeCountries.Add("Azerbaijan");
					_pledgeCountries.Add("Bahamas");
					_pledgeCountries.Add("Bahrain");
					_pledgeCountries.Add("Bangladesh ");
					_pledgeCountries.Add("Barbados");
					_pledgeCountries.Add("Belarus");
					_pledgeCountries.Add("Belgium");
					_pledgeCountries.Add("Belize");
					_pledgeCountries.Add("Bermuda");
					_pledgeCountries.Add("Bhutan");
					_pledgeCountries.Add("Bolivia");
					_pledgeCountries.Add("Bosnia and Herzegovina");
					_pledgeCountries.Add("Botswana");
					_pledgeCountries.Add("Brazil");
					_pledgeCountries.Add("British Indian Ocean Territory");
					_pledgeCountries.Add("Brunei Darussalam");
					_pledgeCountries.Add("Bulgaria");
					_pledgeCountries.Add("Burkina Faso");
					_pledgeCountries.Add("Burundi");
					_pledgeCountries.Add("Cambodia");
					_pledgeCountries.Add("Cameroon");
					_pledgeCountries.Add("Canada");
					_pledgeCountries.Add("Cape Verde");
					_pledgeCountries.Add("Cayman Islands");
					_pledgeCountries.Add("Central African Republic");
					_pledgeCountries.Add("Chad");
					_pledgeCountries.Add("Chile");
					_pledgeCountries.Add("China");
					_pledgeCountries.Add("Christmas Island");
					_pledgeCountries.Add("Cocos (Keeling) Islands");
					_pledgeCountries.Add("Colombia");
					_pledgeCountries.Add("Comoros");
					_pledgeCountries.Add("Congo");
					_pledgeCountries.Add("Congo Democratic Republic");
					_pledgeCountries.Add("Cook Islands");
					_pledgeCountries.Add("Costa Rica");
					_pledgeCountries.Add("Cote D'Ivoire");
					_pledgeCountries.Add("Croatia");
					_pledgeCountries.Add("Cuba");
					_pledgeCountries.Add("Cyprus");
					_pledgeCountries.Add("Czech Republic");
					_pledgeCountries.Add("Denmark");
					_pledgeCountries.Add("Djibouti");
					_pledgeCountries.Add("Dominica");
					_pledgeCountries.Add("Dominican Republic");
					_pledgeCountries.Add("East Timor");
					_pledgeCountries.Add("Ecuador");
					_pledgeCountries.Add("Egypt");
					_pledgeCountries.Add("El Salvador");
					_pledgeCountries.Add("Equatorial Guinea");
					_pledgeCountries.Add("Eritrea");
					_pledgeCountries.Add("Estonia");
					_pledgeCountries.Add("Ethiopia");
					_pledgeCountries.Add("Falkland Islands (Malvinas)");
					_pledgeCountries.Add("Faroe Islands");
					_pledgeCountries.Add("Fiji");
					_pledgeCountries.Add("Finland");
					_pledgeCountries.Add("France");
					_pledgeCountries.Add("French Guiana");
					_pledgeCountries.Add("French Polynesia");
					_pledgeCountries.Add("French Southern Territories");
					_pledgeCountries.Add("Gabon");
					_pledgeCountries.Add("Gambia");
					_pledgeCountries.Add("Georgia");
					_pledgeCountries.Add("Germany");
					_pledgeCountries.Add("Ghana");
					_pledgeCountries.Add("Gibraltar");
					_pledgeCountries.Add("Greece");
					_pledgeCountries.Add("Greenland");
					_pledgeCountries.Add("Grenada");
					_pledgeCountries.Add("Guadeloupe");
					_pledgeCountries.Add("Guam");
					_pledgeCountries.Add("Guatemala");
					_pledgeCountries.Add("Guinea");
					_pledgeCountries.Add("Guinea-Bissau");
					_pledgeCountries.Add("Guyana");
					_pledgeCountries.Add("Haiti");
					_pledgeCountries.Add("Heard and McDonald Islands");
					_pledgeCountries.Add("Holy See (Vatican City)");
					_pledgeCountries.Add("Honduras");
					_pledgeCountries.Add("Hong Kong");
					_pledgeCountries.Add("Hungary");
					_pledgeCountries.Add("Iceland");
					_pledgeCountries.Add("India");
					_pledgeCountries.Add("Indonesia");
					_pledgeCountries.Add("Iran Islamic Republic of");
					_pledgeCountries.Add("Iraq");
					_pledgeCountries.Add("Ireland");
					_pledgeCountries.Add("Israel");
					_pledgeCountries.Add("Italy");
					_pledgeCountries.Add("Jamaica");
					_pledgeCountries.Add("Japan");
					_pledgeCountries.Add("Jordan");
					_pledgeCountries.Add("Kazakstan");
					_pledgeCountries.Add("Kenya");
					_pledgeCountries.Add("Kiribati");
					_pledgeCountries.Add("Korea North ");
					_pledgeCountries.Add("Korea South");
					_pledgeCountries.Add("Kuwait");
					_pledgeCountries.Add("Kyrgyzstan");
					_pledgeCountries.Add("Lao");
					_pledgeCountries.Add("Latvia");
					_pledgeCountries.Add("Lebanon");
					_pledgeCountries.Add("Lesotho");
					_pledgeCountries.Add("Liberia");
					_pledgeCountries.Add("Libyan Arab Jamahiriya");
					_pledgeCountries.Add("Liechtenstein");
					_pledgeCountries.Add("Lithuania");
					_pledgeCountries.Add("Luxembourg");
					_pledgeCountries.Add("Macau");
					_pledgeCountries.Add("Macedonia");
					_pledgeCountries.Add("Madagascar");
					_pledgeCountries.Add("Malawi");
					_pledgeCountries.Add("Malaysia");
					_pledgeCountries.Add("Maldives");
					_pledgeCountries.Add("Mali");
					_pledgeCountries.Add("Malta");
					_pledgeCountries.Add("Marshall Islands");
					_pledgeCountries.Add("Martinique");
					_pledgeCountries.Add("Mauritania");
					_pledgeCountries.Add("Mauritius");
					_pledgeCountries.Add("Mayotte");
					_pledgeCountries.Add("Mexico");
					_pledgeCountries.Add("Micronesia");
					_pledgeCountries.Add("Moldova Republic of");
					_pledgeCountries.Add("Monaco");
					_pledgeCountries.Add("Mongolia");
					_pledgeCountries.Add("Montserrat");
					_pledgeCountries.Add("Morocco");
					_pledgeCountries.Add("Mozambique");
					_pledgeCountries.Add("Myanmar");
					_pledgeCountries.Add("Namibia");
					_pledgeCountries.Add("Nauru");
					_pledgeCountries.Add("Nepal");
					_pledgeCountries.Add("Netherlands");
					_pledgeCountries.Add("Netherlands Antilles");
					_pledgeCountries.Add("New Caledonia");
					_pledgeCountries.Add("New Zealand");
					_pledgeCountries.Add("Nicaragua");
					_pledgeCountries.Add("Niger");
					_pledgeCountries.Add("Nigeria");
					_pledgeCountries.Add("Niue");
					_pledgeCountries.Add("Norfolk Island");
					_pledgeCountries.Add("Northern Mariana Islands");
					_pledgeCountries.Add("Norway");
					_pledgeCountries.Add("Oman");
					_pledgeCountries.Add("Pakistan");
					_pledgeCountries.Add("Palau");
					_pledgeCountries.Add("Palestinian Territory");
					_pledgeCountries.Add("Panama");
					_pledgeCountries.Add("Papua New Guinea");
					_pledgeCountries.Add("Paraguay");
					_pledgeCountries.Add("Peru");
					_pledgeCountries.Add("Philippines");
					_pledgeCountries.Add("Pitcairn");
					_pledgeCountries.Add("Poland");
					_pledgeCountries.Add("Portugal");
					_pledgeCountries.Add("Puerto Rico");
					_pledgeCountries.Add("Qatar");
					_pledgeCountries.Add("Reunion");
					_pledgeCountries.Add("Romania");
					_pledgeCountries.Add("Russian Federation");
					_pledgeCountries.Add("Rwanda");
					_pledgeCountries.Add("S. Georgia and S. Sandwich Is.");
					_pledgeCountries.Add("Saint Helena ");
					_pledgeCountries.Add("Saint Kitts and Nevis");
					_pledgeCountries.Add("Saint Lucia");
					_pledgeCountries.Add("Saint Pierre and Miquelon");
					_pledgeCountries.Add("Samoa");
					_pledgeCountries.Add("San Marino");
					_pledgeCountries.Add("Sao Tome and Principe");
					_pledgeCountries.Add("Saudi Arabia");
					_pledgeCountries.Add("Senegal");
					_pledgeCountries.Add("Seychelles");
					_pledgeCountries.Add("Sierra Leone");
					_pledgeCountries.Add("Singapore");
					_pledgeCountries.Add("Slovakia");
					_pledgeCountries.Add("Slovenia");
					_pledgeCountries.Add("Solomon Islands");
					_pledgeCountries.Add("Somalia");
					_pledgeCountries.Add("South Africa");
					_pledgeCountries.Add("Spain");
					_pledgeCountries.Add("Sri Lanka");
					_pledgeCountries.Add("St. Vincent and Grenadines");
					_pledgeCountries.Add("Sudan");
					_pledgeCountries.Add("Suriname");
					_pledgeCountries.Add("Svalbard and Jan Mayen");
					_pledgeCountries.Add("Swaziland");
					_pledgeCountries.Add("Sweden");
					_pledgeCountries.Add("Switzerland");
					_pledgeCountries.Add("Syrian Arab Republic");
					_pledgeCountries.Add("Taiwan");
					_pledgeCountries.Add("Tajikistan");
					_pledgeCountries.Add("Tanzania United Republic of");
					_pledgeCountries.Add("Thailand");
					_pledgeCountries.Add("Togo");
					_pledgeCountries.Add("Tokelau");
					_pledgeCountries.Add("Tonga");
					_pledgeCountries.Add("Trinidad and Tobago");
					_pledgeCountries.Add("Tunisia");
					_pledgeCountries.Add("Turkey");
					_pledgeCountries.Add("Turkmenistan");
					_pledgeCountries.Add("Turks and Caicos Islands");
					_pledgeCountries.Add("Tuvalu");
					_pledgeCountries.Add("U.S.Minor Outlying Islands");
					_pledgeCountries.Add("Uganda");
					_pledgeCountries.Add("Ukraine");
					_pledgeCountries.Add("United Arab Emirates");
					_pledgeCountries.Add("United Kingdom");
					_pledgeCountries.Add("United States");
					_pledgeCountries.Add("Uruguay");
					_pledgeCountries.Add("Uzbekistan");
					_pledgeCountries.Add("Vanuatu");
					_pledgeCountries.Add("Venezuela");
					_pledgeCountries.Add("Viet Nam");
					_pledgeCountries.Add("Virgin Islands British");
					_pledgeCountries.Add("Virgin Islands U.S.");
					_pledgeCountries.Add("Wallis and Futuna");
					_pledgeCountries.Add("Western Sahara");
					_pledgeCountries.Add("Yemen");
					_pledgeCountries.Add("Yugoslavia");
					_pledgeCountries.Add("Zambia");
					_pledgeCountries.Add("Zimbabwe");
				}
				return _pledgeCountries;
			}
		}

		public IEnumerable<string> PrimaryPracticeTypes
		{
			get
			{
				if (_primaryPracticeTypes.Count == 0)
				{
					_primaryPracticeTypes.Add("Academic/University-based");
					_primaryPracticeTypes.Add("Private Office/Imaging Center");
					_primaryPracticeTypes.Add("Children's Hospital");
					_primaryPracticeTypes.Add("Community Hospital-based");
					_primaryPracticeTypes.Add("Multispecialty Clinic");
					_primaryPracticeTypes.Add("VA/Military/Public Health System");
					_primaryPracticeTypes.Add("Other");
				}
				return _primaryPracticeTypes;
			}
		}

		public IEnumerable<string> ImageWiselyCampaign
		{
			get
			{
				if (_imageWiselyCampaign.Count == 0)
				{
					_imageWiselyCampaign.Add("AAPM");
					_imageWiselyCampaign.Add("AAP");
					_imageWiselyCampaign.Add("ACR");
					_imageWiselyCampaign.Add("AOCR");
					_imageWiselyCampaign.Add("ARRS");
					_imageWiselyCampaign.Add("ARRT");
					_imageWiselyCampaign.Add("ASRT");
					_imageWiselyCampaign.Add("AUR");
					_imageWiselyCampaign.Add("CRCPD");
					_imageWiselyCampaign.Add("NCRP");
					_imageWiselyCampaign.Add("Press");
					_imageWiselyCampaign.Add("RSNA");
					_imageWiselyCampaign.Add("SBCT-MR");
					_imageWiselyCampaign.Add("Internet");
					_imageWiselyCampaign.Add("Scientific Publication");
					_imageWiselyCampaign.Add("SIR");
					_imageWiselyCampaign.Add("Social Media");
					_imageWiselyCampaign.Add("SPR");
					_imageWiselyCampaign.Add("Trade Publication");
					_imageWiselyCampaign.Add("Other");
				}
				return _imageWiselyCampaign;
			}
		}

	}
}