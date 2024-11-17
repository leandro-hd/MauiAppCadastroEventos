namespace MauiAppCadastroEventos.Models
{
    public class Hospedagem
    {
        public string NomeEvento { get; set; }
        public string LocalEvento { get; set; }
        public double CustoEvento { get; set; }
        public int QntParticipantes { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }
        public int Estadia
        {
            get => DataCheckOut.Subtract(DataCheckIn).Days;
        }
        public double ValorTotal
        {
            get
            {
                double total = QntParticipantes * CustoEvento;

                return total;
            }
        }
    }
}