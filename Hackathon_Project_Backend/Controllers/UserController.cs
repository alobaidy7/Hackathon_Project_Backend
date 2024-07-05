using Hackathon_Project_Backend.Data;
using Hackathon_Project_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon_Project_Backend.Controllers
{
    [Route("/api")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        //[HttpPost]
        //[Route("[Controller]/[Action]")]
        //public IActionResult AddYear(YearDTO yearDTO)
        //{
        //    var NewYear = new Year();
        //    if (yearDTO == null)
        //        return BadRequest("Something is wrong");

        //    NewYear.StartTime = yearDTO.StartTime;
        //    NewYear.EndTime = yearDTO.EndTime;
        //    NewYear.NameYear = yearDTO.NameYear;
        //    _context.Years.Add(NewYear);
        //    _context.SaveChanges();
        //    return Ok(NewYear);
        //}


        [HttpGet]
        [Route("[Controller]/[Action]")]
        public IActionResult GetAllUsers()
        {

            var AllUsers = _context.Users.ToList();

            if (AllUsers == null)
                return NotFound("not found any Data");

            return Ok(AllUsers);
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
