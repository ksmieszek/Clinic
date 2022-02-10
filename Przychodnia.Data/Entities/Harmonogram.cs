using System;

namespace Przychodnia.Data.Entities
{
    public class Harmonogram
    {
        public int Id { get; set; }
        public DateTime DatoGodzina { get; set; }
        public Uzytkownik Lekarz { get; set; }
        public bool Aktywny { get; set; } = true;
    }
}
