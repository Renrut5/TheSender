using System;
using TheSender.Items;
using TheSender.Entities;

namespace TheSender.Events
{
    interface IEncounter
    {
        public void EncounterIntro();
        public void EncounterMain(ref MainPlayer player);
        public void EncounterSuccess();
        public void EncounterFailure();
        public bool IsEncounterSuccessful();
    }
}
