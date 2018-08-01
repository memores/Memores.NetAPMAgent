﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Memores.NetAPMAgent.Model.Base
{
    public abstract class TrackingObject
    {
        /// <summary>
        /// Object UUID
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        /// Object started UTC date and time
        /// </summary>
        public DateTime DateStart { get; set; }


        /// <summary>
        /// Object completed UTC date and time
        /// </summary>
        public DateTime DateEnd { get; set; }


        /// <summary>
        /// How long the object took to complete
        /// </summary>
        public double Duration => DateEnd == default(DateTime)
            ? (DateTime.UtcNow - DateStart).TotalMilliseconds
            : (DateEnd - DateStart).TotalMilliseconds;


        /// <summary>
        /// Name of the current object
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// The type of the object
        /// </summary>
        public string Type { get; set; }


        public abstract void End();
    }
}
