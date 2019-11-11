using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandmarkRemarkService.Models
{
    public class MarkerViewModel
    {
        /// <summary>
        /// A simple ViewModel for UI
        /// </summary>
        /// <param name="lat">latitude</param>
        /// <param name="lng">longitude</param>
        /// <param name="text">Text to display</param>
        /// <param name="readOnly">Indicating if user can update this mark based on who created it. True if another person created it.</param>
        /// <param name="userName">Name of the user who created it.</param>
        public MarkerViewModel(double lat, double lng, string text, bool readOnly, string userName)
        {
            Lat = lat;
            Lng = lng;
            Text = text;
            ReadOnly = readOnly;
            UserName = userName;
        }

        /// <summary>
        /// Latitude
        /// </summary>
        public double Lat { get;  }

        /// <summary>
        /// Longitude
        /// </summary>
        public double Lng { get; }

        /// <summary>
        /// Text to display
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Indicating if user can update this mark based on who created it. True if another person created it.
        /// </summary>
        public bool ReadOnly { get;}

        /// <summary>
        /// Name of the user who created it.
        /// </summary>
        public string UserName { get;}
    }
}
