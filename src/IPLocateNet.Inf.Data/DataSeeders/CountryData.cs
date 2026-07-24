namespace IPLocateNet.Inf.Data.DataSeeders;

internal static class CountryData
{
    #region Countries

    private const string _countries = """
        Afghanistan                                                 | UN member         | AF | AFG
        Aland Islands                                               | Finland           | AX | ALA
        Albania                                                     | UN member         | AL | ALB
        Algeria                                                     | UN member         | DZ | DZA
        American Samoa                                              | United States     | AS | ASM
        Andorra                                                     | UN member         | AD | AND
        Angola                                                      | UN member         | AO | AGO
        Anguilla                                                    | United Kingdom    | AI | AIA
        Antarctica                                                  | Antarctic Treaty  | AQ | ATA
        Antigua and Barbuda                                         | UN member         | AG | ATG
        Argentina                                                   | UN member         | AR | ARG
        Armenia                                                     | UN member         | AM | ARM
        Aruba                                                       | Netherlands       | AW | ABW
        Australia                                                   | UN member         | AU | AUS
        Austria                                                     | UN member         | AT | AUT
        Azerbaijan                                                  | UN member         | AZ | AZE
        Bahamas (the)                                               | UN member         | BS | BHS
        Bahrain                                                     | UN member         | BH | BHR
        Bangladesh                                                  | UN member         | BD | BGD
        Barbados                                                    | UN member         | BB | BRB
        Belarus                                                     | UN member         | BY | BLR
        Belgium                                                     | UN member         | BE | BEL
        Belize                                                      | UN member         | BZ | BLZ
        Benin                                                       | UN member         | BJ | BEN
        Bermuda                                                     | United Kingdom    | BM | BMU
        Bhutan                                                      | UN member         | BT | BTN
        Bolivia (Plurinational State of)                            | UN member         | BO | BOL
        Bonaire, Sint Eustatius, Saba                               | Netherlands       | BQ | BES
        Bosnia and Herzegovina                                      | UN member         | BA | BIH
        Botswana                                                    | UN member         | BW | BWA
        Bouvet Island                                               | Norway            | BV | BVT
        Brazil                                                      | UN member         | BR | BRA
        British Indian Ocean Territory (the)                        | United Kingdom    | IO | IOT
        Brunei Darussalam                                           | UN member         | BN | BRN
        Bulgaria                                                    | UN member         | BG | BGR
        Burkina Faso                                                | UN member         | BF | BFA
        Burundi                                                     | UN member         | BI | BDI
        Cabo Verde                                                  | UN member         | CV | CPV
        Cambodia                                                    | UN member         | KH | KHM
        Cameroon                                                    | UN member         | CM | CMR
        Canada                                                      | UN member         | CA | CAN
        Cayman Islands (the)                                        | United Kingdom    | KY | CYM
        Central African Republic (the)                              | UN member         | CF | CAF
        Chad                                                        | UN member         | TD | TCD
        Chile                                                       | UN member         | CL | CHL
        China                                                       | UN member         | CN | CHN
        Christmas Island                                            | Australia         | CX | CXR
        Cocos (Keeling) Islands (the)                               | Australia         | CC | CCK
        Colombia                                                    | UN member         | CO | COL
        Comoros (the)                                               | UN member         | KM | COM
        Congo (the Democratic Republic of the)                      | UN member         | CD | COD
        Congo (the)                                                 | UN member         | CG | COG
        Cook Islands (the)                                          | New Zealand       | CK | COK
        Costa Rica                                                  | UN member         | CR | CRI
        Cote d'Ivoire                                               | UN member         | CI | CIV
        Croatia                                                     | UN member         | HR | HRV
        Cuba                                                        | UN member         | CU | CUB
        Curaçao                                                     | Netherlands       | CW | CUW
        Cyprus                                                      | UN member         | CY | CYP
        Czechia                                                     | UN member         | CZ | CZE
        Denmark                                                     | UN member         | DK | DNK
        Djibouti                                                    | UN member         | DJ | DJI
        Dominica                                                    | UN member         | DM | DMA
        Dominican Republic (the)                                    | UN member         | DO | DOM
        Ecuador                                                     | UN member         | EC | ECU
        Egypt                                                       | UN member         | EG | EGY
        El Salvador                                                 | UN member         | SV | SLV
        Equatorial Guinea                                           | UN member         | GQ | GNQ
        Eritrea                                                     | UN member         | ER | ERI
        Estonia                                                     | UN member         | EE | EST
        Eswatini                                                    | UN member         | SZ | SWZ
        Ethiopia                                                    | UN member         | ET | ETH
        Falkland Islands (the)                                      | United Kingdom    | FK | FLK
        Faroe Islands (the)                                         | Denmark           | FO | FRO
        Fiji                                                        | UN member         | FJ | FJI
        Finland                                                     | UN member         | FI | FIN
        France                                                      | UN member         | FR | FRA
        French Guiana                                               | France            | GF | GUF
        French Polynesia                                            | France            | PF | PYF
        French Southern Territories (the)                           | France            | TF | ATF
        Gabon                                                       | UN member         | GA | GAB
        Gambia (the)                                                | UN member         | GM | GMB
        Georgia                                                     | UN member         | GE | GEO
        Germany                                                     | UN member         | DE | DEU
        Ghana                                                       | UN member         | GH | GHA
        Gibraltar                                                   | United Kingdom    | GI | GIB
        Greece                                                      | UN member         | GR | GRC
        Greenland                                                   | Denmark           | GL | GRL
        Grenada                                                     | UN member         | GD | GRD
        Guadeloupe                                                  | France            | GP | GLP
        Guam                                                        | United States     | GU | GUM
        Guatemala                                                   | UN member         | GT | GTM
        Guernsey                                                    | British Crown     | GG | GGY
        Guinea                                                      | UN member         | GN | GIN
        Guinea-Bissau                                               | UN member         | GW | GNB
        Guyana                                                      | UN member         | GY | GUY
        Haiti                                                       | UN member         | HT | HTI
        Heard Island and McDonald Islands                           | Australia         | HM | HMD
        Holy See (the)                                              | UN observer       | VA | VAT
        Honduras                                                    | UN member         | HN | HND
        Hong Kong                                                   | China             | HK | HKG
        Hungary                                                     | UN member         | HU | HUN
        Iceland                                                     | UN member         | IS | ISL
        India                                                       | UN member         | IN | IND
        Indonesia                                                   | UN member         | ID | IDN
        Iran (Islamic Republic of)                                  | UN member         | IR | IRN
        Iraq                                                        | UN member         | IQ | IRQ
        Ireland                                                     | UN member         | IE | IRL
        Isle of Man                                                 | British Crown     | IM | IMN
        Israel                                                      | UN member         | IL | ISR
        Italy                                                       | UN member         | IT | ITA
        Jamaica                                                     | UN member         | JM | JAM
        Japan                                                       | UN member         | JP | JPN
        Jersey                                                      | British Crown     | JE | JEY
        Jordan                                                      | UN member         | JO | JOR
        Kazakhstan                                                  | UN member         | KZ | KAZ
        Kenya                                                       | UN member         | KE | KEN
        Kiribati                                                    | UN member         | KI | KIR
        Korea (the Democratic People's Republic of)                 | UN member         | KP | PRK
        Korea (the Republic of)                                     | UN member         | KR | KOR
        Kuwait                                                      | UN member         | KW | KWT
        Kyrgyzstan                                                  | UN member         | KG | KGZ
        Lao People's Democratic Republic (the)                      | UN member         | LA | LAO
        Latvia                                                      | UN member         | LV | LVA
        Lebanon                                                     | UN member         | LB | LBN
        Lesotho                                                     | UN member         | LS | LSO
        Liberia                                                     | UN member         | LR | LBR
        Libya                                                       | UN member         | LY | LBY
        Liechtenstein                                               | UN member         | LI | LIE
        Lithuania                                                   | UN member         | LT | LTU
        Luxembourg                                                  | UN member         | LU | LUX
        Macao                                                       | China             | MO | MAC
        Madagascar                                                  | UN member         | MG | MDG
        Malawi                                                      | UN member         | MW | MWI
        Malaysia                                                    | UN member         | MY | MYS
        Maldives                                                    | UN member         | MV | MDV
        Mali                                                        | UN member         | ML | MLI
        Malta                                                       | UN member         | MT | MLT
        Marshall Islands (the)                                      | UN member         | MH | MHL
        Martinique                                                  | France            | MQ | MTQ
        Mauritania                                                  | UN member         | MR | MRT
        Mauritius                                                   | UN member         | MU | MUS
        Mayotte                                                     | France            | YT | MYT
        Mexico                                                      | UN member         | MX | MEX
        Micronesia (Federated States of)                            | UN member         | FM | FSM
        Moldova (the Republic of)                                   | UN member         | MD | MDA
        Monaco                                                      | UN member         | MC | MCO
        Mongolia                                                    | UN member         | MN | MNG
        Montenegro                                                  | UN member         | ME | MNE
        Montserrat                                                  | United Kingdom    | MS | MSR
        Morocco                                                     | UN member         | MA | MAR
        Mozambique                                                  | UN member         | MZ | MOZ
        Myanmar                                                     | UN member         | MM | MMR
        Namibia                                                     | UN member         | NA | NAM
        Nauru                                                       | UN member         | NR | NRU
        Nepal                                                       | UN member         | NP | NPL
        Netherlands (Kingdom of the)                                | UN member         | NL | NLD
        New Caledonia                                               | France            | NC | NCL
        New Zealand                                                 | UN member         | NZ | NZL
        Nicaragua                                                   | UN member         | NI | NIC
        Niger (the)                                                 | UN member         | NE | NER
        Nigeria                                                     | UN member         | NG | NGA
        Niue                                                        | New Zealand       | NU | NIU
        Norfolk Island                                              | Australia         | NF | NFK
        Northern Mariana Islands (the)                              | United States     | MP | MNP
        Norway                                                      | UN member         | NO | NOR
        North Macedonia                                             | UN member         | MK | MKD
        Oman                                                        | UN member         | OM | OMN
        Pakistan                                                    | UN member         | PK | PAK
        Palau                                                       | UN member         | PW | PLW
        Palestine, State of                                         | UN observer       | PS | PSE
        Panama                                                      | UN member         | PA | PAN
        Papua New Guinea                                            | UN member         | PG | PNG
        Paraguay                                                    | UN member         | PY | PRY
        Peru                                                        | UN member         | PE | PER
        Philippines (the)                                           | UN member         | PH | PHL
        Pitcairn                                                    | United Kingdom    | PN | PCN
        Poland                                                      | UN member         | PL | POL
        Portugal                                                    | UN member         | PT | PRT
        Puerto Rico                                                 | United States     | PR | PRI
        Qatar                                                       | UN member         | QA | QAT
        Reunion                                                     | France            | RE | REU
        Romania                                                     | UN member         | RO | ROU
        Russian Federation (the)                                    | UN member         | RU | RUS
        Rwanda                                                      | UN member         | RW | RWA
        Saint Barthelemy                                            | France            | BL | BLM
        Saint Kitts and Nevis                                       | UN member         | KN | KNA
        Saint Lucia                                                 | UN member         | LC | LCA
        Saint Martin (French part)                                  | France            | MF | MAF
        Saint Pierre and Miquelon                                   | France            | PM | SPM
        Saint Vincent and the Grenadines                            | UN member         | VC | VCT
        Saint Helena, Ascension Island, Tristan da Cunha            | United Kingdom    | SH | SHN
        Samoa                                                       | UN member         | WS | WSM
        San Marino                                                  | UN member         | SM | SMR
        Sao Tome and Principe                                       | UN member         | ST | STP
        Saudi Arabia                                                | UN member         | SA | SAU
        Senegal                                                     | UN member         | SN | SEN
        Serbia                                                      | UN member         | RS | SRB
        Seychelles                                                  | UN member         | SC | SYC
        Sierra Leone                                                | UN member         | SL | SLE
        Singapore                                                   | UN member         | SG | SGP
        Sint Maarten (Dutch part)                                   | Netherlands       | SX | SXM
        Slovakia                                                    | UN member         | SK | SVK
        Slovenia                                                    | UN member         | SI | SVN
        Solomon Islands                                             | UN member         | SB | SLB
        Somalia                                                     | UN member         | SO | SOM
        South Africa                                                | UN member         | ZA | ZAF
        South Georgia and the South Sandwich Islands                | United Kingdom    | GS | SGS
        South Sudan                                                 | UN member         | SS | SSD
        Spain                                                       | UN member         | ES | ESP
        Sri Lanka                                                   | UN member         | LK | LKA
        Sudan (the)                                                 | UN member         | SD | SDN
        Suriname                                                    | UN member         | SR | SUR
        Svalbard, Jan Mayen                                         | Norway            | SJ | SJM
        Sweden                                                      | UN member         | SE | SWE
        Switzerland                                                 | UN member         | CH | CHE
        Syrian Arab Republic (the)                                  | UN member         | SY | SYR
        Taiwan (Province of China)                                  | Disputed          | TW | TWN
        Tajikistan                                                  | UN member         | TJ | TJK
        Tanzania, the United Republic of                            | UN member         | TZ | TZA
        Thailand                                                    | UN member         | TH | THA
        Timor-Leste                                                 | UN member         | TL | TLS
        Togo                                                        | UN member         | TG | TGO
        Tokelau                                                     | New Zealand       | TK | TKL
        Tonga                                                       | UN member         | TO | TON
        Trinidad and Tobago                                         | UN member         | TT | TTO
        Tunisia                                                     | UN member         | TN | TUN
        Turkiye                                                     | UN member         | TR | TUR
        Turkmenistan                                                | UN member         | TM | TKM
        Turks and Caicos Islands (the)                              | United Kingdom    | TC | TCA
        Tuvalu                                                      | UN member         | TV | TUV
        Uganda                                                      | UN member         | UG | UGA
        Ukraine                                                     | UN member         | UA | UKR
        United Arab Emirates (the)                                  | UN member         | AE | ARE
        United Kingdom of Great Britain and Northern Ireland (the)  | UN member         | GB | GBR
        United States Minor Outlying Islands (the)                  | United States     | UM | UMI
        United States of America (the)                              | UN member         | US | USA
        Uruguay                                                     | UN member         | UY | URY
        Uzbekistan                                                  | UN member         | UZ | UZB
        Vanuatu                                                     | UN member         | VU | VUT
        Venezuela (Bolivarian Republic of)                          | UN member         | VE | VEN
        Viet Nam                                                    | UN member         | VN | VNM
        Virgin Islands (British)                                    | United Kingdom    | VG | VGB
        Virgin Islands (U.S.)                                       | United States     | VI | VIR
        Wallis and Futuna                                           | France            | WF | WLF
        Western Sahara                                              | Disputed          | EH | ESH
        Yemen                                                       | UN member         | YE | YEM
        Zambia                                                      | UN member         | ZM | ZMB
        Zimbabwe                                                    | UN member         | ZW | ZWE
        """;

    #endregion

    static CountryData()
    {
        var lines = _countries
            .Replace("\r", string.Empty)
            .Split(['\n'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var countries = lines
            .Select(
                line =>
                line.Split(['|'], StringSplitOptions.TrimEntries) is string[] segments && segments.Length == 4
                    ? new CountryDataRecord(segments[0], segments[1], segments[2], segments[3])
                    : null)
            .Where(x => x != null)
            .OfType<CountryDataRecord>()
            .ToList();
        Countries = countries;

        Sovereignties = Countries.Select(x => x.Sovereignty).Distinct().ToList();
    }

    public static IEnumerable<CountryDataRecord> Countries { get; }

    public static IEnumerable<string> Sovereignties { get; }
}
