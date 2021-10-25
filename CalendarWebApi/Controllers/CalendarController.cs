using CalendarWebApi.DTO;
using CalendarWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {

        /// <summary>
        /// POST create new event
        /// </summary>
        /// <param name="eventDetail">Event details</param>
        /// <returns>HTTP response 201</returns>
        [HttpPost]
        public ActionResult AddEvent([FromBody] CreateForm eventDetail)
        {

            using (Models.ProjectTestDBContext db = new Models.ProjectTestDBContext())
            {
                Calendar calendar = new Calendar();
                calendar.Name = eventDetail.Name;
                calendar.Location = eventDetail.Location;
                calendar.Time = eventDetail.Time;
                calendar.EventOrganizer = eventDetail.EventOrganizer;
                calendar.Members = eventDetail.Members;
                db.Calendars.Add(calendar);
                db.SaveChanges();

                return Created("", calendar);
            }

        }

        /// <summary>
        /// Delete an event by id
        /// </summary>
        /// <param name="id">id of the row in dtabase</param>
        /// <returns>response</returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteEvent(int id)
        {
            using (Models.ProjectTestDBContext db = new Models.ProjectTestDBContext())
            {
                Calendar calendar = db.Calendars.Find(id);
                if (calendar is null)
                {
                    return NotFound(); //Ok("Not Found") or NoContent()
                }
                else
                {
                    db.Calendars.Remove(calendar);
                    db.SaveChanges();
                    return Ok();
                }
            }
        }

        /// <summary>
        /// Update an event by id
        /// </summary>
        /// <param name="id">id of the event in db</param>
        /// <param name="eventDetail">new data of an event</param>
        /// <returns>response</returns>
        [HttpPut("{id}")]
        public ActionResult EditEvent(int id, [FromBody] CreateForm eventDetail)
        {
            using (Models.ProjectTestDBContext db = new Models.ProjectTestDBContext())
            {
                Calendar calendar = db.Calendars.Find(id);
                if (calendar is null)
                {
                    return NotFound(); //Ok("Not Found") or NoContent()
                }
                else
                {
                    calendar.Name = eventDetail.Name;
                    calendar.Location = eventDetail.Location;
                    calendar.Time = eventDetail.Time;
                    calendar.EventOrganizer = eventDetail.EventOrganizer;
                    calendar.Members = eventDetail.Members;
                    db.Calendars.Update(calendar);
                    db.SaveChanges();
                    return Ok();
                }
            }
        }

        /// <summary>
        /// Get all events in database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAllEvents()
        {
            using (Models.ProjectTestDBContext db = new Models.ProjectTestDBContext())
            {
                var events = db.Calendars.ToList();
                if (events.Count == 0)
                {
                    return Ok(events);
                }
                return Ok(events);
            }
        }

        /// <summary>
        /// Get details of events by his parameters
        /// </summary>
        /// <param name="query">id of the event, eventorganizer of event, location of event and name of event</param>
        /// <returns>response</returns>
        [Route("query")]
        [HttpGet]
        public ActionResult GetOrganizer([FromQuery] Query query)
        {
            using (Models.ProjectTestDBContext db = new Models.ProjectTestDBContext())
            {
                var events = db.Calendars.ToList();
                events = events.Where(x => x.Id == query.id || x.EventOrganizer == query.eventOrganizer || x.Location == query.location || x.Name == query.name).ToList();

                return Ok(events);
            }
        }

        /// <summary>
        /// Sort all events in database by time
        /// </summary>
        /// <returns>events</returns>
        [Route("sort")]
        [HttpGet]
        public ActionResult SortDesc()
        {
            using (Models.ProjectTestDBContext db = new Models.ProjectTestDBContext())
            {
                var events = db.Calendars.ToList();
                events = events.OrderByDescending(x => x.Time).ToList();

                return Ok(events);
            }
        }
    }
}
