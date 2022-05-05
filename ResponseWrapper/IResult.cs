using System.Collections.Generic;

namespace ResponseWrapper
{
    /// <summary>
    /// Response wrapper interface which houses list of messages and a succeded boolean flag.
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// List of messages contained in the response.
        /// </summary>
        List<string> Messages { get; set; }

        /// <summary>
        /// Flag that indicate whether the request succeded or failed. True if succeded, other false.
        /// </summary>
        bool Succeeded { get; set; }
    }

    /// <summary>
    /// Response wrapper interface with an output of type <typeparamref name="T"/> which houses data of type <typeparamref name="T"/>, list of messages and a succeded boolean flag.
    /// </summary>
    /// <typeparam name="T">Output parameter which inside the response Data</typeparam>
    public interface IResult<out T> : IResult
    {
        /// <summary>
        /// Holds the actual data of type <typeparamref name="T"/> in the response.
        /// </summary>
        T Data { get; }
    }
}
