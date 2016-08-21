using System;
using System.Linq;
using LiteDB;
using ATMobile.Objects;
using System.Collections.Generic;
using ATMobile.Daos;
using ATMobile.Plugins.Equipment.Objects;

namespace ATMobile.Plugins.Equipment.Daos
{
    public class SightSettingDao : AbstractDao<SightSetting>
    {
        public SightSettingDao (LiteDatabase _database)
            : base (_database)
        {
        }

        public override void BuildIndexes ()
        {
        }

        public override string CollectionName {
            get {
                return "SightSettings";
            }
        }

        public List<SightSetting> GetSightSettings (Guid _archerGuid)
        {
            var settings = GetChildren (_archerGuid);

            return settings.OrderBy ((SightSetting arg) => arg.Distance).ToList ();
        }
    }
}

