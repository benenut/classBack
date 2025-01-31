using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("subjects")]

    public class SubjectController : Controller
    {
        public readonly SubjectRepository _subjectRepository;

        public SubjectController(SubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        [HttpGet]
        public ActionResult<ICollection<Subject>> GetSubjects()
        {
            return Ok(_subjectRepository.GetSubjects());
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateSubject(SubjectCreateDTO subject)
        {
            _subjectRepository.CreateSubject(subject);
            return Ok();
        }

        [HttpPut]
        [Route("update/{subjectId}")]
        public ActionResult UpdateSubject(SubjectUpdateDTO subject, [FromRoute] int subjectId)
        {
            _subjectRepository.UpdateSubject(subject, subjectId);
            return Ok();
        }
    }
}
