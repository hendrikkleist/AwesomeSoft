using AwesomeSoft.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeSoft.Domain.Entities;

public class MeetingRoom : BaseModel
{
    public int RoomNumber { get; set; }
    public int Capacity { get; set; }
}
