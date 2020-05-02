using System;
using System.Collections.Generic;
using System.Text;
using TheSender.Entities;

namespace TheSender.Events
{
    abstract class BaseEncounter
    {

        protected bool isEncounterSuccessful;

        public BaseEncounter()
        {
            isEncounterSuccessful = false;
        }

        public bool IsEncounterSuccessful()
        {
            return isEncounterSuccessful;
        }

    }
}
