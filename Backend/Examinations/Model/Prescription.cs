// File:    Prescription.cs
// Author:  Vlajkov
// Created: Tuesday, April 07, 2020 12:22:01 AM
// Purpose: Definition of Class Prescription

using System;
using System.Collections.Generic;
using Backend.Examinations.Model.Enums;
using Backend.Utils;
using Backend.Medications.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Examinations.Model
{
   public class Prescription : Treatment
    {
        private const int RESERVATION_DAYS = 10;
        public bool Reserved { get; set; }
        [NotMapped]
        public Period ReservationPeriod { get; set; }
        public int HourlyIntake { get; set; }
        [ForeignKey("Medication")]
        public int MedicationId { get; set; }
        public virtual Medication Medication { get; set; }

        public Prescription() : base(TreatmentType.Prescription)
        {
            Date = DateTime.Today;
        }

        public Prescription(DateTime dateOfPrescription, bool reserved, int hourlyIntake, string additionalNotes, Medication medication)
            : base(dateOfPrescription, additionalNotes, TreatmentType.Prescription)
        {
            Reserved = reserved;
            if (Reserved)
            {
                ReservationPeriod = new Period(DateTime.Today, DateTime.Today.AddDays(RESERVATION_DAYS));
            }
            HourlyIntake = hourlyIntake;
            Medication = medication;
        }

        public Prescription(int id) : base(id) { }


        public void InitializeReservationDates()
        {
            if (Reserved) 
                ReservationPeriod = new Period(DateTime.Today, DateTime.Today.AddDays(RESERVATION_DAYS));
        }

        public bool IsStillActive(DateTime startDate, DateTime endDate)
        {
            return Date.CompareTo(startDate) > 0 &&
                   Date.CompareTo(endDate) < 0;
        }
    }
}