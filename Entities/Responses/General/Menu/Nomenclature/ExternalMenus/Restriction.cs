﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoTransport.Net.Entities.Responses.General.Menu.Nomenclature.ExternalMenus
{
    /// <summary>
    /// Contains information about a restriction.
    /// </summary>
    [JsonObject]
    public class Restriction
    {
        /// <summary>
        /// Minimum amount.
        /// </summary>
        [JsonProperty(PropertyName = "minQuantity", Required = Required.Always)]
        public int MinQuantity { get; set; }

        /// <summary>
        /// Maximum amount.
        /// </summary>
        [JsonProperty(PropertyName = "maxQuantity", Required = Required.Always)]
        public int MaxQuantity { get; set; }

        /// <summary>
        /// Amount free of charge.
        /// </summary>
        [JsonProperty(PropertyName = "freeQuantity", Required = Required.Always)]
        public int FreeQuantity { get; set; }

        /// <summary>
        /// Default amount.
        /// </summary>
        [JsonProperty(PropertyName = "byDefault", Required = Required.Always)]
        public int ByDefault { get; set; }
    }
}
