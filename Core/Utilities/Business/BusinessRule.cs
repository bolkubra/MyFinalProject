using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRule
    {
        //parametreyle gönderdiğimiz iş kurallarının başarısız olanını businessa haber ver 
        public static IResult Run(params IResult[] logics)
        {
            foreach (var result in logics)
            {
                if (!result.Success)
                {
                    return result;
                }
            }

            //foreach (var logic in logics)
            //{
            //    if (!logic.Succes)
            //    {
            //        return logic;
            //    }

            //}
            return null;
        }
    }
}
