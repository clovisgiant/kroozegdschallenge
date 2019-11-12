using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Krooze.EntranceTest.WriteHere.Tests.WebTests;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Krooze.EntranceTest.Tests
{
    public class WebTests
    {
        readonly WebTest _test = new WebTest();

        [SetUp]
        public void Setup()
        {
        }




        [Test]
        public void Movies()
        {
            var result = _test.GetAllMoviesAsync();
            Assert.IsNotNull(result.Result);
            string json = result.Result.ToString();
            var parsed = JObject.Parse(json);            
            Assert.IsNotNull(result);
            var count = parsed.SelectToken("count").Value<int>();
            Assert.AreEqual(count, parsed.SelectToken("results").Value<JArray>().Count);
            var aNewHope = parsed.SelectToken("results").Value<JArray>().FirstOrDefault(x => x["episode_id"].Value<int>() == 4);
            Assert.IsNotNull(aNewHope);
            Assert.AreEqual("A New Hope", aNewHope["title"].Value<string>());
            Assert.Pass();

        }

        [Test]
        public void Director()
        {
            var result = _test.GetDirector();
            Assert.IsNotNull(result.Result);
            Assert.AreEqual("George Lucas", result.Result);
            Assert.Pass();
        }
    }
}