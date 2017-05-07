using System;
using System.Collections.Generic;

namespace CarService.Model
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public CarStatus Status { get; set; }
        public Location Location { get; set; }
        public Guid CurrentDriverId { get; internal set; }
    }

    public enum CarStatus
    {
        Default = 0,
        Parked = 1,
        Moving = 2
    }
}