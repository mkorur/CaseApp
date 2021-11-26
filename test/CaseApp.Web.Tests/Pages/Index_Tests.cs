using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CaseApp.Pages
{
    public class Index_Tests : CaseAppWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
