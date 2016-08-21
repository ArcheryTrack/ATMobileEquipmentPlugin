using System;
using System.Collections.Generic;
using ATMobile.Daos;
using ATMobile.Managers;
using ATMobile.Objects;
using ATMobile.Plugins.Equipment.Daos;
using ATMobile.Plugins.Equipment.Objects;

namespace ATMobile.Plugins.Equipment.Managers
{
    public class EquipmentManager : IDisposable
    {
        private ATManager m_Manager;

        public EquipmentManager ()
        {
            m_Manager = ATManager.GetInstance ();
        }

        public void Dispose ()
        {
            m_Manager = null;
        }

        #region Sight Settings

        public List<SightSetting> GetSightSettings (Guid _archerGuid)
        {
            SightSettingDao dao = new SightSettingDao (m_Manager.Database);
            var settings = dao.GetSightSettings (_archerGuid);
            return settings;
        }

        public void Persist (SightSetting _sightSetting)
        {
            SightSettingDao dao = new SightSettingDao (m_Manager.Database);
            dao.Persist (_sightSetting);
        }

        #endregion

    }
}

