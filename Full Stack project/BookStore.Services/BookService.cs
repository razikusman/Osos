using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using Azure;

namespace UserManagement
{
    public class BookService : IBookService
    {
        private readonly BookStoreContext _context;

        public BookService(BookStoreContext bookStoreContext) 
        {
            _context = bookStoreContext;
        }

        public async Task<APIResponseModel<BookResponse>> CreateBookAsync(BookRequest bookRequest)
        { 
            try
            {
                var response = new APIResponseModel<BookResponse>();
                if (bookRequest.Id.ToString() == "-1")
                {

                    var book = new Book()
                    {
                        Description = bookRequest.Description,
                        Name = bookRequest.Name,
                        IsActive = bookRequest.IsActive,
                        AuthorId = 1
                    };

                    //create data
                    _context.books.Add(book);

                    await _context.SaveChangesAsync();

                    //create response

                    response.Data = CreateBookResponse(book);
                    response.IsError = false;
                    response.ResponseCode = (int)HttpStatusCode.OK;
                    
                    return response;
                }

                else
                {

                    response.Data = null;
                    response.IsError = true;
                    response.ResponseCode = (int)HttpStatusCode.BadRequest;

                    return response;
                }


                

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<APIResponseModel<BookResponse>> DeleteBookAsync(string bookId)
        {
            try
            {
                APIResponseModel<BookResponse> response = new APIResponseModel<BookResponse>();
                Book book = await _context.books.FirstOrDefaultAsync(b => b.BookId.ToString() == bookId);

                if (book != null)
                {
                    _context.books.Remove(book);

                    await _context.SaveChangesAsync();

                    response.Data = CreateBookResponse(book);
                    response.IsError = false;
                    response.ResponseCode = (int)HttpStatusCode.OK;

                    return response;
                }

                else
                {
                    response.Data = null;
                    response.IsError = true;
                    response.ResponseCode = (int)HttpStatusCode.BadRequest;

                    return response;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<APIResponseModel<IList<BookResponse>>> GetALlBookAsync()
        {
            APIResponseModel<IList<BookResponse>> response = new APIResponseModel<IList<BookResponse>>();
            IList<Book> books = await _context.books
                                                    .Include(b => b.author)
                                                    .ToListAsync();

            response.Data = books.Select(b => new BookResponse() {
                                                                      author = new AuthorResponse() { AuthorId = b.author.AuthorId, Name = b.author.Name},
                                                                      AuthorId = b.AuthorId,
                                                                      Description = b.Description,
                                                                      Id = b.BookId.ToString(),
                                                                      IsActive = b.IsActive,
                                                                      Name = b.Name,
                                                                  })
                                                                  .ToList();
            response.IsError = false;
            response.ResponseCode= (int)HttpStatusCode.OK;

            return response;

        }

        public async Task<APIResponseModel<BookResponse>> GetBookAsync(string bookId)
        {
            try
            {
                APIResponseModel<BookResponse> response = new APIResponseModel<BookResponse>();

                if (!String.IsNullOrWhiteSpace(bookId))
                {

                    Book book = await _context.books.FirstOrDefaultAsync(b => b.BookId.ToString() == bookId);

                    response.Data = CreateBookResponse(book);
                    response.IsError = false;
                    response.ResponseCode = (int)HttpStatusCode.OK;

                    return response;
                }
                else{
                    response.Data = null;
                    response.IsError = true;
                    response.ResponseCode = (int)HttpStatusCode.BadRequest;

                    return response;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<APIResponseModel<BookResponse>> UpdateBookAsync(BookRequest bookRequest)
        {
            try
            {
                APIResponseModel<BookResponse> response = new APIResponseModel<BookResponse>();

                if (bookRequest != null)
                {
                    Book bk = await _context.books.FirstOrDefaultAsync(b => b.BookId.ToString() == bookRequest.Id);

                    bk.Description = bookRequest.Description;
                    bk.IsActive = bookRequest.IsActive;
                    bk.Name = bookRequest.Name;

                    _context.Entry(bk).State = EntityState.Modified;

                    await _context.SaveChangesAsync();

                    response.Data = CreateBookResponse(bk);
                    response.IsError = false;
                    response.ResponseCode = (int)HttpStatusCode.OK;

                    return response;
                }
                else
                {
                    response.Data = null;
                    response.IsError = true;
                    response.ResponseCode = (int)HttpStatusCode.BadRequest;

                    return response;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private BookResponse CreateBookResponse(Book bk)
        {
            return new BookResponse()
            {
                Name = bk.Name,
                Description = bk.Description,
                IsActive = bk.IsActive,
                author =   CreateAuthorResponse(bk.author),
                AuthorId = bk.AuthorId,
                Id = bk.BookId.ToString()
            };
        }

        private AuthorResponse CreateAuthorResponse(Author author)
        {
            AuthorResponse authorResponse = new AuthorResponse();

            if (author != null)
            {
                authorResponse.AuthorId = author.AuthorId;
                authorResponse.Name = author.Name;
            }

            return authorResponse;
        }
    }
}
