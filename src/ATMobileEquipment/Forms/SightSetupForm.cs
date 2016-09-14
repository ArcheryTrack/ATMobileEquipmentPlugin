using System;
using System.Collections.Generic;
using ATMobile.Constants;
using ATMobile.Controls;
using ATMobile.Forms;
using ATMobile.Managers;
using ATMobile.Objects;
using ATMobile.Plugins.Equipment.Controls;
using ATMobile.Plugins.Equipment.Objects;
using Xamarin.Forms;

namespace ATMobile.Plugins.Equipment.Forms
{
    public class SightSetupForm : AbstractListForm
    {
        private bool m_Loading;

        private SightSettingListView m_SightSettings;
        private PracticeHistoryListView m_PracticeHistory;

        private Archer m_CurrentArcher;
        private ArcherBar m_ArcherBar;


        public SightSetupForm () : base ("Sight Setup")
        {
            m_Loading = true;

            //Load Archers and setup picker
            m_ArcherBar = new ArcherBar ();
            m_ArcherBar.ArcherPicked += ArcherPicked;
            m_CurrentArcher = m_ArcherBar.CurrentArcher;
            OutsideLayout.Children.Insert (1, m_ArcherBar);

            m_SightSettings = new SightSettingListView ();
            m_SightSettings.ItemSelected += OnSelected;
            ListFrame.Content = m_SightSettings;

            m_Loading = false;
        }

        void ArcherPicked (Archer archer)
        {
            if (!m_Loading) {
                m_CurrentArcher = archer;

                if (m_CurrentArcher != null) {
                    ATManager.GetInstance ().SettingManager.SetCurrentArcher (m_CurrentArcher.Id);
                }

                RefreshList ();
            }
        }

        public override void Add ()
        {
            if (m_CurrentArcher != null) {
                SightSettingForm addSetting = new SightSettingForm ();
                addSetting.SetSightSetting (m_CurrentArcher, null);

                Navigation.PushModalAsync (addSetting);
            }
        }

        void OnSelected (object sender, SelectedItemChangedEventArgs e)
        {
            SightSetting setting = (SightSetting)e.SelectedItem;

            if (m_CurrentArcher != null) {
                SightSettingForm addSetting = new SightSettingForm ();
                addSetting.SetSightSetting (m_CurrentArcher, setting);
                Navigation.PushModalAsync (addSetting);
            }
        }

        protected override void OnAppearing ()
        {
            RefreshList ();
        }

        private void RefreshList ()
        {
            if (m_CurrentArcher == null) {
                m_SightSettings.ClearList ();
                AddButton.IsEnabled = false;
            } else {
                m_SightSettings.RefreshList (m_CurrentArcher.Id);
                AddButton.IsEnabled = true;
            }
        }
    }
}

