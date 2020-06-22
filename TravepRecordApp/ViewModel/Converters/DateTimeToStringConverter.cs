using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TravepRecordApp.ViewModel.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture){
            DateTimeOffset dateTime = (DateTimeOffset)value;
            DateTimeOffset righNow = DateTimeOffset.Now;
            var difference = righNow - dateTime;

            if (difference.TotalDays > 1) return $"{dateTime:d}";
            else { 
                if (difference.TotalSeconds<60) return $"{Math.Round(difference.TotalSeconds, MidpointRounding.ToEven)} seconds ago";
                if (difference.TotalMinutes<60) return $"{difference.Minutes} minutes ago";
                if (difference.TotalHours < 24) return $"{difference.Hours} hours ago";
                return "Yesterday";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTimeOffset.Now;
        }
    }
}
