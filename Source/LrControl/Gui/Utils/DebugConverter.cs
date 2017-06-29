﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace LrControl.Gui.Utils
{
    public class DebugConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
            return value;
        }
    }
}