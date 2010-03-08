﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Signum.Windows
{
    public static class ControlExtensions
    {
        public static bool IsSet(this DependencyObject depObj, DependencyProperty prop)
        {
            return DependencyPropertyHelper.GetValueSource(depObj, prop).BaseValueSource == BaseValueSource.Local;
        }

        public static bool NotSet(this DependencyObject depObj, DependencyProperty prop)
        {
            return DependencyPropertyHelper.GetValueSource(depObj, prop).BaseValueSource != BaseValueSource.Local;
        }

        public static T Set<T>(this T depObj, DependencyProperty prop, object value) where T : DependencyObject
        {
            depObj.SetValue(prop, value);
            return depObj;
        }

        public static T Handle<T>(this T uiElement, RoutedEvent routedEvent, RoutedEventHandler handler) where T : UIElement
        {
            uiElement.AddHandler(routedEvent, handler);
            return uiElement; 
        }

        public static Visibility ToVisibility(this bool val)
        {
            return val ? Visibility.Visible : Visibility.Collapsed;
        }

        public static bool FromVisibility(this Visibility val)
        {
            return val == Visibility.Visible;
        }

        public static TabControl AddTab(this TabControl tabControl, string header, Control content)
        {
            tabControl.Items.Add(new TabItem { Header = header, Content = content });
            return tabControl;
        }

        public static T Hide<T>(this T uiElement) where T : UIElement
        {
            uiElement.Visibility = Visibility.Hidden;
            return uiElement;
        }

        public static T Collapse<T>(this T uiElement) where T : UIElement
        {
            uiElement.Visibility = Visibility.Collapsed;
            return uiElement;
        }

        public static T Visible<T>(this T uiElement) where T : UIElement
        {
            uiElement.Visibility = Visibility.Collapsed;
            return uiElement;
        }

        public static T ReadOnly<T>(this T uiElement) where T : UIElement
        {
            Common.SetIsReadOnly(uiElement, true);
            return uiElement;
        }

        public static T Editable<T>(this T uiElement) where T : UIElement
        {
            Common.SetIsReadOnly(uiElement, false); 
            return uiElement;
        }

    }
}
