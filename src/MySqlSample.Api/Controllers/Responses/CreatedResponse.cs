namespace MySqlSample.Api.Controllers.Responses
{
    public class CreatedResponse
    {
        public CreatedResponse(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}