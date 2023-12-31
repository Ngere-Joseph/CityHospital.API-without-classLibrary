﻿namespace CityInfo.API.Data.DTOs
{
    public class HospitalDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? HospitalType { get; set; }

        public IEnumerable<DoctorDTO> Doctors { get; set; }
            = new List<DoctorDTO>();
    }
}
