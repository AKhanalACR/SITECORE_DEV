using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.ImageWiselyContent.Services.Entities
{
    public class PledgeItems
    {
        private static IList<SelectListItem> _countries;

        // Canadian Provinces
        private static IList<SelectListItem> _provinces;

        // USA states
        private static IList<SelectListItem> _states;

        private static IList<SelectListItem> _practiceTypes;
        private static IList<SelectListItem> _professions;
        private static IList<SelectListItem> _professionsAndRoles;
        private static IList<SelectListItem> _imageWiselyCampaign;

        public static IEnumerable<SelectListItem> Countries { 
            get 
            {
                if (_countries == null)
                {
                    _countries = new List<SelectListItem>
                    {
                        new SelectListItem() {Text = "Afghanistan", Value = "Afghanistan"},
                        new SelectListItem() {Text = "Albania", Value = "Albania"},
                        new SelectListItem() {Text = "Algeria", Value = "Algeria"},
                        new SelectListItem() {Text = "American Samoa", Value = "American Samoa"},
                        new SelectListItem() {Text = "Andorra", Value = "Andorra"},
                        new SelectListItem() {Text = "Angola", Value = "Angola"},
                        new SelectListItem() {Text = "Anguilla", Value = "Anguilla"},
                        new SelectListItem() {Text = "Antarctica", Value = "Antarctica"},
                        new SelectListItem() {Text = "Antigua and Barbuda", Value = "Antigua and Barbuda"},
                        new SelectListItem() {Text = "Argentina", Value = "Argentina"},
                        new SelectListItem() {Text = "Armenia ", Value = "Armenia"},
                        new SelectListItem() {Text = "Aruba", Value = "Aruba"},
                        new SelectListItem() {Text = "Australia", Value = "Australia"},
                        new SelectListItem() {Text = "Austria", Value = "Austria"},
                        new SelectListItem() {Text = "Azerbaijan", Value = "Azerbaijan"},
                        new SelectListItem() {Text = "Bahamas", Value = "Bahamas"},
                        new SelectListItem() {Text = "Bahrain", Value = "Bahrain"},
                        new SelectListItem() {Text = "Bangladesh ", Value = "Bangladesh"},
                        new SelectListItem() {Text = "Barbados", Value = "Barbados"},
                        new SelectListItem() {Text = "Belarus", Value = "Belarus"},
                        new SelectListItem() {Text = "Belgium", Value = "Belgium"},
                        new SelectListItem() {Text = "Belize", Value = "Belize"},
                        new SelectListItem() {Text = "Bermuda", Value = "Bermuda"},
                        new SelectListItem() {Text = "Bhutan", Value = "Bhutan"},
                        new SelectListItem() {Text = "Bolivia", Value = "Bolivia"},
                        new SelectListItem() {Text = "Bosnia and Herzegovina", Value = "Bosnia and Herzegovina"},
                        new SelectListItem() {Text = "Botswana", Value = "Botswana"},
                        new SelectListItem() {Text = "Brazil", Value = "Brazil"},
                        new SelectListItem()
                        {
                            Text = "British Indian Ocean Territory",
                            Value = "British Indian Ocean Territory"
                        },
                        new SelectListItem() {Text = "Brunei Darussalam", Value = "Brunei Darussalam"},
                        new SelectListItem() {Text = "Bulgaria", Value = "Bulgaria"},
                        new SelectListItem() {Text = "Burkina Faso", Value = "Burkina Faso"},
                        new SelectListItem() {Text = "Burundi", Value = "Burundi"},
                        new SelectListItem() {Text = "Cambodia", Value = "Cambodia"},
                        new SelectListItem() {Text = "Cameroon", Value = "Cameroon"},
                        new SelectListItem() {Text = "Canada", Value = "Canada"},
                        new SelectListItem() {Text = "Cape Verde", Value = "Cape Verde"},
                        new SelectListItem() {Text = "Cayman Islands", Value = "Cayman Islands"},
                        new SelectListItem() {Text = "Central African Republic", Value = "Central African Republic"},
                        new SelectListItem() {Text = "Chad", Value = "Chad"},
                        new SelectListItem() {Text = "Chile", Value = "Chile"},
                        new SelectListItem() {Text = "China", Value = "China"},
                        new SelectListItem() {Text = "Christmas Island", Value = "Christmas Island"},
                        new SelectListItem() {Text = "Cocos (Keeling) Islands", Value = "Cocos (Keeling) Islands"},
                        new SelectListItem() {Text = "Colombia", Value = "Colombia"},
                        new SelectListItem() {Text = "Comoros", Value = "Comoros"},
                        new SelectListItem() {Text = "Congo", Value = "Congo"},
                        new SelectListItem() {Text = "Congo Democratic Republic", Value = "Congo Democratic Republic"},
                        new SelectListItem() {Text = "Cook Islands", Value = "Cook Islands"},
                        new SelectListItem() {Text = "Costa Rica", Value = "Costa Rica"},
                        new SelectListItem() {Text = "Cote D'Ivoire", Value = "Cote D'Ivoire"},
                        new SelectListItem() {Text = "Croatia", Value = "Croatia"},
                        new SelectListItem() {Text = "Cuba", Value = "Cuba"},
                        new SelectListItem() {Text = "Cyprus", Value = "Cyprus"},
                        new SelectListItem() {Text = "Czech Republic", Value = "Czech Republic"},
                        new SelectListItem() {Text = "Denmark", Value = "Denmark"},
                        new SelectListItem() {Text = "Djibouti", Value = "Djibouti"},
                        new SelectListItem() {Text = "Dominica", Value = "Dominica"},
                        new SelectListItem() {Text = "Dominican Republic", Value = "Dominican Republic"},
                        new SelectListItem() {Text = "East Timor", Value = "East Timor"},
                        new SelectListItem() {Text = "Ecuador", Value = "Ecuador"},
                        new SelectListItem() {Text = "Egypt", Value = "Egypt"},
                        new SelectListItem() {Text = "El Salvador", Value = "El Salvador"},
                        new SelectListItem() {Text = "Equatorial Guinea", Value = "Equatorial Guinea"},
                        new SelectListItem() {Text = "Eritrea", Value = "Eritrea"},
                        new SelectListItem() {Text = "Estonia", Value = "Estonia"},
                        new SelectListItem() {Text = "Ethiopia", Value = "Ethiopia"},
                        new SelectListItem()
                        {
                            Text = "Falkland Islands (Malvinas)",
                            Value = "Falkland Islands (Malvinas)"
                        },
                        new SelectListItem() {Text = "Faroe Islands", Value = "Faroe Islands"},
                        new SelectListItem() {Text = "Fiji", Value = "Fiji"},
                        new SelectListItem() {Text = "Finland", Value = "Finland"},
                        new SelectListItem() {Text = "France", Value = "France"},
                        new SelectListItem() {Text = "French Guiana", Value = "French Guiana"},
                        new SelectListItem() {Text = "French Polynesia", Value = "French Polynesia"},
                        new SelectListItem()
                        {
                            Text = "French Southern Territories",
                            Value = "French Southern Territories"
                        },
                        new SelectListItem() {Text = "Gabon", Value = "Gabon"},
                        new SelectListItem() {Text = "Gambia", Value = "Gambia"},
                        new SelectListItem() {Text = "Georgia", Value = "Georgia"},
                        new SelectListItem() {Text = "Germany", Value = "Germany"},
                        new SelectListItem() {Text = "Ghana", Value = "Ghana"},
                        new SelectListItem() {Text = "Gibraltar", Value = "Gibraltar"},
                        new SelectListItem() {Text = "Greece", Value = "Greece"},
                        new SelectListItem() {Text = "Greenland", Value = "Greenland"},
                        new SelectListItem() {Text = "Grenada", Value = "Grenada"},
                        new SelectListItem() {Text = "Guadeloupe", Value = "Guadeloupe"},
                        new SelectListItem() {Text = "Guam", Value = "Guam"},
                        new SelectListItem() {Text = "Guatemala", Value = "Guatemala"},
                        new SelectListItem() {Text = "Guinea", Value = "Guinea"},
                        new SelectListItem() {Text = "Guinea-Bissau", Value = "Guinea-Bissau"},
                        new SelectListItem() {Text = "Guyana", Value = "Guyana"},
                        new SelectListItem() {Text = "Haiti", Value = "Haiti"},
                        new SelectListItem() {Text = "Heard and McDonald Islands", Value = "Heard and McDonald Islands"},
                        new SelectListItem() {Text = "Holy See (Vatican City)", Value = "Holy See (Vatican City)"},
                        new SelectListItem() {Text = "Honduras", Value = "Honduras"},
                        new SelectListItem() {Text = "Hong Kong", Value = "Hong Kong"},
                        new SelectListItem() {Text = "Hungary", Value = "Hungary"},
                        new SelectListItem() {Text = "Iceland", Value = "Iceland"},
                        new SelectListItem() {Text = "India", Value = "India"},
                        new SelectListItem() {Text = "Indonesia", Value = "Indonesia"},
                        new SelectListItem() {Text = "Iran Islamic Republic of", Value = "Iran Islamic Republic of"},
                        new SelectListItem() {Text = "Iraq", Value = "Iraq"},
                        new SelectListItem() {Text = "Ireland", Value = "Ireland"},
                        new SelectListItem() {Text = "Israel", Value = "Israel"},
                        new SelectListItem() {Text = "Italy", Value = "Italy"},
                        new SelectListItem() {Text = "Jamaica", Value = "Jamaica"},
                        new SelectListItem() {Text = "Japan", Value = "Japan"},
                        new SelectListItem() {Text = "Jordan", Value = "Jordan"},
                        new SelectListItem() {Text = "Kazakstan", Value = "Kazakstan"},
                        new SelectListItem() {Text = "Kenya", Value = "Kenya"},
                        new SelectListItem() {Text = "Kiribati", Value = "Kiribati"},
                        new SelectListItem() {Text = "Korea North ", Value = "Korea North"},
                        new SelectListItem() {Text = "Korea South", Value = "Korea South"},
                        new SelectListItem() {Text = "Kuwait", Value = "Kuwait"},
                        new SelectListItem() {Text = "Kyrgyzstan", Value = "Kyrgyzstan"},
                        new SelectListItem() {Text = "Lao", Value = "Lao"},
                        new SelectListItem() {Text = "Latvia", Value = "Latvia"},
                        new SelectListItem() {Text = "Lebanon", Value = "Lebanon"},
                        new SelectListItem() {Text = "Lesotho", Value = "Lesotho"},
                        new SelectListItem() {Text = "Liberia", Value = "Liberia"},
                        new SelectListItem() {Text = "Libyan Arab Jamahiriya", Value = "Libyan Arab Jamahiriya"},
                        new SelectListItem() {Text = "Liechtenstein", Value = "Liechtenstein"},
                        new SelectListItem() {Text = "Lithuania", Value = "Lithuania"},
                        new SelectListItem() {Text = "Luxembourg", Value = "Luxembourg"},
                        new SelectListItem() {Text = "Macau", Value = "Macau"},
                        new SelectListItem() {Text = "Macedonia", Value = "Macedonia"},
                        new SelectListItem() {Text = "Madagascar", Value = "Madagascar"},
                        new SelectListItem() {Text = "Malawi", Value = "Malawi"},
                        new SelectListItem() {Text = "Malaysia", Value = "Malaysia"},
                        new SelectListItem() {Text = "Maldives", Value = "Maldives"},
                        new SelectListItem() {Text = "Mali", Value = "Mali"},
                        new SelectListItem() {Text = "Malta", Value = "Malta"},
                        new SelectListItem() {Text = "Marshall Islands", Value = "Marshall Islands"},
                        new SelectListItem() {Text = "Martinique", Value = "Martinique"},
                        new SelectListItem() {Text = "Mauritania", Value = "Mauritania"},
                        new SelectListItem() {Text = "Mauritius", Value = "Mauritius"},
                        new SelectListItem() {Text = "Mayotte", Value = "Mayotte"},
                        new SelectListItem() {Text = "Mexico", Value = "Mexico"},
                        new SelectListItem() {Text = "Micronesia", Value = "Micronesia"},
                        new SelectListItem() {Text = "Moldova Republic of", Value = "Moldova Republic of"},
                        new SelectListItem() {Text = "Monaco", Value = "Monaco"},
                        new SelectListItem() {Text = "Mongolia", Value = "Mongolia"},
                        new SelectListItem() {Text = "Montserrat", Value = "Montserrat"},
                        new SelectListItem() {Text = "Morocco", Value = "Morocco"},
                        new SelectListItem() {Text = "Mozambique", Value = "Mozambique"},
                        new SelectListItem() {Text = "Myanmar", Value = "Myanmar"},
                        new SelectListItem() {Text = "Namibia", Value = "Namibia"},
                        new SelectListItem() {Text = "Nauru", Value = "Nauru"},
                        new SelectListItem() {Text = "Nepal", Value = "Nepal"},
                        new SelectListItem() {Text = "Netherlands", Value = "Netherlands"},
                        new SelectListItem() {Text = "Netherlands Antilles", Value = "Netherlands Antilles"},
                        new SelectListItem() {Text = "New Caledonia", Value = "New Caledonia"},
                        new SelectListItem() {Text = "New Zealand", Value = "New Zealand"},
                        new SelectListItem() {Text = "Nicaragua", Value = "Nicaragua"},
                        new SelectListItem() {Text = "Niger", Value = "Niger"},
                        new SelectListItem() {Text = "Nigeria", Value = "Nigeria"},
                        new SelectListItem() {Text = "Niue", Value = "Niue"},
                        new SelectListItem() {Text = "Norfolk Island", Value = "Norfolk Island"},
                        new SelectListItem() {Text = "Northern Mariana Islands", Value = "Northern Mariana Islands"},
                        new SelectListItem() {Text = "Norway", Value = "Norway"},
                        new SelectListItem() {Text = "Oman", Value = "Oman"},
                        new SelectListItem() {Text = "Pakistan", Value = "Pakistan"},
                        new SelectListItem() {Text = "Palau", Value = "Palau"},
                        new SelectListItem() {Text = "Palestinian Territory", Value = "Palestinian Territory"},
                        new SelectListItem() {Text = "Panama", Value = "Panama"},
                        new SelectListItem() {Text = "Papua New Guinea", Value = "Papua New Guinea"},
                        new SelectListItem() {Text = "Paraguay", Value = "Paraguay"},
                        new SelectListItem() {Text = "Peru", Value = "Peru"},
                        new SelectListItem() {Text = "Philippines", Value = "Philippines"},
                        new SelectListItem() {Text = "Pitcairn", Value = "Pitcairn"},
                        new SelectListItem() {Text = "Poland", Value = "Poland"},
                        new SelectListItem() {Text = "Portugal", Value = "Portugal"},
                        new SelectListItem() {Text = "Puerto Rico", Value = "Puerto Rico"},
                        new SelectListItem() {Text = "Qatar", Value = "Qatar"},
                        new SelectListItem() {Text = "Reunion", Value = "Reunion"},
                        new SelectListItem() {Text = "Romania", Value = "Romania"},
                        new SelectListItem() {Text = "Russian Federation", Value = "Russian Federation"},
                        new SelectListItem() {Text = "Rwanda", Value = "Rwanda"},
                        new SelectListItem()
                        {
                            Text = "S. Georgia and S. Sandwich Is.",
                            Value = "S. Georgia and S. Sandwich Is."
                        },
                        new SelectListItem() {Text = "Saint Helena", Value = "Saint Helena"},
                        new SelectListItem() {Text = "Saint Kitts and Nevis", Value = "Saint Kitts and Nevis"},
                        new SelectListItem() {Text = "Saint Lucia", Value = "Saint Lucia"},
                        new SelectListItem() {Text = "Saint Pierre and Miquelon", Value = "Saint Pierre and Miquelon"},
                        new SelectListItem() {Text = "Samoa", Value = "Samoa"},
                        new SelectListItem() {Text = "San Marino", Value = "San Marino"},
                        new SelectListItem() {Text = "Sao Tome and Principe", Value = "Sao Tome and Principe"},
                        new SelectListItem() {Text = "Saudi Arabia", Value = "Saudi Arabia"},
                        new SelectListItem() {Text = "Senegal", Value = "Senegal"},
                        new SelectListItem() {Text = "Seychelles", Value = "Seychelles"},
                        new SelectListItem() {Text = "Sierra Leone", Value = "Sierra Leone"},
                        new SelectListItem() {Text = "Singapore", Value = "Singapore"},
                        new SelectListItem() {Text = "Slovakia", Value = "Slovakia"},
                        new SelectListItem() {Text = "Slovenia", Value = "Slovenia"},
                        new SelectListItem() {Text = "Solomon Islands", Value = "Solomon Islands"},
                        new SelectListItem() {Text = "Somalia", Value = "Somalia"},
                        new SelectListItem() {Text = "South Africa", Value = "South Africa"},
                        new SelectListItem() {Text = "Spain", Value = "Spain"},
                        new SelectListItem() {Text = "Sri Lanka", Value = "Sri Lanka"},
                        new SelectListItem() {Text = "St. Vincent and Grenadines", Value = "St. Vincent and Grenadines"},
                        new SelectListItem() {Text = "Sudan", Value = "Sudan"},
                        new SelectListItem() {Text = "Suriname", Value = "Suriname"},
                        new SelectListItem() {Text = "Svalbard and Jan Mayen", Value = "Svalbard and Jan Mayen"},
                        new SelectListItem() {Text = "Swaziland", Value = "Swaziland"},
                        new SelectListItem() {Text = "Sweden", Value = "Sweden"},
                        new SelectListItem() {Text = "Switzerland", Value = "Switzerland"},
                        new SelectListItem() {Text = "Syrian Arab Republic", Value = "Syrian Arab Republic"},
                        new SelectListItem() {Text = "Taiwan", Value = "Taiwan"},
                        new SelectListItem() {Text = "Tajikistan", Value = "Tajikistan"},
                        new SelectListItem()
                        {
                            Text = "Tanzania United Republic of",
                            Value = "Tanzania United Republic of"
                        },
                        new SelectListItem() {Text = "Thailand", Value = "Thailand"},
                        new SelectListItem() {Text = "Togo", Value = "Togo"},
                        new SelectListItem() {Text = "Tokelau", Value = "Tokelau"},
                        new SelectListItem() {Text = "Tonga", Value = "Tonga"},
                        new SelectListItem() {Text = "Trinidad and Tobago", Value = "Trinidad and Tobago"},
                        new SelectListItem() {Text = "Tunisia", Value = "Tunisia"},
                        new SelectListItem() {Text = "Turkey", Value = "Turkey"},
                        new SelectListItem() {Text = "Turkmenistan", Value = "Turkmenistan"},
                        new SelectListItem() {Text = "Turks and Caicos Islands", Value = "Turks and Caicos Islands"},
                        new SelectListItem() {Text = "Tuvalu", Value = "Tuvalu"},
                        new SelectListItem() {Text = "U.S.Minor Outlying Islands", Value = "U.S.Minor Outlying Islands"},
                        new SelectListItem() {Text = "Uganda", Value = "Uganda"},
                        new SelectListItem() {Text = "Ukraine", Value = "Ukraine"},
                        new SelectListItem() {Text = "United Arab Emirates", Value = "United Arab Emirates"},
                        new SelectListItem() {Text = "United Kingdom", Value = "United Kingdom"},
                        new SelectListItem() {Text = "United States", Value = "United States" },
                        new SelectListItem() {Text = "Uruguay", Value = "Uruguay"},
                        new SelectListItem() {Text = "Uzbekistan", Value = "Uzbekistan"},
                        new SelectListItem() {Text = "Vanuatu", Value = "Vanuatu"},
                        new SelectListItem() {Text = "Venezuela", Value = "Venezuela"},
                        new SelectListItem() {Text = "Viet Nam", Value = "Viet Nam"},
                        new SelectListItem() {Text = "Virgin Islands British", Value = "Virgin Islands British"},
                        new SelectListItem() {Text = "Virgin Islands U.S.", Value = "Virgin Islands U.S."},
                        new SelectListItem() {Text = "Wallis and Futuna", Value = "Wallis and Futuna"},
                        new SelectListItem() {Text = "Western Sahara", Value = "Western Sahara"},
                        new SelectListItem() {Text = "Yemen", Value = "Yemen"},
                        new SelectListItem() {Text = "Yugoslavia", Value = "Yugoslavia"},
                        new SelectListItem() {Text = "Zambia", Value = "Zambia"},
                        new SelectListItem() {Text = "Zimbabwe", Value = "Zimbabwe"}
                    };

                }

                return _countries;
            } 
        }

        public static IEnumerable<SelectListItem> PracticeTypes 
        {
            get 
            {
                if (_practiceTypes == null)
                {
                    _practiceTypes = new List<SelectListItem>();

                    _practiceTypes.Add(new SelectListItem() { Text = "Academic/University-based", Value = "Academic/University-based" });
                    _practiceTypes.Add(new SelectListItem() { Text = "Private Office/Imaging Center", Value = "Private Office/Imaging Center" });
                    _practiceTypes.Add(new SelectListItem() { Text = "Children's Hospital", Value = "Children's Hospital" });
                    _practiceTypes.Add(new SelectListItem() { Text = "Community Hospital-based", Value = "Community Hospital-based" });
                    _practiceTypes.Add(new SelectListItem() { Text = "Multispecialty Clinic", Value = "Multispecialty Clinic" });
                    _practiceTypes.Add(new SelectListItem() { Text = "VA/Military/Public Health System", Value = "VA/Military/Public Health System" });
                    _practiceTypes.Add(new SelectListItem() { Text = "Other", Value = "Other" });
                }

                return _practiceTypes;
            }
        }

        public static IEnumerable<SelectListItem> Professions
        {
            get
            {
                if (_professions == null)
                {
                    _professions = new List<SelectListItem>();
                    _professions.Add(new SelectListItem() { Text = "Radiologist", Value = "Radiologist" });
                    _professions.Add(new SelectListItem() { Text = "Non-Radiologist Physician", Value = "Non-Radiologist Physician" });
                    _professions.Add(new SelectListItem() { Text = "Medical Physicist", Value = "Medical Physicist" });
                    _professions.Add(new SelectListItem() { Text = "Radiation Oncologist", Value = "Radiation Oncologist" });
                    _professions.Add(new SelectListItem() { Text = "Imaging Technologist", Value = "Imaging Technologist" });
                    _professions.Add(new SelectListItem() { Text = "Registered Radiologist Assistant", Value = "Registered Radiologist Assistant" });
                    _professions.Add(new SelectListItem() { Text = "Hospital/Department Administrator", Value = "Hospital/Department Administrator" });
                    _professions.Add(new SelectListItem() { Text = "Nurse", Value = "Nurse" });
                    _professions.Add(new SelectListItem() { Text = "Physician Assistant", Value = "Physician Assistant" });
                    _professions.Add(new SelectListItem() { Text = "Radiation Therapist", Value = "Radiation Therapist" });
                    _professions.Add(new SelectListItem() { Text = "Student", Value = "Student" });
                    _professions.Add(new SelectListItem() { Text = "Other", Value = "Other" });
                }

                return _professions;
            }
        }
        public static IEnumerable<SelectListItem> ProfessionsAndRoles
        {
            get 
            {
                if (_professionsAndRoles == null)
                {
                    _professionsAndRoles = new List<SelectListItem>();
                    _professionsAndRoles.Add(new SelectListItem() { Text = "Non-Radiologist Physician", Value = "Non-Radiologist Physician" });
                    _professionsAndRoles.Add(new SelectListItem() { Text = "Hospital/Department Administrator", Value = "Hospital/Department Administrator" });
                    _professionsAndRoles.Add(new SelectListItem() { Text = "Nurse", Value = "Nurse" });
                    _professionsAndRoles.Add(new SelectListItem() { Text = "Physician Assistant", Value = "Physician Assistant" });
                    _professionsAndRoles.Add(new SelectListItem() { Text = "Other", Value = "Other" });
                }

                return _professionsAndRoles;
            }
        }

        public static IEnumerable<SelectListItem> ImageWiselyCampaign
        {
            get 
            {
                if (_imageWiselyCampaign == null)
                {
                    _imageWiselyCampaign = new List<SelectListItem>();

                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "AAPM", Value = "AAPM" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "AAP", Value = "AAP" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "ACR", Value = "ACR" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "AOCR", Value = "AOCR" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "ARRS", Value = "ARRS" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "ARRT", Value = "ARRT" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "ASRT", Value = "ASRT" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "AUR", Value = "AUR" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "CRCPD", Value = "CRCPD" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "NCRP", Value = "NCRP" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "Press", Value = "Press" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "RSNA", Value = "RSNA" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "SBCT-MR", Value = "SBCT-MR" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "Internet", Value = "Internet" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "Scientific Publication", Value = "Scientific Publication" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "SIR", Value = "SIR" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "Social Media", Value = "Social Media" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "SPR", Value = "SPR" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "Trade Publication", Value = "Trade Publication" });
                    _imageWiselyCampaign.Add(new SelectListItem() { Text = "Other", Value = "Other" });
                }

                return _imageWiselyCampaign;
            }
        }

        public static IEnumerable<SelectListItem> Provinces
        {
            get
            {
                if (_provinces == null)
                {
                    _provinces = new List<SelectListItem>();

                    _provinces.Add(new SelectListItem() { Text = "Alberta", Value = "AB" });
                    _provinces.Add(new SelectListItem() { Text = "British Columbia", Value = "BC" });
                    _provinces.Add(new SelectListItem() { Text = "Manitoba", Value = "MB" });
                    _provinces.Add(new SelectListItem() { Text = "New Brunswick", Value = "NB" });
                    _provinces.Add(new SelectListItem() { Text = "Newfoundland", Value = "NF" });
                    _provinces.Add(new SelectListItem() { Text = "Northwest Territories", Value = "NT" });
                    _provinces.Add(new SelectListItem() { Text = "Nova Scotia", Value = "NS" });
                    _provinces.Add(new SelectListItem() { Text = "Ontario", Value = "ON" });
                    _provinces.Add(new SelectListItem() { Text = "Prince Edward Island", Value = "PE" });
                    _provinces.Add(new SelectListItem() { Text = "Quebec", Value = "QC" });
                    _provinces.Add(new SelectListItem() { Text = "Saskatchewan", Value = "SK" });
                    _provinces.Add(new SelectListItem() { Text = "Yukon", Value = "YT" });
                }

                return _provinces;

            }
        }

        public static IEnumerable<SelectListItem> States
        {
            get 
            {
                if (_states == null)
                {
                    _states = new List<SelectListItem>();

                    _states.Add(new SelectListItem() { Value = "AL", Text = "Alabama" });
                    _states.Add(new SelectListItem() { Value = "AK", Text = "Alaska" });
                    _states.Add(new SelectListItem() { Value = "AS", Text = "American Samoa" });
                    _states.Add(new SelectListItem() { Value = "AZ", Text = "Arizona" });
                    _states.Add(new SelectListItem() { Value = "AR", Text = "Arkansas" });
                    _states.Add(new SelectListItem() { Value = "CA", Text = "California" });
                    _states.Add(new SelectListItem() { Value = "CO", Text = "Colorado" });
                    _states.Add(new SelectListItem() { Value = "CT", Text = "Connecticut" });
                    _states.Add(new SelectListItem() { Value = "DE", Text = "Delaware" });
                    _states.Add(new SelectListItem() { Value = "DC", Text = "District of Columbia" });
                    _states.Add(new SelectListItem() { Value = "FM", Text = "Fed. States of Micronesia" });
                    _states.Add(new SelectListItem() { Value = "FL", Text = "Florida" });
                    _states.Add(new SelectListItem() { Value = "GA", Text = "Georgia" });
                    _states.Add(new SelectListItem() { Value = "GU", Text = "Guam" });
                    _states.Add(new SelectListItem() { Value = "HI", Text = "Hawaii" });
                    _states.Add(new SelectListItem() { Value = "ID", Text = "Idaho" });
                    _states.Add(new SelectListItem() { Value = "IL", Text = "Illinois" });
                    _states.Add(new SelectListItem() { Value = "IN", Text = "Indiana" });
                    _states.Add(new SelectListItem() { Value = "IA", Text = "Iowa" });
                    _states.Add(new SelectListItem() { Value = "KS", Text = "Kansas" });
                    _states.Add(new SelectListItem() { Value = "KY", Text = "Kentucky" });
                    _states.Add(new SelectListItem() { Value = "LA", Text = "Louisiana" });
                    _states.Add(new SelectListItem() { Value = "ME", Text = "Maine" });
                    _states.Add(new SelectListItem() { Value = "MH", Text = "Marshall Islands" });
                    _states.Add(new SelectListItem() { Value = "MD", Text = "Maryland" });
                    _states.Add(new SelectListItem() { Value = "MA", Text = "Massachusetts" });
                    _states.Add(new SelectListItem() { Value = "MI", Text = "Michigan" });
                    _states.Add(new SelectListItem() { Value = "MN", Text = "Minnesota" });
                    _states.Add(new SelectListItem() { Value = "MS", Text = "Mississippi" });
                    _states.Add(new SelectListItem() { Value = "MO", Text = "Missouri" });
                    _states.Add(new SelectListItem() { Value = "MT", Text = "Montana" });
                    _states.Add(new SelectListItem() { Value = "NE", Text = "Nebraska" });
                    _states.Add(new SelectListItem() { Value = "NV", Text = "Nevada" });
                    _states.Add(new SelectListItem() { Value = "NH", Text = "New Hampshire" });
                    _states.Add(new SelectListItem() { Value = "NJ", Text = "New Jersey" });
                    _states.Add(new SelectListItem() { Value = "NM", Text = "New Mexico" });
                    _states.Add(new SelectListItem() { Value = "NY", Text = "New York" });
                    _states.Add(new SelectListItem() { Value = "NC", Text = "North Carolina" });
                    _states.Add(new SelectListItem() { Value = "ND", Text = "North Dakota" });
                    _states.Add(new SelectListItem() { Value = "MP", Text = "Northern Mariana Is." });
                    _states.Add(new SelectListItem() { Value = "OH", Text = "Ohio" });
                    _states.Add(new SelectListItem() { Value = "OK", Text = "Oklahoma" });
                    _states.Add(new SelectListItem() { Value = "OR", Text = "Oregon" });
                    _states.Add(new SelectListItem() { Value = "PW", Text = "Palau" });
                    _states.Add(new SelectListItem() { Value = "PA", Text = "Pennsylvania" });
                    _states.Add(new SelectListItem() { Value = "PR", Text = "Puerto Rico" });
                    _states.Add(new SelectListItem() { Value = "RI", Text = "Rhode Island" });
                    _states.Add(new SelectListItem() { Value = "SC", Text = "South Carolina" });
                    _states.Add(new SelectListItem() { Value = "SD", Text = "South Dakota" });
                    _states.Add(new SelectListItem() { Value = "TN", Text = "Tennessee" });
                    _states.Add(new SelectListItem() { Value = "TX", Text = "Texas" });
                    _states.Add(new SelectListItem() { Value = "UT", Text = "Utah" });
                    _states.Add(new SelectListItem() { Value = "VT", Text = "Vermont" });
                    _states.Add(new SelectListItem() { Value = "VI", Text = "Virgin Islands" });
                    _states.Add(new SelectListItem() { Value = "VA", Text = "Virginia" });
                    _states.Add(new SelectListItem() { Value = "WA", Text = "Washington" });
                    _states.Add(new SelectListItem() { Value = "WV", Text = "West Virginia" });
                    _states.Add(new SelectListItem() { Value = "WI", Text = "Wisconsin" });
                    _states.Add(new SelectListItem() { Value = "WY", Text = "Wyoming" });
                }

                return _states;

            }
        }


    }
}