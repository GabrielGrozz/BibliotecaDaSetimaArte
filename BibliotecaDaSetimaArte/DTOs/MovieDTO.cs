﻿namespace BibliotecaDaSetimaArte.DTOs
{
    public class MovieDTO
    {
        public int MovieId { get; set; }

        public string? Name { get; set; }

        public string? Synopsis { get; set; }

        public int? ReleaseDate { get; set; }

        public string? ImageURL { get; set; }
    }
}
