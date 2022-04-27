using Microsoft.AspNetCore.Http;
using Moq;

namespace Beis.LearningPlatform.Api.Tests.ControllerTests
{
    public class ControllerTestBase
	{
		protected static Mock<HttpContext> GetMockedHttpContextAccessor()
		{
			Mock<HttpResponse> httpResponse = new();
			Mock<HttpContext> httpContext = new();

			httpResponse.SetupGet(x => x.Headers)
				.Returns(new Mock<IHeaderDictionary>().Object);
			httpContext.SetupGet(x => x.Response)
				.Returns(httpResponse.Object);
			
			return httpContext;
		}
	}
}