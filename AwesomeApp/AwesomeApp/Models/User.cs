using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AwesomeApp.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("surName")]
        public string SurName { get; set; }

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

    }
}
