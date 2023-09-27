using Calcu.Models;
using MediatR;

namespace Calcu.Features.Intentos.Dto
{
    //public class GuardarIntentosCommand : IRequest<List>
    public class GuardarIntentosCommand : IRequest<List<IntentosCalculo>>
    {
        public decimal IntentosCalculoAmount { get; set; }
        public decimal IntentosCalculoRate { get; set; }
        public int IntentosCalculoDuration { get; set; }
        //public decimal IntentosCalculoTotal { get; set; }
    }
}
