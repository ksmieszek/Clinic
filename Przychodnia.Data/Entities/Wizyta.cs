namespace Przychodnia.Data.Entities
{
    public class Wizyta
    {
        public int Id { get; set; }
        public Harmonogram Harmonogram { get; set; }
        public Uzytkownik Pacjent { get; set; }
        public bool CzyZrealizowana { get; set; }
        public bool CzyAktywna { get; set; } = true;
    }
}
