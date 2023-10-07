using CityInfo.API.Contracts;
using CityInfo.API.Data.DTOs;
using CityInfo.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/hospitals/{hospitalId}/doctors")]
    public class DoctorController : Controller
    {
       private readonly IRepositoryManager _repository;

        public DoctorController(IRepositoryManager repository)
        {
            _repository = repository ?? 
                throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            var doctors = _repository.Doctor.FindAll(trackChanges: true);

            var payload = new List<DoctorDTO>();
            foreach (var doctor in doctors)
            {
                payload.Add(new DoctorDTO
                {
                    Name = doctor.FName + doctor.LName,
                    Specialization = doctor.Specialization,
                    YearsExperience = doctor.YearsExperience

                }) ;
            }

            return Ok(payload);

        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<DoctorDTO>> GetDoctor(int hospitalId)
        {
            var hospital = _repository.Hospital.FindByCondition(h => h.Id == hospitalId, trackChanges: true)
                                            .Include(h => h.Doctors)
                                            .FirstOrDefault();

            if (hospital == null)
            {
                return NotFound(); // Handle the case if the hospital doesn't exist
            }

            var payload = hospital.Doctors.Select(doctor => new DoctorDTO
            {
                Online = doctor.Online,
                Name = doctor.FName + " " + doctor.LName,
                YearsExperience = doctor.YearsExperience,
                Specialization = doctor.Specialization,
                HospitalOfPrimatyAssighnment = new HospitalDto
                {
                    Id = hospital.Id,
                    Name = hospital.Name,
                    HospitalType = hospital.HospitalType,
                }
            }).ToList();

            return Ok(payload);
        }

        ////Get all doctors from a city
        //[HttpGet]
        //public ActionResult FetchDoctors( int cityId)
        //{
        //    var city = _repository.City.GetById(cityId);

        //    if(city == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(city);

        //}
        //1. Fetch a single city

        //2. Fetch all hospitals in that city
        //3. Fetch all doctors in the fetched hospitals

    }
}
