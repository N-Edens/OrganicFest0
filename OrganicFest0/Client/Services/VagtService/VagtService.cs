using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bambus.Shared;

namespace OrganicFest0.Client.Services.VagtService
{
    public class VagtService : IVagtService
    {
        private List<Vagt> vagter = new List<Vagt>(); // Dette er blot et eksempel. Du skal muligvis bruge en database eller anden datalager.

        HttpClient http;

        public VagtService() {
            http = new HttpClient();
        }


        public async Task<IEnumerable<Vagt>> GetAllVagts()
        {
            // Implementer logik for at hente alle vagter (f.eks. fra en database)
            return await Task.FromResult(vagter);
        }

        public async Task AddVagt(Vagt vagt)
        {
            // Implementer logik for at tilføje en vagt (f.eks. til en database)
            vagter.Add(vagt);
            await Task.CompletedTask;
        }

        public List<Vagt> GetVagts()
        {
            // Returnér alle vagter (kan være synkront, da vi arbejder med en liste i hukommelsen)
            return vagter;
        }
    }
}
