﻿using Clc.Polaris.Api.Models;
using Clc.Polaris.Api.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Clc.Polaris.Api
{
    public partial class PapiClient
    {
        /// <summary>
        /// Search for bibliographic records
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public PapiResponse<BibSearchResult> BibSearch(BibSearchOptions options)
        {
            var url = $"/PAPIService/REST/public/v1/1300/100/{options.Branch}/search/bibs/{options.SearchType}/{options.Qualifier}?q={PolarisEncode(options.Term)}&sort={options.SortOption}&page={options.Page}&bibsperpage={options.PageSize}";
            return Execute<BibSearchResult>(HttpMethod.Get, url);
        }
    }
}