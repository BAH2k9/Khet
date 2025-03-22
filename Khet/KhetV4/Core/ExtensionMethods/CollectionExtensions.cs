using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhetV4.Core.ExtensionMethods
{
    public static class CollectionExtensions
    {
        public static BindableCollection<T> ToBindableCollection<T>(this IEnumerable<T> source)
        {
            if (source == null)
                return new BindableCollection<T>();

            return new BindableCollection<T>(source);
        }
    }
}
