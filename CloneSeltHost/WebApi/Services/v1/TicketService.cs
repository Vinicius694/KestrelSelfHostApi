using ICA.Ng.Carpark.WebApi.Domains;
using ICA.Ng.Carpark.WebApi.Services.v1.Interfaces;

namespace ICA.Ng.Carpark.WebApi.Services.v1
{
    public class TicketService : ITicketService
    {
        public Ticket GetById(int id) 
        {
            Ticket ticket = new Ticket();

            ticket.Id = "1";
            ticket.Description = "First Ticket";
            ticket.CreationDate = DateTime.Today;

            return ticket;
        }
        public int CreateTicket()
        {
            throw new NotImplementedException();
        }

        public int DeleteTicket(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTicket(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetAllTickets()
        {
            return GetAllTicketsDummy();
        }

       public List<Ticket> GetAllTicketsDummy()
        {
            //dummy data (look database access)

            List<Ticket> list = new List<Ticket>();

            Ticket t1 = new Ticket();
            t1.Id = "1";
            t1.Description = "First Ticket";
            t1.CreationDate = DateTime.Today;
            list.Add(t1);

            Ticket t2 = new Ticket();
            t2.Id = "2";
            t2.Description = "Second Ticket";
            t2.CreationDate = DateTime.Now;
            list.Add(t2);

            Ticket t3 = new Ticket();
            t3.Id = "3";
            t3.Description = "Third Ticket";
            t3.CreationDate = DateTime.Today;
            list.Add(t3);

            return list;
        }
    }
}
