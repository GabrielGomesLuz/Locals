using Locals.Models;

namespace Locals.Repositories.Interfaces
{

//metodo para criar um interesse de reserva e posterior uma pagina de detalhes
    public interface IReservaRepository
    {

        void CriarReserva(ReservaInteresse Reserva);


    }
}
