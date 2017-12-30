using System;
using System.Collections.Generic;
using System.Text;

namespace Nevitium.Domain.Entities.Settings
{
    public class WebServices
    {        
        public WebService UpcWebService { get; set; } = new WebService();
        public AmazonMarketplaceWebService AmazonMWS { get; set; } = new AmazonMarketplaceWebService();
                      
    }
}
