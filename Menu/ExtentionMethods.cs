using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Menu.Extentions
{
    public static class ExtentionMethods
    {

       /// <summary>
       /// Find the first ancestor in the visual tree that has the specified type
       /// or null if no ancestor is found
       /// </summary>
       /// <typeparam name="T"> the type to search for</typeparam>
       /// <param name="obj"></param>
       /// <returns></returns>
        public static T FindAncestor<T>(this DependencyObject obj) where T: DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(obj);
            if(parent is null)
            {
                return null;
            }
            if(parent is T)
            {
                return parent as T;
            }
            return FindAncestor<T>(parent);
        }



    }
}
