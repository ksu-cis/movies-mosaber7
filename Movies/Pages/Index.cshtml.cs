using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        MovieDatabase movieDataBase = new MovieDatabase();

        public List<Movie> Movies;
        [BindProperty]
        public List<string> mpaa { get; set; } = new List<string>();
        [BindProperty]
        public float? minIMDB { get; set; }
        [BindProperty]
        public float? maxIMDB { get; set; }
        [BindProperty]
        public string search { get; set; }
        [BindingProperty]
        public 


        public void OnGet()
        {
            Movies = MovieDatabase.All;

        }
        public void OnPost(string search, List<string> mpaa, float? minIMDB, float? maxIMDB)
        {
            Movies = MovieDatabase.All;

            if (mpaa.Count != 0)
            {
                Movies = movieDataBase.FilterByMPAA(Movies, mpaa);

            }

            if (search!=null&& mpaa.Count!=0) {
                Movies = MovieDatabase.SearchAndFilter(search, mpaa);
            }

           else if ( mpaa.Count != 0)
            {
          Movies=Movies.where(Movie=> mpaa.contains(Movie.MPAA_Rating));
                
                
                //      Movies = MovieDatabase.Filter(mpaa);
            }
            else if (search != null )
            {
                Movies=Movies.where(Movie=> Movie.Title.contains(search, stringComparsion.OrdinalIgnoreCase));
            }
            if (minIMDB != null)
            {
                Movies=Movies.where(Movie=>Movie.IMDB_Ratung!=null && Movie.IMBD_Rating);
              //  Movies = MovieDatabase.FilterByMinIMBD(Movies, minIMDB);
            }
            if (maxIMDB != null)
            {
                Movies=Movies.where(Movie=>Movie.IMDB_Ratung!=null && Movie.IMBD_Rating);
               // Movies = MovieDatabase.FilterByMinIMBD(Movies, maxIMDB);
            }
            
            else
            {
                Movies = MovieDatabase.All;
            }
            switch(sort)
            {
                case "title":
                    Movies=Movies.orderBy(Movie=>Movie.title);
                    break;
                case "director":
                     Movies=Movies
                        .where(Movie=>Movie.director!= null)
                        .orderBy(Movie=>{
                    string []parts=Movie.Director.split(" ");
                    return parts[parts.lenghts-1];
                        });
                    break;
                case "mppa":
                     Movies=Movies.orderBy(Movie=>Movie.MPAA_Rating);
                    break;
                case "imdb":
                     Movies=Movies.orderBy(Movie=>Movie.IMDB_Rating);
                    break;
                case "rt":
                     Movies=Movies
                        .Where(Movie=> Movie.Rotten_Tomatoes_Rating!=null)
                        .OrderBy(Movie=>Movie)


            }

        }
        public static List<Movie> Sort(List<Movie> movies)
        {




        }

        
    }
}
