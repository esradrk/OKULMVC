namespace OKULMVC.Models
{
    public class DersOgrenci
    {
        public int DersOgrenciid { get; set; }
        public int Ogrenciid { get; set; }
        public int Dersid { get; set; }

        public Ogrenci Student { get; set; }
        public Ders Course { get; set; }
    }
}
