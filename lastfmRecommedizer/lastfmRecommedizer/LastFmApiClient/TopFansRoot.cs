using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lastfmRecommedizer.LastFmApiClient
{
    [XmlRoot(ElementName = "lfm")]
    public class TopFansRoot
    {
        [XmlElement(ElementName = "topfans")]
        public UserList Userlist { get; set; }

       
    }
}
