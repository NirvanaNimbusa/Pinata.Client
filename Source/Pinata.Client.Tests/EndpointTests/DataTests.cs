using System.Threading.Tasks;
using NUnit.Framework;
using static System.Net.Http.HttpMethod;

namespace Pinata.Client.Tests.EndpointTests
{
   public class DataTests : MockServerTest
   {
      private PinataClient client;

      [SetUp]
      public virtual void BeforeEachTest()
      {
         var config = new Config()
         {
            ApiKey = "key",
            ApiSecret = "secret"
         };

         this.client = new PinataClient(config);
      }

      [Test]
      public async Task UserPinnedDataTotal_with_no_values()
      {
         this.server.RespondWithJsonTestFile();

         var r = await client.Data.UserPinnedDataTotalAsync();

         this.server
            .ShouldHaveCalledPath("/data/userPinnedDataTotal")
            .WithVerb(Get);

         await Verify(r);
      }

      [Test]
      public async Task UserPinnedDataTotal_with_values()
      {
         this.server.RespondWithJsonTestFile();

         var r = await client.Data.UserPinnedDataTotalAsync();

         this.server
            .ShouldHaveCalledPath("/data/userPinnedDataTotal")
            .WithVerb(Get);

         await Verify(r);
      }

      [Test]
      public async Task Get_Pin_List()
      {
         this.server.RespondWithJsonTestFile();

         var filter = new
            {
               status = "pinned"
            };

         var r = await this.client.Data.PinList(filter);

         this.server.ShouldHaveCalledPath("/data/pinList")
            .WithQueryParam("status", "pinned")
            .WithVerb(Get);

         await Verify(r);
      }
   }
}
