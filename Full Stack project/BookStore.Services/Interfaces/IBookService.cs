using UserManagement;

namespace UserManagement
{ 
    public interface IBookService
    {
        Task<APIResponseModel<BookResponse>> CreateBookAsync(BookRequest bookRequest);
        Task<APIResponseModel<BookResponse>> UpdateBookAsync(BookRequest bookRequest);
        Task<APIResponseModel<BookResponse>> DeleteBookAsync(string bookId);
        Task<APIResponseModel<IList<BookResponse>>> GetALlBookAsync();
        Task<APIResponseModel<BookResponse>> GetBookAsync(string bookId);
    }
}
