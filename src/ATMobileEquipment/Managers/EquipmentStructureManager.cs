using System;
using ATMobile.Plugins.Equipment.Daos;
using LiteDB;

namespace ATMobile.Plugins.Equipment.Managers
{
    public class EquipmentStructureManager
    {
        private LiteDatabase m_Database;

        public EquipmentStructureManager (LiteDatabase _database)
        {
            m_Database = _database;
        }

        public void BuildStructure ()
        {
            SightSettingDao sightSettingDao = new SightSettingDao (m_Database);
            sightSettingDao.BuildIndexes ();
        }
    }
}

