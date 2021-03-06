﻿namespace WheresMyCar.CarService.Model
{
    public class CarCreatedPayload
    {
        public string Name { get; private set; }
        public string LicenseNumber { get; private set; }

        public CarCreatedPayload(string name, string licenseNumber)
        {
            this.Name = name;
            this.LicenseNumber = licenseNumber;
        }
    }
}