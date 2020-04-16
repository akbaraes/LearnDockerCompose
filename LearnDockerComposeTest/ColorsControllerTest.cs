using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using LearnDockerCompose;
using LearnDockerCompose.Contract;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace LearnDockerComposeTest
{
    public class ColorsControllerTest : IntegrationTest
    {


        [Fact]
        public async Task GetAll_ShouldRetuenEmptyValue()
        {
            var response = await TestClient.GetAsync("api/Colors");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var data = await response.Content.ReadAsAsync<List<Color>>();
            data.Should().HaveCount(0);
        }
    }
}
