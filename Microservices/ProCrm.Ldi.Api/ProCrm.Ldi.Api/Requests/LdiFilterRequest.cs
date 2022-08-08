using Microsoft.AspNetCore.Mvc;
namespace ProCrm.Ldi.Api.Requests
{
    public class LdiFilterRequest
    {
        [FromQuery(Name ="id")]
        public int Id { get; set; }

        [FromQuery(Name = "status")]
        public string Status { get; set; }

        [FromQuery(Name = "attached_to")]
        public string AttachedTo { get; set; }

        [FromQuery(Name = "full_name")]
        public string FullName { get; set; }

        [FromQuery(Name = "job_title")]
        public string JobTitle { get; set; }

       
    }
}
