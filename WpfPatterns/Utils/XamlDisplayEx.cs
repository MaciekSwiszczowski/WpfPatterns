﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfPatterns.Utils
{
    public static class XamlDisplayEx
    {
        // A copy-paste from MaterialDesignDemo app
        public static readonly DependencyProperty ButtonDockProperty = DependencyProperty.RegisterAttached(
            "ButtonDock", typeof(Dock), typeof(XamlDisplayEx), new PropertyMetadata(default(Dock)));

        public static void SetButtonDock(DependencyObject element, Dock value)
        {
            element.SetValue(ButtonDockProperty, value);
        }

        public static Dock GetButtonDock(DependencyObject element)
        {
            return (Dock)element.GetValue(ButtonDockProperty);
        }
    }
}
