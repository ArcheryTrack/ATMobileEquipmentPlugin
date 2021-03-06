﻿using System;
using ATMobile.Interfaces;
using ATMobile.Objects;

namespace ATMobile.Plugins.Equipment.Objects
{
    public class SightSetting : AbstractObject, IHasParent
    {
        public DateTime DateTime { get; set; }

        public Distance Distance { get; set; }

        public double Setting { get; set; }

        public Guid ParentId { get; set; }

        public string DistanceText {
            get {
                if (Distance != null) {
                    return Distance.ToString ();
                }

                return null;
            }
        }
    }
}

