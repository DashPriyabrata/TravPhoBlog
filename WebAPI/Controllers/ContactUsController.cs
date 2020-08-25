using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    public class ContactUsController : ApiController
    {
        IContactUsRepository contactUsRepo;

        public ContactUsController()
        {
            contactUsRepo = new ContactUsRepository(new MyTravelBlogEntities());
        }

        [Route("api/ContactUs/All")]
        [ResponseType(typeof(List<contactus>))]
        public async Task<IHttpActionResult> GetAllRecords()
        {
            return Ok(await contactUsRepo.GetAllRecords());
        }

        [HttpPost]
        [Route("api/ContactUs/Add")]
        [ResponseType(typeof(contactus))]
        public async Task<IHttpActionResult> AddRecord([FromBody] contactus submission)
        {
            //EF6 can't identify whether db has default values set, so it will instead insert null to these columns.
            //I want the deafult values to be set thus assigning them in code. 
            submission.Date = DateTime.Now;
            submission.IsAdminRead = false;
            submission.IsActive = true;
            return Ok(await contactUsRepo.AddRecord(submission));
        }

        [HttpPatch]
        [Route("api/ContactUs/Update/AdminRead")]
        [ResponseType(typeof(bool?))]
        public async Task<IHttpActionResult> UpdateIsAdminReadProperty([FromBody] int id)
        {
            var status = await contactUsRepo.UpdateIsAdminReadProperty(id);
            return status != null ? (IHttpActionResult)Ok(status) : BadRequest("No record found for the input id: " + id);
        }
    }
}
