using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResponseWrapper
{
    /// <summary>
    /// Result class which implements IResult interface.
    /// </summary>
    public class Result : IResult
    {
        public Result()
        {
        }

        /// <summary>
        /// Flag used to mark failed request.
        /// </summary>
        public bool Failed => !Succeeded;

        public List<string> Messages { get; set; } = new List<string>();

        public bool Succeeded { get; set; }

        /// <summary>
        /// Method used when request failed.
        /// </summary>
        /// <returns>Result object with Succeeded prop set to false.</returns>
        public static IResult Fail()
        {
            return new Result { Succeeded = false };
        }

        /// <summary>
        /// Method used when request failed and includes custom message.
        /// </summary>
        /// <param name="message">Custom text added to response object.</param>
        /// <returns>Result object with Succeeded set to false and Messages containing custom message parameter received.</returns>
        public static IResult Fail(string message)
        {
            return new Result { Succeeded = false, Messages = new List<string> { message } };
        }

        /// <summary>
        /// Method used when request failed and includes list of custom messages.
        /// </summary>
        /// <param name="messages">List of custom text added to response object.</param>
        /// <returns>Result object with Succeeded set to false and Messages containing list of custom messages received as parameter.</returns>
        public static IResult Fail(List<string> messages)
        {
            return new Result { Succeeded = false, Messages = messages };
        }

        /// <summary>
        /// Asynchronous method used when request failed.
        /// </summary>
        /// <returns>Task of Result object with Succeeded prop set to false.</returns>
        public static Task<IResult> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        /// <summary>
        /// Asynchronous method used when request failed and includes custom message.
        /// </summary>
        /// <param name="message">Custom text added to response object.</param>
        /// <returns>Task of Result object with Succeeded set to false and Messages containing custom message parameter received.</returns>
        public static Task<IResult> FailAsync(string message)
        {
            return Task.FromResult(Fail(message));
        }

        /// <summary>
        /// Method used when request succeed.
        /// </summary>
        /// <returns>Result object with Succeeded prop set to true.</returns>
        public static IResult Success()
        {
            return new Result { Succeeded = true };
        }

        /// <summary>
        /// Method used when request succeeded and includes custom message.
        /// </summary>
        /// <param name="message">Custom text added to response object.</param>
        /// <returns>Result object with Succeeded set to true and Messages containing custom message parameter received.</returns>
        public static IResult Success(string message)
        {
            return new Result { Succeeded = true, Messages = new List<string> { message } };
        }

        /// <summary>
        /// Asynchronous method used when request succeeded.
        /// </summary>
        /// <returns>Task of Result object with Succeeded prop set to false.</returns>
        public static Task<IResult> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        /// <summary>
        /// Asynchronous method used when request succeeded and includes custom message.
        /// </summary>
        /// <param name="message">Custom text added to response object.</param>
        /// <returns>Task of Result object with Succeeded set to true and Messages containing custom message parameter received.</returns>
        public static Task<IResult> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }
    }

    /// <summary>
    /// Result class of type <typeparamref name="T"/> which implements IResult of type <typeparamref name="T"/> interface and inherit <see cref="Result"/>.
    /// </summary>
    public class Result<T> : Result, IResult<T>
    {
        public Result()
        {
        }

        public T Data { get; set; }

        /// <summary>
        /// Method used when request failed.
        /// </summary>
        /// <returns>Result object containing type <typeparamref name="T"/> and Succeeded prop set to false.</returns>
        public static new Result<T> Fail()
        {
            return new Result<T> { Succeeded = false };
        }

        /// <summary>
        /// Method used when request failed and includes custom message.
        /// </summary>
        /// <param name="message">Custom text added to response object.</param>
        /// <returns>Result object containing type <typeparamref name="T"/>, Succeeded set to false and Messages containing custom message parameter received.</returns>
        public static new Result<T> Fail(string message)
        {
            return new Result<T> { Succeeded = false, Messages = new List<string> { message } };
        }

        /// <summary>
        /// Method used when request failed and includes list of custom messages.
        /// </summary>
        /// <param name="messages">List of custom text added to response object.</param>
        /// <returns>Result object containing type <typeparamref name="T"/>, Succeeded set to false and Messages containing list of custom messages received as parameter.</returns>
        public static new Result<T> Fail(List<string> messages)
        {
            return new Result<T> { Succeeded = false, Messages = messages };
        }

        /// <summary>
        /// Asynchronous method used when request failed.
        /// </summary>
        /// <returns>Task of Result object containing type <typeparamref name="T"/> and Succeeded prop set to false.</returns>
        public static new Task<Result<T>> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        /// <summary>
        /// Asynchronous method used when request failed and includes custom message.
        /// </summary>
        /// <param name="message">Custom text added to response object.</param>
        /// <returns>Task of Result object containing type <typeparamref name="T"/>, Succeeded set to false and Messages containing custom message parameter received.</returns>
        public static new Task<Result<T>> FailAsync(string message)
        {
            return Task.FromResult(Fail(message));
        }

        /// <summary>
        /// Method used when request succeeded.
        /// </summary>
        /// <returns>Result object containing type <typeparamref name="T"/> and Succeeded prop set to true.</returns>
        public static new Result<T> Success()
        {
            return new Result<T> { Succeeded = true };
        }

        /// <summary>
        /// Method used when request succeeded and includes custom message.
        /// </summary>
        /// <param name="message">Custom text added to response object.</param>
        /// <returns>Result object containing type <typeparamref name="T"/>, Succeeded set to true and Messages containing custom message parameter received.</returns>
        public static new Result<T> Success(string message)
        {
            return new Result<T> { Succeeded = true, Messages = new List<string> { message } };
        }

        /// <summary>
        /// Method used when request succeeded and expects <paramref name="data"/> parameter.
        /// </summary>
        /// <param name="data">Data added to the response object.</param>
        /// <returns>Result of type <typeparamref name="T"/>.</returns>
        public static Result<T> Success(T data)
        {
            return new Result<T> { Succeeded = true, Data = data };
        }

        /// <summary>
        /// Method used when request succeeded and expects <paramref name="data"/> and <paramref name="message"/> parameters.
        /// </summary>
        /// <param name="data">Data added to the response object.</param>
        /// <param name="message">Custom text added to response object.</param>
        /// <returns></returns>
        public static Result<T> Success(T data, string message)
        {
            return new Result<T> { Succeeded = true, Data = data, Messages = new List<string> { message } };
        }

        /// <summary>
        /// Method used when request succeeded and expects <paramref name="data"/> and <paramref name="messages"/> parameters.
        /// </summary>
        /// <param name="data">Data added to the response object.</param>
        /// <param name="messages">List of custom text added to response object.</param>
        /// <returns></returns>
        public static Result<T> Success(T data, List<string> messages)
        {
            return new Result<T> { Succeeded = true, Data = data, Messages = messages };
        }

        /// <summary>
        /// Asynchronous method used when request succeeded.
        /// </summary>
        /// <returns>Task of Result object containing type <typeparamref name="T"/> and Succeeded prop set to true.</returns>
        public static new Task<Result<T>> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        /// <summary>
        /// Asynchronous method used when request succeeded and includes custom message.
        /// </summary>
        /// <param name="message">Custom text added to response object.</param>
        /// <returns>Task ofResult object containing type <typeparamref name="T"/>, Succeeded set to true and Messages containing custom message parameter received.</returns>
        public static new Task<Result<T>> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }

        /// <summary>
        /// Asynchronous method used when request succeeded and expects <paramref name="data"/> parameter.
        /// </summary>
        /// <param name="data">Data added to the response object.</param>
        /// <returns>Task of Result object containing type <typeparamref name="T"/>.</returns>
        public static Task<Result<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        }

        /// <summary>
        /// Asynchronous method used when request succeeded and expects <paramref name="data"/> and <paramref name="message"/> parameter.
        /// </summary>
        /// <param name="data">Data added to the response object.</param>
        /// <param name="message">Custom text added to response object.</param>
        /// <returns></returns>
        public static Task<Result<T>> SuccessAsync(T data, string message)
        {
            return Task.FromResult(Success(data, message));
        }
    }
}
