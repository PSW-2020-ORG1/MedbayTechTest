// File:    VaccinesController.cs
// Author:  Vlajkov
// Created: Wednesday, May 20, 2020 2:50:31 AM
// Purpose: Definition of Class VaccinesController

using Backend.Records.Model;
using Backend.Records.Model.Enums;
using Service.MedicalRecordService;
using System;
using System.Collections.Generic;

namespace Backend.Examinations.Controller.MedicalRecordController
{
   public class VaccinesController
   {
        public VaccinesController(VaccinesService vaccinesService)
        {
            this.vaccinesService = vaccinesService;
        }

        public IEnumerable<Vaccines> GetAllVaccines() => 
            vaccinesService.GetAllVaccines();

        public Vaccines CreateVaccine(Vaccines vaccine) => 
            vaccinesService.CreateVaccine(vaccine);

        public VaccinesService vaccinesService;
   
   }
}