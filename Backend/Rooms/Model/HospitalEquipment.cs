/***********************************************************************
 * Module:  HospitalEquipment.cs
 * Author:  ThinkPad
 * Purpose: Definition of the Class HealthCorporation.2Manager.HospitalEquipment
 ***********************************************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.General.Model;

namespace Model.Rooms
{
    public class HospitalEquipment : IIdentifiable<int>
    {
        [Key]
        public int Id { get; set; }
        public int QuantityInRoom { get;  set; }
        public int QuantityInStorage { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get;  set; }
        public virtual Room Room { get;  set; }
        [ForeignKey("EquipmentType")]
        public int EquipmentTypeId { get;  set; }
        public virtual EquipmentType EquipmentType { get;  set; }

        public HospitalEquipment (int id, int quantityInRoom, int quantityinStorage, Room room, EquipmentType et)
        {
            QuantityInRoom = quantityInRoom;
            QuantityInStorage = quantityinStorage;
            Room = room;
            RoomId = Room.Id;
            EquipmentType = et;
            EquipmentTypeId = et.Id;
        }

        public HospitalEquipment ()
        {
        }

        public int GetId ()
        {
            return Id;
        }

        public void SetId (int id)
        {
            this.Id = id;
        }
    }
}