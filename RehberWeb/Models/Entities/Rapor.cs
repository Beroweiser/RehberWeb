namespace RehberWeb.Models.Entities
{
    public class Rapor
    {
        public int Id { get; set; }
        public string Raporun_Talep_Edildiği_Tarih { get; set; }
        public string Raporun_Durumu { get; set; }
        public ICollection<RaporData> Data { get; set; }
    }
}
