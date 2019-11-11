using System.Collections.Generic;
using System.Threading.Tasks;
using LandmarkRemarkService.Database;
using LandmarkRemarkService.Models;
using LandmarkRemarkService.WorkerClasses;
using Microsoft.AspNetCore.Mvc;

namespace LandmarkRemarkService.Controllers
{
    /// <summary>
    /// A RESTful API for handling user actions on the map points.
    /// </summary>
    [Route("api/[controller]")]
    public class UserLandmarkController : Controller
    {
        private readonly ILandmarkOperation _landmarkOperation;

        public UserLandmarkController(ILandmarkOperation landmarkOperation)
        {
            _landmarkOperation = landmarkOperation;
        }

        /// <summary>
        /// Gets all the available points for the user with ID.
        /// </summary>
        /// <param name="userId">user ID</param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<List<MarkerViewModel>> Get(string userId)
        {
            return await _landmarkOperation.GetLandmarks(userId);
        }

        /// <summary>
        /// Adds a landmark for a user with all the required information such as location or note.
        /// </summary>
        /// <param name="mapLandmark">Marker DTO including long/lat and content</param>
        [HttpPost]
        public async Task<MarkerViewModel> Post([FromBody]MapLandmark mapLandmark)
        {
            return await _landmarkOperation.SaveLandmarks(mapLandmark);
        }

        /// <summary>
        ///  Updates a landmark for a user with all the required information such as location or note.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Deletes a point
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
