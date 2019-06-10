using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;
namespace BLL
{
    public class bll
    {
        DAL.dal dal = new dal();
        public List<AllInfo> GetInvitation()
        {
            return dal.GetInvitation();
        }
    }
}
