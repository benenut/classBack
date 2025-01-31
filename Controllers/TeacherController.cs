using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("teachers")]

    public class TeacherController : Controller
    {
        public readonly TeacherRepository _teacherRepository;

        public TeacherController(TeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public ActionResult<ICollection<Teacher>> GetTeachers()
        {
            return Ok(_teacherRepository.GetTeachers());
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateTeacher(TeacherCreateDTO teacher)
        {
            _teacherRepository.CreateTeacher(teacher);
            return Ok();
        }



        [HttpPut]
        [Route("update/{teacherId}")]
        public ActionResult UpdateTeacher(TeacherUpdateDTO teacher, [FromRoute] int teacherId)
        {
            _teacherRepository.UpdateTeacher(teacher, teacherId);
            return Ok();
        }
    }
}
