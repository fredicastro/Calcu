using Calcu.Features.Intentos.Dto;
using Calcu.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Calcu.Features.Intentos
{
    public class GuardarIntentosCommandHandler : IRequestHandler<GuardarIntentosCommand, List<IntentosCalculo>>
    {
        private readonly FmcDbContext _dbContext;
        public GuardarIntentosCommandHandler(FmcDbContext dbContext) 
        {
        _dbContext = dbContext;
        }                   
        //public async Task<int> Handle(GuardarIntentosCommand request, CancellationToken cancellationToken)
        public async Task<List<IntentosCalculo>> Handle(GuardarIntentosCommand request, CancellationToken cancellationToken)
        {
            try
            {
                double doubleRate = (double)request.IntentosCalculoRate/100;
                double doubleAmount = (double)request.IntentosCalculoAmount;
                double PagoMensual, Monto, TasaMensual;
                int Plazo = request.IntentosCalculoDuration ;
                TasaMensual = (double)request.IntentosCalculoRate / 1200;

                PagoMensual = doubleAmount * TasaMensual / (1 - Math.Pow(1 + TasaMensual, -Plazo ));
                var Intento = new IntentosCalculo
                {
                    IntentosCalculoAmount = request.IntentosCalculoAmount,
                    //tasa anual
                    IntentosCalculoRate = request.IntentosCalculoRate,
                    IntentosCalculoDuration = request.IntentosCalculoDuration,
                    IntentosCalculoTotal = (decimal)PagoMensual
                };
                _dbContext.IntentosCalculo.Add(Intento);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return _dbContext.IntentosCalculo.Where(a => a.IntentosCalculoId == Intento.IntentosCalculoId).ToList();


            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

         }
    }
}
