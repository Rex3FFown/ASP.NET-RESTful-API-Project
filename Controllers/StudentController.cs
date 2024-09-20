// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using efcoreRestFull.Context;
// using efcoreRestFull.Entities;
// using Microsoft.AspNetCore.Cors;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace efcoreRestFull.Controllers
// {
//     [ApiController]
//     [Route("student")]
//     [EnableCors("AllowSpecificOrigin")]
//     public class StudentController : Controller
//     {
//         private readonly DataContext _context;

//         public StudentController(DataContext context)
//         {
//             _context = context;
//         }
//         [HttpGet]
//         public async Task<IActionResult> GetAllStudent()
//         {
//             var students = await _context.Students.ToListAsync();
//             return Ok(students);
//         }

//         [HttpPost]
//         public async Task<IActionResult> AddNewStudent([FromBody] Student student)
//         {
//             if (student == null)
//             {
//                 return BadRequest("Null");
//             }

//             _context.Students.Add(student);
//             await _context.SaveChangesAsync();
//             return Ok(student);
//         }

//         [HttpPut]
//         public async Task<IActionResult> UpdateStudent([FromBody] Student student)
//         {
//             if (student == null)
//             {
//                 return BadRequest("Null");
//             }
//             _context.Students.Update(student);
//             _context.SaveChangesAsync();
//             return Ok(student);
//         }

//         [HttpDelete("{id}")]
//         public void DeleteStudent([FromRoute] int id)
//         {
//             var student = _context.Students.Find(id);
//             if (student != null)
//             {
//                 _context.Students.Remove(student);
//             }
//             _context.SaveChanges();
//         }

//     }
// }