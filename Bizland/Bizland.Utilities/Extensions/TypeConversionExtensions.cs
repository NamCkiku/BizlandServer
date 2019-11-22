﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Bizland.Utilities.Extensions
{
    public static class TypeConversionExtensions
    {
        [DebuggerStepThrough]
        public static T ConvertTo<T>(this string input)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                return (T)converter.ConvertFromString(input);
            }
            catch (NotSupportedException)
            {
                return default;
            }
        }
    }
}
