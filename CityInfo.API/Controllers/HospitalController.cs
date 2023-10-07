using CityInfo.API.Contracts;
using CityInfo.API.Data.DTOs;
using CityInfo.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/hospitals")]
    public class HospitalController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public HospitalController(IRepositoryManager repository)
        {
            _repositoryManager = repository 
                ?? throw new ArgumentNullException(nameof(repository));
        }


        [HttpGet]
        public ActionResult <IEnumerable<HospitalDto>> GetHospital(int cityId)
        {
            if (!_repositoryManager.Hospital.CityExist(cityId))
            {
                return NotFound();
            }

            var hospitalPerCity = _repositoryManager.Hospital.GetAllHospitalPerCity(cityId);

            var hospitals = hospitalPerCity.Select(hospital => new HospitalDto
            {
                Name = hospital.Name,
                HospitalType = hospital.HospitalType,
                Id = hospital.Id,
                
            });

            return Ok(hospitals);
        }

        [HttpGet("doctor")]
        public ActionResult<IEnumerable<HospitalDto>> GetHospitalDoctors(int cityId)
        {
            if (!_repositoryManager.Hospital.CityExist(cityId))
            {
                return NotFound();
            }

            var hospitalPerCity = _repositoryManager.Hospital.GetAllHospitalPerCity(cityId);

            var hospitals = hospitalPerCity.Select(hospital => new HospitalDto
            {
                Name = hospital.Name,
                HospitalType = hospital.HospitalType,
                Id = hospital.Id,

                Doctors = hospital.Doctors.Select(doctor => new DoctorDTO 
                {
                    Name = doctor.FName + "" + doctor.LName,
                    Specialization = doctor.Specialization,
                    YearsExperience = doctor.YearsExperience,
                    Online = doctor.Online,
                })

            });

            return Ok(hospitals);
        }


        [HttpGet("{id}")]
        public ActionResult GetHospitalbyId(int id, int cityId)
        {
            if (!_repositoryManager.Hospital.CityExist(cityId))
            {
                return NotFound();
            }

            var singleHospital = _repositoryManager.Hospital.GetSingleHospitalPerCity(cityId, id);

            if (singleHospital == null)
            {
                return NotFound();
            }

            var hospital = new HospitalDto
            {
                Name = singleHospital.Name,
                HospitalType = singleHospital.HospitalType,
                Id = singleHospital.Id,
            };

            return Ok(hospital);
        }
        
    }
}
