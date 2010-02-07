﻿using System;
using System.Collections.Generic;
using System.Windows;
using gorilla.commons.utility;

namespace presentation.windows.views
{
    public partial class ShellWindow : RegionManager
    {
        readonly IDictionary<Type, UIElement> regions;

        public ShellWindow()
        {
            InitializeComponent();
            regions = new Dictionary<Type, UIElement>
                      {
                          {GetType(), this},
                          {typeof (Window), this},
                          {Tabs.GetType(), Tabs},
                          {StatusBar.GetType(), StatusBar},
                          {Menu.GetType(), Menu},
                      };
        }

        public void region<Region>(Action<Region> configure) where Region : UIElement
        {
            ensure_that_the_region_exists<Region>();
            configure(regions[typeof (Region)].downcast_to<Region>());
        }

        void ensure_that_the_region_exists<Region>()
        {
            if (!regions.ContainsKey(typeof (Region)))
                throw new Exception("Could not find region: {0}".formatted_using(typeof (Region)));
        }
    }
}