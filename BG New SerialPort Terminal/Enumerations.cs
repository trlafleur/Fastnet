

using System;

namespace BGSerialLib
{
	/// <summary>
	/// BGEventType
	/// </summary>
	public enum BGEventType 
	{
		/// <summary>
		/// Data timeout event fired when data haven't been received from
        /// B&G Net device for a while
		/// </summary>
		TimeOut,
        /// <summary>
        /// If we have valid Data
        /// </summary>
        Valid,
        /// <summary>
        /// If we have a Frame CheckSum error on the data
        /// </summary>
        CheckSum,
		/// <summary>
		/// B&G Frame not recognized
		/// </summary>
		Unknown
	}
}
