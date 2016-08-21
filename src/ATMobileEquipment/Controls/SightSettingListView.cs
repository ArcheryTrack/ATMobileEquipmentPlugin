using System;
using System.Collections.Generic;
using ATMobile.Cells;
using ATMobile.Controls;
using ATMobile.Managers;
using ATMobile.Plugins.Equipment.Managers;
using ATMobile.Plugins.Equipment.Objects;
using Xamarin.Forms;

namespace ATMobile.Plugins.Equipment.Controls
{
    public class SightSettingListView : AbstractListView
    {
        private List<SightSetting> m_SightSettings;

        public SightSettingListView ()
        {
            ItemTemplate = new DataTemplate (typeof (SightSettingCell));
            //RowHeight = 60;
            HasUnevenRows = true;
        }

        public void RefreshList (Guid _archerGuid)
        {
            using (var em = new EquipmentManager ()) {
                m_SightSettings = em.GetSightSettings (_archerGuid);
                ItemsSource = m_SightSettings;
            }
        }

        public void ClearList ()
        {
            ItemsSource = null;
        }
    }
}

