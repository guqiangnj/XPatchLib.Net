﻿// Copyright © 2013-2017 - GuQiang
// Licensed under the LGPL-3.0 license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;

namespace XPatchLib
{
    internal static class IEnumerableHelper
    {
        public static int FindIndex<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            int index = -1;
            foreach (T item in items)
            {
                index++;
                if (predicate(item))
                    break;
            }
            return index;
        }
    }
}