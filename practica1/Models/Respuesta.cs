﻿using System;

namespace practica1.Models
{
    public class Respuesta
    {
        public long Codigo { get; set; }
        public string Mensaje { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
    }
}