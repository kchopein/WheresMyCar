using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WheresMyCar.MongoDBLibrary
{
    /// <summary>
    /// Context to work with MongoDB databases.
    /// </summary>
    public abstract class MongoDBContext
    {
        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        protected IMongoDatabase Database { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDBContext"/> class.
        /// </summary>
        /// <param name="settings">The MongoDB settings.</param>
        public MongoDBContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                Database = client.GetDatabase(settings.Value.Database);
        }
    }
}