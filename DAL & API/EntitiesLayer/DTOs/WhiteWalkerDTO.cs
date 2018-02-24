using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.DTOs
{
    public class WhiteWalkerDTO
    {
        public int Id { get; set; }
        public int NumberOfUnits { get; set; }

        public WhiteWalkerDTO()
        {

        }

        public WhiteWalkerDTO(int p_id, int p_numberOfUnits = 0)
        {
            Id = p_id;
            NumberOfUnits = p_numberOfUnits;
        }
        public WhiteWalkerDTO(WhiteWalker ww)
        {
            Id = ww.Id;
            NumberOfUnits = ww.NumberOfUnits;
        }
    }
}
