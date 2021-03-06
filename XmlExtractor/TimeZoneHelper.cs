﻿namespace Suyati.XmlExtractor
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal static class TimezoneHelper
    {
        /// <summary>
        /// To replace the Time zone abbreviation from datetime string
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        internal static string ReplaceTimezoneAbbreviation(string dateTime)
        {
            if (!string.IsNullOrEmpty(dateTime))
            {
                foreach (var keyVal in TimezoneHelper.Timezones)
                {
                    if (dateTime.EndsWith(" " + keyVal.Key, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return dateTime.Replace(" " + keyVal.Key, " " + keyVal.Value);
                    }
                }
            }
            return dateTime;
        }

        /// <summary>
        /// To replace the timezone offset to default format
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="success"></param>
        /// <returns></returns>
        internal static string ReplaceOffSetToDefaultFormat(string dateTime, out bool success)
        {
            success = false;

            // Timezone offset in the format (+/-HHMM)
            var regex = @"(\+|\-)(\d{2})(\d{2})$";

            // If matches
            if (Regex.IsMatch(dateTime, regex))
            {

                var matches = Regex.Matches(dateTime, regex);
                if (matches != null && matches.Count > 0)
                {
                    var match = matches[0];
                    if (match.Groups != null && match.Groups.Count > 3)
                    {
                        // Replacing offset with default format (+/-HH:MM)
                        var replacement = string.Format("{0}{1}:{2}",
                            match.Groups[1].Success ? match.Groups[1].Value : "+",
                            match.Groups[2].Success ? match.Groups[2].Value : "00",
                            match.Groups[3].Success ? match.Groups[3].Value : "00");
                        success = true;
                        return Regex.Replace(dateTime, regex, replacement);
                    }
                }
            }
            return dateTime;
        }

        /// <summary>
        /// The Abbreviations and aits Timezone info
        /// </summary>
        internal static Dictionary<string, string> Timezones = new Dictionary<string, string>()
        {
                    {"A","+1:00"},{"ACDT","+10:30"},{"ACST","+9:30"},{"ACT","-5:00"},{"ACWST","+8:45"},{"ADT","-3:00"},{"AEDT","+11:00"},
                    {"AEST","+10:00"},{"AET","+10:00"},{"AFT","+4:30"},{"AKDT","-8:00"},{"AKST","-9:00"},{"ALMT","+6:00"},{"HNR","-7:00"},{"MST","+8:00"},
                    {"AMST","+5:00"},{"AMDT","+5:00"},{"AMT","+4:00"},{"ANAST","+12:00"},{"ANAT","+12:00"},{"ADST","-3:00"},{"AST","-3:00"},{"HAA","-3:00"},
                    {"CST","+9:30"},{"AQTT","+5:00"},{"ART","+8:45"},{"AT","-4:00"},{"HNA","-4:00"},{"AWDT","+9:00"},{"MCK","+3:00"},{"MT","-7:00"},
                    {"WDT","+9:00"},{"AWST","+8:00"},{"WAT","+8:00"},{"AZODT","+0:00"},{"AZOT","-1:00"},{"AZOST","-1:00"},{"AZST","+5:00"},{"N","-1:00"},
                    {"AZT","+4:00"},{"AoE","-12:00"},{"B","+8:45"},{"BNT","+8:00"},{"BDT","+8:00"},{"BRST","-2:00"},{"BRT","-3:00"},{"BT","-3:00"},{"BST","+1:00"},
                    {"BDST","+1:00"},{"C","+3:00"},{"CAST","+8:00"},{"CDST","-5:00"},{"NACDT","-5:00"},{"HAC","-5:00"},{"CEST","+2:00"},{"CEDT","+2:00"},
                    {"ECST","+2:00"},{"MESZ","+2:00"},{"CET","+1:00"},{"ECT","+1:00"},{"MEZ","+1:00"},{"CHADT","+13:45"},{"CDT","+13:45"},{"CHAST","+12:45"},
                    {"CHOT","+8:00"},{"CHUT","+10:00"},{"CLST","-3:00"},{"CLDT","-3:00"},{"CLT","-3:00"},{"CT","-6:00"},{"NACST","-6:00"},{"HNC","-6:00"},
                    {"ChST","+10:00"},{"GST","+10:00"},{"D","+4:00"},{"DAVT","+7:00"},{"DDUT","+10:00"},{"E","+5:00"},{"EASST","-5:00"},{"EADT","-5:00"},
                    {"EAST","-5:00"},{"EAT","+3:00"},{"EDT","+4:00"},{"EDST","-4:00"},{"NAEDT","-4:00"},{"HAE","-4:00"},{"MSK","+3:00"},{"NAMST","-7:00"},
                    {"EEST","+3:00"},{"EEDT","+3:00"},{"OESZ","+3:00"},{"EET","+2:00"},{"OEZ","+2:00"},{"EGST","+0:00"},{"EST","-5:00"},{"ET","-5:00"},
                    {"NAEST","-5:00"},{"HNE","-5:00"},{"F","+6:00"},{"FET","+3:00"},{"FJST","+13:00"},{"FJDT","+13:00"},{"FKST","-3:00"},{"FKDT","-3:00"},
                    {"FKT","-4:00"},{"G","+7:00"},{"GALT","-6:00"},{"GAMT","-9:00"},{"GILT","+12:00"},{"GMT","+0:00"},{"UTC","+0:00"},{"GT","+0:00"},
                    {"H","+8:00"},{"HADT","-9:00"},{"HDT","-9:00"},{"HAST","-10:00"},{"HST","-10:00"},{"HOVT","+7:00"},{"I","+9:00"},{"ICT","+7:00"},
                    {"IRDT","+4:30"},{"IDT","+4:30"},{"IRKST","+9:00"},{"IRKT","+8:00"},{"IRST","+3:30"},{"IT","+3:30"},{"NCT","+11:00"},{"NDT","-2:30"},
                    {"IST","+5:30"},{"K","+10:00"},{"KGT","+6:00"},{"KOST","+11:00"},{"KRAST","+8:00"},{"KRAT","+7:00"},{"KST","+9:00"},{"HAT","-2:30"},
                    {"KT","+9:00"},{"KUYT","+4:00"},{"SAMST","+4:00"},{"L","+11:00"},{"LHDT","+11:00"},{"LHST","+10:30"},{"LINT","+14:00"},{"M","+12:00"},
                    {"MAGST","+12:00"},{"MAGT","+10:00"},{"MART","-9:30"},{"MAWT","+5:00"},{"MDT","-6:00"},{"MDST","-6:00"},{"NAMDT","-6:00"},{"HAR","-6:00"},
                    {"HNT","-3:30"},{"NZDT","+13:00"},{"NZST","+12:00"},{"O","-2:00"},{"OMSST","+7:00"},{"NOVST","+7:00"},{"OMST","+6:00"},{"NOVT","+6:00"},
                    {"ORAT","+5:00"},{"P","-3:00"},{"PDT","-7:00"},{"PDST","-7:00"},{"NAPDT","-7:00"},{"HAP","-7:00"},{"PETST","+12:00"},{"PETT","+12:00"},
                    {"PHOT","+13:00"},{"PKT","+5:00"},{"PMDT","-2:00"},{"PMST","-3:00"},{"PONT","+11:00"},{"PST","-8:00"},{"PT","-8:00"},{"NAPST","-8:00"},
                    {"HNP","-8:00"},{"PYST","-3:00"},{"Q","-4:00"},{"QYZT","+6:00"},{"R","-5:00"},{"RET","+4:00"},{"ROTT","-3:00"},{"S","-6:00"},{"SAKT","+10:00"},
                    {"SAMT","+4:00"},{"SAST","+2:00"},{"SGT","+8:00"},{"SST","+8:00"},{"SRET","+11:00"},{"SYOT","+3:00"},{"T","-7:00"},{"NFT","+11:30"},
                    {"TAHT","-10:00"},{"TFT","+5:00"},{"KIT","+5:00"},{"TJT","+5:00"},{"U","-8:00"},{"ULAT","+8:00"},{"UYST","-2:00"},{"V","-9:00"},
                    {"VET","-4:30"},{"HLV","-4:30"},{"VLAST","+11:00"},{"VLAT","+10:00"},{"VOST","+6:00"},{"VUT","+11:00"},{"EFATE","+11:00"},{"W","-10:00"},
                    {"WAKT","+12:00"},{"WARST","-3:00"},{"WAST","+2:00"},{"WEST","+1:00"},{"WEDT","+1:00"},{"WESZ","+1:00"},{"WEZ","+0:00"},{"NST","-3:30"},
                    {"WGST","-2:00"},{"WIT","+9:00"},{"WITA","+8:00"},{"WST","+13:00"},{"ST","+13:00"},{"WT","+0:00"},{"X","-11:00"},{"Y","-12:00"},
                    {"YAKST","+10:00"},{"YAKT","+9:00"},{"YAPT","+10:00"},{"YEKST","+6:00"},{"YEKT","+5:00"},{"Z","+0:00"}
        };
    }
}
