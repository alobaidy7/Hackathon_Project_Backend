using Hackathon_Project_Backend.Data;
using Hackathon_Project_Backend.DTOs;
using Hackathon_Project_Backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_Project_Backend.Controllers
{
    [Route("/api")]
    [ApiController]
   // [EnableCors("CorsPolicy")]
    public class ReadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReadController(ApplicationDbContext context)
        {
            _context = context;
        }

        

        [HttpGet]
        [Route("[Controller]/[Action]")]
        public IActionResult GetAllReads()
        {

            var AllReads = _context.Reads.ToList();

            if (AllReads == null)
                return NotFound("not found any reads");

            return Ok(AllReads);
        }



        // Get Reads By City
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public IActionResult GetReadsByCityId(int? cityId)
        {

            var AllReads = _context.Reads.Where(r=>r.CityId == cityId).ToList();

            if (AllReads == null)
                return NotFound("not found any reads");

            return Ok(AllReads);
        }



     




        //  storing read
        [HttpPost]
        [Route("[Controller]/[Action]")]
        public IActionResult StoreRead(ReadDTO readDTO)
        {


            var NewRead = new Read();
            if (readDTO == null)
                return BadRequest("Something is wrong");

            NewRead.GazPercentage = readDTO.GazPercentage;
            NewRead.TempDeg = readDTO.TempDeg;
            NewRead.DCM = readDTO.DCM;
            NewRead.UpdateTime = DateTime.Now;

            NewRead.Quality = NewRead.DCM * NewRead.TempDeg; // formula
            NewRead.CityId = readDTO.CityId;
            

            _context.Reads.Add(NewRead);
            _context.SaveChanges();
            return Ok(NewRead);
        }





        [HttpPut]
        [Route("[Controller]/[Action]")]
        public IActionResult UpdateRead(int id, ReadDTO readDTO)
        {
            var existingRead = _context.Reads.FirstOrDefault(r => r.Id == id);
            if (existingRead == null)
            {
                return NotFound();
            }

          
            existingRead.GazPercentage = readDTO.GazPercentage;
            existingRead.TempDeg = readDTO.TempDeg;
            existingRead.DCM = readDTO.DCM;
            existingRead.UpdateTime = DateTime.Now;
            existingRead.Quality = existingRead.DCM * existingRead.TempDeg;
            existingRead.CityId = readDTO.CityId;

            _context.Reads.Update(existingRead);
            _context.SaveChanges();

            return Ok(existingRead);
        }



        [HttpDelete]
        [Route("[Controller]/[Action]")]
        public IActionResult DeleteRead(int id)
        {
            var existingRead = _context.Reads.FirstOrDefault(r => r.Id == id);
            if (existingRead == null)
            {
                return NotFound();
            }

            _context.Reads.Remove(existingRead);
            _context.SaveChanges();

            return Ok(true);
        }






        //[HttpGet]
        //[Route("[Controller]/[Action]")]
        //public IActionResult GetYearById(int? id)
        //{
        //    if (id == null)
        //        return BadRequest();
        //    var Year = _context.Years.FirstOrDefault(x => x.Id == id);

        //    if (Year == null)
        //        return NotFound("not found!");

        //    return Ok(Year);
        //}



        //[HttpPut]
        //[Route("[Controller]/[Action]")]
        //public IActionResult PutYear(int id,YearDTO yearDTO)
        //{
        //    var ExsistYear = _context.Years.FirstOrDefault(x=>x.Id == id);
        //    if (ExsistYear == null)
        //        return NotFound();
        //    ExsistYear.StartTime= yearDTO.StartTime;
        //    ExsistYear.EndTime= yearDTO.EndTime;
        //    ExsistYear.NameYear = yearDTO.NameYear;

        //    _context.Years.Update(ExsistYear);
        //    _context.SaveChanges();

        //    return Ok(ExsistYear);
        //}

        //[HttpDelete]
        //[Route("[Controller]/[Action]")]
        //public IActionResult DeleteYear(int id)
        //{
        //    var ExsistYear = _context.Years.FirstOrDefault(x => x.Id == id);
        //    if (ExsistYear == null)
        //        return NotFound();
        //    _context.Years.Remove(ExsistYear);
        //    _context.SaveChanges();
        //    return Ok(true);
        //}
    }
}
