using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandmarkRemarkService.Database;
using LandmarkRemarkService.Models;
using Microsoft.Extensions.Logging;

namespace LandmarkRemarkService.WorkerClasses
{
    /// <summary>
    /// Landmark operation class, all the data returning to UI provide the same model.
    /// </summary>
    public class LandmarkOperation : ILandmarkOperation
    {
        private readonly ILogger<LandmarkOperation> _logger;
        /// <summary>
        /// DI for logger (log4net)
        /// </summary>
        /// <param name="logger"></param>
        public LandmarkOperation(ILogger<LandmarkOperation> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Gets the list of ALL markers and based on user id matching makes a decision if they are editable.
        /// </summary>
        /// <param name="userId">ID of the current user</param>
        /// <returns></returns>
        public async Task<List<MarkerViewModel>> GetLandmarks(string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    throw new InvalidOperationException("User ID is empty.");
                }

                await using var context = new LandmarkDbContext();
                return context.UserContextInfo.SelectMany(user => user.MapLandmarks, 
                        (user, landmark) => new MarkerViewModel(landmark.Lat, landmark.Lng, landmark.Text, user.UserId == userId, user.Name))
                            .ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error retrieving landmarks. Method: {Method}, time: {time}", nameof(GetLandmarks), DateTime.Now);
                throw;
            }
        }

        public Task<List<MapLandmark>> DeleteUserLandmarks(int userId, int landmarkId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Saves the new landmark.
        /// 
        /// </summary>
        /// <param name="mapLandmark"></param>
        /// <returns>marker view model</returns>
        public async Task<MarkerViewModel> SaveLandmarks(MapLandmark mapLandmark)
        {
            try
            {
                await using var context = new LandmarkDbContext();
                var newLandMark = context.MapLandmark.Add(new MapLandmark
                {
                    Text = mapLandmark.Text,
                    Lat = mapLandmark.Lat,
                    Lng = mapLandmark.Lng,
                    UserId = mapLandmark.UserId
                }).Entity;

                context.SaveChanges();
                var userName = context.UserContextInfo.First(x => x.UserId == newLandMark.UserId).Name;

                return new MarkerViewModel(newLandMark.Lat, newLandMark.Lng, newLandMark.Text, false, userName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving landmarks. Method: {Method}, time: {time}", nameof(SaveLandmarks), DateTime.Now);
                throw;
            }
        }
    }
}
