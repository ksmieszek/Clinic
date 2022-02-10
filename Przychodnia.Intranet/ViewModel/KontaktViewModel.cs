using Przychodnia.Data.Entities;
using Przychodnia.Data.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia.Intranet.ViewModel
{
    public class KontaktViewModel
    {
        public List<Uzytkownik> uzytkownicy { get; set; }
        public List<Adres> adresy { get; set; }
        //public List<Rola> role { get; set; }
        //public List<Poradnia> poradnie { get; set; }

        //public Uzytkownik nowyUzytkownik { get; set; }
        //public Adres nowyAdres { get; set; }

        public int Id { get; set; }
        public int? UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }
        public int? AdresId { get; set; }
        public Adres Adres { get; set; }
        [RegularExpression(@"^\+48\(?([0-9]{9})$", ErrorMessage = "Nieprawidłowy numer telefonu (pamietaj o dodaniu numeru kierunkowego)")]
        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        public string Telefon { get; set; }
        [EmailAddress(ErrorMessage ="Adres Email jest nieprawidłowy")]
        public string Email { get; set; }
        public string Opis { get; set; }
        public bool Aktywny { get; set; }
        [PriorityAttribute]
        public int? PozycjaWyswietlania { get; set; }

        //Modal view uzytkownik
        //public int? NowaRolaId { get; set; }
        //public int? NowaPoradnieId { get; set; }
        //public string NowyEmail { get; set; }
        //public string NoweHaslo { get; set; }
        //public string NoweImie { get; set; }
        //public string NoweNazwisko { get; set; }
        //[PeselValidator]
        //public string NowyPesel { get; set; }

        //Modal view adres
        //public string Miejscowosc { get; set; }
        //[ZIPCodeValidator]
        //public string KodPocztowy { get; set; }
        //public string Ulica { get; set; }
        //public string NumerDomu { get; set; }
        //public string NumerMieszkania { get; set; }

        public KontaktViewModel()
        {

        }

        //public KontaktViewModel(List<Uzytkownik> uzytkownicy, List<Adres> adresy, List<Rola> role, List<Poradnia> poradnie, Uzytkownik nowyUzytkownik, int id, int? uzytkownikId, Uzytkownik uzytkownik, int? adresId, Adres adres, string telefon, string email, string opis, bool aktywny, int? pozycjaWyswietlania, int? nowaRolaId, int? nowaPoradnieId, string nowyEmail, string noweHaslo, string noweImie, string noweNazwisko, string nowyPesel, string miejscowosc, string kodPocztowy, string ulica, string numerDomu, string numerMieszkania) : this(uzytkownicy, adresy, role, poradnie)
        //{
        //    this.nowyUzytkownik = nowyUzytkownik;
        //    Id = id;
        //    UzytkownikId = uzytkownikId;
        //    Uzytkownik = uzytkownik;
        //    AdresId = adresId;
        //    Adres = adres;
        //    Telefon = telefon;
        //    Email = email;
        //    Opis = opis;
        //    Aktywny = aktywny;
        //    PozycjaWyswietlania = pozycjaWyswietlania;
        //    NowaRolaId = nowaRolaId;
        //    NowaPoradnieId = nowaPoradnieId;
        //    NowyEmail = nowyEmail;
        //    NoweHaslo = noweHaslo;
        //    NoweImie = noweImie;
        //    NoweNazwisko = noweNazwisko;
        //    NowyPesel = nowyPesel;
        //    Miejscowosc = miejscowosc;
        //    KodPocztowy = kodPocztowy;
        //    Ulica = ulica;
        //    NumerDomu = numerDomu;
        //    NumerMieszkania = numerMieszkania;
        //}

        //public KontaktViewModel(List<Uzytkownik> uzytkownicy, List<Adres> adresy, List<Rola> role, List<Poradnia> poradnie, Kontakt kontakt)
        //{
        //    this.uzytkownicy = uzytkownicy;
        //    this.adresy = adresy;
        //    this.role = role;
        //    this.poradnie = poradnie;
        //    this.Id = kontakt.Id;
        //    this.UzytkownikId = kontakt.UzytkownikId;
        //    this.Uzytkownik = kontakt.Uzytkownik;
        //    this.AdresId = kontakt.AdresId;
        //    this.Adres = kontakt.Adres;
        //    this.Telefon = kontakt.Telefon;
        //    this.Email = kontakt.Email;
        //    this.Opis = kontakt.Opis;
        //    this.Aktywny = kontakt.Aktywny;
        //    this.PozycjaWyswietlania = kontakt.PozycjaWyswietlania;
        //}

        //public KontaktViewModel(List<Uzytkownik> uzytkownicy, List<Adres> adresy, List<Rola> role, List<Poradnia> poradnie)
        //{
        //    this.uzytkownicy = uzytkownicy;
        //    this.adresy = adresy;
        //    this.role = role;
        //    this.poradnie = poradnie;
        //}

        public KontaktViewModel(List<Uzytkownik> uzytkownicy, List<Adres> adresy)
        {
            this.uzytkownicy = uzytkownicy;
            this.adresy = adresy;
        }

        public KontaktViewModel(List<Uzytkownik> uzytkownicy, List<Adres> adresy, int id, int? uzytkownikId, Uzytkownik uzytkownik, int? adresId, Adres adres, string telefon, string email, string opis, bool aktywny, int? pozycjaWyswietlania)
        {
            this.uzytkownicy = uzytkownicy;
            this.adresy = adresy;
            Id = id;
            UzytkownikId = uzytkownikId;
            Uzytkownik = uzytkownik;
            AdresId = adresId;
            Adres = adres;
            Telefon = telefon;
            Email = email;
            Opis = opis;
            Aktywny = aktywny;
            PozycjaWyswietlania = pozycjaWyswietlania;
        }
    }
}
