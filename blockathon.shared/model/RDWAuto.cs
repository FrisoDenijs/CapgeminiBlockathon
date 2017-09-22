using System;
using System.Collections.Generic;
using System.Text;

namespace blockathon.shared.model
{
#pragma warning disable IDE1006 // Naming Styles
    public class RDWAuto
    {
        public int aantal_cilinders { get; set; }
        public int aantal_deuren { get; set; }
        public int aantal_wielen { get; set; }
        public int aantal_zitplaatsen { get; set; }
        public int afstand_hart_koppeling_tot_achterzijde_voertuig { get; set; }
        public int afstand_voorzijde_voertuig_tot_hart_koppeling { get; set; }
        public string api_gekentekende_voertuigen_assen { get; set; }
        public string api_gekentekende_voertuigen_brandstof { get; set; }
        public string api_gekentekende_voertuigen_carrosserie { get; set; }
        public string api_gekentekende_voertuigen_carrosserie_specifiek { get; set; }
        public string api_gekentekende_voertuigen_voertuigklasse { get; set; }
        public int breedte { get; set; }
        public int bruto_bpm { get; set; }
        public int catalogusprijs { get; set; }
        public int cilinderinhoud { get; set; }
        public string datum_eerste_afgifte_nederland { get; set; }
        public string datum_eerste_toelating { get; set; }
        public string datum_tenaamstelling { get; set; }
        public string eerste_kleur { get; set; }
        public string europese_voertuigcategorie { get; set; }
        public string export_indicator { get; set; }
        public string handelsbenaming { get; set; }
        public string inrichting { get; set; }
        public string kenteken { get; set; }
        public int lengte { get; set; }
        public int massa_ledig_voertuig { get; set; }
        public int massa_rijklaar { get; set; }
        public int maximum_massa_trekken_ongeremd { get; set; }
        public int maximum_trekken_massa_geremd { get; set; }
        public string merk { get; set; }
        public string openstaande_terugroepactie_indicator { get; set; }
        public string plaats_chassisnummer { get; set; }
        public string retrofit_roetfilter { get; set; }
        public int technische_max_massa_voertuig { get; set; }
        public int toegestane_maximum_massa_voertuig { get; set; }
        public string tweede_kleur { get; set; }
        public string typegoedkeuringsnummer { get; set; }
        public string uitvoering { get; set; }
        public string variant { get; set; }
        public double vermogen_massarijklaar { get; set; }
        public string vervaldatum_apk { get; set; }
        public string voertuigsoort { get; set; }
        public int volgnummer_wijziging_eu_typegoedkeuring { get; set; }
        public string wacht_op_keuren { get; set; }
        public string wam_verzekerd { get; set; }
        public int wielbasis { get; set; }
        public string zuinigheidslabel { get; set; }
    }
}
#pragma warning restore IDE1006 // Naming Styles
