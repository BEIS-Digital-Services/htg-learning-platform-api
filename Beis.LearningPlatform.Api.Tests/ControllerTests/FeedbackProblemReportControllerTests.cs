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
    public class FeedbackProblemReportControllerTests : ControllerTestBase
	{
		private FeedbackProblemReportController _controller;

		[SetUp]
		public void Setup()
		{
            _controller = new FeedbackProblemReportController(new FeedbackProblemReportTestRepository())
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
			var result = _controller.GetFeedbackProblemReportOptions();
			Assert.IsNotNull(result);
			Assert.IsTrue(result is OkResult);
		}

		[Test]
		public async Task Should_Get_FeedbackProblemReport_For_Valid_Id()
		{
			var result = await _controller.GetFeedbackProblemReport(1);
			Assert.IsNotNull(result);

			var okResult = result as OkObjectResult;
			Assert.IsNotNull(okResult);
			Assert.AreEqual(okResult.StatusCode, 200);

			var data = okResult.Value as FeedbackProblemReport;
			Assert.IsNotNull(data);
			Assert.AreEqual(data.Id, 1);
		}

		[Test]
		public async Task Should_Get_NotFound_FeedbackProblemReport_For_Invalid_Id()
		{
			var result = await _controller.GetFeedbackProblemReport(0);
			Assert.IsNotNull(result);

			var notFoundResult = result as NotFoundResult;
			Assert.IsNotNull(notFoundResult);
			Assert.AreEqual(notFoundResult.StatusCode, 404);
		}

		[Test]
		public async Task Should_Get_FeedbackProblemReports_For_Valid_PaginationParameter()
		{
			var paginationParameter = new PaginationParameter { PageNumber = 1, PageSize = 2 };
			var result = await _controller.GetFeedbackProblemReports(paginationParameter);
			Assert.IsNotNull(result);

			var okResult = result as OkObjectResult;
			Assert.IsNotNull(okResult);
			Assert.AreEqual(okResult.StatusCode, 200);

			var data = okResult.Value as IEnumerable<FeedbackProblemReport>;
			Assert.IsNotNull(data);
			Assert.AreEqual(data.Count(), paginationParameter.PageSize);
		}

		[Test]
		public async Task Should_Not_Get_FeedbackProblemReports_For_Invalid_PaginationParameter()
		{
			var paginationParameter = new PaginationParameter { PageNumber = 0, PageSize = 0 };
			var result = await _controller.GetFeedbackProblemReports(paginationParameter);
			Assert.IsNotNull(result);

			var badRequestResult = result as BadRequestResult;
			Assert.IsNotNull(badRequestResult);
			Assert.AreEqual(badRequestResult.StatusCode, 400);
		}

		[Test]
		public async Task Should_Create_FeedbackProblemReport_For_Valid_Object()
		{
			var result = await _controller.CreateFeedbackProblemReport(new FeedbackProblemReport());
			Assert.IsNotNull(result);

			var createdAtRouteResult = result.Result as CreatedAtRouteResult;
			Assert.IsNotNull(createdAtRouteResult);
			Assert.AreEqual(createdAtRouteResult.StatusCode, 201);

			var data = createdAtRouteResult.Value as FeedbackProblemReport;
			Assert.IsNotNull(data);
			Assert.AreNotEqual(data.Id, default);
		}

		[Test]
		public async Task Should_Not_Create_FeedbackProblemReport_For_InValid_Object()
		{
			var result = await _controller.CreateFeedbackProblemReport(null);
			Assert.IsNotNull(result);

			var badRequestResult = result.Result as BadRequestResult;
			Assert.IsNotNull(badRequestResult);
			Assert.AreEqual(badRequestResult.StatusCode, 400);
		}


		[Test]
		public async Task Should_Update_FeedbackProblemReport_For_Valid_Object()
		{
			var newRecord = new FeedbackProblemReport
			{
				Id = 1
			};

			var result = await _controller.UpdateFeedbackProblemReport(newRecord);
			Assert.IsNotNull(result);

			var noContentResult = result as NoContentResult;
			Assert.IsNotNull(noContentResult);
			Assert.AreEqual(noContentResult.StatusCode, 204);
		}

		[Test]
		public async Task Should_Not_Update_FeedbackProblemReport_For_Invalid_Object()
		{
			var newRecord = new FeedbackProblemReport
			{
				Id = -1
			};
			var result = await _controller.UpdateFeedbackProblemReport(newRecord);
			Assert.IsNotNull(result);

			var notFoundResult = result as NotFoundResult;
			Assert.IsNotNull(notFoundResult);
			Assert.AreEqual(notFoundResult.StatusCode, 404);
		}

		[Test]
		public async Task Should_Delete_FeedbackProblemReport_For_Valid_Id()
		{			
			var result = await _controller.DeleteFeedbackProblemReport(1);
			Assert.IsNotNull(result);

			var noContentResult = result as NoContentResult;
			Assert.IsNotNull(noContentResult);
			Assert.AreEqual(noContentResult.StatusCode, 204);
		}

		[Test]
		public async Task Should_Not_Delete_FeedbackProblemReport_For_Invalid_Id()
		{
			var result = await _controller.DeleteFeedbackProblemReport(0);
			Assert.IsNotNull(result);

			var notFoundResult = result as NotFoundResult;
			Assert.IsNotNull(notFoundResult);
			Assert.AreEqual(notFoundResult.StatusCode, 404);
		}
	}
}