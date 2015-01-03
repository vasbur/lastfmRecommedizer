using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lastfmRecommedizer.LastFmApiClient
{
    public class UserList 
    {
        [XmlElement(ElementName="user")]
        public List<User> Users { get; set; }

        
    }
}
