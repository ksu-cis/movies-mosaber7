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
                Movies = MovieDatabase.Filter(mpaa);
            }
            else if (search != null )
            {
                Movies = movieDataBase.search(Movies,search);
            }
            if (minIMDB != null)
            {

                Movies = MovieDatabase.FilterByMinIMBD(Movies, minIMDB);
            }
            if (maxIMDB != null)
            {

                Movies = MovieDatabase.FilterByMinIMBD(Movies, maxIMDB);
            }
            else
            {
                Movies = MovieDatabase.All;
            }


        }

        
    }
}
