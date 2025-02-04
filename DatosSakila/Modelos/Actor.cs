﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatosSakila.Modelos
{
    [Table("actor")]
    [Index(nameof(LastName), Name = "idx_actor_last_name")]
    public partial class Actor
    {
    /*
        public Actor(string firstName, string lastName)
        {
                FirstName = firstName;
                LastName = lastName;
        }*/

        [Key]
        [Column("actor_id")]
        public ushort ActorId { get; set; }

        [Column("first_name")]
        [StringLength(45)]
        public string FirstName { get; set; } = null!;

        [Column("last_name")]
        [StringLength(45)]
        public string LastName { get; set; } = null!;

        [Column("last_update", TypeName = "timestamp")]
        public DateTime LastUpdate { get; set; }

        public string NombreCompleto { get 
            {
                string salida = $"{LastName}, {FirstName}";

                return salida;
            } 
        }
    }
}
