using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Messaging;
public class OrderCreated
{
    public required int id { get; set; }

    public required int count { get; set; }
}
