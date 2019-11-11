using System.Collections.Generic;
using System.Threading.Tasks;
using LandmarkRemarkService.Database;
using LandmarkRemarkService.Models;

namespace LandmarkRemarkService.WorkerClasses
{
    public interface ILandmarkOperation
    {
        Task<List<MarkerViewModel>> GetLandmarks(string userId);
        Task<List<MapLandmark>> DeleteUserLandmarks(int userId, int landmarkId);
        Task<MarkerViewModel> SaveLandmarks(MapLandmark mapLandmark);
    }
}