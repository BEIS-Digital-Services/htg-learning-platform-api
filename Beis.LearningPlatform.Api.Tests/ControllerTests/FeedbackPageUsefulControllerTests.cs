using Beis.LearningPlatform.Api.Controllers;
using Beis.LearningPlatform.Api.Tests.Repositories;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beis.LearningPlatform.Api.Tests.ControllerTests
{
    public class FeedbackPageUsefulControllerTests : ControllerTestBase
	{
		private FeedbackPageUsefulController _controller;

		[SetUp]
		public void Setup()
		{
            _controller = new FeedbackPageUsefulController(new FeedbackPageUsefulTestRepository())
            {
                ControllerContext =
                {
                    HttpContext = GetMockedHttpContextAccessor().Object
                }
            };
		}

		[Test]
		public void Should_Return_Options()
		{
			var result = _controller.GetFeedbackPageUsefulOptions();
			Assert.IsNotNull(result);
			Assert.IsTrue(result is OkResult);
		}

		[Test]
		public async Task Should_Get_FeedbackPageUseful_For_Valid_Id()
		{
			var result = await _controller.GetFeedbackPageUseful(1);
			Assert.IsNotNull(result);

			var okResult = result as OkObjectResult;
			Assert.IsNotNull(okResult);
			Assert.AreEqual(okResult.StatusCode, 200);

			var data = okResult.Value as FeedbackPageUseful;
			Assert.IsNotNull(data);
			Assert.AreEqual(data.Id, 1);
		}

		[Test]
		public async Task Should_Get_NotFound_FeedbackPageUseful_For_Invalid_Id()
		{
			var result = await _controller.GetFeedbackPageUseful(0);
			Assert.IsNotNull(result);

			var notFoundResult = result as NotFoundResult;
			Assert.IsNotNull(notFoundResult);
			Assert.AreEqual(notFoundResult.StatusCode, 404);
		}

		[Test]
		public async Task Should_Get_FeedbackPageUsefuls_For_Valid_PaginationParameter()
		{
			var paginationParameter = new PaginationParameter { PageNumber = 1, PageSize = 2 };
			var result = await _controller.GetFeedbackPageUsefuls(paginationParameter);
			Assert.IsNotNull(result);

			var okResult = result as OkObjectResult;
			Assert.IsNotNull(okResult);
			Assert.AreEqual(okResult.StatusCode, 200);

			var data = okResult.Value as IEnumerable<FeedbackPageUseful>;
			Assert.IsNotNull(data);
			Assert.AreEqual(data.Count(), paginationParameter.PageSize);
		}

		[Test]
		public async Task Should_Not_Get_FeedbackPageUsefuls_For_Invalid_PaginationParameter()
		{
			var paginationParameter = new PaginationParameter { PageNumber = 0, PageSize = 0 };
			var result = await _controller.GetFeedbackPageUsefuls(paginationParameter);
			Assert.IsNotNull(result);

			var badRequestResult = result as BadRequestResult;
			Assert.IsNotNull(badRequestResult);
			Assert.AreEqual(badRequestResult.StatusCode, 400);
		}

		[Test]
		public async Task Should_Create_FeedbackPageUseful_For_Valid_Object()
		{
			var result = await _controller.CreateFeedbackPageUseful(new FeedbackPageUseful());
			Assert.IsNotNull(result);

			var createdAtRouteResult = result.Result as CreatedAtRouteResult;
			Assert.IsNotNull(createdAtRouteResult);
			Assert.AreEqual(createdAtRouteResult.StatusCode, 201);

			var data = createdAtRouteResult.Value as FeedbackPageUseful;
			Assert.IsNotNull(data);
			Assert.AreNotEqual(data.Id, default);
		}

		[Test]
		public async Task Should_Not_Create_FeedbackPageUseful_For_InValid_Object()
		{
			var result = await _controller.CreateFeedbackPageUseful(null);
			Assert.IsNotNull(result);

			var badRequestResult = result.Result as BadRequestResult;
			Assert.IsNotNull(badRequestResult);
			Assert.AreEqual(badRequestResult.StatusCode, 400);
		}


		[Test]
		public async Task Should_Update_FeedbackPageUseful_For_Valid_Object()
		{
			var newRecord = new FeedbackPageUseful
			{
				Id = 1
			};

			var result = await _controller.UpdateFeedbackPageUseful(newRecord);
			Assert.IsNotNull(result);

			var noContentResult = result as NoContentResult;
			Assert.IsNotNull(noContentResult);
			Assert.AreEqual(noContentResult.StatusCode, 204);
		}

		[Test]
		public async Task Should_Not_Update_FeedbackPageUseful_For_Invalid_Object()
		{
			var newRecord = new FeedbackPageUseful
			{
				Id = -1
			};
			var result = await _controller.UpdateFeedbackPageUseful(newRecord);
			Assert.IsNotNull(result);

			var notFoundResult = result as NotFoundResult;
			Assert.IsNotNull(notFoundResult);
			Assert.AreEqual(notFoundResult.StatusCode, 404);
		}

		[Test]
		public async Task Should_Delete_FeedbackPageUseful_For_Valid_Id()
		{			
			var result = await _controller.DeleteFeedbackPageUseful(1);
			Assert.IsNotNull(result);

			var noContentResult = result as NoContentResult;
			Assert.IsNotNull(noContentResult);
			Assert.AreEqual(noContentResult.StatusCode, 204);
		}

		[Test]
		public async Task Should_Not_Delete_FeedbackPageUseful_For_Invalid_Id()
		{
			var result = await _controller.DeleteFeedbackPageUseful(0);
			Assert.IsNotNull(result);

			var notFoundResult = result as NotFoundResult;
			Assert.IsNotNull(notFoundResult);
			Assert.AreEqual(notFoundResult.StatusCode, 404);
		}
	}
}