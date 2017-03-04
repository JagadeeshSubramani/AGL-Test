using System;
using System.Net;
using System.Configuration;
using PeoplePets.Models;
using System.Collections.Generic;
using System.IO;

namespace ServiceWrapper.People
{
    public class PeopleWrapper
    {
        public IEnumerable<Owner> GetOwners()
        {
            try
            {
                var svcUrl = ConfigurationManager.AppSettings["PeopleServiceUrl"];
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(svcUrl);
                request.ContentType = "application/json";

                var response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (var streamReader = new StreamReader(responseStream))
                        {
                            var jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                            return jsonSerializer.Deserialize<IEnumerable<Owner>>(streamReader.ReadToEnd());
                        }
                    }
                }
                else
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).",
                        response.StatusCode, response.StatusDescription));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
