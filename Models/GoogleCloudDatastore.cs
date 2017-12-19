using System;
using Google.Cloud.Datastore.V1;

namespace HowzWebAPI001.Models
{
    public static class GoogleCloudDatastore
    {
        private static string gcpProjectId = "howzgcp004";

        public static DatastoreDb CreateDb()
        {
            // Instantiates a client
            DatastoreDb db = DatastoreDb.Create(gcpProjectId);
            return db;
        }

        public static Key ToKey(long id, string kind) =>
            new Key().WithElement(kind, id);

        public static long ToId(Key key) => key.Path[0].Id;

    }
}
