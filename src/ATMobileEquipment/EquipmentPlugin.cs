using System;
using System.Collections.Generic;
using ATMobile.Interfaces;
using ATMobile.Managers;
using ATMobile.Objects;
using ATMobile.Plugins.Equipment.Forms;
using Xamarin.Forms;

namespace ATMobile.Plugins.Equipment
{
    public class EquipmentPlugin : IPlugin, IDisposable
    {
        private ATManager m_Manager;

        public void InitializePlugin (ATManager _manager)
        {
            m_Manager = _manager;
        }


        public void Dispose ()
        {
            if (m_Manager != null) {
                m_Manager = null;
            }
        }

        public List<PluginMenuOption> GetMainMenuItems ()
        {
            var list = new List<PluginMenuOption> ();

            list.Add (new PluginMenuOption (this) {
                IconSource = null,
                Title = "Sight Setup",
                TargetType = typeof (SightSetupForm)
            });

            return list;
        }

        public List<PluginMenuOption> GetSettingsMenuItems ()
        {
            return null;
        }

        public Page GetPage (PluginMenuOption _menuOption)
        {
            return (Page)Activator.CreateInstance (_menuOption.TargetType);
        }
    }
}

