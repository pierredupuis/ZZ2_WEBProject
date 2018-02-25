using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntitiesLayer.DTOs
{
    public class WarDTO
    {
        public int Id { get; set; }
        public WarDTO()
        {
            Id = -1;
        }
        public WarDTO(int p_id)
        {
            Id = p_id;
        }
    }
}