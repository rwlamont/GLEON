using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    class HeaderRecgonition
    {
        #region Avanced Detecion
        public string[] WordsTemperature = {"temp",
                                            "Temp",
                                            "TEMP",
                                            "tmp",
                                            "Tmp",
                                            "TMP",
                                            "temperature",
                                            "Temperature",
                                            "TEMPERATURE",
                                            "tem",
                                            "Tem",
                                            "TEM"
                                            };
        public string[] WordsWater = {     "water",
                                           "Water",
                                           "WATER",
                                           "wtr",
                                           "Wtr",
                                           "WTR",
                                           "h2o",
                                           "H2o",
                                           "H2O"
                                      };
        public string[] WordsAir =  {       "air",
                                            "Air",
                                            "AIR"                                            
                                    };
        public string[] WordsWind = {       "wnd",
                                            "Wnd",
                                            "WND",
                                            "wind",
                                            "Wind",
                                            "WIND"
                                     };
        public string[] WordsSpeed = {      "spd",
                                            "Spd",
                                            "SPD",
                                            "speed",
                                            "Speed",
                                            "SPEED",
                                            "velocity",
                                            "Velocity",
                                            "VELOCITY"
                                     };
        public string RoughGuess(string inHeader)
        {
            if (inHeader == "")
                return "";
            if (Regex.IsMatch(inHeader, @"([a-z]|[A-Z]){2,6}_[d,h,e,m]([0-9]|[.])+([^),^(]*)") ||
                        Regex.IsMatch(inHeader, @"([a-z]|[A-Z]){2,6}_i([0-9]|[.])+\-([0-9]|[.])+([^),^(]*)") ||
                        Regex.IsMatch(inHeader, @"([a-z]|[A-Z]){2,6}_[v,n]([^),^(]*)"))
                return inHeader;
            if (Regex.IsMatch(inHeader, @"DateTime"))
                return inHeader;
            if(TemperatureHeaderCheck(inHeader))
                return TemperatureFormating(inHeader);
            return "";
        }
        private string TemperatureFormating(string inHeader)
        {
            if (AirHeaderCheck(inHeader))
            {
                string depthValue = NumberExtractor(inHeader);
                return "AirTem_h" + depthValue + "(degC)";
            }
            if (WaterHeaderCheck(inHeader))
            {
                string heightValue = NumberExtractor(inHeader);
                return "TmpWtr_d" + heightValue + "(degC)";
            }
            if (inHeader.Contains("Dew"))
            {
                string heightValue = NumberExtractor(inHeader);
                return "TmpDew_h" + heightValue + "(degC)";
            }
            if (inHeader.Contains("Lg"))
            {
                string heightValue = NumberExtractor(inHeader);
                return "TmpLg_h" + heightValue + "(degC)";
            }
            if (inHeader.Contains("Ref"))
            {
                string heightValue = NumberExtractor(inHeader);
                return "AirRef_h" + heightValue + "(degC)";
            }
            return "";
        }
        private bool TemperatureHeaderCheck(string inHeader)
        {
            for(int i = 0; i <WordsTemperature.Count();i++)
            {
                if(inHeader.Contains(WordsTemperature[i]))
                    return true;
            }
            return false;
        }
        
        private bool AirHeaderCheck(string inHeader)
        {
            for (int i = 0; i < WordsAir.Count(); i++)
            {
                if (inHeader.Contains(WordsAir[i]))
                    return true;
            }
            return false;
        }
        private bool WaterHeaderCheck(string inHeader)
        {
            for (int i = 0; i < WordsWater.Count(); i++)
            {
                if (inHeader.Contains(WordsWater[i]))
                    return true;
            }
            return false;
        }
        private string NumberExtractor(string inHeader)
        {
            const string Numbers = "0123456789.";
            var numberBuilder = new StringBuilder();
            foreach (char c in inHeader)
            {
                if (Numbers.IndexOf(c) > -1)
                    numberBuilder.Append(c);
            }
            return numberBuilder.ToString();
        }
        public bool checkforHeaderWords(string inHeader)
        {
            if (TemperatureHeaderCheck(inHeader) || WaterHeaderCheck(inHeader) || AirHeaderCheck(inHeader))
            {
                return true;
            }
            return false;
        }
#endregion
        #region Basic Detection
        public string getTestCode(string input)
        {
            if(Regex.IsMatch(input, @"([a-z]|[A-Z]){2,6}_[d,h,e,m]([0-9]|[.])+([^),^(]*)") ||
                        Regex.IsMatch(input, @"([a-z]|[A-Z]){2,6}_i([0-9]|[.])+\-([0-9]|[.])+([^),^(]*)") ||
                        Regex.IsMatch(input, @"([a-z]|[A-Z]){2,6}_[v,n]([^),^(]*)"))
            {
                return input.Substring(0, input.IndexOf("_"));
            }
            return "";
        }
        public bool isHeaderInStandardFormat(string input)
        {
            if (Regex.IsMatch(input, @"([a-z]|[A-Z]){2,6}_[d,h,e,m]([0-9]|[.])+([^),^(]*)") ||
                Regex.IsMatch(input, @"([a-z]|[A-Z]){2,6}_i([0-9]|[.])+\-([0-9]|[.])+([^),^(]*)") ||
                Regex.IsMatch(input, @"([a-z]|[A-Z]){2,6}_[v,n]([^),^(]*)") ||
                Regex.IsMatch(input, @"DateTime"))
            {
                return true;
            }
            return false;
        }
        public bool isHeaderInStandardVariableFormat(string input)
        {
            if (Regex.IsMatch(input, @"([a-z]|[A-Z]){2,6}_[d,h,e,m]([0-9]|[.])+([^),^(]*)") ||
                Regex.IsMatch(input, @"([a-z]|[A-Z]){2,6}_i([0-9]|[.])+\-([0-9]|[.])+([^),^(]*)") ||
                Regex.IsMatch(input, @"([a-z]|[A-Z]){2,6}_[v,n]([^),^(]*)"))
            {
                return true;
            }
            return false;
        }
        public string getHeaderType(string input)
        {
            if (Regex.IsMatch(input, @"([a-z]|[A-Z]){2,6}_[d,h,e,m]([0-9]|[.])+([^),^(]*)"))
            {
                return "dhem";
            }
            else if (Regex.IsMatch(input, @"([a-z]|[A-Z]){2,6}_i([0-9]|[.])+\-([0-9]|[.])+([^),^(]*)"))
            {
                return "i";
            }
            else if (Regex.IsMatch(input, @"([a-z]|[A-Z]){2,6}_[v,n]([^),^(]*)"))
            {
                return "vn";
            }
            else if (Regex.IsMatch(input, @"DateTime"))
            {
                return "DateTime";
            }
            return "";
        }
        #endregion
        
    }
}
