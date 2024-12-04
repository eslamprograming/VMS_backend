using DAL.ModelVM.Sherad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface ImoneyReportsRepo
    {
        //NetProfitbetweenProc,NetProfitProc,NettotalOrderprice,
        //NettotalOrderpricebetween,NettotalSuppliyprice,NettotalSuppliypricebetween
        Task<Response<decimal>> NetProfitbetweenProc(DateTime startdate,DateTime enddate);
        Task<Response<decimal>> NetProfitProc();
        Task<Response<decimal>> NettotalOrderprice();
        Task<Response<decimal>> NettotalOrderpricebetween(DateTime startdate, DateTime enddate);
        Task<Response<decimal>> NettotalSuppliyprice();
        Task<Response<decimal>> NettotalSuppliypricebetween(DateTime startdate, DateTime enddate);

    }
}
