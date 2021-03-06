// File:    Specialization.cs
// Author:  Vlajkov
// Created: Thursday, April 16, 2020 8:27:27 PM
// Purpose: Definition of Class Specialization

using Backend.General.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Users
{
    public class Specialization : IIdentifiable<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SpecializationName { get; set; }

        public Specialization(int id, string name)
        {
            Id = id;
            SpecializationName = name;
        }

        public Specialization()
        {

        }
        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
    
}