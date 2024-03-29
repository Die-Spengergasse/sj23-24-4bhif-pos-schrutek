using Spg.AloMalo.DomainModel.Model;

namespace Spg.AloMalo.DomainModel.Test.Helpers 
{ 
    public static class DatabaseUtilities
    {
        public static List<Photographer> GetSeedingPhotographers()
        {
            return new List<Photographer>()
            {
                new Photographer(
                    "Martin",
                    "Schrutek",
                    new Address("Photo Street 1", "1234", "Photoville", "Photanien"){ State= new() { Name = "N�" } }, //, new State("N�")
                    new PhoneNumber(43, 1234, "123456789"),
                    new PhoneNumber(43, 1234, "123456789"),
                    new List<EMail>() { new EMail("schrutek@spengergasse.at"), new EMail("schrutek2@spengergasse.at") },
                    new EMail("schrutek@spengergasse.at")
                )
            };
        }
    } 
}
