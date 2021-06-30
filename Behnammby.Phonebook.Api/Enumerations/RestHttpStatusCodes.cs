namespace Behnammby.Phonebook.Api.Enumerations
{
    public enum RestHttpStatusCodes
    {
        OK = 200, //The request was successfully completed.
        Created = 201, //A new resource was successfully created.
        BadRequest = 400, //The request was invalid.
        Unauthorized = 401, //The request did not include an authentication token or the authentication token was expired.
        Forbidden = 403, //The client did not have permission to access the requested resource.
        NotFound = 404, //The requested resource was not found.
        MethodNotAllowed = 405, //The HTTP method in the request was not supported by the resource. For example, the DELETE method cannot be used with the Agent API.
        Conflict = 409, //The request could not be completed due to a conflict. For example,  POST ContentStore Folder API cannot complete if the given file or folder name already exists in the parent location.
        InternalServerError = 500, //The request was not completed due to an internal error on the server side.
        ServiceUnavailable = 503, //The server was unavailable.
    }
}