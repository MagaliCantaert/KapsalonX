using System;
using System.Collections.Generic;
using System.Text;

namespace EE.KapsalonX.Domain.Boeken
{
    public class Planning
    {
        Guid PlanningId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
    }
}
