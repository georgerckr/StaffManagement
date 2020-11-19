using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using StaffManagement.Data;
using StaffManagement.Model;
using System.Collections.Generic;
using System.Linq;

namespace StaffManagement.Web.Controllers
{
    
    [Route("api/Staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        DBStaffRepository dBStaffRepository = new DBStaffRepository();

        [HttpGet("{ID:int}")]
        public ActionResult<Staff> GetStaffByID(int ID)
        {
            var staff = dBStaffRepository.GetStaffById(ID);
            if (staff == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(staff);
            }
        }
       
        [HttpGet]
        public ActionResult<IEnumerable<Staff>> GetStaffByType(string type)
        {
            switch (type.ToLower())
            {
                case "teaching":
                    List<TeachingStaff> teachingStaffs = dBStaffRepository
                        .GetStaffByType(StaffType.TeachingStaff)
                        .Select(x => x as TeachingStaff).ToList();
                    if (teachingStaffs.Count == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return Ok(teachingStaffs);
                    }

                case "admin":                    
                    List<AdministrativeStaff> administrativeStaffs = dBStaffRepository
                        .GetStaffByType(StaffType.AdministrativeStaff)
                        .Select(x => x as AdministrativeStaff).ToList();
                    if (administrativeStaffs.Count == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return Ok(administrativeStaffs);
                    }

                case "support":                    
                    List<SupportStaff> supportStaffs = dBStaffRepository
                        .GetStaffByType(StaffType.SupportStaff)
                        .Select(x => x as SupportStaff).ToList();
                    if (supportStaffs.Count == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return Ok(supportStaffs);
                    }

                default:
                    break;
            }

            return BadRequest();
        }

        [HttpPost]
        public ActionResult<Staff> AddStaff([FromBody] JObject staff)
        {
            int type = (int)staff["staffType"];
            switch (type)
            {
                case 1:
                    TeachingStaff teachingStaff = staff.ToObject<TeachingStaff>();
                    dBStaffRepository.AddStaff(teachingStaff);
                    return Ok(teachingStaff);
                    break;

                case 2:
                    AdministrativeStaff administrativeStaff = staff.ToObject<AdministrativeStaff>();
                    dBStaffRepository.AddStaff(administrativeStaff);
                    return Ok(administrativeStaff);
                    break;

                case 3:
                    SupportStaff supportStaff = staff.ToObject<SupportStaff>();
                    dBStaffRepository.AddStaff(supportStaff);
                    return Ok(supportStaff);
                    break;
                default:
                    break;
            }
            return NotFound();
        }
        
        [HttpPut("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Staff> UpdateStaff(int ID, [FromBody] JObject staff)
        {
            int type = (int)staff["staffType"];
            switch (type)
            {
                case 1:
                    TeachingStaff teachingStaff = staff.ToObject<TeachingStaff>();
                    teachingStaff.StaffId = ID;
                    dBStaffRepository.UpdateStaff(teachingStaff);
                    return Ok();

                case 2:
                    AdministrativeStaff administrativeStaff = staff.ToObject<AdministrativeStaff>();
                    administrativeStaff.StaffId = ID;
                    dBStaffRepository.UpdateStaff(administrativeStaff);
                    return Ok();

                case 3:
                    SupportStaff supportStaff = staff.ToObject<SupportStaff>();
                    supportStaff.StaffId = ID;
                    dBStaffRepository.UpdateStaff(supportStaff);
                    return Ok();

                default:
                    break;
            }
            return NotFound();
        }

        [HttpDelete("{ID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int ID)
        {
            var staff = dBStaffRepository.GetStaffById(ID);
            if (staff == null)
            {
                return NotFound();
            }
            dBStaffRepository.RemoveStaff(ID);
            return Ok();
        }
    }
}
