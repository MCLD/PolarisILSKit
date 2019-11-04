using Clc.Polaris.Api;
using Clc.Polaris.Api.Models;
using Microsoft.Extensions.Configuration;

namespace PolarisILSKit
{
    public class PapiHelper : PapiClient
    {
        public int UserId { get; set; }
        public int WorkstationId { get; set; }

        public PapiHelper(IConfigurationSection config)
        {
            AccessID = config[PapiConfigurationKeys.AccessID];
            AccessKey = config[PapiConfigurationKeys.AccessKey];
            Hostname = config[PapiConfigurationKeys.HostName];
            StaffOverrideAccount = new PolarisUser
            {
                Domain = config[PapiConfigurationKeys.Domain],
                Username = config[PapiConfigurationKeys.UserName],
                Password = config[PapiConfigurationKeys.Password]
            };

            UserId = config.GetValue<int>(PapiConfigurationKeys.UserId);
            WorkstationId = config.GetValue<int>(PapiConfigurationKeys.WorkstationId);
        }

        public bool IsConfigured()
        {
            return !string.IsNullOrEmpty(AccessID)
                && !string.IsNullOrEmpty(AccessKey)
                && !string.IsNullOrEmpty(Hostname)
                && StaffOverrideAccount != null
                && UserId > 0
                && WorkstationId > 0;
        }
    }
}
