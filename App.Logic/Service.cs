using App.Logic.Interfaces;
using System;
using System.Collections.Generic;

namespace App.Logic
{
    public class Service : IService
    {
        private static readonly log4net.ILog s_logger = log4net.LogManager.GetLogger(typeof(Service));
        public List<string> GetData()
        {
            var retVal = new List<string>();
            try
            {
                retVal.Add("Test_value1");
                retVal.Add("Test_value2");
            }
            catch (Exception ex)
            {
                s_logger.Error(ex);
                throw;
            }
            return retVal;
        }
    }
}
