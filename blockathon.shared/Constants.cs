using System;

namespace blockathon.shared
{
    public class Constants
    {
        public const string RDWWebApi = "https://opendata.rdw.nl/resource/m9d7-ebf2.json";

        /*
         * Cloud API Credentials:
            Publishable Key
            pk_b3df95925ac01743f882ab5a
            Secret Key
            sk_adf2ba316752f4eaf9c8151b
        */
        public const string OpenALPR = "https://api.openalpr.com/v2/recognize_url?recognize_vehicle=1&country=eu&secret_key=sk_adf2ba316752f4eaf9c8151b";
        public const string ALPRSecretKey = "sk_adf2ba316752f4eaf9c8151b";
    }
}
