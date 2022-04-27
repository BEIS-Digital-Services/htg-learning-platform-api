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
    public class DiagnosticToolEmailAnswerControllerTests : ControllerTestBase
	{
		private DiagnosticToolEmailAnswerController _controller;

		[SetUp]
		public void Setup()
		{
            _controller = new DiagnosticToolEmailAnswerController(new DiagnosticToolEmailAnswerTestRepository())
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
			var result = _controller.GetDiagnosticToolEmailAnswerOptions();
			Assert.IsNotNull(result);
			Assert.IsTrue(result is OkResult);
		}

		[Test]
		public async Task Should_Get_DiagnosticToolEmailAnswer_For_Valid_Id()
		{
			var result = await _controller.GetDiagnosticToolEmailAnswer(1);
			Assert.IsNotNull(result);

			var okResult = result as OkObjectResult;
			Assert.IsNotNull(okResult);
			Assert.AreEqual(okResult.StatusCode, 200);

			var data = okResult.Value as DiagnosticToolEmailAnswer;
			Assert.IsNotNull(data);
			Assert.AreEqual(data.Id, 1);
		}

		[Test]
		public async Task Should_Get_NotFound_DiagnosticToolEmailAnswer_For_Invalid_Id()
		{
			var result = await _controller.GetDiagnosticToolEmailAnswer(0);
			Assert.IsNotNull(result);

			var notFoundResult = result as NotFoundResult;
			Assert.IsNotNull(notFoundResult);
			Assert.AreEqual(notFoundResult.StatusCode, 404);
		}

        [Test]
        public async Task Should_Get_DiagnosticToolEmailAnswer_For_Valid_Email()
        {
            var result = await _controller.GetDiagnosticToolEmailAnswerByEmail("mailme_1@mailememore.com");
            Assert.IsNotNull(result);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(okResult.StatusCode, 200);

            var data = okResult.Value as IEnumerable<DiagnosticToolEmailAnswer>;
            Assert.IsNotNull(data);
            Assert.IsTrue(data.Any());
            Assert.AreEqual(data.First().Id, 1);
        }

        [Test]
        public async Task Should_Get_NotFound_DiagnosticToolEmailAnswer_For_Invalid_Email()
        {
            var result = await _controller.GetDiagnosticToolEmailAnswerByEmail("nu_such_email@mailememore.com");
            Assert.IsNotNull(result);

            var notFoundResult = result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(notFoundResult.StatusCode, 404);
        }

		[Test]
		public async Task Should_Get_DiagnosticToolEmailAnswers_For_Valid_PaginationParameter()
		{
			var paginationParameter = new PaginationParameter { PageNumber = 1, PageSize = 2 };
			var result = await _controller.GetDiagnosticToolEmailAnswers(paginationParameter);
			Assert.IsNotNull(result);

			var okResult = result as OkObjectResult;
			Assert.IsNotNull(okResult);
			Assert.AreEqual(okResult.StatusCode, 200);

			var data = okResult.Value as IEnumerable<DiagnosticToolEmailAnswer>;
			Assert.IsNotNull(data);
			Assert.AreEqual(data.Count(), paginationParameter.PageSize);
		}

		[Test]
		public async Task Should_Not_Get_DiagnosticToolEmailAnswers_For_Invalid_PaginationParameter()
		{
			var paginationParameter = new PaginationParameter { PageNumber = 0, PageSize = 0 };
			var result = await _controller.GetDiagnosticToolEmailAnswers(paginationParameter);
			Assert.IsNotNull(result);

			var badRequestResult = result as BadRequestResult;
			Assert.IsNotNull(badRequestResult);
			Assert.AreEqual(badRequestResult.StatusCode, 400);
		}

		[Test]
		public async Task Should_Create_DiagnosticToolEmailAnswer_For_Valid_Object()
		{
			var result = await _controller.CreateDiagnosticToolEmailAnswer(new DiagnosticToolEmailAnswer());
			Assert.IsNotNull(result);

			var createdAtRouteResult = result.Result as CreatedAtRouteResult;
			Assert.IsNotNull(createdAtRouteResult);
			Assert.AreEqual(createdAtRouteResult.StatusCode, 201);

			var data = createdAtRouteResult.Value as DiagnosticToolEmailAnswer;
			Assert.IsNotNull(data);
			Assert.AreNotEqual(data.Id, default);
		}

		[Test]
		public async Task Should_Not_Create_DiagnosticToolEmailAnswer_For_InValid_Object()
		{
			var result = await _controller.CreateDiagnosticToolEmailAnswer(null);
			Assert.IsNotNull(result);

			var badRequestResult = result.Result as BadRequestResult;
			Assert.IsNotNull(badRequestResult);
			Assert.AreEqual(badRequestResult.StatusCode, 400);
		}


		[Test]
		public async Task Should_Update_DiagnosticToolEmailAnswer_For_Valid_Object()
		{
			var newRecord = new DiagnosticToolEmailAnswer
			{
				Id = 1
			};

			var result = await _controller.UpdateDiagnosticToolEmailAnswer(newRecord);
			Assert.IsNotNull(result);

			var noContentResult = result as NoContentResult;
			Assert.IsNotNull(noContentResult);
			Assert.AreEqual(noContentResult.StatusCode, 204);
		}

		[Test]
		public async Task Should_Not_Update_DiagnosticToolEmailAnswer_For_Invalid_Object()
		{
			var newRecord = new DiagnosticToolEmailAnswer
			{
				Id = -1
			};
			var result = await _controller.UpdateDiagnosticToolEmailAnswer(newRecord);
			Assert.IsNotNull(result);

			var notFoundResult = result as NotFoundResult;
			Assert.IsNotNull(notFoundResult);
			Assert.AreEqual(notFoundResult.StatusCode, 404);
		}

		[Test]
		public async Task Should_Delete_DiagnosticToolEmailAnswer_For_Valid_Id()
		{			
			var result = await _controller.DeleteDiagnosticToolEmailAnswer(1);
			Assert.IsNotNull(result);

			var noContentResult = result as NoContentResult;
			Assert.IsNotNull(noContentResult);
			Assert.AreEqual(noContentResult.StatusCode, 204);
		}

		[Test]
		public async Task Should_Not_Delete_DiagnosticToolEmailAnswer_For_Invalid_Id()
		{
			var result = await _controller.DeleteDiagnosticToolEmailAnswer(0);
			Assert.IsNotNull(result);

			var notFoundResult = result as NotFoundResult;
			Assert.IsNotNull(notFoundResult);
			Assert.AreEqual(notFoundResult.StatusCode, 404);
		}
	}
}