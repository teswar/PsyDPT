using Psydpt.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Psydpt.Areas.Patient.ViewModels
{
    public class PatientSigeCapsVM : Data.Entities.PatientSigeCaps
    {
        public PatientSigeCapsVM()
            : this(null)
        { }

        public PatientSigeCapsVM(PatientSigeCaps dbmodel)
        {
            if (dbmodel == null) { return; }

            PatientSigeCapId = dbmodel.PatientSigeCapId;
            Sleepiness = dbmodel.Sleepiness;
            Interest = dbmodel.Interest;
            EnergyLevel = dbmodel.EnergyLevel;
            Concentration = dbmodel.Concentration;
            Appetite = dbmodel.Appetite;
            Agitation = dbmodel.Agitation;
            GuiltyFeelings = dbmodel.GuiltyFeelings;
            SucidalThoughts = dbmodel.SucidalThoughts;
        }

        public PatientSigeCaps GetDbModel()
        {
            if (this == null) { return null; }
            return new PatientSigeCaps()
            {
                PatientSigeCapId = this.PatientSigeCapId,
                Sleepiness = this.Sleepiness,
                Interest = this.Interest,
                EnergyLevel = this.EnergyLevel,
                Concentration = this.Concentration,
                Appetite = this.Appetite,
                Agitation = this.Agitation,
                GuiltyFeelings = this.GuiltyFeelings,
                SucidalThoughts = this.SucidalThoughts
            };
        }


    }
}