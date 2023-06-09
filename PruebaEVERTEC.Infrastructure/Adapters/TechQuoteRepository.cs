﻿
using PruebaEVERTEC.Application.Ports.Output.Repositories;
using PruebaEVERTEC.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaEVERTEC.Infrastructure.Adapters
{
    public class TechQuoteRepository : ITechQuoteRepository
    {

        private readonly List<string> _techQuotes = new List<string>
        {
            "“De vez en cuando, una nueva tecnología, un antiguo problema y una gran idea se convierten en una innovación”.",
            "“Las grandes oportunidades nacen de haber sabido aprovechar las pequeñas”.",
            "“Si decides hacer solo las cosas que sabes que van a funcionar, dejarás un montón de oportunidades encima de la mesa”.",
            "“La conectividad es un derecho humano”.",
            "“El mundo se puede cambiar en 140 caracteres”.",
            "“La tecnología no es nada. Lo importante es que tengas fe en la gente, que sean básicamente buenas e inteligentes, y si les das herramientas, harán cosas maravillosas con ellas”.",
            "“La ciencia de hoy es la tecnología del mañana”.",
            "“Incluso cuando te tomas unas vacaciones de la tecnología, la tecnología no se toma un descanso de ti”.",
            "“El verdadero peligro no es que las computadoras comenzaran a pensar como los hombres, sino que los hombres comenzaran a pensar como las computadoras”.",
            "“La tecnología es una palabra que describe algo que no funciona todavía”.",
            "Cualquier tecnología suficientemente avanzada es equivalente a la magia.",
            "Todos los grandes inventos tecnológicos creados por el hombre – el avión, el automóvil, el ordenador – dicen poco acerca de su inteligencia, pero dicen mucho de su pereza.",
            "Que algo no haya salido como hayas querido no significa que sea inútil.",
            "Se ha vuelto terriblemente obvio que nuestra tecnología ha superado nuestra humanidad.",
            "Una máquina puede hacer el trabajo de cincuenta hombres ordinarios. Ninguna máquina puede hacer el trabajo de un hombre extraordinario.",
            "La tecnología es una palabra que describe algo que no funciona todavía.",
            "La humanidad es alcanzar la tecnología adecuada para las razones equivocadas.",
            "Creo que las novelas que dejan de lado la tecnología malinterpretan la vida tan mal como los victorianos tergiversaron la vida, dejando fuera el sexo."
        };

        public Task<List<TechQuote>> FindAll()
        {
            List<TechQuote> result = _techQuotes
                .Select((quote, index) => MapFromString(index + 1, quote))
                .ToList();

            return Task.FromResult(result);
        }

        private TechQuote MapFromString(long id, string str)
        {
            return new TechQuote { Id = id, Quote = str };
        }
    }
}
