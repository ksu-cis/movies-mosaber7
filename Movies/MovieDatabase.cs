﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Movies
{
    /// <summary>
    /// A class representing a database of movies
    /// </summary>
    public class MovieDatabase
    {
        private static List<Movie> movies = new List<Movie>();

        /// <summary>
        /// Loads the movie database from the JSON file
        /// </summary>
        public MovieDatabase() {
            
            
        }


        public static List<Movie> All { get {
                if (movies == null)
                {
                   using (StreamReader file = System.IO.File.OpenText("movies.json"))
                    {
                        string json = file.ReadToEnd();
                        movies = JsonConvert.DeserializeObject<List<Movie>>(json);
                    }
                }
                return movies; } }

        public List<Movie> search(List<Movie> movies ,string searchstring)

        {
           
            List<Movie> result = new List<Movie>();
            foreach (Movie movie in movies ) {


                if (movie.Title.Contains(searchstring, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(movie);
                }
            }
            return result;


        }
        public List<Movie> FilterByMPAA(List<Movie> movies, List<string> mpaa) {

            List<Movie> results = new List<Movie>();
            foreach (Movie movie in movies)
            {


                if (mpaa.Contains(movie.MPAA_Rating))
                {
                    results.Add(movie);
                }
            }
            return results;




        }

        public static  List<Movie> Filter(List<String> rating)
        {
            List<Movie> result = new List<Movie>();
            foreach (Movie movie in movies) {
              if(rating.Contains(movie.MPAA_Rating))  result.Add(movie);
            }

            return result;
        }
        public static List<Movie> SearchAndFilter(string searchstring,List<String> rating)
        {
            List<Movie> result = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (rating.Contains(movie.MPAA_Rating)&& movie.Title.Contains(searchstring, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(movie);
                }
            }

            return result;
        }
        public static List<Movie> FilterByMinIMBD(List<Movie> movies, float? minIDMB)
        {
            List<Movie> result = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.IMDB_Rating >= minIDMB)
                {
                    result.Add(movie);
                }
            }

            return result;


        }


    }
}
