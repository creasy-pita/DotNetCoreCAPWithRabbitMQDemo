using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSubScriber.Dtos;

namespace WebSubScriber
{
    public class Service1: ICapSubscribe
    {
        [CapSubscribe("xxx.services.account.check")]
        public void BarMessageProcessor(Person p)
        {

        }
    }
}
