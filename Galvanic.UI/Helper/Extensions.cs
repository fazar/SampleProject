using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Omu.ValueInjecter;

namespace Galvanic.UI.Helper
{    
    public static class Extensions
    {
        //taken from http://blog.aquabirdconsulting.com/?p=318
        public static T ToDomain<T>(this object source, T domain = default(T))
            where T : class, new()
        {
            if (domain == null)
                domain = new T();

            if (source == null)
                return domain;

            domain.InjectFrom(source)                
                .InjectFrom<FlatLoopValueInjection>(source)
                .InjectFrom<UnflatLoopValueInjection>(source);

            return domain;
        }

        public static T ToViewModel<T>(this object source, T viewmodel = default(T))
            where T : class, new()
        {
            if (viewmodel == null)
                viewmodel = new T();

            if (source == null)
                return viewmodel;

            viewmodel.InjectFrom(source)
                .InjectFrom<FlatLoopValueInjection>(source)
                .InjectFrom<UnflatLoopValueInjection>(source)
                .InjectFrom<NullablesToNormal>(source)
                .InjectFrom<NormalToNullables>(source)
                .InjectFrom<IntToEnum>(source)
                .InjectFrom<EnumToInt>(source);

            return viewmodel;
        }

        public static IEnumerable<T> Map<T>(this object[] source, T viewmodel = default(T)) where T : class
        {
            foreach (var item in source)
            {
                //if(viewmodel == null)
                //    viewmodel = new List<T>();
                viewmodel.InjectFrom(item);
                yield return viewmodel;                    
            }
        }
    }
}