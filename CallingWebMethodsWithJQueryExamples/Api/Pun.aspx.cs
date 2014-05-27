using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;

namespace CallingWebMethodsWithJQueryExamples.Api
{
    public class Pun : System.Web.UI.Page
    {
        public class PunModel
        {
            public int Id { get; set; }
            public string Joke { get; set; }
            public string Author { get; set; }
        }

        private static readonly List<PunModel> Puns = new List<PunModel>
        {
            new PunModel { Id = 1, Joke = "Did you hear about the guy whose whole left side was cut off? He's all right now.", Author = "Clark Kent" },
            new PunModel { Id = 2, Joke = "I wondered why the baseball was getting bigger. Then it hit me.", Author = "Peter Parker" },
            new PunModel { Id = 3, Joke = "I'm reading a book about anti-gravity. It's impossible to put down.", Author = "Bruce Wayne" },
            new PunModel { Id = 4, Joke = "It's not that the man did not know how to juggle, he just didn't have the balls to do it.", Author = "Bruce Banner" },
            new PunModel { Id = 5, Joke = "My friend's bakery burned down last night. Now his business is toast.", Author = "Hal Jordan" }
        };

        protected void Page_Load( object sender, EventArgs e )
        {
        }
        
        [WebMethod]
        public static PunModel GetRandomPun()
        {
            var numberOfPuns = Puns.Count;

            var randomNumber = new Random().Next( 1, numberOfPuns + 1 );

            var pun = Puns.FirstOrDefault( x => x.Id == randomNumber );

            return pun;
        }

        [WebMethod]
        public static PunModel GetPunById( int id )
        {
            var pun = Puns.FirstOrDefault( x => x.Id == id );

            if ( pun == null )
            {
                throw new Exception( string.Format( "Pun {0} does not exist.", id ) );
            }

            return pun;
        }

        [WebMethod]
        public static int GetException()
        {
            throw new Exception( "This is an example exception message returned from the server.");
        }

        [WebMethod]
        public static int AddPun( PunModel pun )
        {
            var nextId = Puns.Max( x => x.Id ) + 1;

            pun.Id = nextId;

            Puns.Add( pun );

            return pun.Id;
        }

        [WebMethod]
        public static List<PunModel> GetAllPuns()
        {
            return Puns;
        }
    }
}