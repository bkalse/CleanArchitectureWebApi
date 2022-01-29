using CleanCQRS.Models.Common;

namespace CleanCQRS.Models.Queries.Book.GetBookById
{
    public class GetBookByIdRequest : QueryBase<GetBookByIdResponse>
    {
        public long Id { set; get; }
    }
}
