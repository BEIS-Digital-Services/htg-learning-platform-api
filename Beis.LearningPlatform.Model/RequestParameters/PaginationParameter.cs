namespace Beis.LearningPlatform.Model.RequestParameters
{
	public class PaginationParameter
	{
		private const int MaxPageSize = 100;
        private int _pageSize = 10;

		public int PageNumber { get; set; } = 1;

		public int PageSize
		{
			get => _pageSize;
            set => _pageSize = Math.Min(MaxPageSize, value);
        }

		public int Skip => this.PageNumber * this.PageSize;

        public bool IsValid()
		{
			return PageNumber * PageSize > 0;
		}
	}
}