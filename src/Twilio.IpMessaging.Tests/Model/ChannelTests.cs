using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using Twilio.IpMessaging;

namespace Twilio.IpMessaging.Tests.Model
{
    [TestFixture]
    public class IpMessagingChannelTests
    {
        [Test]
        public void testDeserializeInstanceResponse()
        {
            var doc = File.ReadAllText(Path.Combine("../../Resources", "channel.json"));
            var json = new JsonDeserializer();
            var output = json.Deserialize<Channel>(new RestResponse { Content = doc });

            Assert.NotNull(output);
            Assert.AreEqual("CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Sid);
            Assert.AreEqual("ACaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.AccountSid);
            Assert.AreEqual("ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.ServiceSid);
            Assert.AreEqual("my channel", output.FriendlyName);
            Assert.IsEmpty(output.Attributes);
            Assert.AreEqual("system", output.CreatedBy);
            Assert.AreEqual("public", output.Type);
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", output.Url);
            Dictionary<string, string> dictionary = output.Links;
            Assert.NotNull(dictionary);
            Assert.True(dictionary.ContainsKey("members"));
            Assert.True(dictionary.ContainsKey("messages"));
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Members", dictionary["members"]);
            Assert.AreEqual("http://localhost/v1/Services/ISaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Channels/CHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/Messages", dictionary["messages"]);
        }
    }
}
