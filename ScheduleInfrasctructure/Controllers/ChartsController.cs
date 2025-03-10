using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace ScheduleInfrasctructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        // Для зручного повернення даних
        private record CountByFacultyResponseItem(string Faculty, int GroupCount);

        private readonly lab_1Context scheduleContext;

        public ChartsController(lab_1Context scheduleContext)
        {
            this.scheduleContext = scheduleContext;
        }

        [HttpGet("countByFaculty")]
        public async Task<JsonResult> GetCountByFacultyAsync(CancellationToken cancellationToken)
        {
            var responseItems = await scheduleContext
                .Groups
                .GroupBy(g => g.Faculty.Name) 
                .Select(g => new CountByFacultyResponseItem(g.Key, g.Count()))
                .ToListAsync(cancellationToken);


            return new JsonResult(responseItems);
        }

        [HttpGet("countByDepartment")]
        public async Task<JsonResult> GetCountByDepartmentAsync(CancellationToken cancellationToken)
        {
            var responseItems = await scheduleContext
                .Teachers
                .GroupBy(t => t.Department.Name)
                .Select(g => new {
                    DepartmentName = g.Key,
                    TeacherCount = g.Count()
                })
                .ToListAsync(cancellationToken);

            return new JsonResult(responseItems);
        }

    }
}