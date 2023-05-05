using ICA.Ng.Carpark.WebApi.Domains;

namespace ICA.Ng.Carpark.WebApi.Services.v1.Interfaces
{
    public interface ITicketService
    {
        public int CreateTicket();
        public List<Ticket> GetAllTickets();
        public Ticket GetById(int id);
        public void UpdateTicket(int id);
        public int DeleteTicket(int id);
        public List<Ticket> GetAllTicketsDummy();
    }
}
