using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace WindowsFormsApplication1
{
    class DateConverter
    {
        public string acceptedFormat = null;
        DateTime ConvertedDate;
        int IntNum;
        Double Num;
        string output;
        DateTime ExcelNumStartDate = new DateTime(1899, 12, 30);
        string[] _AcceptedFormats = File.ReadAllLines(@"Control Files\Formats.txt");
        public string ConvertDateToStandard(string inDate)
        {
            inDate.Replace("\"", String.Empty);
            if (acceptedFormat == null)
            {
                foreach(string stringAttempt in _AcceptedFormats)
                {
                    if(DateTime.TryParseExact(inDate,stringAttempt, null, DateTimeStyles.None, out ConvertedDate))
                    {
                        output = ConvertedDate.ToString("yyyy-MM-dd HH:mm:ss");
                        acceptedFormat = stringAttempt;
                        return output;
                    }
                }

                if (int.TryParse(inDate, out IntNum))//Integer Number format
                {
                    if (inDate.Length == 7)//yyyyddd
                    {
                        if (Convert.ToDouble(inDate.Substring(4, 3)) <= 366)
                        {
                            DateTime DaysInYearDateTime = new DateTime(Convert.ToInt16(inDate.Substring(0, 4)), 1, 1);
                            DaysInYearDateTime = DaysInYearDateTime.AddDays(Convert.ToDouble(inDate.Substring(4, 3)) - 1);
                            output = DaysInYearDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                            return output;
                        }
                        else
                        {
                            output = ExcelNumStartDate.AddDays(IntNum).ToString("yyyy-MM-dd HH:mm:ss");
                            return output;
                        }
                    }
                    else
                    {
                        output = ExcelNumStartDate.AddDays(IntNum).ToString("yyyy-MM-dd HH:mm:ss");
                        return output;
                    }


                }
                else if (double.TryParse(inDate, out Num))
                {
                    output = ExcelNumStartDate.AddDays(Num).ToString("yyyy-MM-dd HH:mm:ss");
                    return output;
                }
            }
            else
            {
                if (DateTime.TryParseExact(inDate, acceptedFormat, null, DateTimeStyles.None, out ConvertedDate))
                {
                    output = ConvertedDate.ToString("yyyy-MM-dd HH:mm:ss");
                    return output;
                }
                else
                {
                    acceptedFormat = null;
                    return ConvertDateToStandard(inDate);
                }
            }
            return null;
        }
    }
}
