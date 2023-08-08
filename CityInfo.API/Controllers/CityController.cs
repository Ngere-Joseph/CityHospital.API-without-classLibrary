using CityInfo.API;
using CityInfo.API.Contracts;
using CityInfo.API.Data.DTOs;
using CityInfo.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CityController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public CityController(IRepositoryManager repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> FindAllCities()    
        {
           var cities = _repository.City.FindAll(trackChanges: true).Include(c => c.Hospitals).ToList();

            var payload = new List<CityDto>();
            foreach (var city in cities)
            {
                payload.Add(new CityDto
                {
                    Id = city.Id,
                    Description = city.Description,
                    Name = city.Name,
                    
                    Hospitals = city.Hospitals.Select(hospital => new HospitalDto
                    {
                        Id = hospital.Id,
                        Name = hospital.Name,
                        HospitalType = hospital.HospitalType,
                    }).ToList()
                }) ;                        
            }
            return Ok(payload);
        }

        [HttpGet("{id}")]
        public ActionResult FindCity(int id) 
        {
            var city = _repository.City.GetById(id);

            if(city == null)
            {
                return NotFound();
            }

            return Ok(new CityDto 
            { Id = city.Id, 
              Description = city.Description,
              Name = city.Name,            
            });
        }

        [HttpPost]
        public ActionResult CreateCity([FromBody] City city)
        {
            //Create parent model
            _repository.City.Create(city);

            //associate childModel with parent Model
            if (city.Hospitals != null && city.Hospitals.Any())
            {
                foreach (var hospital in city.Hospitals)
                {
                    var existingHospital = _repository.Hospital.FindByCondition
                        (c => c.Id == hospital.Id, trackChanges: false).FirstOrDefault();
                    if (existingHospital != null)
                    {
                        //if above condition is true, remove the hospital and replace with existingHospital to avoid tracking issues

                        city.Hospitals.Remove(hospital);
                        city.Hospitals.Add(existingHospital);

                        //Set the correct CityId for the existingHospital
                        existingHospital.CityId = city.Id;
                    }
                    else
                    {
                        //Set the correct CityId for the new hospital
                        hospital.CityId = city.Id;
                        _repository.Hospital.Create(hospital);
                    }
                }

            }
            _repository.Save();

            return CreatedAtAction(nameof(CreateCity), new { id = city.Id }, city);
        }
    }
}
