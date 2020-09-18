﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EServer.Dtos
{
    public class MotorcycleDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Serialnumber { get; set; }
    }
}
