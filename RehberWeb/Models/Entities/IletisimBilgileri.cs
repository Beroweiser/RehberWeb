﻿namespace RehberWeb.Models.Entities
{
    public class IletisimBilgileri
    {
        public int Id { get; set; }
        public string TelefonNumarasi { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public string Konum { get; set; }
        public int RehberId { get; set; }
    }
}
