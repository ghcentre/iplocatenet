using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IPLocateNet.Inf.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sovereignties",
                columns: table => new
                {
                    Id = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sovereignties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SovereigntyId = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Code3 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Sovereignties_SovereigntyId",
                        column: x => x.SovereigntyId,
                        principalTable: "Sovereignties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IPv4Ranges",
                columns: table => new
                {
                    StartingIP = table.Column<byte[]>(type: "BLOB", nullable: false),
                    EndingIP = table.Column<byte[]>(type: "BLOB", nullable: false),
                    CountryId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPv4Ranges", x => x.StartingIP);
                    table.ForeignKey(
                        name: "FK_IPv4Ranges_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sovereignties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (ushort)1, "UN member" },
                    { (ushort)2, "Finland" },
                    { (ushort)3, "United States" },
                    { (ushort)4, "United Kingdom" },
                    { (ushort)5, "Antarctic Treaty" },
                    { (ushort)6, "Netherlands" },
                    { (ushort)7, "Norway" },
                    { (ushort)8, "Australia" },
                    { (ushort)9, "New Zealand" },
                    { (ushort)10, "Denmark" },
                    { (ushort)11, "France" },
                    { (ushort)12, "British Crown" },
                    { (ushort)13, "UN observer" },
                    { (ushort)14, "China" },
                    { (ushort)15, "Disputed" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code3", "Name", "SovereigntyId" },
                values: new object[,]
                {
                    { "AD", "AND", "Andorra", (ushort)1 },
                    { "AE", "ARE", "United Arab Emirates (the)", (ushort)1 },
                    { "AF", "AFG", "Afghanistan", (ushort)1 },
                    { "AG", "ATG", "Antigua and Barbuda", (ushort)1 },
                    { "AI", "AIA", "Anguilla", (ushort)4 },
                    { "AL", "ALB", "Albania", (ushort)1 },
                    { "AM", "ARM", "Armenia", (ushort)1 },
                    { "AO", "AGO", "Angola", (ushort)1 },
                    { "AQ", "ATA", "Antarctica", (ushort)5 },
                    { "AR", "ARG", "Argentina", (ushort)1 },
                    { "AS", "ASM", "American Samoa", (ushort)3 },
                    { "AT", "AUT", "Austria", (ushort)1 },
                    { "AU", "AUS", "Australia", (ushort)1 },
                    { "AW", "ABW", "Aruba", (ushort)6 },
                    { "AX", "ALA", "Aland Islands", (ushort)2 },
                    { "AZ", "AZE", "Azerbaijan", (ushort)1 },
                    { "BA", "BIH", "Bosnia and Herzegovina", (ushort)1 },
                    { "BB", "BRB", "Barbados", (ushort)1 },
                    { "BD", "BGD", "Bangladesh", (ushort)1 },
                    { "BE", "BEL", "Belgium", (ushort)1 },
                    { "BF", "BFA", "Burkina Faso", (ushort)1 },
                    { "BG", "BGR", "Bulgaria", (ushort)1 },
                    { "BH", "BHR", "Bahrain", (ushort)1 },
                    { "BI", "BDI", "Burundi", (ushort)1 },
                    { "BJ", "BEN", "Benin", (ushort)1 },
                    { "BL", "BLM", "Saint Barthelemy", (ushort)11 },
                    { "BM", "BMU", "Bermuda", (ushort)4 },
                    { "BN", "BRN", "Brunei Darussalam", (ushort)1 },
                    { "BO", "BOL", "Bolivia (Plurinational State of)", (ushort)1 },
                    { "BQ", "BES", "Bonaire, Sint Eustatius, Saba", (ushort)6 },
                    { "BR", "BRA", "Brazil", (ushort)1 },
                    { "BS", "BHS", "Bahamas (the)", (ushort)1 },
                    { "BT", "BTN", "Bhutan", (ushort)1 },
                    { "BV", "BVT", "Bouvet Island", (ushort)7 },
                    { "BW", "BWA", "Botswana", (ushort)1 },
                    { "BY", "BLR", "Belarus", (ushort)1 },
                    { "BZ", "BLZ", "Belize", (ushort)1 },
                    { "CA", "CAN", "Canada", (ushort)1 },
                    { "CC", "CCK", "Cocos (Keeling) Islands (the)", (ushort)8 },
                    { "CD", "COD", "Congo (the Democratic Republic of the)", (ushort)1 },
                    { "CF", "CAF", "Central African Republic (the)", (ushort)1 },
                    { "CG", "COG", "Congo (the)", (ushort)1 },
                    { "CH", "CHE", "Switzerland", (ushort)1 },
                    { "CI", "CIV", "Cote d'Ivoire", (ushort)1 },
                    { "CK", "COK", "Cook Islands (the)", (ushort)9 },
                    { "CL", "CHL", "Chile", (ushort)1 },
                    { "CM", "CMR", "Cameroon", (ushort)1 },
                    { "CN", "CHN", "China", (ushort)1 },
                    { "CO", "COL", "Colombia", (ushort)1 },
                    { "CR", "CRI", "Costa Rica", (ushort)1 },
                    { "CU", "CUB", "Cuba", (ushort)1 },
                    { "CV", "CPV", "Cabo Verde", (ushort)1 },
                    { "CW", "CUW", "Curaçao", (ushort)6 },
                    { "CX", "CXR", "Christmas Island", (ushort)8 },
                    { "CY", "CYP", "Cyprus", (ushort)1 },
                    { "CZ", "CZE", "Czechia", (ushort)1 },
                    { "DE", "DEU", "Germany", (ushort)1 },
                    { "DJ", "DJI", "Djibouti", (ushort)1 },
                    { "DK", "DNK", "Denmark", (ushort)1 },
                    { "DM", "DMA", "Dominica", (ushort)1 },
                    { "DO", "DOM", "Dominican Republic (the)", (ushort)1 },
                    { "DZ", "DZA", "Algeria", (ushort)1 },
                    { "EC", "ECU", "Ecuador", (ushort)1 },
                    { "EE", "EST", "Estonia", (ushort)1 },
                    { "EG", "EGY", "Egypt", (ushort)1 },
                    { "EH", "ESH", "Western Sahara", (ushort)15 },
                    { "ER", "ERI", "Eritrea", (ushort)1 },
                    { "ES", "ESP", "Spain", (ushort)1 },
                    { "ET", "ETH", "Ethiopia", (ushort)1 },
                    { "FI", "FIN", "Finland", (ushort)1 },
                    { "FJ", "FJI", "Fiji", (ushort)1 },
                    { "FK", "FLK", "Falkland Islands (the)", (ushort)4 },
                    { "FM", "FSM", "Micronesia (Federated States of)", (ushort)1 },
                    { "FO", "FRO", "Faroe Islands (the)", (ushort)10 },
                    { "FR", "FRA", "France", (ushort)1 },
                    { "GA", "GAB", "Gabon", (ushort)1 },
                    { "GB", "GBR", "United Kingdom of Great Britain and Northern Ireland (the)", (ushort)1 },
                    { "GD", "GRD", "Grenada", (ushort)1 },
                    { "GE", "GEO", "Georgia", (ushort)1 },
                    { "GF", "GUF", "French Guiana", (ushort)11 },
                    { "GG", "GGY", "Guernsey", (ushort)12 },
                    { "GH", "GHA", "Ghana", (ushort)1 },
                    { "GI", "GIB", "Gibraltar", (ushort)4 },
                    { "GL", "GRL", "Greenland", (ushort)10 },
                    { "GM", "GMB", "Gambia (the)", (ushort)1 },
                    { "GN", "GIN", "Guinea", (ushort)1 },
                    { "GP", "GLP", "Guadeloupe", (ushort)11 },
                    { "GQ", "GNQ", "Equatorial Guinea", (ushort)1 },
                    { "GR", "GRC", "Greece", (ushort)1 },
                    { "GS", "SGS", "South Georgia and the South Sandwich Islands", (ushort)4 },
                    { "GT", "GTM", "Guatemala", (ushort)1 },
                    { "GU", "GUM", "Guam", (ushort)3 },
                    { "GW", "GNB", "Guinea-Bissau", (ushort)1 },
                    { "GY", "GUY", "Guyana", (ushort)1 },
                    { "HK", "HKG", "Hong Kong", (ushort)14 },
                    { "HM", "HMD", "Heard Island and McDonald Islands", (ushort)8 },
                    { "HN", "HND", "Honduras", (ushort)1 },
                    { "HR", "HRV", "Croatia", (ushort)1 },
                    { "HT", "HTI", "Haiti", (ushort)1 },
                    { "HU", "HUN", "Hungary", (ushort)1 },
                    { "ID", "IDN", "Indonesia", (ushort)1 },
                    { "IE", "IRL", "Ireland", (ushort)1 },
                    { "IL", "ISR", "Israel", (ushort)1 },
                    { "IM", "IMN", "Isle of Man", (ushort)12 },
                    { "IN", "IND", "India", (ushort)1 },
                    { "IO", "IOT", "British Indian Ocean Territory (the)", (ushort)4 },
                    { "IQ", "IRQ", "Iraq", (ushort)1 },
                    { "IR", "IRN", "Iran (Islamic Republic of)", (ushort)1 },
                    { "IS", "ISL", "Iceland", (ushort)1 },
                    { "IT", "ITA", "Italy", (ushort)1 },
                    { "JE", "JEY", "Jersey", (ushort)12 },
                    { "JM", "JAM", "Jamaica", (ushort)1 },
                    { "JO", "JOR", "Jordan", (ushort)1 },
                    { "JP", "JPN", "Japan", (ushort)1 },
                    { "KE", "KEN", "Kenya", (ushort)1 },
                    { "KG", "KGZ", "Kyrgyzstan", (ushort)1 },
                    { "KH", "KHM", "Cambodia", (ushort)1 },
                    { "KI", "KIR", "Kiribati", (ushort)1 },
                    { "KM", "COM", "Comoros (the)", (ushort)1 },
                    { "KN", "KNA", "Saint Kitts and Nevis", (ushort)1 },
                    { "KP", "PRK", "Korea (the Democratic People's Republic of)", (ushort)1 },
                    { "KR", "KOR", "Korea (the Republic of)", (ushort)1 },
                    { "KW", "KWT", "Kuwait", (ushort)1 },
                    { "KY", "CYM", "Cayman Islands (the)", (ushort)4 },
                    { "KZ", "KAZ", "Kazakhstan", (ushort)1 },
                    { "LA", "LAO", "Lao People's Democratic Republic (the)", (ushort)1 },
                    { "LB", "LBN", "Lebanon", (ushort)1 },
                    { "LC", "LCA", "Saint Lucia", (ushort)1 },
                    { "LI", "LIE", "Liechtenstein", (ushort)1 },
                    { "LK", "LKA", "Sri Lanka", (ushort)1 },
                    { "LR", "LBR", "Liberia", (ushort)1 },
                    { "LS", "LSO", "Lesotho", (ushort)1 },
                    { "LT", "LTU", "Lithuania", (ushort)1 },
                    { "LU", "LUX", "Luxembourg", (ushort)1 },
                    { "LV", "LVA", "Latvia", (ushort)1 },
                    { "LY", "LBY", "Libya", (ushort)1 },
                    { "MA", "MAR", "Morocco", (ushort)1 },
                    { "MC", "MCO", "Monaco", (ushort)1 },
                    { "MD", "MDA", "Moldova (the Republic of)", (ushort)1 },
                    { "ME", "MNE", "Montenegro", (ushort)1 },
                    { "MF", "MAF", "Saint Martin (French part)", (ushort)11 },
                    { "MG", "MDG", "Madagascar", (ushort)1 },
                    { "MH", "MHL", "Marshall Islands (the)", (ushort)1 },
                    { "MK", "MKD", "North Macedonia", (ushort)1 },
                    { "ML", "MLI", "Mali", (ushort)1 },
                    { "MM", "MMR", "Myanmar", (ushort)1 },
                    { "MN", "MNG", "Mongolia", (ushort)1 },
                    { "MO", "MAC", "Macao", (ushort)14 },
                    { "MP", "MNP", "Northern Mariana Islands (the)", (ushort)3 },
                    { "MQ", "MTQ", "Martinique", (ushort)11 },
                    { "MR", "MRT", "Mauritania", (ushort)1 },
                    { "MS", "MSR", "Montserrat", (ushort)4 },
                    { "MT", "MLT", "Malta", (ushort)1 },
                    { "MU", "MUS", "Mauritius", (ushort)1 },
                    { "MV", "MDV", "Maldives", (ushort)1 },
                    { "MW", "MWI", "Malawi", (ushort)1 },
                    { "MX", "MEX", "Mexico", (ushort)1 },
                    { "MY", "MYS", "Malaysia", (ushort)1 },
                    { "MZ", "MOZ", "Mozambique", (ushort)1 },
                    { "NA", "NAM", "Namibia", (ushort)1 },
                    { "NC", "NCL", "New Caledonia", (ushort)11 },
                    { "NE", "NER", "Niger (the)", (ushort)1 },
                    { "NF", "NFK", "Norfolk Island", (ushort)8 },
                    { "NG", "NGA", "Nigeria", (ushort)1 },
                    { "NI", "NIC", "Nicaragua", (ushort)1 },
                    { "NL", "NLD", "Netherlands (Kingdom of the)", (ushort)1 },
                    { "NO", "NOR", "Norway", (ushort)1 },
                    { "NP", "NPL", "Nepal", (ushort)1 },
                    { "NR", "NRU", "Nauru", (ushort)1 },
                    { "NU", "NIU", "Niue", (ushort)9 },
                    { "NZ", "NZL", "New Zealand", (ushort)1 },
                    { "OM", "OMN", "Oman", (ushort)1 },
                    { "PA", "PAN", "Panama", (ushort)1 },
                    { "PE", "PER", "Peru", (ushort)1 },
                    { "PF", "PYF", "French Polynesia", (ushort)11 },
                    { "PG", "PNG", "Papua New Guinea", (ushort)1 },
                    { "PH", "PHL", "Philippines (the)", (ushort)1 },
                    { "PK", "PAK", "Pakistan", (ushort)1 },
                    { "PL", "POL", "Poland", (ushort)1 },
                    { "PM", "SPM", "Saint Pierre and Miquelon", (ushort)11 },
                    { "PN", "PCN", "Pitcairn", (ushort)4 },
                    { "PR", "PRI", "Puerto Rico", (ushort)3 },
                    { "PS", "PSE", "Palestine, State of", (ushort)13 },
                    { "PT", "PRT", "Portugal", (ushort)1 },
                    { "PW", "PLW", "Palau", (ushort)1 },
                    { "PY", "PRY", "Paraguay", (ushort)1 },
                    { "QA", "QAT", "Qatar", (ushort)1 },
                    { "RE", "REU", "Reunion", (ushort)11 },
                    { "RO", "ROU", "Romania", (ushort)1 },
                    { "RS", "SRB", "Serbia", (ushort)1 },
                    { "RU", "RUS", "Russian Federation (the)", (ushort)1 },
                    { "RW", "RWA", "Rwanda", (ushort)1 },
                    { "SA", "SAU", "Saudi Arabia", (ushort)1 },
                    { "SB", "SLB", "Solomon Islands", (ushort)1 },
                    { "SC", "SYC", "Seychelles", (ushort)1 },
                    { "SD", "SDN", "Sudan (the)", (ushort)1 },
                    { "SE", "SWE", "Sweden", (ushort)1 },
                    { "SG", "SGP", "Singapore", (ushort)1 },
                    { "SH", "SHN", "Saint Helena, Ascension Island, Tristan da Cunha", (ushort)4 },
                    { "SI", "SVN", "Slovenia", (ushort)1 },
                    { "SJ", "SJM", "Svalbard, Jan Mayen", (ushort)7 },
                    { "SK", "SVK", "Slovakia", (ushort)1 },
                    { "SL", "SLE", "Sierra Leone", (ushort)1 },
                    { "SM", "SMR", "San Marino", (ushort)1 },
                    { "SN", "SEN", "Senegal", (ushort)1 },
                    { "SO", "SOM", "Somalia", (ushort)1 },
                    { "SR", "SUR", "Suriname", (ushort)1 },
                    { "SS", "SSD", "South Sudan", (ushort)1 },
                    { "ST", "STP", "Sao Tome and Principe", (ushort)1 },
                    { "SV", "SLV", "El Salvador", (ushort)1 },
                    { "SX", "SXM", "Sint Maarten (Dutch part)", (ushort)6 },
                    { "SY", "SYR", "Syrian Arab Republic (the)", (ushort)1 },
                    { "SZ", "SWZ", "Eswatini", (ushort)1 },
                    { "TC", "TCA", "Turks and Caicos Islands (the)", (ushort)4 },
                    { "TD", "TCD", "Chad", (ushort)1 },
                    { "TF", "ATF", "French Southern Territories (the)", (ushort)11 },
                    { "TG", "TGO", "Togo", (ushort)1 },
                    { "TH", "THA", "Thailand", (ushort)1 },
                    { "TJ", "TJK", "Tajikistan", (ushort)1 },
                    { "TK", "TKL", "Tokelau", (ushort)9 },
                    { "TL", "TLS", "Timor-Leste", (ushort)1 },
                    { "TM", "TKM", "Turkmenistan", (ushort)1 },
                    { "TN", "TUN", "Tunisia", (ushort)1 },
                    { "TO", "TON", "Tonga", (ushort)1 },
                    { "TR", "TUR", "Turkiye", (ushort)1 },
                    { "TT", "TTO", "Trinidad and Tobago", (ushort)1 },
                    { "TV", "TUV", "Tuvalu", (ushort)1 },
                    { "TW", "TWN", "Taiwan (Province of China)", (ushort)15 },
                    { "TZ", "TZA", "Tanzania, the United Republic of", (ushort)1 },
                    { "UA", "UKR", "Ukraine", (ushort)1 },
                    { "UG", "UGA", "Uganda", (ushort)1 },
                    { "UM", "UMI", "United States Minor Outlying Islands (the)", (ushort)3 },
                    { "US", "USA", "United States of America (the)", (ushort)1 },
                    { "UY", "URY", "Uruguay", (ushort)1 },
                    { "UZ", "UZB", "Uzbekistan", (ushort)1 },
                    { "VA", "VAT", "Holy See (the)", (ushort)13 },
                    { "VC", "VCT", "Saint Vincent and the Grenadines", (ushort)1 },
                    { "VE", "VEN", "Venezuela (Bolivarian Republic of)", (ushort)1 },
                    { "VG", "VGB", "Virgin Islands (British)", (ushort)4 },
                    { "VI", "VIR", "Virgin Islands (U.S.)", (ushort)3 },
                    { "VN", "VNM", "Viet Nam", (ushort)1 },
                    { "VU", "VUT", "Vanuatu", (ushort)1 },
                    { "WF", "WLF", "Wallis and Futuna", (ushort)11 },
                    { "WS", "WSM", "Samoa", (ushort)1 },
                    { "YE", "YEM", "Yemen", (ushort)1 },
                    { "YT", "MYT", "Mayotte", (ushort)11 },
                    { "ZA", "ZAF", "South Africa", (ushort)1 },
                    { "ZM", "ZMB", "Zambia", (ushort)1 },
                    { "ZW", "ZWE", "Zimbabwe", (ushort)1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SovereigntyId",
                table: "Countries",
                column: "SovereigntyId");

            migrationBuilder.CreateIndex(
                name: "IX_IPv4Ranges_CountryId",
                table: "IPv4Ranges",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IPv4Ranges");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Sovereignties");
        }
    }
}
